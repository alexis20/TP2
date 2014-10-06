namespace TP2
{
    partial class FORM_Rapport
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
            this.CRV_Rapport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRV_Rapport
            // 
            this.CRV_Rapport.ActiveViewIndex = -1;
            this.CRV_Rapport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRV_Rapport.CachedPageNumberPerDoc = 10;
            this.CRV_Rapport.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRV_Rapport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRV_Rapport.Location = new System.Drawing.Point(0, 0);
            this.CRV_Rapport.Name = "CRV_Rapport";
            this.CRV_Rapport.Size = new System.Drawing.Size(818, 428);
            this.CRV_Rapport.TabIndex = 0;
            // 
            // FORM_Rapport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 428);
            this.Controls.Add(this.CRV_Rapport);
            this.Name = "FORM_Rapport";
            this.Text = "FORM_Rapport";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRV_Rapport;
    }
}