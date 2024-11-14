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
        List<Cliente> ObterCliente();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void ExcluirCliente(string id);
        /// <summary>
        /// asdada
        /// </summary>
        /// <param name="alteradoCliente">adsadada</param>
        void AtualizarCliente(Cliente alteradoCliente);
        void AlterarTelefone(Cliente cliente);
    }
}