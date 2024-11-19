using EmpresaVendas._1___Classes;
using EmpresaVendas.Classes;
using EmpresaVendas.Conecctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace EmpresaVendas.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private DbConnection<Cliente> conn;

        public ClienteRepositorio()
        {
            conn = new DbConnection<Cliente>();
        }
        public bool VerificaCliente(string telefone)
        {
            //METODO QUE VERIFICA SE JÁ POSSUÍ O TELEFONE CADASTRADO
            string query = $"SELECT id FROM public.c_clientes_tb WHERE telefone = '{telefone}'";
            var result = conn.VerificarnoBanco(sql: query, param: telefone);
            if (result != null)
            {
                MessageBox.Show("Esse telefone já está cadastrado no banco de dados");
                return false;
            }
            return result == null;
        }
        //Adiciona um cliente no banco de dados
        public bool CadastrarCliente(Cliente cliente)
        {
            string query = @"INSERT INTO public.c_clientes_tb(
	                        nome, email, telefone, cep, endereco, ativo)
	                        VALUES (@nome, @email, @telefone, @cep, @endereco, true);";

            var result = conn.Executar(sql: query, param: cliente);
            return result == 1;
        }


        //Coleta todos os dados do meu banco e armazena em uma lista
        public List<Cliente> ObterClienteAtivos()
        {

            string query = @"SELECT * FROM public.c_clientes_tb WHERE ativo = true;";
            var clientes = conn.Consulta(sql: query);

            return clientes.ToList();
        }
        //Edita somente o telefone
        public bool AtualizarTelefone(Cliente cliente)
        {
            string query = $"UPDATE public.c_cliente_tb SET telefone = '{cliente.Telefone} WHERE {cliente.Id}'";
            var result = conn.Executar(sql: query, param: cliente);
            return result == 1;
        }
        //Edição de Cliente
        public bool AtualizarCliente(Cliente cliente)
        {

            string query = $"UPDATE public.c_clientes_tb SET nome = '{cliente.nome}', email = '{cliente.Email}', cep = '{cliente.Cep}', endereco = '{cliente.Endereco}', telefone = '{cliente.Telefone}' WHERE id = {cliente.Id};";
            var result = conn.Executar(sql: query, param: cliente);
            return result == 1;
        }

        //Exclusão de cliente
        public bool InativarCliente(string id)
        {
            string query = $"UPDATE public.c_clientes_tb SET ativo = false WHERE id = {id};";
            var result = conn.Executar(sql: query, param: id);
            return result == 1;
        }
        public List<Cliente> ObterClienteInativos()
        {
            string query = "SELECT id, nome FROM public.c_clientes_tb WHERE ativo = false";
            var result = conn.Consulta(sql: query);
            return result.ToList();
        }
        public bool AtivarCliente(int id)
        {
            string query = $"UPDATE public.c_clientes_tb SET ativo = true WHERE id = {id};";
            var result = conn.Executar(sql: query, param: id);
            return result == 1;

        }
    }
}
