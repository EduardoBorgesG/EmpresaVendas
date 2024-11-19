namespace EmpresaVendas.Formularios.Produtos
{
    partial class frmProdutos
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
            this.gridProdutos = new System.Windows.Forms.DataGridView();
            this.btnCadastrarProduto = new System.Windows.Forms.Button();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.btnExcluirProduto = new System.Windows.Forms.Button();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.lblPrecoProduto = new System.Windows.Forms.Label();
            this.lblEstoqueProduto = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.rtxtDescricaoProduto = new System.Windows.Forms.RichTextBox();
            this.txtEstoqueProduto = new System.Windows.Forms.TextBox();
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPrecoProduto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProdutos
            // 
            this.gridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutos.Location = new System.Drawing.Point(6, 210);
            this.gridProdutos.Name = "gridProdutos";
            this.gridProdutos.Size = new System.Drawing.Size(668, 307);
            this.gridProdutos.TabIndex = 0;
            // 
            // btnCadastrarProduto
            // 
            this.btnCadastrarProduto.Location = new System.Drawing.Point(12, 523);
            this.btnCadastrarProduto.Name = "btnCadastrarProduto";
            this.btnCadastrarProduto.Size = new System.Drawing.Size(103, 56);
            this.btnCadastrarProduto.TabIndex = 1;
            this.btnCadastrarProduto.Text = "CADASTRAR";
            this.btnCadastrarProduto.UseVisualStyleBackColor = true;
            this.btnCadastrarProduto.Click += new System.EventHandler(this.btnCadastrarProduto_Click);
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.Location = new System.Drawing.Point(235, 523);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(103, 56);
            this.btnEditarProduto.TabIndex = 2;
            this.btnEditarProduto.Text = "EDITAR";
            this.btnEditarProduto.UseVisualStyleBackColor = true;
            this.btnEditarProduto.Click += new System.EventHandler(this.btnEditarProduto_Click);
            // 
            // btnExcluirProduto
            // 
            this.btnExcluirProduto.Location = new System.Drawing.Point(513, 523);
            this.btnExcluirProduto.Name = "btnExcluirProduto";
            this.btnExcluirProduto.Size = new System.Drawing.Size(161, 56);
            this.btnExcluirProduto.TabIndex = 3;
            this.btnExcluirProduto.Text = "EXCLUIR";
            this.btnExcluirProduto.UseVisualStyleBackColor = true;
            this.btnExcluirProduto.Click += new System.EventHandler(this.btnExcluirProduto_Click);
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblNomeProduto.Location = new System.Drawing.Point(12, 52);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(49, 16);
            this.lblNomeProduto.TabIndex = 4;
            this.lblNomeProduto.Text = "Nome: ";
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblDescricaoProduto.Location = new System.Drawing.Point(12, 90);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(73, 16);
            this.lblDescricaoProduto.TabIndex = 5;
            this.lblDescricaoProduto.Text = "Descrição: ";
            // 
            // lblPrecoProduto
            // 
            this.lblPrecoProduto.AutoSize = true;
            this.lblPrecoProduto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblPrecoProduto.Location = new System.Drawing.Point(433, 52);
            this.lblPrecoProduto.Name = "lblPrecoProduto";
            this.lblPrecoProduto.Size = new System.Drawing.Size(45, 16);
            this.lblPrecoProduto.TabIndex = 6;
            this.lblPrecoProduto.Text = "Preço:";
            // 
            // lblEstoqueProduto
            // 
            this.lblEstoqueProduto.AutoSize = true;
            this.lblEstoqueProduto.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblEstoqueProduto.Location = new System.Drawing.Point(433, 90);
            this.lblEstoqueProduto.Name = "lblEstoqueProduto";
            this.lblEstoqueProduto.Size = new System.Drawing.Size(63, 16);
            this.lblEstoqueProduto.TabIndex = 7;
            this.lblEstoqueProduto.Text = "Estoque: ";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(67, 51);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(330, 20);
            this.txtNomeProduto.TabIndex = 8;
            // 
            // rtxtDescricaoProduto
            // 
            this.rtxtDescricaoProduto.Location = new System.Drawing.Point(91, 90);
            this.rtxtDescricaoProduto.Name = "rtxtDescricaoProduto";
            this.rtxtDescricaoProduto.Size = new System.Drawing.Size(306, 96);
            this.rtxtDescricaoProduto.TabIndex = 9;
            this.rtxtDescricaoProduto.Text = "";
            // 
            // txtEstoqueProduto
            // 
            this.txtEstoqueProduto.Location = new System.Drawing.Point(493, 89);
            this.txtEstoqueProduto.Name = "txtEstoqueProduto";
            this.txtEstoqueProduto.Size = new System.Drawing.Size(69, 20);
            this.txtEstoqueProduto.TabIndex = 11;
            this.txtEstoqueProduto.Enter += new System.EventHandler(this.txtEstoqueProduto_Enter);
            this.txtEstoqueProduto.Leave += new System.EventHandler(this.txtEstoqueProduto_Leave);
            // 
            // btnSalvarProduto
            // 
            this.btnSalvarProduto.Location = new System.Drawing.Point(121, 523);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(103, 56);
            this.btnSalvarProduto.TabIndex = 13;
            this.btnSalvarProduto.Text = "SALVAR";
            this.btnSalvarProduto.UseVisualStyleBackColor = true;
            this.btnSalvarProduto.Click += new System.EventHandler(this.btnSalvarProduto_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(344, 523);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 56);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPrecoProduto
            // 
            this.txtPrecoProduto.Location = new System.Drawing.Point(493, 51);
            this.txtPrecoProduto.Name = "txtPrecoProduto";
            this.txtPrecoProduto.Size = new System.Drawing.Size(69, 20);
            this.txtPrecoProduto.TabIndex = 15;
            this.txtPrecoProduto.Leave += new System.EventHandler(this.txtPrecoProduto_Leave);
            // 
            // frmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 591);
            this.Controls.Add(this.txtPrecoProduto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvarProduto);
            this.Controls.Add(this.txtEstoqueProduto);
            this.Controls.Add(this.rtxtDescricaoProduto);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.lblEstoqueProduto);
            this.Controls.Add(this.lblPrecoProduto);
            this.Controls.Add(this.lblDescricaoProduto);
            this.Controls.Add(this.lblNomeProduto);
            this.Controls.Add(this.btnExcluirProduto);
            this.Controls.Add(this.btnEditarProduto);
            this.Controls.Add(this.btnCadastrarProduto);
            this.Controls.Add(this.gridProdutos);
            this.Name = "frmProdutos";
            this.Text = "Cadastro de Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProdutos;
        private System.Windows.Forms.Button btnCadastrarProduto;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Button btnExcluirProduto;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.Label lblPrecoProduto;
        private System.Windows.Forms.Label lblEstoqueProduto;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.RichTextBox rtxtDescricaoProduto;
        private System.Windows.Forms.TextBox txtEstoqueProduto;
        private System.Windows.Forms.Button btnSalvarProduto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtPrecoProduto;
    }
}