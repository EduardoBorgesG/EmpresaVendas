using EmpresaVendas._1___Classes;
using EmpresaVendas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._4___Servicos
{
    public interface IVendaServico
    {
        List<Venda> ObterCliente();
        List<Venda> ObterProdutos();
        void NovaVenda(Venda venda);

    }
}
