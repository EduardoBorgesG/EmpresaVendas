using EmpresaVendas._1___Classes;
using EmpresaVendas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._3___Repositorios
{
    public interface IVendaRepositorio
    {
        List<Venda> BuscarClientes();
        List<Venda> BuscaProduto();
        bool IncluirVenda(Venda venda);
    }
}
