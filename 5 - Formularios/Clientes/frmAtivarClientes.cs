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

namespace EmpresaVendas._5___Formularios.Clientes
{
    public partial class frmAtivarClientes : Form
    {
        private readonly IClienteSerico _clienteSerico;
        public frmAtivarClientes(IClienteSerico clienteSerico)
        {
            InitializeComponent();
            _clienteSerico = clienteSerico;
            CarregarGrid();
            btnAtivarCliente.Enabled = false;
        }
        private void CarregarGrid()
        {
            //Obtem os clientes inativos do banco dados
            var Produtos = _clienteSerico.ObterClientesInativos();
            gridClientesInativos.DataSource = Produtos;
            FormatarDG();

        }
        private void FormatarDG()
        {
            gridClientesInativos.Columns[0].Visible = false;
            gridClientesInativos.Columns[1].HeaderText = "Nome do Cliente";
            gridClientesInativos.Columns[1].Width = 250;

        }
        private void gridClientesInativos_Click(object sender, EventArgs e)
        {
            btnAtivarCliente.Enabled = true;
        }

        private void btnAtivarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(gridClientesInativos.CurrentRow.Cells[0].Value);
                _clienteSerico.AtivarCliente(id);
                btnAtivarCliente.Enabled = false;
                MessageBox.Show("Cliente invativado com sucesso!", "Cliente Ativado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CarregarGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
