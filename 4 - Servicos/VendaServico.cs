using EmpresaVendas._1___Classes;
using EmpresaVendas._3___Repositorios;
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
    public class VendaServico : IVendaServico
    {
        private readonly IVendaRepositorio _vendaRepositorio;
        public VendaServico(IVendaRepositorio vendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
        }

        public decimal AtualizaPreco(int id)
        {
            try
            {
                decimal resultado = _vendaRepositorio.AtualizaPreco(id);
                return resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int FinalizarVenda(Venda venda, List<VendaItens> itens)
        {
            if (itens == null || itens.Count == 0) throw new Exception("Adicione ao menos um produto à venda");
            return _vendaRepositorio.RegistrarVenda(venda, itens);
        }
        public object AdquirirProdutos(int id)
        {
            try
            {
                object resultado = _vendaRepositorio.AdquiriPropriedades(id);
                return resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        
        
    }
}
