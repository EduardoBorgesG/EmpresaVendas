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
using EmpresaVendas._5___Formularios.Clientes;

namespace EmpresaVendas.Formularios
{
    public partial class frmClientes : Form
    {
        private readonly IClienteSerico _clienteSerico;

        //private List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public frmClientes(IClienteSerico clienteSerico)
        {
            InitializeComponent();
            _clienteSerico = clienteSerico;
            ObterClientes();
            FormatarDg();
            btnCancelarEdicao.Enabled = false;
            btnEditarCliente.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelarEdicao.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        private void ObterClientes()
        {
            var Clientes = _clienteSerico.ObterCliente();
            gridClientes.DataSource = Clientes;
        }
        private void LimparCampos()
        {
            //Metodo para limpar meus campos após salvar
            txtNomeCliente.Clear();
            txtEmailCliente.Clear();
            mtxtCepCliente.Clear();
            mtxtTelefoneCliente.Clear();
            txtEnderecoCliente.Clear();
        }
        public void ObterId()
        {
            //NÃO ESTÁ SENDO USADO
            var id = Convert.ToInt32(gridClientes.CurrentRow.Cells[0].Value);
            var cliente = new Cliente(id);
        }
        private void ObterDados()
        {
            //Coleta os dados da grid e passa para os campos de texto
            txtNomeCliente.Text = gridClientes.CurrentRow.Cells[1].Value.ToString();
            txtEmailCliente.Text = gridClientes.CurrentRow.Cells[2].Value.ToString();
            mtxtTelefoneCliente.Text = gridClientes.CurrentRow.Cells[3].Value.ToString();
            mtxtCepCliente.Text = gridClientes.CurrentRow.Cells[4].Value.ToString();
            txtEnderecoCliente.Text = gridClientes.CurrentRow.Cells[5].Value.ToString();
        }
        private void BloquearCampos()
        {
            txtNomeCliente.Enabled = false;
            txtEmailCliente.Enabled = false;
            mtxtCepCliente.Enabled = false;
            txtEnderecoCliente.Enabled = false;
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


        private void txtNomeCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermiteLetras(sender, e);
        }
        /// <summary>
        /// Metodo para permitir somente letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PermiteLetras(object sender, KeyPressEventArgs e)
        {           
            e.Handled = (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar)) ? true : e.Handled;
        }
        /// <summary>
        /// Código do botão de incluir um novo registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            //IF para verificar se os campos estão vazios
            if (txtNomeCliente.Text == "" || txtEmailCliente.Text == "" || mtxtTelefoneCliente.Text == "(  )      -" || mtxtCepCliente.Text == "     -" || txtEnderecoCliente.Text == "")
            {
                MessageBox.Show("É obrigatório preencher todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {           
                    //METODO DE INCLUSÃO NO BANCO DE DADOS
                    var nome = txtNomeCliente.Text;
                    var email = txtEmailCliente.Text;
                    var telefone = mtxtTelefoneCliente.Text;
                    var cep = mtxtCepCliente.Text;
                    var endereco = txtEnderecoCliente.Text;
                    var Cliente = new Cliente(nome, email, telefone, cep, endereco);
                    _clienteSerico.NovoCliente(Cliente);
                    MessageBox.Show("Registro incluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao Incluir : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
                LimparCampos();
                ObterClientes();
            }
        }
        /// <summary>
        /// Código do botão para editar um registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditarClientes_Click(object sender, EventArgs e)
        {
            ObterDados();
            btnCancelarEdicao.Enabled = true;
            btnSalvar.Enabled = true;
            btnIncluirCliente.Enabled = false;
            btnCancelarEdicao.Enabled = true;
            mtxtTelefoneCliente.Enabled = false;
            btnEditarCliente.Enabled = false;
        }
        private void gridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditarCliente.Enabled = true;
            ObterId();
        }
        private void btnExcluirClientes_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Deseja excluir esse Cliente?", "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //Metodo para excluir um cliente
                    var id = gridClientes.CurrentRow.Cells[0].Value.ToString();
                    _clienteSerico.ExcluirCliente(id);
                    MessageBox.Show("Cliente excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Atualiza os dados da minha grid
                    ObterClientes();
                    return;
                }
                return;
                }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao Excluir : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
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
                MessageBox.Show("Registro editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos();
                //atualiza os dados da minha grid
                ObterClientes();
                btnEditarCliente.Enabled = true;
                mtxtTelefoneCliente.Enabled = true;
                btnSalvar.Enabled = false;
                btnCancelarEdicao.Enabled = false;
            } 
            catch (Exception ex)
            { 
                MessageBox.Show($"Ocorreu um erro ao Salvar : {ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelarEdicao_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnEditarCliente.Enabled = true;
            btnSalvar.Enabled= false;
            btnCancelarEdicao.Enabled= false;
        }

        private void btnAlterarTelefone_Click(object sender, EventArgs e)
        {
            //try 
            //{               
            //    var telefone = mtxtTelefoneCliente.Text;
            //    var id = Convert.ToInt32(gridClientes.CurrentRow.Cells[0].Value);
            //    var cliente = new Cliente(telefone, id);
            //    _clienteSerico.AlterarTelefone(cliente);
            //} 
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            
        }
    }
}
