using EmpresaVendas._1___Classes;
using EmpresaVendas._1___Classes.Excecoes;
using EmpresaVendas._3___Repositorios;
using System;
using System.Collections.Generic;

namespace EmpresaVendas._4___Servicos
{
    public class VendaServico : IVendaServico
    {
        private readonly IVendaRepositorio _vendaRepositorio;
        public VendaServico(IVendaRepositorio vendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
        }

        public int FinalizarVenda(Venda venda, List<VendaItens> itens)
        {
            if (itens == null || itens.Count == 0) throw new RegraNegocioException("Adicione ao menos um produto à venda");
            return _vendaRepositorio.RegistrarVenda(venda, itens);
        }
    }
}
