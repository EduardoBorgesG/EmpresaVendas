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
        public void InativarCliente(string id)
        {
            _clienteRepositorio.InativarCliente(id);
        }
        /// <summary>
        /// Metodo para obter todos os clientes do banco
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ObterClientesAtivos()
        {
            return _clienteRepositorio.ObterClienteAtivos();
        }

        public List<Cliente> ObterClientesInativos()
        {
            return _clienteRepositorio.ObterClienteInativos();
        }
        public bool AtivarCliente(int id)
        {
            return _clienteRepositorio.AtivarCliente(id);
        }
    }
}
