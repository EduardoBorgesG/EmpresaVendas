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
            this.btnNovoCliente = new System.Windows.Forms.Button();
            this.btnEditarClientes = new System.Windows.Forms.Button();
            this.btnExcluirClientes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridClientes
            // 
            this.gridClientes.AccessibleName = "gridClientes";
            this.gridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClientes.Location = new System.Drawing.Point(12, 12);
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.Size = new System.Drawing.Size(776, 336);
            this.gridClientes.TabIndex = 0;
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.Location = new System.Drawing.Point(76, 372);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(153, 49);
            this.btnNovoCliente.TabIndex = 1;
            this.btnNovoCliente.Text = "NOVO";
            this.btnNovoCliente.UseVisualStyleBackColor = true;
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // btnEditarClientes
            // 
            this.btnEditarClientes.Location = new System.Drawing.Point(323, 372);
            this.btnEditarClientes.Name = "btnEditarClientes";
            this.btnEditarClientes.Size = new System.Drawing.Size(153, 49);
            this.btnEditarClientes.TabIndex = 2;
            this.btnEditarClientes.Text = "EDITAR";
            this.btnEditarClientes.UseVisualStyleBackColor = true;
            this.btnEditarClientes.Click += new System.EventHandler(this.btnEditarClientes_Click);
            // 
            // btnExcluirClientes
            // 
            this.btnExcluirClientes.Location = new System.Drawing.Point(559, 372);
            this.btnExcluirClientes.Name = "btnExcluirClientes";
            this.btnExcluirClientes.Size = new System.Drawing.Size(153, 49);
            this.btnExcluirClientes.TabIndex = 3;
            this.btnExcluirClientes.Text = "EXCLUIR";
            this.btnExcluirClientes.UseVisualStyleBackColor = true;
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExcluirClientes);
            this.Controls.Add(this.btnEditarClientes);
            this.Controls.Add(this.btnNovoCliente);
            this.Controls.Add(this.gridClientes);
            this.Name = "frmClientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridClientes;
        private System.Windows.Forms.Button btnNovoCliente;
        private System.Windows.Forms.Button btnEditarClientes;
        private System.Windows.Forms.Button btnExcluirClientes;
    }
}