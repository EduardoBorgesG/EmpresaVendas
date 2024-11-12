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
using EmpresaVendas.Conecctions;
using EmpresaVendas.Formularios.Clientes;

namespace EmpresaVendas
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();           
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos frm = new frmProdutos();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var conn = new DbConnection();
                conn.Dispose();
                MessageBox.Show("Conexão sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocrreu um erro {ex}");

            }
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncluirClientes frm = new frmIncluirClientes();
            frm.Show();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.Show();
        }
    }
}
