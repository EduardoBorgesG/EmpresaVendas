using EmpresaVendas._1___Classes;
using EmpresaVendas.Classes;
using EmpresaVendas.Conecctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaVendas._3___Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private DbConnection<Produto> conn;

        public ProdutoRepositorio()
        {
            conn = new DbConnection<Produto>();
        }
        //Cadastrar Produto
        public bool CadastrarProduto(Produto produto)
        {
            string query = @"INSERT INTO public.p_produtos_tb(
	                         nome, descricao, preco_produto, estoque)
	                         VALUES (@nome, @descricao, @preco_produto, @estoque);";
            var result = conn.Executar(sql: query, param: produto);
            return result == 1;
        }
        //Editar Produto
        public bool EditarProduto(Produto produto)
        {
            string query = $"UPDATE public.p_produtos_tb SET nome= '{produto.Nome}', descricao= '{produto.Descricao}', preco_produto= '{produto.Preco_produto}', estoque={produto.Estoque} WHERE id = {produto.Id};";
            var result = conn.Executar(sql: query, param: produto) ; 
            return result == 1;
        }
        //Remover Produto
        public bool ExcluirProduto(string id)
        {
            string query = $"DELETE FROM public.p_produtos_tb WHERE id = {id};";
            var result = conn.Executar(sql: query, param: id);
            return result == 1;
        }
        public bool VerificaProduto(string nome) 
        {
            //METODO QUE VERIFICA SE JÁ possuí esse produto cadastrado
            string query = $"SELECT id FROM public.p_produtos_tb WHERE nome = '{nome}'";
            var result = conn.VerificarnoBanco(sql: query, param: nome);
            if (result != null)
            {
                MessageBox.Show("Esse produto já está cadastrado no banco de dados");
                return false;
            }
            return result == null;

        }
        public List<Produto> ObterProduto()
        {
            try
            {
                string query = @"SELECT * FROM public.p_produtos_tb;";
                var produtos = conn.Consulta(sql: query);
                return produtos.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
