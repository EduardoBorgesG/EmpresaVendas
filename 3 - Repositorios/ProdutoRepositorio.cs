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
	                         nome, descricao, preco_produto, estoque, ativo)
	                         VALUES (@nome, @descricao, @preco_produto, @estoque, true);";
            var result = conn.Executar(sql: query, param: produto);
            return result == 1;
        }
        //Editar Produto
        public bool EditarProduto(Produto produto)
        {
            string query = $"UPDATE public.p_produtos_tb SET nome= '{produto.nome}', descricao= '{produto.Descricao}', preco_produto= '{produto.Preco_produto}' WHERE id = {produto.Id};";
            var result = conn.Executar(sql: query, param: produto) ; 
            return result == 1;
        }
        //Remover Produto
        public bool EsgotarProduto(int id)
        {
            //NÃO DELETA PRODUTO SOMENTE ZERA O ESTOQUE
            string query = $"UPDATE public.p_produtos_tb SET estoque = 0, ativo = false WHERE id = {id};";
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
        public bool AtivarProduto(int id)
        {
            try
            {
                string query = $"UPDATE public.p_produtos_tb SET ativo = true WHERE id = {id}";
                var produtos = conn.Executar(sql: query, param: id);
                return produtos == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> ObterProdutosInativos()
        {
            try
            {
                string query = @"SELECT id, nome FROM public.p_produtos_tb WHERE ativo = false";
                var produtos = conn.Consulta(sql: query);
                return produtos.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Produto> ObterProduto()
        {
            try
            {
                string query = @"SELECT * FROM public.p_produtos_tb WHERE ativo = true;";
                var produtos = conn.Consulta(sql: query);
                return produtos.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Alimenta a minha lista de seleção de produtos buscando por ID
        public List<Produto> ColetaDadosProduto(int id)
        {
            try
            {
                string query = $"SELECT id, nome, preco_produto FROM p_produtos_tb WHERE id = {id}";
                var Produtos2 = conn.ColetaValoresDoBanco(sql: query, param: id);
                return Produtos2.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object VerificaEstoque(int id)
        {
            //Verifica se a quantidade é maior ou igual ao estoque
            try
            {
                string query = $"SELECT estoque FROM p_produtos_tb WHERE id = {id}";
                object result = conn.VerificarnoBanco(sql: query, param: id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
