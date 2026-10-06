using EmpresaVendas._1___Classes;
using EmpresaVendas.Infra;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace EmpresaVendas._3___Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProdutoRepositorio(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        //Cadastrar Produto
        public bool CadastrarProduto(Produto produto)
        {
            const string sql = @"INSERT INTO public.p_produtos_tb (nome, descricao, preco_produto, estoque, ativo)
                                 VALUES (@nome, @descricao, @preco_produto, @estoque, true);";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@nome", produto.nome);
                comando.AdicionarParametro("@descricao", produto.Descricao);
                comando.AdicionarParametro("@preco_produto", produto.Preco_produto);
                comando.AdicionarParametro("@estoque", produto.Estoque);
                return comando.ExecuteNonQuery() == 1;
            }
        }

        //Editar Produto
        public bool EditarProduto(Produto produto)
        {
            const string sql = @"UPDATE public.p_produtos_tb
                                 SET nome = @nome, descricao = @descricao, preco_produto = @preco_produto, estoque = @estoque
                                 WHERE id = @id;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@nome", produto.nome);
                comando.AdicionarParametro("@descricao", produto.Descricao);
                comando.AdicionarParametro("@preco_produto", produto.Preco_produto);
                comando.AdicionarParametro("@estoque", produto.Estoque);
                comando.AdicionarParametro("@id", produto.Id);
                return comando.ExecuteNonQuery() == 1;
            }
        }

        //Não deleta o produto: zera o estoque e o marca como inativo
        public bool EsgotarProduto(int id)
        {
            const string sql = "UPDATE public.p_produtos_tb SET estoque = 0, ativo = false WHERE id = @id;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@id", id);
                return comando.ExecuteNonQuery() == 1;
            }
        }

        public bool VerificaProduto(string nome)
        {
            //Retorna true quando o produto ainda NÃO existe (pode cadastrar)
            const string sql = "SELECT 1 FROM public.p_produtos_tb WHERE nome = @nome LIMIT 1;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@nome", nome);
                return comando.ExecuteScalar() == null;
            }
        }

        public bool AtivarProduto(int id)
        {
            const string sql = "UPDATE public.p_produtos_tb SET ativo = true WHERE id = @id;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@id", id);
                return comando.ExecuteNonQuery() == 1;
            }
        }

        public List<Produto> ObterProdutosInativos()
        {
            const string sql = @"SELECT id, nome
                                 FROM public.p_produtos_tb
                                 WHERE ativo = false
                                 ORDER BY nome;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                return comando.LerLista(registro => new Produto
                {
                    Id = registro.ObterInt("id"),
                    nome = registro.ObterString("nome")
                });
            }
        }

        //Obtém os produtos ativos
        public List<Produto> ObterProduto()
        {
            const string sql = @"SELECT id, nome, descricao, preco_produto, estoque
                                 FROM public.p_produtos_tb
                                 WHERE ativo = true
                                 ORDER BY nome;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                return comando.LerLista(MapearProduto);
            }
        }

        //Alimenta a lista de seleção de produtos da venda buscando por ID
        public List<Produto> ColetaDadosProduto(int id)
        {
            const string sql = "SELECT id, nome, preco_produto FROM public.p_produtos_tb WHERE id = @id;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@id", id);
                return comando.LerLista(registro => new Produto
                {
                    Id = registro.ObterInt("id"),
                    nome = registro.ObterString("nome"),
                    Preco_produto = registro.ObterDecimal("preco_produto")
                });
            }
        }

        //Retorna o estoque atual do produto (ou null se o produto não existir)
        public object VerificaEstoque(int id)
        {
            const string sql = "SELECT estoque FROM public.p_produtos_tb WHERE id = @id;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@id", id);
                return comando.ExecuteScalar();
            }
        }

        private static Produto MapearProduto(IDataRecord registro)
        {
            return new Produto
            {
                Id = registro.ObterInt("id"),
                nome = registro.ObterString("nome"),
                Descricao = registro.ObterString("descricao"),
                Preco_produto = registro.ObterDecimal("preco_produto"),
                Estoque = registro.ObterInt("estoque")
            };
        }
    }
}
