using EmpresaVendas.Classes;
using EmpresaVendas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaVendas.Servicos
{
    public class ClienteSerico : IClienteSerico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteSerico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="novoCliente"></param>
        public void NovoCliente(Cliente novoCliente)
        {
            if (_clienteRepositorio.VerificaCliente(novoCliente.Telefone) == true)
            {
                _clienteRepositorio.CadastrarCliente(novoCliente);
                return;
            }
            MessageBox.Show("Este cliente já está cadastrado");

        }
        /// <summary>
        /// Atualiza Cliente
        /// </summary>
        /// <param name="alteradoCliente"></param>
        public void AtualizarCliente(Cliente alteradoCliente)
        {            
                _clienteRepositorio.AtualizarCliente(alteradoCliente);
                return;           
        }
        /// <summary>
        /// Excluir cliente do banco de dados
        /// </summary>
        /// <param name="id"></param>
        public void ExcluirCliente(string id)
        {
            _clienteRepositorio.ExcluirCliente(id);
        }
        /// <summary>
        /// Metodo para obter todos os clientes do banco
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ObterCliente()
        {
            return _clienteRepositorio.ObterCliente();
        }
        /// <summary>
        /// Metodo para alterar o Telefone
        /// </summary>
        /// <param name="cliente"></param>
        /// <exception cref="Exception"></exception>
        public void AlterarTelefone(Cliente cliente)
        {
            if (_clienteRepositorio.VerificaCliente(cliente.Telefone))
            {
                var Cliente = _clienteRepositorio.ObterUm(cliente.Telefone);
                if (Cliente == null) throw new Exception();

                if (_clienteRepositorio.VerificaCliente(cliente.Telefone)) throw new Exception();

                Cliente.AlterarTelefone(cliente.Telefone);
                _clienteRepositorio.AtualizarTelefone(Cliente);
            }
        }
    }
}
