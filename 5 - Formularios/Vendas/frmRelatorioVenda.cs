using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace EmpresaVendas._5___Formularios.Vendas
{
    public partial class frmRelatorioVenda : Form
    {
        public frmRelatorioVenda()
        {
            InitializeComponent();
        }

        private void frmRelatorioVenda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'empresa_vendaDataSet.v_relatorio_vendas'. Você pode movê-la ou removê-la conforme necessário.
            this.v_relatorio_vendasTableAdapter.Fill(this.empresa_vendaDataSet.v_relatorio_vendas);

            reportViewer1.RefreshReport();
            
        }
    }
}
