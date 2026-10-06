using EmpresaVendas.Formularios;
using EmpresaVendas.Formularios.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpresaVendas._5___Formularios;
using EmpresaVendas._5___Formularios.Vendas;
using EmpresaVendas._5___Formularios.Clientes;
using EmpresaVendas._5___Formularios.Produtos;


namespace EmpresaVendas
{
    public partial class frmInicial : Form
    {
        private readonly IFormFactory _formFactory;

        public frmInicial(IFormFactory formFactory)
        {
            InitializeComponent();
            _formFactory = formFactory;
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<frmProdutos>().Show();
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<frmClientes>().Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<frmVenda>().Show();
        }

        private void relatórioClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<frmRelatorioClientes>().Show();
        }

        private void relatórioProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<frmRelatorioProduto>().Show();
        }

        private void relatórioVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<frmRelatorioVenda>().Show();
        }

        private void produtosInativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<frmAtivarProdutos>().Show();
        }

        private void clientesInativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formFactory.Criar<frmAtivarClientes>().Show();
        }
    }
}
