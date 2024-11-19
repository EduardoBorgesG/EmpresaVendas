namespace EmpresaVendas._5___Formularios.Vendas
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
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gridVisualizacaoProdutos = new System.Windows.Forms.DataGridView();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorASerPago = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridVisualizacaoProdutos)).BeginInit();
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
            this.cbListaClientes.Items.AddRange(new object[] {
            "teste1",
            "teste2",
            "teste3"});
            this.cbListaClientes.Location = new System.Drawing.Point(63, 24);
            this.cbListaClientes.Name = "cbListaClientes";
            this.cbListaClientes.Size = new System.Drawing.Size(272, 21);
            this.cbListaClientes.TabIndex = 1;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(12, 60);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(50, 13);
            this.lblProduto.TabIndex = 2;
            this.lblProduto.Text = "Produto: ";
            // 
            // cbListaProduto
            // 
            this.cbListaProduto.FormattingEnabled = true;
            this.cbListaProduto.Location = new System.Drawing.Point(63, 57);
            this.cbListaProduto.Name = "cbListaProduto";
            this.cbListaProduto.Size = new System.Drawing.Size(272, 21);
            this.cbListaProduto.TabIndex = 3;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(341, 60);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(68, 13);
            this.lblQuantidade.TabIndex = 5;
            this.lblQuantidade.Text = "Quantidade: ";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(415, 57);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(58, 20);
            this.txtQuantidade.TabIndex = 6;
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPagamento.Location = new System.Drawing.Point(605, 21);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(172, 19);
            this.lblFormaPagamento.TabIndex = 11;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Location = new System.Drawing.Point(12, 373);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(131, 52);
            this.btnFinalizarVenda.TabIndex = 20;
            this.btnFinalizarVenda.Text = "FINALIZAR VENDA";
            this.btnFinalizarVenda.UseVisualStyleBackColor = true;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(675, 379);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 52);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // gridVisualizacaoProdutos
            // 
            this.gridVisualizacaoProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVisualizacaoProdutos.Location = new System.Drawing.Point(15, 114);
            this.gridVisualizacaoProdutos.Name = "gridVisualizacaoProdutos";
            this.gridVisualizacaoProdutos.Size = new System.Drawing.Size(518, 204);
            this.gridVisualizacaoProdutos.TabIndex = 22;
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(482, 55);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(51, 23);
            this.btnAdicionarProduto.TabIndex = 23;
            this.btnAdicionarProduto.Text = "+";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(606, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Valor a ser pago: ";
            // 
            // txtValorASerPago
            // 
            this.txtValorASerPago.Enabled = false;
            this.txtValorASerPago.Location = new System.Drawing.Point(692, 57);
            this.txtValorASerPago.Name = "txtValorASerPago";
            this.txtValorASerPago.Size = new System.Drawing.Size(85, 20);
            this.txtValorASerPago.TabIndex = 26;
            // 
            // frmVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 448);
            this.Controls.Add(this.txtValorASerPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.gridVisualizacaoProdutos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.cbListaProduto);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.cbListaClientes);
            this.Controls.Add(this.lblCliente);
            this.Name = "frmVenda";
            this.Text = "Cadastrar uma Venda";
            ((System.ComponentModel.ISupportInitialize)(this.gridVisualizacaoProdutos)).EndInit();
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
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView gridVisualizacaoProdutos;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValorASerPago;
    }
}