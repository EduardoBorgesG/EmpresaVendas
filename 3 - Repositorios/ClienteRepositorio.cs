using EmpresaVendas.Classes;
using EmpresaVendas.Infra;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace EmpresaVendas.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly IConnectionFactory _connectionFactory;

        public ClienteRepositorio(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool VerificaCliente(string telefone)
        {
            //Retorna true quando o telefone ainda NÃO existe (pode cadastrar)
            const string sql = "SELECT 1 FROM public.c_clientes_tb WHERE telefone = @telefone LIMIT 1;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@telefone", telefone);
                return comando.ExecuteScalar() == null;
            }
        }

        //Adiciona um cliente no banco de dados
        public bool CadastrarCliente(Cliente cliente)
        {
            const string sql = @"INSERT INTO public.c_clientes_tb (nome, email, telefone, cep, endereco, ativo)
                                 VALUES (@nome, @email, @telefone, @cep, @endereco, true);";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@nome", cliente.nome);
                comando.AdicionarParametro("@email", cliente.Email);
                comando.AdicionarParametro("@telefone", cliente.Telefone);
                comando.AdicionarParametro("@cep", cliente.Cep);
                comando.AdicionarParametro("@endereco", cliente.Endereco);
                return comando.ExecuteNonQuery() == 1;
            }
        }

        public List<Cliente> ObterClienteAtivos()
        {
            const string sql = @"SELECT id, nome, email, telefone, cep, endereco
                                 FROM public.c_clientes_tb
                                 WHERE ativo = true
                                 ORDER BY nome;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                return comando.LerLista(MapearCliente);
            }
        }

        //Edição de Cliente
        public bool AtualizarCliente(Cliente cliente)
        {
            const string sql = @"UPDATE public.c_clientes_tb
                                 SET nome = @nome, email = @email, telefone = @telefone, cep = @cep, endereco = @endereco
                                 WHERE id = @id;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@nome", cliente.nome);
                comando.AdicionarParametro("@email", cliente.Email);
                comando.AdicionarParametro("@telefone", cliente.Telefone);
                comando.AdicionarParametro("@cep", cliente.Cep);
                comando.AdicionarParametro("@endereco", cliente.Endereco);
                comando.AdicionarParametro("@id", cliente.Id);
                return comando.ExecuteNonQuery() == 1;
            }
        }

        //Não exclui: apenas marca o cliente como inativo
        public bool InativarCliente(string id)
        {
            return AlterarStatus(Convert.ToInt32(id), ativo: false);
        }

        public bool AtivarCliente(int id)
        {
            return AlterarStatus(id, ativo: true);
        }

        public List<Cliente> ObterClienteInativos()
        {
            const string sql = @"SELECT id, nome
                                 FROM public.c_clientes_tb
                                 WHERE ativo = false
                                 ORDER BY nome;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                return comando.LerLista(registro => new Cliente
                {
                    Id = registro.ObterInt("id"),
                    nome = registro.ObterString("nome")
                });
            }
        }

        private bool AlterarStatus(int id, bool ativo)
        {
            const string sql = "UPDATE public.c_clientes_tb SET ativo = @ativo WHERE id = @id;";

            using (var conexao = _connectionFactory.CriarConexao())
            using (var comando = new NpgsqlCommand(sql, conexao))
            {
                comando.AdicionarParametro("@ativo", ativo);
                comando.AdicionarParametro("@id", id);
                return comando.ExecuteNonQuery() == 1;
            }
        }

        private static Cliente MapearCliente(IDataRecord registro)
        {
            return new Cliente
            {
                Id = registro.ObterInt("id"),
                nome = registro.ObterString("nome"),
                Email = registro.ObterString("email"),
                Telefone = registro.ObterString("telefone"),
                Cep = registro.ObterString("cep"),
                Endereco = registro.ObterString("endereco")
            };
        }
    }
}
