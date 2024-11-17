using EmpresaVendas._1___Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._4___Servicos
{
    public interface IProdutoServico
    {
        void AtualizarProduto(Produto alteradoProduto);
        void NovoProduto(Produto novoProduto);
        void ExcluirProduto(string id);
        List<Produto> ObterProduto();
        List<Produto> ColetaDadosProduto(int id);
    }
}
