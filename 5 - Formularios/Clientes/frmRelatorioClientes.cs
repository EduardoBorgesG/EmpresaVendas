using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpresaVendas.Formularios;
using EmpresaVendas._5___Formularios;

namespace EmpresaVendas._5___Formularios.Clientes
{
    public partial class frmRelatorioClientes : Form
    {
        public frmRelatorioClientes()
        {
            InitializeComponent();
        }

        private void frmRelatorioClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'empresa_vendaDataSet.c_clientes_tb'. Você pode movê-la ou removê-la conforme necessário.
            this.c_clientes_tbTableAdapter.Fill(this.empresa_vendaDataSet.c_clientes_tb);

            this.reportViewer1.RefreshReport();
        }
    }
}
