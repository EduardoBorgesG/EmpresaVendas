using EmpresaVendas._1___Classes;
using EmpresaVendas._4___Servicos;
using EmpresaVendas.Classes;
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
using EmpresaVendas.Conecctions;
using System.Globalization;
using NPOI.XWPF.UserModel;


namespace EmpresaVendas.Formularios.Produtos
{
    public partial class frmProdutos : Form
    {
        private readonly IProdutoServico _produtoServico;
        private List<Produto> Produto { get; set; } = new List<Produto>();
        public frmProdutos(IProdutoServico produtoServico)
        {
            InitializeComponent();
            _produtoServico = produtoServico;
            ObterProduto();
            txtPrecoProduto.Text = "R$";
            btnSalvarProduto.Enabled = false;
            btnCancelar.Enabled = false;
        }
        private void PermitirNumero(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsNumber(e.KeyChar)) ? true : e.Handled;
        }
        /// <summary>
        /// Obtem os produtos do banco de dados e alimenta minha data grid
        /// </summary>
        private void ObterProduto()
        {
            //Obtem os produtos do banco dados
            var Produtos = _produtoServico.ObterProduto();
            gridProdutos.DataSource = Produtos;
            FormatarDG();
        }
        private void ObterDados()
        {
            //Coleta os dados da grid e passa para os campos de texto
            txtNomeProduto.Text = gridProdutos.CurrentRow.Cells[1].Value.ToString();
            rtxtDescricaoProduto.Text = gridProdutos.CurrentRow.Cells[2].Value.ToString();
            decimal formato_moeda = Convert.ToDecimal(gridProdutos.CurrentRow.Cells[3].Value.ToString());
            txtPrecoProduto.Text = formato_moeda.ToString("C");
            txtEstoqueProduto.Text = gridProdutos.CurrentRow.Cells[4].Value.ToString();
        }
        private void LimparCampos()
        {
            txtNomeProduto.Clear();
            rtxtDescricaoProduto.Clear();
            txtPrecoProduto.Clear();
            txtEstoqueProduto.Clear();
        }
        private void FormatarDG()
        {
            //Formata o nome das colunas do DataGrid
            gridProdutos.Columns[0].Visible = false;
            gridProdutos.Columns[1].HeaderText = "Produto";
            gridProdutos.Columns[2].HeaderText = "Descrição";
            gridProdutos.Columns[3].HeaderText = "Preço";
            gridProdutos.Columns[4].HeaderText = "Estoque";

            //Formata a largura da coluna do DataGrid
            gridProdutos.Columns[1].Width = 150;
            gridProdutos.Columns[2].Width = 150;
            gridProdutos.Columns[3].Width = 50;
            gridProdutos.Columns[4].Width = 50;
        }
        private void btnEditarProduto_Click(object sender, EventArgs e)
        {
            ObterDados();
            btnCadastrarProduto.Enabled = false;
            btnSalvarProduto.Enabled = true;
            btnEditarProduto.Enabled = false;
            btnCancelar.Enabled = true;
        }
        /// <summary>
        /// Efetuaa inclusão do produto no banco de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            if (txtNomeProduto.Text == "" || rtxtDescricaoProduto.Text == "" || txtPrecoProduto.Text.Replace("R$", "").Trim().Replace(".", "") == "" || txtEstoqueProduto.Text == "")
            {
                MessageBox.Show("É obrigatório preencher todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    var nome = txtNomeProduto.Text;
                    var descricao = rtxtDescricaoProduto.Text;
                    var preco_produto = Convert.ToDecimal(txtPrecoProduto.Text.Replace("R$", "").Replace(".", ","));
                    var estoque = Convert.ToInt32(txtEstoqueProduto.Text);
                    var Produto = new Produto(nome, descricao, estoque, preco_produto);
                    _produtoServico.NovoProduto(Produto);
                    MessageBox.Show("Produto incluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao Incluir : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LimparCampos();
                ObterProduto();
            }
        }

        private void mtxtPrecoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirNumero(sender, e);
        }

        private void btnExcluirProduto_Click(object sender, EventArgs e)
        {
            //NÃO EXCLUÍ, SOMENTE ATUALIZA O ESTOQUE PARA 0
            try
            {
                DialogResult resultado = MessageBox.Show("Não é possível excluir por completo um produto" +
                                                         "Deseja zerar o estoque desse Produto?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //Metodo para excluir um cliente
                    var id = gridProdutos.CurrentRow.Cells[0].Value.ToString();
                    _produtoServico.EsgotarProduto(Convert.ToInt32(id));
                    MessageBox.Show("Estoque esgotado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Atualiza os dados da minha grid
                    ObterProduto();
                    return;
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao Excluir : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(gridProdutos.CurrentRow.Cells[0].Value);
            try
            {
                //Metodo para editar um cliente                
                var nome = txtNomeProduto.Text;
                var descricao = rtxtDescricaoProduto.Text;
                var preco_produto = Convert.ToDecimal(txtPrecoProduto.Text.Replace("R$", "").Replace(",", "."));
                var produto = new Produto(id, nome, descricao, preco_produto);
                _produtoServico.AtualizarProduto(produto);
                MessageBox.Show("Produto editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos();
                //atualiza os dados da minha grid
                ObterProduto();
                btnCadastrarProduto.Enabled = true;
                btnSalvarProduto.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao Salvar : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    
       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnEditarProduto.Enabled = true;
            btnSalvarProduto.Enabled = false;
        }       
        private void txtEstoqueProduto_Enter(object sender, EventArgs e)
        {
        }

        private void txtPrecoProduto_Leave(object sender, EventArgs e)
        {
            if (txtPrecoProduto.Text.Trim() == "")
            {
                txtPrecoProduto.Text = "R$";
                return;
            }
            else
            {
                return;
            }            
        }

        private void txtEstoqueProduto_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
