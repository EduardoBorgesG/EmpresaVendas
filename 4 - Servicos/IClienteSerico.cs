using EmpresaVendas.Classes;
using System.Collections.Generic;

namespace EmpresaVendas.Servicos
{
    public interface IClienteSerico
    {
        void NovoCliente(Cliente novoCliente);
        void AlterarTelefone(string antigoTelefone, string novoTelefone);
        List<Cliente> ObterTodos();
        void ExcluirCliente(string id);
        void AtualizarCliente(Cliente alteradoCliente);
    }
}