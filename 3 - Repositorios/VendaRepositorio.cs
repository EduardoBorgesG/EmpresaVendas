using EmpresaVendas._1___Classes;
using EmpresaVendas.Classes;
using EmpresaVendas.Conecctions;
using Npgsql;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaVendas._3___Repositorios
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private DbConnection<Venda> conn;
        public VendaRepositorio()
        {
            conn = new DbConnection<Venda>();
        }
        //Alimenta lista de seleção dos clientes
        
        
        
        public int RegistrarVenda(Venda venda, List<VendaItens> itens)
        {
            //Grava a venda, os itens e baixa o estoque em uma única transação:
            //se qualquer passo falhar, nada é gravado (rollback automático no Dispose sem Commit)
            string queryVenda = @"INSERT INTO public.v_vendas_tb(valor_pago, nome_cliente_id) VALUES (@valor_pago, @cliente_id) RETURNING id;";
            string queryItem = @"INSERT INTO public.v_vendas_item_tb(venda_id, produto_id, quantidade) VALUES (@vendaId, @produto_id, @quantidade);";
            //O "estoque >= @quantidade" impede estoque negativo mesmo se dois usuários venderem ao mesmo tempo
            string queryEstoque = @"UPDATE public.p_produtos_tb SET estoque = estoque - @quantidade WHERE id = @produto_id AND estoque >= @quantidade;";

            using (var transaction = conn.IniciarTransacao())
            {
                int venda_id = Convert.ToInt32(conn.ExecuteScalarMetodo(sql: queryVenda, param: venda, transaction: transaction));

                foreach (var item in itens)
                {
                    item.vendaId = venda_id;
                    if (conn.Executar(sql: queryEstoque, param: item, transaction: transaction) != 1)
                    {
                        throw new Exception($"Estoque insuficiente para o produto de código {item.produto_id}. A venda não foi gravada.");
                    }
                    conn.Executar(sql: queryItem, param: item, transaction: transaction);
                }

                transaction.Commit();
                return venda_id;
            }
        }
        public decimal AtualizaPreco(int id)
        {
            //Verifica o preço do produto e atualiza na minha textbox
            try
            {
                string query = $"SELECT preco_produto FROM p_produtos_tb WHERE id = {id}";
                decimal result = Convert.ToDecimal(conn.VerificarnoBanco(sql: query, param: id));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
       
        public object AdquirirEstoquePreco(int id)
        {
            try
            {
                string query = "SELECT p.estoque, p.preco_produto FROM p_produtos_tb p LEFT JOIN v_vendas_tb v ON v.estoque_id = p.id AND v.valor_pago = p.preco_produto;\r\n";
                object result = conn.ColetaDadosBanco(sql: query, param: id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object AdquiriPropriedades(int id)
        {
            //NÃO ESTÁ SENDO USADO
            try
            {
                string query = @"SELECT p.nome AS nome_produto, p.estoque, c.nome AS nome_cliente, p.preco_produto FROM p_produtos_tb p JOIN v_vendas_tb v ON v.nome_produto_id = p.id JOIN c_clientes_tb c ON c.id = v.nome_cliente_id WHERE v.estoque_id = @id";
                object result = conn.ColetaDadosBanco(sql: query, param: id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object VerificarQuantidade(int id)
        {
            string query = "";
            object result = conn.VerificarnoBanco(sql: query, param: id);
            return result;
        }       
   

    }
}
