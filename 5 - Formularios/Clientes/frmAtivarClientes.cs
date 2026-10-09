using EmpresaVendas._5___Formularios.Erros;
using EmpresaVendas.Servicos;
using System;
using System.Windows.Forms;


namespace EmpresaVendas._5___Formularios.Clientes
{
    public partial class frmAtivarClientes : Form
    {
        private readonly IClienteSerico _clienteSerico;
        private readonly ITratadorErros _tratadorErros;
        public frmAtivarClientes(IClienteSerico clienteSerico, ITratadorErros tratadorErros)
        {
            InitializeComponent();
            _clienteSerico = clienteSerico;
            _tratadorErros = tratadorErros;
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
                MessageBox.Show("Cliente ativado com sucesso!", "Cliente Ativado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CarregarGrid();
            }
            catch (Exception ex)
            {
                _tratadorErros.Tratar("Ocorreu um  erro ao ativar o cliente", ex);
            }
        }
    }
}
