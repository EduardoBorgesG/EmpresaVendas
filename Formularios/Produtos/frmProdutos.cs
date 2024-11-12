using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaVendas.Formularios.Produtos
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void btnEditarProduto_Click(object sender, EventArgs e)
        {
            frmEditarProdutos frm = new frmEditarProdutos();
            frm.Show();
        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            frmIncluirProdutos frm = new frmIncluirProdutos();
            frm.Show();
        }
    }
}
