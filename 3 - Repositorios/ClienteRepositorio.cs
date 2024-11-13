using EmpresaVendas.Classes;
using EmpresaVendas.Conecctions;
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
            string query = @"SELECT id FROM public.c_clientes_tb WHERE telefone(telefone) VALUES (@telefone)";
            var result = conn.Executar(sql: query, param: telefone);
            if (result == 1)
            {
                MessageBox.Show("Esse telefone já está cadastrado no banco de dados");
            }
            return result == 1;
        }
        //Adiciona um cliente no banco de dados
        public bool CadastrarCliente(Cliente cliente)
        {
            string query = @"INSERT INTO public.c_clientes_tb(
	                        nome, email, telefone, cep, endereco)
	                        VALUES (@nome, @email, @telefone, @cep, @endereco);";

            var result = conn.Executar(sql: query, param: cliente);
            return result == 1;
        }
        public Cliente ObterUm(string telefone)
        {

            string query = @"SELECT *
	                        FROM public.c_clientes_tb WHERE public.c_clientes_tb.telefone = @telefone LIMIT 1;";
            var cliente = conn.Consulta(sql: query, param: telefone);
            return cliente.FirstOrDefault();
        }
        //Coleta todos os dados do meu banco e armazena em uma lista
        public List<Cliente> Obter()
        {

            string query = @"SELECT *
	                        FROM public.c_clientes_tb ORDER BY id;";
            var clientes = conn.Consulta(sql: query);

            return clientes.ToList();
        }
        //Edição de Cliente
        public bool AtualizarCliente(Cliente cliente)
        {

            string query = $"UPDATE public.c_clientes_tb SET nome = '{cliente.Nome}', email = '{cliente.Email}', telefone = '{cliente.Telefone}', cep = '{cliente.Cep}', endereco = '{cliente.Endereco}' WHERE id = {cliente.Id};";
            var result = conn.Executar(sql: query, param: cliente);
            return result == 1;
        }

        //Exclusão de cliente
        public bool ExcluirCliente(string id)
        {
 
            string query = $"DELETE FROM public.c_clientes_tb WHERE id = {id};";
            var result = conn.Executar(sql: query, param: id);
            return result == 1;
        }
    }
}
