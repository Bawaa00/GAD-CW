namespace dashNew1
{
    partial class AccidentReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btn_load = new MetroFramework.Controls.MetroTile();
            this.btn_search = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmb_lplate = new MetroFramework.Controls.MetroComboBox();
            this.reportViewerAcc = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet_Service = new dashNew1.DataSet_Service();
            this.Acc_repairBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Acc_repairTableAdapter = new dashNew1.DataSet_ServiceTableAdapters.Acc_repairTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Acc_repairBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.ActiveControl = null;
            this.btn_load.BackColor = System.Drawing.Color.Purple;
            this.btn_load.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_load.Location = new System.Drawing.Point(1142, 74);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(113, 48);
            this.btn_load.TabIndex = 7;
            this.btn_load.Text = "LOAD ALL";
            this.btn_load.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_load.UseCustomBackColor = true;
            this.btn_load.UseCustomForeColor = true;
            this.btn_load.UseSelectable = true;
            this.btn_load.UseStyleColors = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_search
            // 
            this.btn_search.ActiveControl = null;
            this.btn_search.BackColor = System.Drawing.Color.Purple;
            this.btn_search.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_search.Location = new System.Drawing.Point(286, 74);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(96, 48);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "SEARCH";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_search.UseCustomBackColor = true;
            this.btn_search.UseCustomForeColor = true;
            this.btn_search.UseSelectable = true;
            this.btn_search.UseStyleColors = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 99);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Licence Plate";
            // 
            // cmb_lplate
            // 
            this.cmb_lplate.DisplayMember = "L_Plate";
            this.cmb_lplate.FormattingEnabled = true;
            this.cmb_lplate.ItemHeight = 23;
            this.cmb_lplate.Location = new System.Drawing.Point(124, 89);
            this.cmb_lplate.Name = "cmb_lplate";
            this.cmb_lplate.Size = new System.Drawing.Size(140, 29);
            this.cmb_lplate.Style = MetroFramework.MetroColorStyle.Purple;
            this.cmb_lplate.TabIndex = 4;
            this.cmb_lplate.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmb_lplate.UseSelectable = true;
            this.cmb_lplate.UseStyleColors = true;
            this.cmb_lplate.ValueMember = "L_Plate";
            // 
            // reportViewerAcc
            // 
            reportDataSource2.Name = "DataSetAccident";
            reportDataSource2.Value = this.Acc_repairBindingSource;
            this.reportViewerAcc.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerAcc.LocalReport.ReportEmbeddedResource = "dashNew1.ReportAccident.rdlc";
            this.reportViewerAcc.Location = new System.Drawing.Point(23, 137);
            this.reportViewerAcc.Name = "reportViewerAcc";
            this.reportViewerAcc.ServerReport.BearerToken = null;
            this.reportViewerAcc.Size = new System.Drawing.Size(1232, 497);
            this.reportViewerAcc.TabIndex = 8;
            // 
            // DataSet_Service
            // 
            this.DataSet_Service.DataSetName = "DataSet_Service";
            this.DataSet_Service.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Acc_repairBindingSource
            // 
            this.Acc_repairBindingSource.DataMember = "Acc_repair";
            this.Acc_repairBindingSource.DataSource = this.DataSet_Service;
            // 
            // Acc_repairTableAdapter
            // 
            this.Acc_repairTableAdapter.ClearBeforeFill = true;
            // 
            // AccidentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 657);
            this.Controls.Add(this.reportViewerAcc);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cmb_lplate);
            this.Name = "AccidentReport";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Accident Report";
            this.Load += new System.EventHandler(this.AccidentReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Acc_repairBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btn_load;
        private MetroFramework.Controls.MetroTile btn_search;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cmb_lplate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerAcc;
        private System.Windows.Forms.BindingSource Acc_repairBindingSource;
        private DataSet_Service DataSet_Service;
        private DataSet_ServiceTableAdapters.Acc_repairTableAdapter Acc_repairTableAdapter;
    }
}