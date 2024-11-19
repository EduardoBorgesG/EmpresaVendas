using EmpresaVendas.Classes;
using System.Collections.Generic;

namespace EmpresaVendas.Repositorios
{
    public interface IClienteRepositorio
    {
        bool CadastrarCliente(Cliente cliente);
        bool AtualizarCliente(Cliente cliente);
        bool InativarCliente(string id);
        List<Cliente> ObterClienteAtivos();
        bool VerificaCliente(string telefone);
        List<Cliente> ObterClienteInativos();
        bool AtivarCliente(int id);
    }
}