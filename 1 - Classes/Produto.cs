using EmpresaVendas._1___Classes.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._1___Classes
{
    public class Produto
    {        
        public int Id { get; set; }
        public string nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco_produto { get; set; }
        public int Estoque { get; set; }
        public Produto()
        {
                
        }
        public Produto(string nome, string descricao, int estoque, decimal preco_produto)
        {
            nome = !string.IsNullOrEmpty(nome) ? nome : throw new RegraNegocioException("Nome do produto não pode estar vazio");
            this.nome = nome;
            descricao = !string.IsNullOrEmpty(descricao) ? descricao : throw new RegraNegocioException("Preencha a descrição do produto");
            Descricao = descricao;         
            Estoque = estoque;
            Preco_produto = preco_produto;
        }

        public Produto(int id, string nome_produto, string descricao, decimal preco_produto, int estoque)
        {
            Id = id;
            nome = !string.IsNullOrEmpty(nome_produto) ? nome_produto : throw new RegraNegocioException("Nome do produto não pode estar vazio");
            descricao = !string.IsNullOrEmpty(descricao) ? descricao : throw new RegraNegocioException("Preencha a descrição do produto");
            Descricao = descricao;
            Preco_produto = preco_produto;
            Estoque = estoque >= 0 ? estoque : throw new RegraNegocioException("O estoque não pode ser negativo");
        }

    }
}
