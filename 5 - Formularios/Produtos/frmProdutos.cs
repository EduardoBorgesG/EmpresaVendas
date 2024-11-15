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
            mtxtPrecoProduto.Text = gridProdutos.CurrentRow.Cells[3].Value.ToString();
            txtEstoqueProduto.Text = gridProdutos.CurrentRow.Cells[4].Value.ToString();
        }
        private void LimparCampos()
        {
            txtNomeProduto.Clear();
            rtxtDescricaoProduto.Clear();
            mtxtPrecoProduto.Clear();
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
            if (txtNomeProduto.Text == "" || rtxtDescricaoProduto.Text == "" || mtxtPrecoProduto.Text == "" || txtEstoqueProduto == null)
            {
                MessageBox.Show("É obrigatório preencher todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    string formaMoeda = mtxtPrecoProduto.Text.Replace("R$", "");
                    var nome = txtNomeProduto.Text;
                    var descricao = rtxtDescricaoProduto.Text;
                    var preco_produto = Convert.ToDecimal(mtxtPrecoProduto.Text);
                    var estoque = Convert.ToInt32(txtEstoqueProduto.Text);
                    var Produto = new Produto(nome, descricao, estoque, preco_produto);
                    _produtoServico.NovoProduto(Produto);
                    MessageBox.Show("Registro incluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            try
            {
                DialogResult resultado = MessageBox.Show("Deseja excluir esse Produto?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //Metodo para excluir um cliente
                    var id = gridProdutos.CurrentRow.Cells[0].Value.ToString();
                    _produtoServico.ExcluirProduto(id);
                    MessageBox.Show("Produto excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            try
            {
                //Metodo para editar um cliente
                var id = Convert.ToInt32(gridProdutos.CurrentRow.Cells[0].Value);
                var nome = txtNomeProduto.Text;
                var descricao = rtxtDescricaoProduto.Text;
                var preco_produto = Convert.ToDecimal(mtxtPrecoProduto.Text);
                var estoque = Convert.ToInt32(txtEstoqueProduto.Text);
                var produto = new Produto(id, nome, descricao, estoque, preco_produto);
                _produtoServico.AtualizarProduto(produto);
                MessageBox.Show("Produto editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos();
                //atualiza os dados da minha grid
                ObterProduto();
                //btnEditarCliente.Enabled = true;
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
    }
}
