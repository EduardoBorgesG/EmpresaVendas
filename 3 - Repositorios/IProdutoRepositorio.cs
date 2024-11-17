using EmpresaVendas._1___Classes;
using EmpresaVendas.Classes;
using EmpresaVendas.Conecctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._3___Repositorios
{
    public interface IProdutoRepositorio
    {
        bool CadastrarProduto(Produto produto);
        bool ExcluirProduto(string id);
        bool EditarProduto(Produto produto);
        bool VerificaProduto(string nome);
        List<Produto> ObterProduto();
        List<Produto> ColetaDadosProduto(int id);
    }
}
