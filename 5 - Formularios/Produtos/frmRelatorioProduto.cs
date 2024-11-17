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
    public partial class frmRelatorioProduto : Form
    {
        public frmRelatorioProduto()
        {
            InitializeComponent();
        }

        private void frmRelatorioProduto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'empresa_vendaDataSet.p_produtos_tb'. Você pode movê-la ou removê-la conforme necessário.
            this.p_produtos_tbTableAdapter.Fill(this.empresa_vendaDataSet.p_produtos_tb);

            this.reportViewer1.RefreshReport();
        }
    }
}
