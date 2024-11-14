namespace EmpresaVendas._5___Formularios.Venda
{
    partial class frmVenda
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbListaClientes = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.cbListaProduto = new System.Windows.Forms.ComboBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblValorUnidade = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtValorUnidade = new System.Windows.Forms.TextBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 27);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(45, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente: ";
            // 
            // cbListaClientes
            // 
            this.cbListaClientes.FormattingEnabled = true;
            this.cbListaClientes.Location = new System.Drawing.Point(63, 24);
            this.cbListaClientes.Name = "cbListaClientes";
            this.cbListaClientes.Size = new System.Drawing.Size(239, 21);
            this.cbListaClientes.TabIndex = 1;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(12, 64);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(50, 13);
            this.lblProduto.TabIndex = 2;
            this.lblProduto.Text = "Produto: ";
            // 
            // cbListaProduto
            // 
            this.cbListaProduto.FormattingEnabled = true;
            this.cbListaProduto.Location = new System.Drawing.Point(63, 61);
            this.cbListaProduto.Name = "cbListaProduto";
            this.cbListaProduto.Size = new System.Drawing.Size(239, 21);
            this.cbListaProduto.TabIndex = 3;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(319, 27);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(68, 13);
            this.lblQuantidade.TabIndex = 5;
            this.lblQuantidade.Text = "Quantidade: ";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(393, 24);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(58, 20);
            this.txtQuantidade.TabIndex = 6;
            // 
            // lblValorUnidade
            // 
            this.lblValorUnidade.AutoSize = true;
            this.lblValorUnidade.Location = new System.Drawing.Point(517, 27);
            this.lblValorUnidade.Name = "lblValorUnidade";
            this.lblValorUnidade.Size = new System.Drawing.Size(96, 13);
            this.lblValorUnidade.TabIndex = 7;
            this.lblValorUnidade.Text = "Valor por unidade: ";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(517, 64);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(61, 13);
            this.lblValorTotal.TabIndex = 8;
            this.lblValorTotal.Text = "Valor Total:";
            // 
            // txtValorUnidade
            // 
            this.txtValorUnidade.Location = new System.Drawing.Point(619, 24);
            this.txtValorUnidade.Name = "txtValorUnidade";
            this.txtValorUnidade.Size = new System.Drawing.Size(106, 20);
            this.txtValorUnidade.TabIndex = 9;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(619, 61);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(106, 20);
            this.txtValorTotal.TabIndex = 10;
            // 
            // frmVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 426);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.txtValorUnidade);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblValorUnidade);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.cbListaProduto);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.cbListaClientes);
            this.Controls.Add(this.lblCliente);
            this.Name = "frmVenda";
            this.Text = "frmVenda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbListaClientes;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.ComboBox cbListaProduto;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblValorUnidade;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.TextBox txtValorUnidade;
        private System.Windows.Forms.TextBox txtValorTotal;
    }
}