namespace dashNew1
{
    partial class ServiceReport
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
            this.ServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet_Service = new dashNew1.DataSet_Service();
            this.cmb_lplate = new MetroFramework.Controls.MetroComboBox();
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rENT_VEHICLESDataSet = new dashNew1.RENT_VEHICLESDataSet();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btn_search = new MetroFramework.Controls.MetroTile();
            this.btn_load = new MetroFramework.Controls.MetroTile();
            this.vehicleTableAdapter = new dashNew1.RENT_VEHICLESDataSetTableAdapters.VehicleTableAdapter();
            this.reportViewerService = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ServiceTableAdapter = new dashNew1.DataSet_ServiceTableAdapters.ServiceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rENT_VEHICLESDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ServiceBindingSource
            // 
            this.ServiceBindingSource.DataMember = "Service";
            this.ServiceBindingSource.DataSource = this.DataSet_Service;
            // 
            // DataSet_Service
            // 
            this.DataSet_Service.DataSetName = "DataSet_Service";
            this.DataSet_Service.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmb_lplate
            // 
            this.cmb_lplate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.vehicleBindingSource, "L_Plate", true));
            this.cmb_lplate.DisplayMember = "L_Plate";
            this.cmb_lplate.FormattingEnabled = true;
            this.cmb_lplate.ItemHeight = 23;
            this.cmb_lplate.Location = new System.Drawing.Point(135, 78);
            this.cmb_lplate.Name = "cmb_lplate";
            this.cmb_lplate.Size = new System.Drawing.Size(140, 29);
            this.cmb_lplate.Style = MetroFramework.MetroColorStyle.Purple;
            this.cmb_lplate.TabIndex = 0;
            this.cmb_lplate.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmb_lplate.UseSelectable = true;
            this.cmb_lplate.UseStyleColors = true;
            this.cmb_lplate.ValueMember = "L_Plate";
            // 
            // vehicleBindingSource
            // 
            this.vehicleBindingSource.DataMember = "Vehicle";
            this.vehicleBindingSource.DataSource = this.rENT_VEHICLESDataSet;
            // 
            // rENT_VEHICLESDataSet
            // 
            this.rENT_VEHICLESDataSet.DataSetName = "RENT_VEHICLESDataSet";
            this.rENT_VEHICLESDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(34, 88);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Licence Plate";
            // 
            // btn_search
            // 
            this.btn_search.ActiveControl = null;
            this.btn_search.BackColor = System.Drawing.Color.Purple;
            this.btn_search.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_search.Location = new System.Drawing.Point(297, 63);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(96, 48);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "SEARCH";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_search.UseCustomBackColor = true;
            this.btn_search.UseCustomForeColor = true;
            this.btn_search.UseSelectable = true;
            this.btn_search.UseStyleColors = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_load
            // 
            this.btn_load.ActiveControl = null;
            this.btn_load.BackColor = System.Drawing.Color.Purple;
            this.btn_load.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_load.Location = new System.Drawing.Point(978, 63);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(113, 48);
            this.btn_load.TabIndex = 3;
            this.btn_load.Text = "LOAD ALL";
            this.btn_load.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_load.UseCustomBackColor = true;
            this.btn_load.UseCustomForeColor = true;
            this.btn_load.UseSelectable = true;
            this.btn_load.UseStyleColors = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // vehicleTableAdapter
            // 
            this.vehicleTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewerService
            // 
            reportDataSource1.Name = "DataSet_Report";
            reportDataSource1.Value = this.ServiceBindingSource;
            this.reportViewerService.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerService.LocalReport.ReportEmbeddedResource = "dashNew1.Report_Service.rdlc";
            this.reportViewerService.Location = new System.Drawing.Point(34, 136);
            this.reportViewerService.Name = "reportViewerService";
            this.reportViewerService.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reportViewerService.ServerReport.BearerToken = null;
            this.reportViewerService.Size = new System.Drawing.Size(1057, 485);
            this.reportViewerService.TabIndex = 4;
            // 
            // ServiceTableAdapter
            // 
            this.ServiceTableAdapter.ClearBeforeFill = true;
            // 
            // ServiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 644);
            this.Controls.Add(this.reportViewerService);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cmb_lplate);
            this.Name = "ServiceReport";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Service Report";
            this.Load += new System.EventHandler(this.ServiceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rENT_VEHICLESDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmb_lplate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile btn_search;
        private MetroFramework.Controls.MetroTile btn_load;
        private RENT_VEHICLESDataSet rENT_VEHICLESDataSet;
        private System.Windows.Forms.BindingSource vehicleBindingSource;
        private RENT_VEHICLESDataSetTableAdapters.VehicleTableAdapter vehicleTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerService;
        private System.Windows.Forms.BindingSource ServiceBindingSource;
        private DataSet_Service DataSet_Service;
        private DataSet_ServiceTableAdapters.ServiceTableAdapter ServiceTableAdapter;
    }
}