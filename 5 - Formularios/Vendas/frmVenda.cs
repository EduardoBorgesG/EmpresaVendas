﻿using EmpresaVendas._1___Classes;
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
                throw ex;
            }
            ;
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
                throw ex;
            }

        }
     
        private void LimparCampos()
        {
            MessageBox.Show("Venda Incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtValorASerPago.Clear();
            txtValorASerPago.Text = "R$";
            cbListaClientes.Text = string.Empty;
            cbListaProduto.Text = string.Empty;
            txtQuantidade.Clear();
            cbListaClientes.Enabled = true;
            gridVisualizacaoProdutos.Columns.Clear();
        }
        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            int id = IncluirVenda();
            InserirVendaItensDb(id);
            LimparCampos();
        }        
        private int IncluirVenda()
        {
            try
            {
                int cliente_id = Convert.ToInt32(cbListaClientes.SelectedValue);
                decimal valor_pago = Convert.ToDecimal(txtValorASerPago.Text.Replace("R$",""));
                var Venda = new Venda(cliente_id, valor_pago);
                var result = _vendaServico.NovaVenda(Venda);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        private void FormatarDG()
        {
            gridVisualizacaoProdutos.Columns["nome_produto"].HeaderText = "Produto";
            gridVisualizacaoProdutos.Columns["preco_produto"].HeaderText = "Preço do Produto";
            gridVisualizacaoProdutos.Columns["quantidade"].HeaderText = "Quantidade";
        }
        private void VerificaEstoque()
        {
            var id = Convert.ToInt32(cbListaProduto.SelectedValue);
            object resultado = _produtoServico.VerificaEstoque(id);
            if (Convert.ToInt32(resultado) < Convert.ToInt32(txtQuantidade.Text))
            {
                MessageBox.Show("Sem Estoque");
                txtQuantidade.Clear();
                txtQuantidade.Focus();
                return;
            }           
        }
        private void AtualizarPreco()
       {                
                var id = Convert.ToInt32(cbListaProduto.SelectedValue);
                decimal resultado = _vendaServico.AtualizaPreco(id);
                decimal valorTotal = resultado * Convert.ToInt32(txtQuantidade.Text);
                if (txtValorASerPago.Text == "R$")
                {
                    txtValorASerPago.Text = valorTotal.ToString("C");
                    return;
                }
                else
                {
                    decimal x = Convert.ToDecimal(txtValorASerPago.Text.Replace("R$","").Replace(".",","));
                    decimal y = x + valorTotal;
                    txtValorASerPago.Text = y.ToString("C");
                    return;
                }                               
                
        }
        private void AlimentarDG()
        {
            try
            {
                
                var id = Convert.ToInt32(cbListaProduto.SelectedValue);
                var p = _produtoServico.ColetaDadosProduto(id);
                int quantidade = Convert.ToInt32(txtQuantidade.Text);
                var preco = p.Select(v => v.Preco_produto).ToList();
                gridVisualizacaoProdutos.DataSource = preco;


                string nome = cbListaProduto.Text;
                int produto_id = Convert.ToInt32(cbListaProduto.SelectedValue);
                int quantidade_venda = Convert.ToInt32(txtQuantidade.Text);
                decimal preco_produto = Convert.ToDecimal(preco.FirstOrDefault());
                vendas.Add(new VendaItemDTO(produto_id, nome, preco_produto, quantidade_venda));
                gridVisualizacaoProdutos.DataSource = vendas;
                FormatarDG();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            


        }
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            AlimentarDG();
            AtualizarPreco();
            cbListaClientes.Enabled = false;
            btnFinalizarVenda.Enabled = true;
        }
        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            VerificaEstoque();
        }
        private void InserirVendaItensDb(int id)
        {
            foreach (DataGridViewRow row in gridVisualizacaoProdutos.Rows)
            {
                int produto_id = Convert.ToInt32(row.Cells["produto_id"].Value);
                int quantidade = Convert.ToInt32(row.Cells["quantidade"].Value);               
                var VendaItem = new VendaItens(produto_id, quantidade, id);
                _vendaServico.InserirDetalhes(VendaItem);
            }                       
        }
        
    }
}
