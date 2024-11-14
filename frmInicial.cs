using EmpresaVendas.Formularios;
using EmpresaVendas.Formularios.Produtos;
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
using EmpresaVendas.Servicos;
using EmpresaVendas._4___Servicos;
using EmpresaVendas._5___Formularios.Venda;


namespace EmpresaVendas
{
    public partial class frmInicial : Form
    {
        private readonly IClienteSerico _clienteSerico;
        private readonly IProdutoServico _produtoServico;

        public frmInicial(IClienteSerico clienteSerico, IProdutoServico produtoServico)
        {
            InitializeComponent();
            _clienteSerico = clienteSerico;
            _produtoServico = produtoServico;
            
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos frm = new frmProdutos(_produtoServico);
            frm.Show();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var conn = new DbConnection();
        //        conn.Dispose();
        //        MessageBox.Show("Conexão sucesso");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ocrreu um erro {ex}");

        //    }
        //}

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes(_clienteSerico);
            frm.Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenda frm = new frmVenda();
            frm.Show();
        }
    }
}
