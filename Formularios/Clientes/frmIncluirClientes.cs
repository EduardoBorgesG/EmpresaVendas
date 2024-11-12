using EmpresaVendas.Classes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaVendas.Formularios.Clientes
{   
    public partial class frmIncluirClientes : Form
    {
        public frmIncluirClientes()
        {
            InitializeComponent();
        }
        private void btnIncluirCliente_Click(object sender, EventArgs e)
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
                    Cliente.CadastrarCliente(Cliente);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }           

        }
    }
    
}
