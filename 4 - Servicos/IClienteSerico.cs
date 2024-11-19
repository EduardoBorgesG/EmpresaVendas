using EmpresaVendas.Classes;
using System.Collections.Generic;

namespace EmpresaVendas.Servicos
{
    public interface IClienteSerico
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoCliente"></param>
        void NovoCliente(Cliente novoCliente);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="antigoTelefone"></param>
        /// <param name="novoTelefone"></param>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Cliente> ObterClientesAtivos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void InativarCliente(string id);
        /// <summary>
        /// asdada
        /// </summary>
        /// <param name="alteradoCliente">adsadada</param>
        void AtualizarCliente(Cliente alteradoCliente);
        List<Cliente> ObterClientesInativos();
        bool AtivarCliente(int id);
    }
}