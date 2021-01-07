namespace dashNew1
{
    partial class MaintenanceReport
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
            this.reportViewerMR = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn_load = new MetroFramework.Controls.MetroTile();
            this.btn_search = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmb_lplate = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // reportViewerMR
            // 
            this.reportViewerMR.Location = new System.Drawing.Point(28, 117);
            this.reportViewerMR.Name = "reportViewerMR";
            this.reportViewerMR.ServerReport.BearerToken = null;
            this.reportViewerMR.Size = new System.Drawing.Size(1082, 529);
            this.reportViewerMR.TabIndex = 13;
            // 
            // btn_load
            // 
            this.btn_load.ActiveControl = null;
            this.btn_load.BackColor = System.Drawing.Color.Purple;
            this.btn_load.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_load.Location = new System.Drawing.Point(997, 54);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(113, 48);
            this.btn_load.TabIndex = 12;
            this.btn_load.Text = "LOAD ALL";
            this.btn_load.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_load.UseCustomBackColor = true;
            this.btn_load.UseCustomForeColor = true;
            this.btn_load.UseSelectable = true;
            this.btn_load.UseStyleColors = true;
            // 
            // btn_search
            // 
            this.btn_search.ActiveControl = null;
            this.btn_search.BackColor = System.Drawing.Color.Purple;
            this.btn_search.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_search.Location = new System.Drawing.Point(291, 54);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(96, 48);
            this.btn_search.TabIndex = 11;
            this.btn_search.Text = "SEARCH";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_search.UseCustomBackColor = true;
            this.btn_search.UseCustomForeColor = true;
            this.btn_search.UseSelectable = true;
            this.btn_search.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(28, 79);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Licence Plate";
            // 
            // cmb_lplate
            // 
            this.cmb_lplate.DisplayMember = "L_Plate";
            this.cmb_lplate.FormattingEnabled = true;
            this.cmb_lplate.ItemHeight = 23;
            this.cmb_lplate.Location = new System.Drawing.Point(129, 69);
            this.cmb_lplate.Name = "cmb_lplate";
            this.cmb_lplate.Size = new System.Drawing.Size(140, 29);
            this.cmb_lplate.Style = MetroFramework.MetroColorStyle.Purple;
            this.cmb_lplate.TabIndex = 9;
            this.cmb_lplate.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmb_lplate.UseSelectable = true;
            this.cmb_lplate.UseStyleColors = true;
            this.cmb_lplate.ValueMember = "L_Plate";
            // 
            // MaintenanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 669);
            this.Controls.Add(this.reportViewerMR);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cmb_lplate);
            this.Name = "MaintenanceReport";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Maintenance Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerMR;
        private MetroFramework.Controls.MetroTile btn_load;
        private MetroFramework.Controls.MetroTile btn_search;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cmb_lplate;
    }
}