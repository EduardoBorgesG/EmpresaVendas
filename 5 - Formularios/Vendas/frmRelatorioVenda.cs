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
    public partial class frmRelatorioVenda : Form
    {
        public frmRelatorioVenda()
        {
            InitializeComponent();
        }

        private void frmRelatorioVenda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'empresa_vendaDataSet.VendaJoin'. Você pode movê-la ou removê-la conforme necessário.
            this.vendaJoinTableAdapter.Fill(this.empresa_vendaDataSet.VendaJoin);

            this.reportViewer1.RefreshReport();
        }
    }
}
