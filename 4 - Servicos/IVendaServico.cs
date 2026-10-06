using EmpresaVendas._1___Classes;
using System.Collections.Generic;

namespace EmpresaVendas._4___Servicos
{
    public interface IVendaServico
    {
        int FinalizarVenda(Venda venda, List<VendaItens> itens);
    }
}
