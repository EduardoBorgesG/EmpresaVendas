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

namespace EmpresaVendas._4___Servicos
{
    public interface IVendaServico
    {
        int NovaVenda(Venda venda);
        object VerificaEstoque(int id);
        decimal AtualizaPreco(int id);
        object AdquirirProdutos(int id);
        
        bool InserirDetalhes(VendaItens vendaItens);
        

    }
}
