using EmpresaVendas._1___Classes;
using System.Collections.Generic;

namespace EmpresaVendas._3___Repositorios
{
    public interface IVendaRepositorio
    {
        //INCLUÍ VENDA, ITENS E BAIXA O ESTOQUE (TRANSAÇÃO ÚNICA)
        int RegistrarVenda(Venda venda, List<VendaItens> itens);
    }
}
