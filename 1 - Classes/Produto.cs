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
            this.nome = nome;
            Descricao = descricao;         
            Estoque = estoque;
            Preco_produto = preco_produto;
        }

        public Produto(int id, string nome_produto, string descricao, int estoque, decimal preco_produto)
        {
            Id = id;
            this.nome = nome;
            Descricao = descricao;
            Estoque = estoque;
            Preco_produto = preco_produto;            
        }

    }
}
