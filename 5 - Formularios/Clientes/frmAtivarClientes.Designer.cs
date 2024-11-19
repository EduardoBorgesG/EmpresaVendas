namespace EmpresaVendas._5___Formularios.Clientes
{
    partial class frmAtivarClientes
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
            this.btnAtivarCliente = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gridClientesInativos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientesInativos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtivarCliente
            // 
            this.btnAtivarCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivarCliente.Location = new System.Drawing.Point(346, 138);
            this.btnAtivarCliente.Name = "btnAtivarCliente";
            this.btnAtivarCliente.Size = new System.Drawing.Size(124, 70);
            this.btnAtivarCliente.TabIndex = 5;
            this.btnAtivarCliente.Text = "ATIVAR CLIENTE";
            this.btnAtivarCliente.UseVisualStyleBackColor = true;
            this.btnAtivarCliente.Click += new System.EventHandler(this.btnAtivarCliente_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(331, 30);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Qual Produto deseja ativar?";
            // 
            // gridClientesInativos
            // 
            this.gridClientesInativos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClientesInativos.Location = new System.Drawing.Point(17, 78);
            this.gridClientesInativos.Name = "gridClientesInativos";
            this.gridClientesInativos.Size = new System.Drawing.Size(272, 223);
            this.gridClientesInativos.TabIndex = 3;
            this.gridClientesInativos.Click += new System.EventHandler(this.gridClientesInativos_Click);
            // 
            // frmAtivarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 323);
            this.Controls.Add(this.btnAtivarCliente);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gridClientesInativos);
            this.Name = "frmAtivarClientes";
            this.Text = "frmAtivarClientes";
            ((System.ComponentModel.ISupportInitialize)(this.gridClientesInativos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtivarCliente;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView gridClientesInativos;
    }
}