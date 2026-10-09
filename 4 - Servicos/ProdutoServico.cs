using EmpresaVendas._1___Classes;
using EmpresaVendas._1___Classes.Excecoes;
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
            //Lança exceção para o formulário exibir o erro e não mostrar a mensagem de sucesso
            if (!_produtoRepositorio.VerificaProduto(novoProduto.nome))
            {
                throw new RegraNegocioException("Já existe um produto cadastrado com esse nome");
            }
            _produtoRepositorio.CadastrarProduto(novoProduto);

        }
        //editar produto
        public void AtualizarProduto(Produto alteradoProduto)
        {
            _produtoRepositorio.EditarProduto(alteradoProduto);
            return;
        }
        //Remover produto
        public void EsgotarProduto(int id)
        {
            _produtoRepositorio.EsgotarProduto(id);
        }
        public void AtivarProduto(int id)
        {
            _produtoRepositorio.AtivarProduto(id);
        } 
        public List<Produto> ObterProdutosInativos()
        {
            return _produtoRepositorio.ObterProdutosInativos();
        }
        //Obtem os produtos do banco que estão com status ativo
        public List<Produto> ObterProduto()
        {
            return _produtoRepositorio.ObterProduto();

        }
        public List<Produto> ColetaDadosProduto(int id)
        {
            try
            {
                return _produtoRepositorio.ColetaDadosProduto(id);
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
                return _produtoRepositorio.VerificaEstoque(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
