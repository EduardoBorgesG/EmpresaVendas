using EmpresaVendas._1___Classes;
using EmpresaVendas.Classes;
using Npgsql;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaVendas._3___Repositorios
{
    public interface IVendaRepositorio
    {
        //INCLUÍ VENDA
        int IncluirVenda(Venda venda);
        object AdquiriPropriedades(int id);
        object VerificarQuantidade(int id);
        object AdquirirEstoquePreco(int id);
        decimal AtualizaPreco(int id);
        bool InserirVendaItem(VendaItens vendaItens);
        
        

    }
}
