namespace EmpresaVendas._5___Formularios.Vendas
{
    partial class frmRelatorioVenda
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
            this.vendaJoinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendaJoinTableAdapter = new EmpresaVendas.empresa_vendaDataSetTableAdapters.VendaJoinTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.empresa_vendaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaJoinBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Vendas";
            reportDataSource1.Value = this.vendaJoinBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EmpresaVendas.RelatorioVendas.rdlc";
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
            // vendaJoinBindingSource
            // 
            this.vendaJoinBindingSource.DataMember = "VendaJoin";
            this.vendaJoinBindingSource.DataSource = this.empresa_vendaDataSet;
            // 
            // vendaJoinTableAdapter
            // 
            this.vendaJoinTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorioVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRelatorioVenda";
            this.Text = "frmRelatorioVenda";
            this.Load += new System.EventHandler(this.frmRelatorioVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empresa_vendaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaJoinBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private empresa_vendaDataSet empresa_vendaDataSet;
        private System.Windows.Forms.BindingSource vendaJoinBindingSource;
        private empresa_vendaDataSetTableAdapters.VendaJoinTableAdapter vendaJoinTableAdapter;
    }
}