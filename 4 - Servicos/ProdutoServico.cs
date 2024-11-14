using EmpresaVendas._1___Classes;
using EmpresaVendas._3___Repositorios;
using EmpresaVendas._4___Servicos;
using EmpresaVendas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaVendas.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        //Incluir produto
        public void NovoProduto(Produto novoProduto)
        {
            if (_produtoRepositorio.VerificaProduto(novoProduto.Nome) == true)
            {
                _produtoRepositorio.CadastrarProduto(novoProduto);
                return;
            }
            MessageBox.Show("Este produto já está cadastrado");

        }
        //editar produto
        public void AtualizarProduto(Produto alteradoProduto)
        {
            _produtoRepositorio.EditarProduto(alteradoProduto);
            return;
        }
        //Remover produto
        public void ExcluirProduto(string id)
        {
            _produtoRepositorio.ExcluirProduto(id);
        }
        //Obtem todos os produtos do banco
        public List<Produto> ObterProduto()
        {
            return _produtoRepositorio.ObterProduto();
           
        }
    }
}
