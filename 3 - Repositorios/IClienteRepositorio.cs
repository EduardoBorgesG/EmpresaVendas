using EmpresaVendas.Classes;
using System.Collections.Generic;

namespace EmpresaVendas.Repositorios
{
    public interface IClienteRepositorio
    {
        bool CadastrarCliente(Cliente cliente);
        bool AtualizarCliente(Cliente cliente);
        bool ExcluirCliente(string id);
        List<Cliente> Obter();
        bool VerificaCliente(string telefone);
        Cliente ObterUm(string telefone);
        bool AtualizarTelefone(Cliente cliente);
    }
}