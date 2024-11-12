namespace EmpresaVendas.Formularios.Clientes
{
    partial class frmIncluirClientes
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.lblTelefoneCliente = new System.Windows.Forms.Label();
            this.mtxtTelefoneCliente = new System.Windows.Forms.MaskedTextBox();
            this.lblEmailCliente = new System.Windows.Forms.Label();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.lblCepCliente = new System.Windows.Forms.Label();
            this.mtxtCepCliente = new System.Windows.Forms.MaskedTextBox();
            this.lblEnderecoCliente = new System.Windows.Forms.Label();
            this.txtEnderecoCliente = new System.Windows.Forms.TextBox();
            this.btnIncluirCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(288, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cadastro de Clientes";
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.Location = new System.Drawing.Point(24, 87);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(49, 16);
            this.lblNomeCliente.TabIndex = 1;
            this.lblNomeCliente.Text = "Nome: ";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(92, 86);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(240, 20);
            this.txtNomeCliente.TabIndex = 2;
            // 
            // lblTelefoneCliente
            // 
            this.lblTelefoneCliente.AutoSize = true;
            this.lblTelefoneCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefoneCliente.Location = new System.Drawing.Point(24, 52);
            this.lblTelefoneCliente.Name = "lblTelefoneCliente";
            this.lblTelefoneCliente.Size = new System.Drawing.Size(62, 16);
            this.lblTelefoneCliente.TabIndex = 3;
            this.lblTelefoneCliente.Text = "Telefone: ";
            // 
            // mtxtTelefoneCliente
            // 
            this.mtxtTelefoneCliente.Location = new System.Drawing.Point(92, 52);
            this.mtxtTelefoneCliente.Mask = "(99) 00000-0000";
            this.mtxtTelefoneCliente.Name = "mtxtTelefoneCliente";
            this.mtxtTelefoneCliente.Size = new System.Drawing.Size(89, 20);
            this.mtxtTelefoneCliente.TabIndex = 4;
            // 
            // lblEmailCliente
            // 
            this.lblEmailCliente.AutoSize = true;
            this.lblEmailCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailCliente.Location = new System.Drawing.Point(24, 125);
            this.lblEmailCliente.Name = "lblEmailCliente";
            this.lblEmailCliente.Size = new System.Drawing.Size(52, 16);
            this.lblEmailCliente.TabIndex = 5;
            this.lblEmailCliente.Text = "E-mail: ";
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.Location = new System.Drawing.Point(92, 124);
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(240, 20);
            this.txtEmailCliente.TabIndex = 6;
            // 
            // lblCepCliente
            // 
            this.lblCepCliente.AutoSize = true;
            this.lblCepCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCepCliente.Location = new System.Drawing.Point(24, 178);
            this.lblCepCliente.Name = "lblCepCliente";
            this.lblCepCliente.Size = new System.Drawing.Size(42, 16);
            this.lblCepCliente.TabIndex = 7;
            this.lblCepCliente.Text = "CEP: ";
            // 
            // mtxtCepCliente
            // 
            this.mtxtCepCliente.Location = new System.Drawing.Point(92, 177);
            this.mtxtCepCliente.Mask = "00000-999";
            this.mtxtCepCliente.Name = "mtxtCepCliente";
            this.mtxtCepCliente.Size = new System.Drawing.Size(65, 20);
            this.mtxtCepCliente.TabIndex = 8;
            // 
            // lblEnderecoCliente
            // 
            this.lblEnderecoCliente.AutoSize = true;
            this.lblEnderecoCliente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnderecoCliente.Location = new System.Drawing.Point(24, 215);
            this.lblEnderecoCliente.Name = "lblEnderecoCliente";
            this.lblEnderecoCliente.Size = new System.Drawing.Size(70, 16);
            this.lblEnderecoCliente.TabIndex = 9;
            this.lblEnderecoCliente.Text = "Endereço: ";
            // 
            // txtEnderecoCliente
            // 
            this.txtEnderecoCliente.Location = new System.Drawing.Point(100, 214);
            this.txtEnderecoCliente.Name = "txtEnderecoCliente";
            this.txtEnderecoCliente.Size = new System.Drawing.Size(232, 20);
            this.txtEnderecoCliente.TabIndex = 10;
            // 
            // btnIncluirCliente
            // 
            this.btnIncluirCliente.Location = new System.Drawing.Point(111, 258);
            this.btnIncluirCliente.Name = "btnIncluirCliente";
            this.btnIncluirCliente.Size = new System.Drawing.Size(131, 52);
            this.btnIncluirCliente.TabIndex = 11;
            this.btnIncluirCliente.Text = "INCLUIR";
            this.btnIncluirCliente.UseVisualStyleBackColor = true;
            this.btnIncluirCliente.Click += new System.EventHandler(this.btnIncluirCliente_Click);
            // 
            // frmIncluirClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 322);
            this.Controls.Add(this.btnIncluirCliente);
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
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmIncluirClientes";
            this.Text = "Novo Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label lblTelefoneCliente;
        private System.Windows.Forms.MaskedTextBox mtxtTelefoneCliente;
        private System.Windows.Forms.Label lblEmailCliente;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Label lblCepCliente;
        private System.Windows.Forms.MaskedTextBox mtxtCepCliente;
        private System.Windows.Forms.Label lblEnderecoCliente;
        private System.Windows.Forms.TextBox txtEnderecoCliente;
        private System.Windows.Forms.Button btnIncluirCliente;
    }
}