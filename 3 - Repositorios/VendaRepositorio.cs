using EmpresaVendas._1___Classes;
using EmpresaVendas.Classes;
using EmpresaVendas.Conecctions;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Venda> BuscarClientes()
        {
            try
            {
                string query = "SELECT c.id, c.nome FROM c_clientes_tb c LEFT JOIN v_vendas_tb v ON v.nome_cliente_id = c.id;";
                //string query = @"SELECT id, nome FROM c_clientes_tb";
                var cliente = conn.Consulta(sql: query).ToList();
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Alimenta a minha lista de seleção de produtos buscando por ID
        public List<Venda> BuscaProduto()
        {
            string query = @"SELECT p.id, p.nome FROM p_produtos_tb p LEFT JOIN v_vendas_tb v ON v.nome_produto_id = p.id;";
            //string query = "SELECT id, nome FROM p_produtos_tb;";
            var produtos = conn.Consulta(sql: query).ToList();
            return produtos;
        }
        public bool IncluirVenda(Venda venda)
        {
            try
            {
                //FALTA ADICIONAR O ESTOQUE_ID, IMPLEMENTAR LOGICA PARA ATUALIZAR O ESTOQUE E SE FOR IGUAL A ZERO REMOVER O PRODUTO DA TABELA P_PRODUTOS
                string query = @"INSERT INTO public.v_vendas_tb(valor_pago, quantidade_venda, nome_produto_id, nome_cliente_id) VALUES (@valor_pago, @quantidade_venda, @nome_produto_id, @nome_cliente_id);";
                var result = conn.Executar(sql: query, param: venda);
                return result == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object AdquirirEstoque(int id)
        {
            try
            {
                string query = "SELECT p.estoque FROM p_produtos_tb p LEFT JOIN v_vendas_tb v ON v.estoque_id = p.id;";
                object result = conn.VerificarnoBanco(sql: query, param: id);
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
