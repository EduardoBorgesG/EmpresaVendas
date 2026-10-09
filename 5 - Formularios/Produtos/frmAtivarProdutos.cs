using EmpresaVendas._4___Servicos;
using EmpresaVendas._5___Formularios.Erros;
using System;
using System.Windows.Forms;

namespace EmpresaVendas._5___Formularios.Produtos
{
    public partial class frmAtivarProdutos : Form
    {
        private readonly IProdutoServico _produtoServico;
        private readonly ITratadorErros _tratadorErros;

        public frmAtivarProdutos(IProdutoServico produtoServico, ITratadorErros tratadorErros)
        {
            InitializeComponent();

            _produtoServico = produtoServico;
            _tratadorErros = tratadorErros;
            CarregarGrid();
            btnAtivarProduto.Enabled = false;

        }
        private void CarregarGrid()
        {
            //Obtem os produtos inativos do banco dados
            var Produtos = _produtoServico.ObterProdutosInativos();
            gridProdutosInativos.DataSource = Produtos;
            FormatarDG();
            
        }
        private void FormatarDG()
        {
            gridProdutosInativos.Columns[0].Visible = false;
            gridProdutosInativos.Columns[1].HeaderText = "Nome do Produto";
            gridProdutosInativos.Columns[1].Width = 250;

        }
        private void btnAtivarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(gridProdutosInativos.CurrentRow.Cells[0].Value);
                _produtoServico.AtivarProduto(id);
                btnAtivarProduto.Enabled = false;
                MessageBox.Show("Produto ativado com sucesso", "Ativar produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CarregarGrid();
            }
            catch (Exception ex)
            {
                _tratadorErros.Tratar("Ocorreu um erro ao ativar o produto", ex);
            }
            

        }

        private void gridProdutosInativos_Click(object sender, EventArgs e)
        {
            btnAtivarProduto.Enabled = true;
        }
    }
}
