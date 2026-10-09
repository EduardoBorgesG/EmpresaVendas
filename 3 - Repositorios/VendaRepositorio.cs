using EmpresaVendas._1___Classes;
using EmpresaVendas._1___Classes.Excecoes;
using EmpresaVendas.Infra;
using Npgsql;
using System;
using System.Collections.Generic;

namespace EmpresaVendas._3___Repositorios
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private readonly IConnectionFactory _connectionFactory;

        public VendaRepositorio(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int RegistrarVenda(Venda venda, List<VendaItens> itens)
        {
            //Grava a venda, os itens e baixa o estoque em uma única transação:
            //se qualquer passo falhar, nada é gravado (rollback automático no Dispose sem Commit)
            const string sqlVenda = @"INSERT INTO public.v_vendas_tb (valor_pago, nome_cliente_id)
                                      VALUES (@valor_pago, @cliente_id)
                                      RETURNING id;";
            const string sqlItem = @"INSERT INTO public.v_vendas_item_tb (venda_id, produto_id, quantidade)
                                     VALUES (@venda_id, @produto_id, @quantidade);";
            //O "estoque >= @quantidade" impede estoque negativo mesmo se dois usuários venderem ao mesmo tempo
            const string sqlEstoque = @"UPDATE public.p_produtos_tb
                                        SET estoque = estoque - @quantidade
                                        WHERE id = @produto_id AND estoque >= @quantidade;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var transacao = conexao.BeginTransaction())
            {
                int vendaId;
                using (var comando = new NpgsqlCommand(sqlVenda, conexao, transacao))
                {
                    comando.AdicionarParametro("@valor_pago", venda.valor_pago);
                    comando.AdicionarParametro("@cliente_id", venda.cliente_id);
                    vendaId = Convert.ToInt32(comando.ExecuteScalar());
                }

                foreach (var item in itens)
                {
                    item.vendaId = vendaId;

                    using (var comando = new NpgsqlCommand(sqlEstoque, conexao, transacao))
                    {
                        comando.AdicionarParametro("@quantidade", item.quantidade);
                        comando.AdicionarParametro("@produto_id", item.produto_id);
                        if (comando.ExecuteNonQuery() != 1)
                        {
                            throw new RegraNegocioException($"Estoque insuficiente para o produto de código {item.produto_id}. A venda não foi gravada.");
                        }
                    }

                    using (var comando = new NpgsqlCommand(sqlItem, conexao, transacao))
                    {
                        comando.AdicionarParametro("@venda_id", item.vendaId);
                        comando.AdicionarParametro("@produto_id", item.produto_id);
                        comando.AdicionarParametro("@quantidade", item.quantidade);
                        comando.ExecuteNonQuery();
                    }
                }

                transacao.Commit();
                return vendaId;
            }
        }
    }
}
