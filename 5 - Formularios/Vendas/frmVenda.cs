using EmpresaVendas._1___Classes;
using EmpresaVendas._4___Servicos;
using EmpresaVendas.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmpresaVendas._5___Formularios.Vendas
{
    public partial class frmVenda : Form
    {
        private readonly IVendaServico _vendaServico;
        private List<Venda> Venda { get; set; } = new List<Venda>();
        public frmVenda(IVendaServico vendaServico)
        {
            InitializeComponent();
            _vendaServico = vendaServico;
            ListarCliente();
            ListarProdutos();
        }
        //Metodo para alimentar minha lista
        private void ListarCliente()
        {
            try 
            {
                var Cliente = _vendaServico.ObterCliente();
                cbListaClientes.DataSource = Cliente;
                cbListaClientes.ValueMember = "id";
                cbListaClientes.DisplayMember = "nome";
                cbListaClientes.SelectedValue = "id";
            }
            catch(Exception ex) 
            { 
                throw ex; 
            }
            ;
        }
        private void ListarProdutos()
        {
            try 
            {
                var Produto = _vendaServico.ObterProdutos();
                cbListaProduto.DataSource = Produto;
                cbListaProduto.ValueMember = "id";
                cbListaProduto.DisplayMember = "nome";
                cbListaProduto.SelectedValue = "id";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// Metodo para incluir produto no banco de dados
        /// </summary>
        private void IncluirProduto()
        {
            try {
            string valor = mtxtValorTotal.Text.Replace("R$", "");
            valor = valor.Replace(".", ",");
            decimal formaMoeda = Convert.ToDecimal(valor);
            var nome_produto_id = Convert.ToInt32(cbListaProduto.SelectedValue);
            var nome_cliente_id = Convert.ToInt32(cbListaClientes.SelectedValue);
            var quantidade_venda = Convert.ToInt32(txtQuantidade.Text);
            var valor_pago = formaMoeda;           
            var Venda = new Venda(nome_cliente_id, nome_produto_id, quantidade_venda, valor_pago);
            _vendaServico.NovaVenda(Venda);
            }
            catch (Exception ex) { throw ex; }

            //@nome_produto, @nome_cliente, @valor_total, @quantidade_venda, @nome_produto_id, @nome_cliente_id)
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            IncluirProduto();
        }
    }
}
