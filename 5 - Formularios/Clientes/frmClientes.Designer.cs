namespace EmpresaVendas.Formularios
{
    partial class frmClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridClientes = new System.Windows.Forms.DataGridView();
            this.btnIncluirCliente = new System.Windows.Forms.Button();
            this.btnEditarCliente = new System.Windows.Forms.Button();
            this.btnExcluirClientes = new System.Windows.Forms.Button();
            this.txtEnderecoCliente = new System.Windows.Forms.TextBox();
            this.lblEnderecoCliente = new System.Windows.Forms.Label();
            this.mtxtCepCliente = new System.Windows.Forms.MaskedTextBox();
            this.lblCepCliente = new System.Windows.Forms.Label();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.lblEmailCliente = new System.Windows.Forms.Label();
            this.mtxtTelefoneCliente = new System.Windows.Forms.MaskedTextBox();
            this.lblTelefoneCliente = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelarEdicao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridClientes
            // 
            this.gridClientes.AccessibleName = "gridClientes";
            this.gridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClientes.Location = new System.Drawing.Point(12, 188);
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.Size = new System.Drawing.Size(757, 336);
            this.gridClientes.TabIndex = 0;
            this.gridClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClientes_CellClick);
            // 
            // btnIncluirCliente
            // 
            this.btnIncluirCliente.Location = new System.Drawing.Point(12, 530);
            this.btnIncluirCliente.Name = "btnIncluirCliente";
            this.btnIncluirCliente.Size = new System.Drawing.Size(118, 49);
            this.btnIncluirCliente.TabIndex = 1;
            this.btnIncluirCliente.Text = "INCLUIR";
            this.btnIncluirCliente.UseVisualStyleBackColor = true;
            this.btnIncluirCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // btnEditarCliente
            // 
            this.btnEditarCliente.Location = new System.Drawing.Point(257, 530);
            this.btnEditarCliente.Name = "btnEditarCliente";
            this.btnEditarCliente.Size = new System.Drawing.Size(118, 49);
            this.btnEditarCliente.TabIndex = 2;
            this.btnEditarCliente.Text = "EDITAR";
            this.btnEditarCliente.UseVisualStyleBackColor = true;
            this.btnEditarCliente.Click += new System.EventHandler(this.btnEditarClientes_Click);
            // 
            // btnExcluirClientes
            // 
            this.btnExcluirClientes.Location = new System.Drawing.Point(650, 530);
            this.btnExcluirClientes.Name = "btnExcluirClientes";
            this.btnExcluirClientes.Size = new System.Drawing.Size(119, 49);
            this.btnExcluirClientes.TabIndex = 3;
            this.btnExcluirClientes.Text = "INATIVAR CLIENTE";
            this.btnExcluirClientes.UseVisualStyleBackColor = true;
            this.btnExcluirClientes.Click += new System.EventHandler(this.btnExcluirClientes_Click);
            // 
            // txtEnderecoCliente
            // 
            this.txtEnderecoCliente.Location = new System.Drawing.Point(269, 134);
            this.txtEnderecoCliente.Name = "txtEnderecoCliente";
            this.txtEnderecoCliente.Size = new System.Drawing.Size(500, 20);
            this.txtEnderecoCliente.TabIndex = 21;
            // 
            // lblEnderecoCliente
            // 
            this.lblEnderecoCliente.AutoSize = true;
            this.lblEnderecoCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnderecoCliente.Location = new System.Drawing.Point(193, 135);
            this.lblEnderecoCliente.Name = "lblEnderecoCliente";
            this.lblEnderecoCliente.Size = new System.Drawing.Size(70, 16);
            this.lblEnderecoCliente.TabIndex = 20;
            this.lblEnderecoCliente.Text = "Endereço: ";
            // 
            // mtxtCepCliente
            // 
            this.mtxtCepCliente.Location = new System.Drawing.Point(100, 134);
            this.mtxtCepCliente.Mask = "00000-999";
            this.mtxtCepCliente.Name = "mtxtCepCliente";
            this.mtxtCepCliente.Size = new System.Drawing.Size(65, 20);
            this.mtxtCepCliente.TabIndex = 19;
            // 
            // lblCepCliente
            // 
            this.lblCepCliente.AutoSize = true;
            this.lblCepCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCepCliente.Location = new System.Drawing.Point(32, 135);
            this.lblCepCliente.Name = "lblCepCliente";
            this.lblCepCliente.Size = new System.Drawing.Size(42, 16);
            this.lblCepCliente.TabIndex = 18;
            this.lblCepCliente.Text = "CEP: ";
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.Location = new System.Drawing.Point(99, 105);
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(496, 20);
            this.txtEmailCliente.TabIndex = 17;
            // 
            // lblEmailCliente
            // 
            this.lblEmailCliente.AutoSize = true;
            this.lblEmailCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailCliente.Location = new System.Drawing.Point(31, 105);
            this.lblEmailCliente.Name = "lblEmailCliente";
            this.lblEmailCliente.Size = new System.Drawing.Size(52, 16);
            this.lblEmailCliente.TabIndex = 16;
            this.lblEmailCliente.Text = "E-mail: ";
            // 
            // mtxtTelefoneCliente
            // 
            this.mtxtTelefoneCliente.Location = new System.Drawing.Point(675, 78);
            this.mtxtTelefoneCliente.Mask = "(99) 00000-0000";
            this.mtxtTelefoneCliente.Name = "mtxtTelefoneCliente";
            this.mtxtTelefoneCliente.Size = new System.Drawing.Size(94, 20);
            this.mtxtTelefoneCliente.TabIndex = 15;
            // 
            // lblTelefoneCliente
            // 
            this.lblTelefoneCliente.AutoSize = true;
            this.lblTelefoneCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefoneCliente.Location = new System.Drawing.Point(607, 78);
            this.lblTelefoneCliente.Name = "lblTelefoneCliente";
            this.lblTelefoneCliente.Size = new System.Drawing.Size(62, 16);
            this.lblTelefoneCliente.TabIndex = 14;
            this.lblTelefoneCliente.Text = "Telefone: ";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(99, 77);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(496, 20);
            this.txtNomeCliente.TabIndex = 13;
            this.txtNomeCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeCliente_KeyPress);
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.Location = new System.Drawing.Point(31, 79);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(49, 16);
            this.lblNomeCliente.TabIndex = 12;
            this.lblNomeCliente.Text = "Nome: ";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(136, 530);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(118, 49);
            this.btnSalvar.TabIndex = 27;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelarEdicao
            // 
            this.btnCancelarEdicao.Location = new System.Drawing.Point(381, 530);
            this.btnCancelarEdicao.Name = "btnCancelarEdicao";
            this.btnCancelarEdicao.Size = new System.Drawing.Size(118, 49);
            this.btnCancelarEdicao.TabIndex = 28;
            this.btnCancelarEdicao.Text = "CANCELAR";
            this.btnCancelarEdicao.UseVisualStyleBackColor = true;
            this.btnCancelarEdicao.Click += new System.EventHandler(this.btnCancelarEdicao_Click);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 591);
            this.Controls.Add(this.btnCancelarEdicao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtEnderecoCliente);
            this.Controls.Add(this.lblEnderecoCliente);
            this.Controls.Add(this.mtxtCepCliente);
            this.Controls.Add(this.lblCepCliente);
            this.Controls.Add(this.txtEmailCliente);
            this.Controls.Add(this.lblEmailCliente);
            this.Controls.Add(this.mtxtTelefoneCliente);
            this.Controls.Add(this.lblTelefoneCliente);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.btnExcluirClientes);
            this.Controls.Add(this.btnEditarCliente);
            this.Controls.Add(this.btnIncluirCliente);
            this.Controls.Add(this.gridClientes);
            this.Name = "frmClientes";
            this.ShowIcon = false;
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridClientes;
        private System.Windows.Forms.Button btnIncluirCliente;
        private System.Windows.Forms.Button btnEditarCliente;
        private System.Windows.Forms.Button btnExcluirClientes;
        private System.Windows.Forms.TextBox txtEnderecoCliente;
        private System.Windows.Forms.Label lblEnderecoCliente;
        private System.Windows.Forms.MaskedTextBox mtxtCepCliente;
        private System.Windows.Forms.Label lblCepCliente;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Label lblEmailCliente;
        private System.Windows.Forms.MaskedTextBox mtxtTelefoneCliente;
        private System.Windows.Forms.Label lblTelefoneCliente;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelarEdicao;
    }
}