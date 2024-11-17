using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._1___Classes
{
    public class VendaItemDTO
    {

        public int produto_id { get; set; }
        public string nome_produto { get; set; }
        public decimal preco_produto { get; set; }
        public int quantidade { get; set; }

        public VendaItemDTO(int produto_id, string nome_produto, decimal preco_produto, int quantidade)
        {
            this.produto_id = produto_id;
            this.nome_produto = nome_produto;
            this.preco_produto = preco_produto;
            this.quantidade = quantidade;
        }
    }
}
