using EmpresaVendas.Classes;
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
        public decimal valor_pago { get; set; }
        public int cliente_id { get; set; }
        public List<VendaItens> ItensVenda { get; set; }
        public Venda()
        {
            
        }
        public Venda(int cliente_id)
        {
            this.cliente_id = cliente_id;
        }
        public Venda(int id, decimal valor_pago, int cliente_id, List<VendaItens> itensVenda)
        {
            this.id = id;
            this.valor_pago = valor_pago;
            this.cliente_id = cliente_id;
            ItensVenda = itensVenda;
        }
        public Venda(int cliente_id, decimal valor_pago)
        {
            this.cliente_id = cliente_id;
            this.valor_pago = valor_pago;
        }

    }
}
