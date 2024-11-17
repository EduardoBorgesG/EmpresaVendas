using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaVendas._1___Classes
{
    public class VendaItens
    {
        public int id { get; set; }
        public int produto_id { get; set; }
        public int quantidade { get; set; }
        public int vendaId { get; set; }

        public VendaItens()
        {   
            
        }

        public VendaItens(int id, int produto_id, int quantidade, int vendaId)
        {
            this.id = id;
            this.produto_id = produto_id;           
            this.quantidade = quantidade;
            this.vendaId = vendaId;
        }

        public VendaItens(int produto_id, int quantidade, int vendaId)
        {
            this.produto_id = produto_id;
            this.quantidade = quantidade;
            this.vendaId= vendaId;
        }
    }

}
