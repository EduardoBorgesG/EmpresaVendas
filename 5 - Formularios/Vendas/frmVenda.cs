using EmpresaVendas._1___Classes;
using EmpresaVendas._4___Servicos;
using EmpresaVendas.Servicos;
using NPOI.POIFS.NIO;
using NPOI.SS.Formula.Functions;
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
        List<Venda> vendas = new List<Venda>();

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
            catch (Exception ex)
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
            try
            {
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
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            IncluirProduto();
        }
        private void AdicionarProduto(string nome, int quantidade_selecionar, int estoque)
        {
            Venda venda = new Venda { nome = nome, quantidade_venda = quantidade_selecionar, estoque = estoque };
        }
        private void FormatarDG()
        {
            //Formata o nome das colunas do DataGrid
            gridVisualizacaoProdutos.Columns[0].Visible = false;
            gridVisualizacaoProdutos.Columns[1].HeaderText = "Quantidade";
            gridVisualizacaoProdutos.Columns[2].Visible = false;
            gridVisualizacaoProdutos.Columns[3].Visible = false;
            gridVisualizacaoProdutos.Columns[4].Visible = false;
            gridVisualizacaoProdutos.Columns[5].HeaderText = "Produto";
            gridVisualizacaoProdutos.Columns[6].HeaderText = "Estoque";

        }
        private void VerificaEstoque()
        {
            var id = Convert.ToInt32(cbListaProduto.SelectedValue);
            object resultado = _vendaServico.AdquirirEstoque(id);

            if (Convert.ToInt32(resultado) < Convert.ToInt32(txtQuantidade.Text))
            {
                MessageBox.Show("SEM ESTOQUE");
                txtQuantidade.Clear();
                return;
            }
            return;
        }
        private void AlimentarDG()
        {
            var id = Convert.ToInt32(cbListaProduto.SelectedValue);
            object resultado = _vendaServico.AdquirirEstoque(id);
            string nome = cbListaProduto.Text;
            int quantidade_venda = Convert.ToInt32(txtQuantidade.Text);
            int estoque = Convert.ToInt32(resultado);
            vendas.Add(new Venda(nome, quantidade_venda, estoque));
            gridVisualizacaoProdutos.DataSource = null;
            gridVisualizacaoProdutos.DataSource = vendas;
            //FormatarDG();


        }
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            AlimentarDG();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            VerificaEstoque();
        }
        private void GerarScriptInsert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO public.v_vendas_tb( valor_pago, quantidade_venda, nome_produto_id, nome_cliente_id, estoque_id)\r\n\tVALUES ( @valor_pago, @quantidade_venda, @nome_produto_id, @nome_cliente_id, @estoque_id);\r\n");
            var valores = new List<object>();
            for (int i = 0; i < gridVisualizacaoProdutos.Rows.Count; i++)
            {
                decimal valor_pago = Convert.ToDecimal(gridVisualizacaoProdutos.Rows[i].Cells[1].Value);
                int quantidade_venda = Convert.ToInt32(gridVisualizacaoProdutos.Rows[i].Cells[1].Value);
                int nome_produto_id = Convert.ToInt32(gridVisualizacaoProdutos.Rows[i].Cells[1].Value);
                int nome_cliente_id = Convert.ToInt32(gridVisualizacaoProdutos.Rows[i].Cells[1].Value);
                int estoque_id = Convert.ToInt32(gridVisualizacaoProdutos.Rows[i].Cells[1].Value);

            }
        }
    }
}
