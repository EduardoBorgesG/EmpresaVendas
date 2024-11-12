using EmpresaVendas.Formularios.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaVendas.Formularios
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            frmIncluirClientes frm = new frmIncluirClientes();
            frm.Show();
        }

        private void btnEditarClientes_Click(object sender, EventArgs e)
        {
            frmEditarClientes frm = new frmEditarClientes();
            frm.Show();
        }
    }
}
