namespace TP2
{
    partial class FORM_Lister
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
            this.DGV_Liste = new System.Windows.Forms.DataGridView();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.CB_Client = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Liste)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Liste
            // 
            this.DGV_Liste.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Liste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Liste.Location = new System.Drawing.Point(13, 13);
            this.DGV_Liste.Name = "DGV_Liste";
            this.DGV_Liste.ReadOnly = true;
            this.DGV_Liste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Liste.Size = new System.Drawing.Size(480, 223);
            this.DGV_Liste.TabIndex = 0;
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_OK.Location = new System.Drawing.Point(418, 242);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 1;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // CB_Client
            // 
            this.CB_Client.FormattingEnabled = true;
            this.CB_Client.Location = new System.Drawing.Point(13, 242);
            this.CB_Client.Name = "CB_Client";
            this.CB_Client.Size = new System.Drawing.Size(121, 21);
            this.CB_Client.TabIndex = 2;
            this.CB_Client.Visible = false;
            this.CB_Client.SelectedIndexChanged += new System.EventHandler(this.CB_Client_SelectedIndexChanged);
            // 
            // FORM_Lister
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 275);
            this.Controls.Add(this.CB_Client);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.DGV_Liste);
            this.Name = "FORM_Lister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FORM_Lister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Liste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Liste;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.ComboBox CB_Client;
    }
}