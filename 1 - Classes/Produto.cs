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
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco_produto { get; set; }
        public int Estoque { get; set; }
        public Produto(string nome, string descricao, int estoque, decimal preco_produto)
        {
            Nome = nome;
            Descricao = descricao;         
            Estoque = estoque;
            Preco_produto = preco_produto;
        }

        public Produto(int id, string nome, string descricao, int estoque, decimal preco_produto)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Estoque = estoque;
            Preco_produto = preco_produto;            
        }

    }
}
