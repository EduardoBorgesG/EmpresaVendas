namespace EmpresaVendas._5___Formularios.Produtos
{
    partial class frmAtivarProdutos
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
            this.gridProdutosInativos = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAtivarProduto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutosInativos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProdutosInativos
            // 
            this.gridProdutosInativos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutosInativos.Location = new System.Drawing.Point(17, 78);
            this.gridProdutosInativos.Name = "gridProdutosInativos";
            this.gridProdutosInativos.Size = new System.Drawing.Size(272, 223);
            this.gridProdutosInativos.TabIndex = 0;
            this.gridProdutosInativos.Click += new System.EventHandler(this.gridProdutosInativos_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(331, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Qual Produto deseja ativar?";
            // 
            // btnAtivarProduto
            // 
            this.btnAtivarProduto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivarProduto.Location = new System.Drawing.Point(346, 138);
            this.btnAtivarProduto.Name = "btnAtivarProduto";
            this.btnAtivarProduto.Size = new System.Drawing.Size(124, 70);
            this.btnAtivarProduto.TabIndex = 2;
            this.btnAtivarProduto.Text = "ATIVAR PRODUTO";
            this.btnAtivarProduto.UseVisualStyleBackColor = true;
            this.btnAtivarProduto.Click += new System.EventHandler(this.btnAtivarProduto_Click);
            // 
            // frmAtivarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 326);
            this.Controls.Add(this.btnAtivarProduto);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gridProdutosInativos);
            this.Name = "frmAtivarProdutos";
            this.Text = "frmAtivarProdutos";
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutosInativos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProdutosInativos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAtivarProduto;
    }
}