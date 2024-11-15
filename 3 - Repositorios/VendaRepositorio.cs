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
                //string query = "SELECT c.id,c.nome FROM c_clientes_tb c LEFT JOIN v_vendas_tb v ON c.nome = v.nome_cliente;";
                string query = @"SELECT id, nome FROM c_clientes_tb";
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
            //string query = @"SELECT p.id, p.nome FROM p_produtos_tb p LEFT JOIN v_vendas_tb v ON p.nome = v.nome_produto;";
            string query = "SELECT id, nome FROM p_produtos_tb;";
            var produtos = conn.Consulta(sql: query).ToList();
            return produtos;
        }
        public bool IncluirVenda(Venda venda)
        {
            try 
            {
                string query = @"INSERT INTO public.v_vendas_tb(valor_pago, quantidade_venda, nome_produto_id, nome_cliente_id) VALUES (@valor_pago, @quantidade_venda, @nome_produto_id, @nome_cliente_id);";
                var result = conn.Executar(sql: query, param: venda);
                return result == 1;
            } 
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
