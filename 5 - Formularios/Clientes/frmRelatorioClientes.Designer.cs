namespace EmpresaVendas._5___Formularios.Clientes
{
    partial class frmRelatorioClientes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.empresa_vendaDataSet = new EmpresaVendas.empresa_vendaDataSet();
            this.empresavendaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.c_clientes_tbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cclientestbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.c_clientes_tbTableAdapter = new EmpresaVendas.empresa_vendaDataSetTableAdapters.c_clientes_tbTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.empresa_vendaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresavendaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_clientes_tbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cclientestbBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetClientes";
            reportDataSource1.Value = this.cclientestbBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EmpresaVendas.RelatorioClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // empresa_vendaDataSet
            // 
            this.empresa_vendaDataSet.DataSetName = "empresa_vendaDataSet";
            this.empresa_vendaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empresavendaDataSetBindingSource
            // 
            this.empresavendaDataSetBindingSource.DataSource = this.empresa_vendaDataSet;
            this.empresavendaDataSetBindingSource.Position = 0;
            // 
            // c_clientes_tbBindingSource
            // 
            this.c_clientes_tbBindingSource.DataMember = "c_clientes_tb";
            this.c_clientes_tbBindingSource.DataSource = this.empresa_vendaDataSet;
            // 
            // cclientestbBindingSource
            // 
            this.cclientestbBindingSource.DataMember = "c_clientes_tb";
            this.cclientestbBindingSource.DataSource = this.empresavendaDataSetBindingSource;
            // 
            // c_clientes_tbTableAdapter
            // 
            this.c_clientes_tbTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorioClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRelatorioClientes";
            this.Text = "frmRelatorioClientes";
            this.Load += new System.EventHandler(this.frmRelatorioClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empresa_vendaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresavendaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_clientes_tbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cclientestbBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource empresavendaDataSetBindingSource;
        private empresa_vendaDataSet empresa_vendaDataSet;
        private System.Windows.Forms.BindingSource c_clientes_tbBindingSource;
        private System.Windows.Forms.BindingSource cclientestbBindingSource;
        private empresa_vendaDataSetTableAdapters.c_clientes_tbTableAdapter c_clientes_tbTableAdapter;
    }
}