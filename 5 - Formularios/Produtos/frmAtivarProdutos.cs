using EmpresaVendas._1___Classes;
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

namespace EmpresaVendas._5___Formularios.Produtos
{
    public partial class frmAtivarProdutos : Form
    {
        private readonly IProdutoServico _produtoServico;
        public frmAtivarProdutos(IProdutoServico produtoServico)
        {
            InitializeComponent();
            _produtoServico = produtoServico;
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
                throw ex;
            }
            

        }

        private void gridProdutosInativos_Click(object sender, EventArgs e)
        {
            btnAtivarProduto.Enabled = true;
        }
    }
}
