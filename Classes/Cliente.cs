using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using EmpresaVendas.Conecctions;
using System.Data;
using System.Windows.Forms;
using EmpresaVendas.Formularios;

namespace EmpresaVendas.Classes
{
    internal class Cliente
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        
        public Cliente(string nome, string email, string telefone, string cep, string endereco)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cep = cep;
            Endereco = endereco;
        }

        public Cliente(string telefone)
        {
            Telefone = telefone;
        }

        public Cliente()
        {
        }

        public bool VerificaCliente(Cliente cliente)
        {
            //METODO QUE VERIFICA SE JÁ POSSUÍ O TELEFONE CADASTRADO
            var conn = new DbConnection();
            string query = @"SELECT id FROM public.c_clientes_tb WHERE telefone(telefone) VALUES (@telefone)";
            var result = conn.Connection.Execute(sql: query, param: cliente);
            if (result == 1)
            {
                MessageBox.Show("Esse telefone já está cadastrado no banco de dados");
            }
            return result == 1;
        }
        //Adiciona um cliente no banco de dados
        public bool CadastrarCliente(Cliente cliente)
        {
            var conn = new DbConnection();

            string query = @"INSERT INTO public.c_clientes_tb(
	                        nome, email, telefone, cep, endereco)
	                        VALUES (@nome, @email, @telefone, @cep, @endereco);";

            var result = conn.Connection.Execute(sql: query, param: cliente);
            return result == 1;
        }
        public List<Cliente> Obter()
        {
            var conn = new DbConnection();
            string query = @"SELECT id, nome, email, telefone, cep, endereco
	                        FROM public.c_clientes_tb;";
            var clientes = conn.Connection.Query<Cliente>(sql : query);

            return clientes.ToList();
        }
        //public bool ListarClientes(Cliente cliente, DataGrid gridClientes)
        //{
        //    var conn = new DbConnection();
        //    string query = @"SELECT nome, email, telefone, cep FROM public.c_clientes_tb(nome, email, telefone, cep) VALUES (@nome, @email, @telefone, @cep)";
        //    var result = conn.Connection.Execute(sql: query, param: cliente);
        //    NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    gridClientes.DataSource = dt;
        //    return result == 1;
        //}
        public bool EditarCliente(Cliente cliente)
        {
            var conn = new DbConnection();
            string query = @"";
            var result = conn.Connection.Execute(sql: query, param: cliente);
            return result == 1;
        }
    }
}
