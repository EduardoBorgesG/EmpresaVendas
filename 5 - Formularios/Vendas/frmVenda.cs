using EmpresaVendas._1___Classes;
using EmpresaVendas._4___Servicos;
using EmpresaVendas.Servicos;
using Npgsql;
using NPOI.POIFS.NIO;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmpresaVendas._5___Formularios.Vendas
{
    public partial class frmVenda : Form
    {
        private readonly IVendaServico _vendaServico;
        private readonly IClienteSerico _clienteSerico;
        private readonly IProdutoServico _produtoServico;
        private static readonly CultureInfo CulturaBR = new CultureInfo("pt-BR");
        List<VendaItemDTO> vendas = new List<VendaItemDTO>();


        public frmVenda(IVendaServico vendaServico, IClienteSerico clienteSerico, IProdutoServico produtoServico)
        {
            InitializeComponent();
            txtValorASerPago.Text = "R$";
            _produtoServico = produtoServico;
            _clienteSerico = clienteSerico;
            _vendaServico = vendaServico;
            ListarCliente();
            ListarProdutos();
            btnFinalizarVenda.Enabled = false;

        }
        //Metodo para alimentar minha lista
        private void ListarCliente()
        {
            try
            {

                var Cliente = _clienteSerico.ObterClientesAtivos();
                cbListaClientes.DataSource = Cliente;
                cbListaClientes.ValueMember = "id";
                cbListaClientes.DisplayMember = "nome";
                cbListaClientes.SelectedValue = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar os clientes : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListarProdutos()
        {
            try
            {
                var Produto = _produtoServico.ObterProduto();
                cbListaProduto.DataSource = Produto;
                cbListaProduto.ValueMember = "id";
                cbListaProduto.DisplayMember = "nome";
                cbListaProduto.SelectedValue = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar os produtos : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimparCampos()
        {
            //Esvazia o carrinho para a próxima venda não reaproveitar itens da anterior
            vendas.Clear();
            gridVisualizacaoProdutos.DataSource = null;
            txtValorASerPago.Text = "R$";
            cbListaClientes.Text = string.Empty;
            cbListaProduto.Text = string.Empty;
            txtQuantidade.Clear();
            cbListaClientes.Enabled = true;
            btnFinalizarVenda.Enabled = false;
        }
        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                int cliente_id = Convert.ToInt32(cbListaClientes.SelectedValue);
                //O valor é calculado a partir dos itens (preços vindos do banco), e não lido do TextBox
                var venda = new Venda(cliente_id, CalcularTotal());
                var itens = vendas.Select(v => new VendaItens(v.produto_id, v.quantidade, 0)).ToList();
                //Grava venda + itens + baixa de estoque em uma única transação
                _vendaServico.FinalizarVenda(venda, itens);
                MessageBox.Show("Venda Incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos();
                //Recarrega os produtos para refletir o estoque atualizado
                ListarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao finalizar a venda : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private decimal CalcularTotal()
        {
            return vendas.Sum(v => v.preco_produto * v.quantidade);
        }
        private void FormatarDG()
        {
            gridVisualizacaoProdutos.Columns["nome_produto"].HeaderText = "Produto";
            gridVisualizacaoProdutos.Columns["preco_produto"].HeaderText = "Preço do Produto";
            gridVisualizacaoProdutos.Columns["quantidade"].HeaderText = "Quantidade";
        }
        /// <summary>
        /// Lê a quantidade digitada. Retorna false (e avisa o usuário) se estiver vazia ou inválida
        /// </summary>
        private bool ObterQuantidade(out int quantidade)
        {
            if (!int.TryParse(txtQuantidade.Text, out quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Verifica se há estoque para a quantidade pedida, somando o que já está no carrinho para o mesmo produto
        /// </summary>
        private bool VerificaEstoque(int produto_id, int quantidade)
        {
            int estoque = Convert.ToInt32(_produtoServico.VerificaEstoque(produto_id));
            int jaNoCarrinho = vendas.Where(v => v.produto_id == produto_id).Sum(v => v.quantidade);
            if (estoque < jaNoCarrinho + quantidade)
            {
                MessageBox.Show($"Sem Estoque. Disponível: {estoque - jaNoCarrinho}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Clear();
                txtQuantidade.Focus();
                return false;
            }
            return true;
        }
        private void AtualizarTotal()
        {
            txtValorASerPago.Text = CalcularTotal().ToString("C", CulturaBR);
        }
        private void AlimentarDG(int produto_id, int quantidade)
        {
            var p = _produtoServico.ColetaDadosProduto(produto_id);
            decimal preco_produto = p.Select(v => v.Preco_produto).FirstOrDefault();
            string nome = cbListaProduto.Text;
            vendas.Add(new VendaItemDTO(produto_id, nome, preco_produto, quantidade));

            //Desvincula e vincula de novo para a grid enxergar os itens adicionados na lista
            gridVisualizacaoProdutos.DataSource = null;
            gridVisualizacaoProdutos.DataSource = vendas;
            FormatarDG();
        }
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ObterQuantidade(out int quantidade)) return;
                int produto_id = Convert.ToInt32(cbListaProduto.SelectedValue);
                //A verificação de estoque agora BLOQUEIA a inclusão, em vez de só avisar
                if (!VerificaEstoque(produto_id, quantidade)) return;

                AlimentarDG(produto_id, quantidade);
                AtualizarTotal();
                cbListaClientes.Enabled = false;
                btnFinalizarVenda.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao adicionar o produto : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            //Aviso antecipado ao sair do campo; a verificação definitiva ocorre no botão Adicionar
            if (!int.TryParse(txtQuantidade.Text, out int quantidade)) return;
            try
            {
                VerificaEstoque(Convert.ToInt32(cbListaProduto.SelectedValue), quantidade);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao verificar o estoque : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
