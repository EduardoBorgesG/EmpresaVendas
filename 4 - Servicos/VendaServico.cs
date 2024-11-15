using EmpresaVendas._1___Classes;
using EmpresaVendas._3___Repositorios;
using EmpresaVendas.Classes;
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
        //Alimenta a minha lista de seleção de Clientes
        public List<Venda> ObterCliente()
        {
            return _vendaRepositorio.BuscarClientes();
        }
        //Alimenta a minha lista de Produto
        public List<Venda> ObterProdutos() 
        {
            try
            {
              return _vendaRepositorio.BuscaProduto();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        public void NovaVenda(Venda venda)
        {
                _vendaRepositorio.IncluirVenda(venda);
                return;
        }
        public object AdquirirEstoque(int id)
        {
            try
            {
                object resultado = _vendaRepositorio.AdquirirEstoque(id);
                return resultado;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
