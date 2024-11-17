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
        
        
        
        public int IncluirVenda(Venda venda)
        {
            try
            {
                string query = @"INSERT INTO public.v_vendas_tb(valor_pago, nome_cliente_id) VALUES (@valor_pago, @cliente_id) RETURNING id;";
                var result = conn.ExecuteScalarMetodo(sql: query, param: venda);
                int venda_id = Convert.ToInt32(result);
                return venda_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal AtualizaPreco(int id)
        {
            //PASSAR PARA O REPOSITORIO DE PRODUTO DPS
            try
            {
                string query = "SELECT preco_produto FROM p_produtos_tb WHERE id = @id";
                decimal result = Convert.ToDecimal(conn.VerificarnoBanco(sql: query, param: id));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<Venda> ColetaId(Venda venda)
        {
            try
            {
                string query = "SELECT id FROM v_vendas_tb WHERE nome_cliente_id = @cliente_id";
                var result = conn.ColetaValoresDoBanco(sql: query, param: venda);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool InserirVendaItem(VendaItens vendaItens)
        {
            try
            {
                string query = @"INSERT INTO public.v_vendas_item_tb(venda_id, produto_id, quantidade) VALUES (@vendaId, @produto_id, @quantidade);";                                
                var result = conn.Executar(sql: query, param: vendaItens);
                return result == 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object VerificaEstoque(int id)
        {
            //ADICIONAR no repositorio de produtos dps
            try
            {
                string query = "SELECT p.estoque FROM p_produtos_tb p LEFT JOIN v_vendas_tb v ON v.estoque_id = p.id";           
                object result = conn.VerificarnoBanco(sql: query, param: id);
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
