using EmpresaVendas.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpresaVendas.Classes;
using EmpresaVendas.Conecctions;
using Npgsql;
using Dapper;
using EmpresaVendas.Servicos;

namespace EmpresaVendas.Formularios
{
    public partial class frmClientes : Form
    {
        private readonly IClienteSerico _clienteSerico;
        private List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public frmClientes(IClienteSerico clienteSerico)
        {
            InitializeComponent();
            _clienteSerico = clienteSerico;
            ObterClientes();
            FormatarDg();
            btnEditarCliente.Enabled = false;
            btnSalvar.Visible = false;
        }
        private void ObterClientes()
        {
            var Clientes = _clienteSerico.ObterTodos();
            gridClientes.DataSource = Clientes;
        }
        //private string ObterID()
        //{
        //    var repository = new Cliente().Id;
        //    repository = gridClientes.CurrentRow.Cells[0].Value.ToString();
        //    MessageBox.Show(repository);
        //    return repository;
        //}
        private void ObterDados()
        {
            //Coleta os dados da grid e passa para os campos de texto
            txtNomeCliente.Text = gridClientes.CurrentRow.Cells[1].Value.ToString();
            txtEmailCliente.Text = gridClientes.CurrentRow.Cells[2].Value.ToString();
            mtxtTelefoneCliente.Text = gridClientes.CurrentRow.Cells[3].Value.ToString();
            mtxtCepCliente.Text = gridClientes.CurrentRow.Cells[4].Value.ToString();
            txtEnderecoCliente.Text = gridClientes.CurrentRow.Cells[5].Value.ToString();
        }
        private void FormatarDg()
        {
            //Formata o nome das colunas do DataGrid
            gridClientes.Columns[0].Visible = false;
            gridClientes.Columns[1].HeaderText = "Nome";
            gridClientes.Columns[2].HeaderText = "E-mail";
            gridClientes.Columns[3].HeaderText = "Telefone";
            gridClientes.Columns[4].HeaderText = "CEP";
            gridClientes.Columns[5].HeaderText = "Endereço";

            //Formata a largura da coluna do DataGrid
            gridClientes.Columns[1].Width = 180;
            gridClientes.Columns[2].Width = 180;
            gridClientes.Columns[3].Width = 100;
            gridClientes.Columns[4].Width = 75;
            gridClientes.Columns[5].Width = 180;

        }
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text == "" || txtEmailCliente.Text == "" || mtxtTelefoneCliente.Text == "(  )      -" || mtxtCepCliente.Text == "     -" || txtEnderecoCliente.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos");
                return;
            }
            else
            {
                try
                {

                    var nome = txtNomeCliente.Text;
                    var email = txtEmailCliente.Text;
                    var telefone = mtxtTelefoneCliente.Text;
                    var cep = mtxtCepCliente.Text;
                    var endereco = txtEnderecoCliente.Text;
                    var Cliente = new Cliente(nome, email, telefone, cep, endereco);
                    _clienteSerico.NovoCliente(Cliente);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void btnEditarClientes_Click(object sender, EventArgs e)
        {
            ObterDados();
            btnSalvar.Visible = true;
            btnIncluirCliente.Visible = false;
        }

        private void gridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditarCliente.Enabled = true;
            
        }

        //private void btnSalvar_Click(object sender, EventArgs e)
        //{
        //    
        //}

        private void btnExcluirClientes_Click(object sender, EventArgs e)
        {
            try
            {
                //Metodo para excluir um cliente
                var id = gridClientes.CurrentRow.Cells[0].Value.ToString();
                _clienteSerico.ExcluirCliente(id);
                //Atualiza os dados da minha grid
                //ObterClientes();
            }
            catch (Exception ex )
            {
                throw ex;
            }
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Metodo para editar um cliente
            var id = Convert.ToInt32(gridClientes.CurrentRow.Cells[0].Value);
            var nome = txtNomeCliente.Text;
            var email = txtEmailCliente.Text;
            var telefone = mtxtTelefoneCliente.Text;
            var cep = mtxtCepCliente.Text;
            var endereco = txtEnderecoCliente.Text;
            var cliente = new Cliente(id, nome, email, telefone, cep, endereco);
            _clienteSerico.AtualizarCliente(cliente);
            //atualiza os dados da minha grid
            ObterClientes();
        }
    }
}
