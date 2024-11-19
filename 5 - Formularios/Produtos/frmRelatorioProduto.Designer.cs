namespace EmpresaVendas._5___Formularios.Vendas
{
    partial class frmRelatorioProduto
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
            this.pprodutostbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresavendaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresa_vendaDataSet = new EmpresaVendas.empresa_vendaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.p_produtos_tbTableAdapter = new EmpresaVendas.empresa_vendaDataSetTableAdapters.p_produtos_tbTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pprodutostbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresavendaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresa_vendaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pprodutostbBindingSource
            // 
            this.pprodutostbBindingSource.DataMember = "p_produtos_tb";
            this.pprodutostbBindingSource.DataSource = this.empresavendaDataSetBindingSource;
            // 
            // empresavendaDataSetBindingSource
            // 
            this.empresavendaDataSetBindingSource.DataSource = this.empresa_vendaDataSet;
            this.empresavendaDataSetBindingSource.Position = 0;
            // 
            // empresa_vendaDataSet
            // 
            this.empresa_vendaDataSet.DataSetName = "empresa_vendaDataSet";
            this.empresa_vendaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.pprodutostbBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EmpresaVendas.RelatorioProdutos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // p_produtos_tbTableAdapter
            // 
            this.p_produtos_tbTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorioProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRelatorioProduto";
            this.ShowIcon = false;
            this.Text = "frmRelatorioProduto";
            this.Load += new System.EventHandler(this.frmRelatorioProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pprodutostbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresavendaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresa_vendaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private empresa_vendaDataSet empresa_vendaDataSet;
        private System.Windows.Forms.BindingSource empresavendaDataSetBindingSource;
        private System.Windows.Forms.BindingSource pprodutostbBindingSource;
        private empresa_vendaDataSetTableAdapters.p_produtos_tbTableAdapter p_produtos_tbTableAdapter;
    }
}