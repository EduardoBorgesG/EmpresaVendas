namespace EmpresaVendas.Formularios.Produtos
{
    partial class frmIncluirProdutos
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
            this.lblCadastrarProduto = new System.Windows.Forms.Label();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblPrecoProduto = new System.Windows.Forms.Label();
            this.lblEstoqueProduto = new System.Windows.Forms.Label();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.txtPrecoProduto = new System.Windows.Forms.TextBox();
            this.txtEstoqueProduto = new System.Windows.Forms.TextBox();
            this.txtDescricaoProduto = new System.Windows.Forms.RichTextBox();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCadastrarProduto
            // 
            this.lblCadastrarProduto.AutoSize = true;
            this.lblCadastrarProduto.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastrarProduto.Location = new System.Drawing.Point(12, 9);
            this.lblCadastrarProduto.Name = "lblCadastrarProduto";
            this.lblCadastrarProduto.Size = new System.Drawing.Size(288, 38);
            this.lblCadastrarProduto.TabIndex = 0;
            this.lblCadastrarProduto.Text = "Cadastrar Produto";
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeProduto.Location = new System.Drawing.Point(16, 63);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(49, 16);
            this.lblNomeProduto.TabIndex = 1;
            this.lblNomeProduto.Text = "Nome: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 20);
            this.textBox1.TabIndex = 2;
            // 
            // lblPrecoProduto
            // 
            this.lblPrecoProduto.AutoSize = true;
            this.lblPrecoProduto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoProduto.Location = new System.Drawing.Point(16, 96);
            this.lblPrecoProduto.Name = "lblPrecoProduto";
            this.lblPrecoProduto.Size = new System.Drawing.Size(49, 16);
            this.lblPrecoProduto.TabIndex = 3;
            this.lblPrecoProduto.Text = "Preço: ";
            // 
            // lblEstoqueProduto
            // 
            this.lblEstoqueProduto.AutoSize = true;
            this.lblEstoqueProduto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstoqueProduto.Location = new System.Drawing.Point(185, 97);
            this.lblEstoqueProduto.Name = "lblEstoqueProduto";
            this.lblEstoqueProduto.Size = new System.Drawing.Size(63, 16);
            this.lblEstoqueProduto.TabIndex = 4;
            this.lblEstoqueProduto.Text = "Estoque: ";
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoProduto.Location = new System.Drawing.Point(16, 145);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(73, 16);
            this.lblDescricaoProduto.TabIndex = 5;
            this.lblDescricaoProduto.Text = "Descrição: ";
            // 
            // txtPrecoProduto
            // 
            this.txtPrecoProduto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecoProduto.Location = new System.Drawing.Point(71, 95);
            this.txtPrecoProduto.Name = "txtPrecoProduto";
            this.txtPrecoProduto.Size = new System.Drawing.Size(47, 21);
            this.txtPrecoProduto.TabIndex = 6;
            this.txtPrecoProduto.Text = "00,00";
            // 
            // txtEstoqueProduto
            // 
            this.txtEstoqueProduto.Location = new System.Drawing.Point(267, 95);
            this.txtEstoqueProduto.Name = "txtEstoqueProduto";
            this.txtEstoqueProduto.Size = new System.Drawing.Size(33, 20);
            this.txtEstoqueProduto.TabIndex = 7;
            this.txtEstoqueProduto.Text = "0";
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.AccessibleDescription = "";
            this.txtDescricaoProduto.Location = new System.Drawing.Point(95, 144);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(205, 87);
            this.txtDescricaoProduto.TabIndex = 9;
            this.txtDescricaoProduto.Text = "";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.Location = new System.Drawing.Point(95, 268);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(136, 42);
            this.btnIncluir.TabIndex = 10;
            this.btnIncluir.Text = "INCLUIR";
            this.btnIncluir.UseVisualStyleBackColor = true;
            // 
            // frmIncluirProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 322);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.txtDescricaoProduto);
            this.Controls.Add(this.txtEstoqueProduto);
            this.Controls.Add(this.txtPrecoProduto);
            this.Controls.Add(this.lblDescricaoProduto);
            this.Controls.Add(this.lblEstoqueProduto);
            this.Controls.Add(this.lblPrecoProduto);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblNomeProduto);
            this.Controls.Add(this.lblCadastrarProduto);
            this.Name = "frmIncluirProdutos";
            this.Text = "Cadastro de Produto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCadastrarProduto;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblPrecoProduto;
        private System.Windows.Forms.Label lblEstoqueProduto;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.TextBox txtPrecoProduto;
        private System.Windows.Forms.TextBox txtEstoqueProduto;
        private System.Windows.Forms.RichTextBox txtDescricaoProduto;
        private System.Windows.Forms.Button btnIncluir;
    }
}