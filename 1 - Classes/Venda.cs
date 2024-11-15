using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._1___Classes
{
    public class Venda
    {
        public int id { get; set; }
        public int quantidade_venda { get; set; }
        public decimal valor_pago { get; set; }
        public int nome_cliente_id { get; set; }
        public int nome_produto_id { get; set; }
        public string nome { get; set; }
        public Venda(int quantidade, decimal valor_pago)
        {

            this.quantidade_venda = quantidade;
            this.valor_pago = valor_pago;
        }

        public Venda()
        {
        }
        public Venda(int nome_cliente_id)
        {
            this.nome_cliente_id = nome_cliente_id;
        }

        public Venda(int nome_cliente_id, int nome_produto_id, int quantidade_venda, decimal valor_pago)
        {
            this.nome_cliente_id = nome_cliente_id;
            this.nome_produto_id = nome_produto_id;
            this.quantidade_venda = quantidade_venda;
            this.valor_pago = valor_pago;
            
        }
    }
}
