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
        public void NovoCliente(Cliente novoCliente)
        {
            if (_clienteRepositorio.VerificaCliente(novoCliente.Telefone) == true)
            {
                _clienteRepositorio.CadastrarCliente(novoCliente);
                return;
            }
            MessageBox.Show("Este cliente já está cadastrado");

        }
        public void AtualizarCliente(Cliente alteradoCliente)
        {            
                _clienteRepositorio.AtualizarCliente(alteradoCliente);
                return;           
        }
        public void ExcluirCliente(string id)
        {
            _clienteRepositorio.ExcluirCliente(id);
        }
        public List<Cliente> ObterTodos()
        {
            return _clienteRepositorio.Obter();
        }
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
