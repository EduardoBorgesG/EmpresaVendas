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
            if (!_clienteRepositorio.VerificaCliente(novoCliente.Telefone))
            {
                _clienteRepositorio.CadastrarCliente(novoCliente);
                return;
            }
            MessageBox.Show("Este cliente já está cadastrado");           
        }
        public void AtualizarCliente(Cliente alteradoCliente)
        {
            if (!_clienteRepositorio.VerificaCliente(alteradoCliente.Telefone))
            {
                _clienteRepositorio.AtualizarCliente(alteradoCliente);
                return;
            }
            MessageBox.Show("Este cliente já está cadastrado");
        }
        public void ExcluirCliente(string id)
        {
            _clienteRepositorio.ExcluirCliente(id);
        }
        public List<Cliente> ObterTodos()
        {
            return _clienteRepositorio.Obter();
        }
        public void AlterarTelefone(string antigoTelefone, string novoTelefone)
        {
            if (_clienteRepositorio.VerificaCliente(antigoTelefone))
            {
                var Cliente = _clienteRepositorio.ObterUm(antigoTelefone);
                if (Cliente == null) throw new Exception();

                if (_clienteRepositorio.VerificaCliente(novoTelefone)) throw new Exception();

                Cliente.AlterarTelefone(novoTelefone);
                _clienteRepositorio.AtualizarCliente(Cliente);
            }
        }
    }
}
