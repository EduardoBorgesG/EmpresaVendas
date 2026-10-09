using EmpresaVendas._1___Classes;
using EmpresaVendas._1___Classes.Excecoes;
using EmpresaVendas._4___Servicos;
using EmpresaVendas._5___Formularios.Erros;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;


namespace EmpresaVendas.Formularios.Produtos
{
    public partial class frmProdutos : Form
    {
        private readonly IProdutoServico _produtoServico;
        private readonly ITratadorErros _tratadorErros;
        private List<Produto> Produto { get; set; } = new List<Produto>();
        private static readonly CultureInfo CulturaBR = new CultureInfo("pt-BR");
        //Id do produto que está sendo editado (guardado ao clicar em Editar)
        private int _idProdutoEmEdicao;
        public frmProdutos(IProdutoServico produtoServico, ITratadorErros tratadorErros)
        {
            InitializeComponent();
            _produtoServico = produtoServico;
            _tratadorErros = tratadorErros;
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
        /// Converte o texto do campo de preço ("R$ 1.234,56", "12,50" ou "12.50") em decimal,
        /// sem depender da cultura configurada no Windows
        /// </summary>
        private static decimal ConverterPreco(string texto)
        {
            string valor = texto.Replace("R$", "").Trim();
            //Com vírgula: formato brasileiro (ponto = milhar, vírgula = decimal)
            //Sem vírgula: o ponto, se existir, é tratado como separador decimal
            CultureInfo cultura = valor.Contains(",") ? CulturaBR : CultureInfo.InvariantCulture;
            if (!decimal.TryParse(valor, NumberStyles.Number, cultura, out decimal preco) || preco < 0)
            {
                throw new RegraNegocioException("Preço do produto inválido");
            }
            return preco;
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
            decimal preco = Convert.ToDecimal(gridProdutos.CurrentRow.Cells[3].Value);
            txtPrecoProduto.Text = "R$ " + preco.ToString("N2", CulturaBR);
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
            if (gridProdutos.CurrentRow == null) return;
            _idProdutoEmEdicao = Convert.ToInt32(gridProdutos.CurrentRow.Cells[0].Value);
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
                    var preco_produto = ConverterPreco(txtPrecoProduto.Text);
                    var estoque = Convert.ToInt32(txtEstoqueProduto.Text);
                    var Produto = new Produto(nome, descricao, estoque, preco_produto);
                    _produtoServico.NovoProduto(Produto);
                    MessageBox.Show("Produto incluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Só limpa os campos se deu certo, para o usuário poder corrigir em caso de erro
                    LimparCampos();
                    ObterProduto();
                }
                catch (Exception ex)
                {
                    _tratadorErros.Tratar($"Ocorreu um erro ao Incluir : ", ex);
                }
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
                 _tratadorErros.Tratar($"Ocorreu um erro ao Excluir : ", ex);
            }
        }

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            //Usa o id guardado no Editar, e não a linha selecionada agora (que pode ter mudado)
            var id = _idProdutoEmEdicao;
            try
            {
                //Metodo para editar um produto
                var nome = txtNomeProduto.Text;
                var descricao = rtxtDescricaoProduto.Text;
                var preco_produto = ConverterPreco(txtPrecoProduto.Text);
                var estoque = Convert.ToInt32(txtEstoqueProduto.Text);
                var produto = new Produto(id, nome, descricao, preco_produto, estoque);
                _produtoServico.AtualizarProduto(produto);
                MessageBox.Show("Produto editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos();
                //atualiza os dados da minha grid
                ObterProduto();
                btnCadastrarProduto.Enabled = true;
                btnSalvarProduto.Enabled = false;
                btnEditarProduto.Enabled = true;
                btnCancelar.Enabled = false;
            }
            catch (Exception ex)
            {
                _tratadorErros.Tratar($"Ocorreu um erro ao Salvar : ", ex);
            }

        }
    
       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnEditarProduto.Enabled = true;
            btnSalvarProduto.Enabled = false;
            btnCadastrarProduto.Enabled = true;
            btnCancelar.Enabled = false;
        }
        private void txtEstoqueProduto_Enter(object sender, EventArgs e)
        {
        }

        private void txtPrecoProduto_Leave(object sender, EventArgs e)
        {
            if (txtPrecoProduto.Text.Trim() == "")
            {
                txtPrecoProduto.Text = "R$ ";
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
