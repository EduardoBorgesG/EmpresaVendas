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
        public int NovaVenda(Venda venda)
        {
            var result = _vendaRepositorio.IncluirVenda(venda);
            return result;

        }
        public bool InserirDetalhes(VendaItens vendaItens)
        {
            try
            {
                var resultado = _vendaRepositorio.InserirVendaItem(vendaItens);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public object VerificaEstoque(int id)
        {
            try
            {
                object resultado = _vendaRepositorio.VerificaEstoque(id);
                return resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Venda> ColetaID(Venda venda)
        {
            try
            {
                return _vendaRepositorio.ColetaId(venda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
