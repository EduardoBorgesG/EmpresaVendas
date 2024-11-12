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
using EmpresaVendas.Classes;
using EmpresaVendas.Conecctions;
using Npgsql;
using Dapper;

namespace EmpresaVendas.Formularios
{
    public partial class frmClientes : Form
    {
        private List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public frmClientes()
        {
            InitializeComponent();
            ObterClientes();
        }
        private void ObterClientes()
        {
            var repository = new Cliente();
            Clientes = repository.Obter();
            gridClientes.DataSource = Clientes;
        }
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarClientes_Click(object sender, EventArgs e)
        {
            frmEditarClientes frm = new frmEditarClientes();
            frm.Show();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
        }
    }
}
