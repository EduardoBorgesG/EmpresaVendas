namespace EmpresaVendas
{
    partial class frmInicial
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioVendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosInativosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesInativosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.produtosInativosToolStripMenuItem,
            this.clientesInativosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.vendasToolStripMenuItem.Text = "Vendas";
            this.vendasToolStripMenuItem.Click += new System.EventHandler(this.vendasToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatórioClientesToolStripMenuItem,
            this.relatórioProdutosToolStripMenuItem,
            this.relatórioVendasToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // relatórioClientesToolStripMenuItem
            // 
            this.relatórioClientesToolStripMenuItem.Name = "relatórioClientesToolStripMenuItem";
            this.relatórioClientesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.relatórioClientesToolStripMenuItem.Text = "Relatório Clientes";
            this.relatórioClientesToolStripMenuItem.Click += new System.EventHandler(this.relatórioClientesToolStripMenuItem_Click);
            // 
            // relatórioProdutosToolStripMenuItem
            // 
            this.relatórioProdutosToolStripMenuItem.Name = "relatórioProdutosToolStripMenuItem";
            this.relatórioProdutosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.relatórioProdutosToolStripMenuItem.Text = "Relatório Produtos";
            this.relatórioProdutosToolStripMenuItem.Click += new System.EventHandler(this.relatórioProdutosToolStripMenuItem_Click);
            // 
            // relatórioVendasToolStripMenuItem
            // 
            this.relatórioVendasToolStripMenuItem.Name = "relatórioVendasToolStripMenuItem";
            this.relatórioVendasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.relatórioVendasToolStripMenuItem.Text = "Relatório Vendas";
            this.relatórioVendasToolStripMenuItem.Click += new System.EventHandler(this.relatórioVendasToolStripMenuItem_Click);
            // 
            // produtosInativosToolStripMenuItem
            // 
            this.produtosInativosToolStripMenuItem.Name = "produtosInativosToolStripMenuItem";
            this.produtosInativosToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.produtosInativosToolStripMenuItem.Text = "Produtos Inativos";
            this.produtosInativosToolStripMenuItem.Click += new System.EventHandler(this.produtosInativosToolStripMenuItem_Click);
            // 
            // clientesInativosToolStripMenuItem
            // 
            this.clientesInativosToolStripMenuItem.Name = "clientesInativosToolStripMenuItem";
            this.clientesInativosToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.clientesInativosToolStripMenuItem.Text = "Clientes Inativos";
            this.clientesInativosToolStripMenuItem.Click += new System.EventHandler(this.clientesInativosToolStripMenuItem_Click);
            // 
            // frmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmInicial";
            this.Text = "Inicio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioVendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosInativosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesInativosToolStripMenuItem;
    }
}

