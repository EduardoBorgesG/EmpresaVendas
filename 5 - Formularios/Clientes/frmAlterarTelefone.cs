using EmpresaVendas.Formularios;
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
using EmpresaVendas.Classes;

namespace EmpresaVendas._5___Formularios.Clientes
{
    public partial class frmAlterarTelefone : Form
    {
        private readonly IClienteSerico _clienteSerico;
        private readonly Cliente _cliente;

        public frmAlterarTelefone(IClienteSerico clienteSerico, Cliente cliente)
        {
            InitializeComponent();
            _clienteSerico = clienteSerico;
            _cliente = cliente;
            CarregarCampo();
            
        }
        private void CarregarCampo()
        {
            var id = _cliente.Id; 
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CarregarCampo();
        }
    }
}
