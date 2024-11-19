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
            nome = !string.IsNullOrEmpty(nome) ? nome : throw new Exception("Nome do produto não pode estar vazio");
            this.nome = nome;
            descricao = !string.IsNullOrEmpty(descricao) ? descricao : throw new Exception("Preencha a descrição do produto");
            Descricao = descricao;         
            Estoque = estoque;
            Preco_produto = preco_produto;
        }

        public Produto(int id, string nome_produto, string descricao, decimal preco_produto)
        {
            Id = id;            
            nome = !string.IsNullOrEmpty(nome_produto) ? nome : throw new Exception("Nome do produto não pode estar vazio");
            nome = nome_produto;
            descricao = !string.IsNullOrEmpty(descricao) ? descricao : throw new Exception("Preencha a descrição do produto");
            Descricao = descricao;
            Preco_produto = preco_produto;            
        }

    }
}
