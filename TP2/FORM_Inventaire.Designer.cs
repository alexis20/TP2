namespace TP2
{
    partial class FORM_Inventaire
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
            this.LBL_ID_Inventaire = new System.Windows.Forms.Label();
            this.LBL_Description = new System.Windows.Forms.Label();
            this.LBL_ID_Fournisseur = new System.Windows.Forms.Label();
            this.LBL_QTE_Stock = new System.Windows.Forms.Label();
            this.LBL_QTE_Minimum = new System.Windows.Forms.Label();
            this.LBL_QTE_Maximum = new System.Windows.Forms.Label();
            this.TB_ID_Inventaire = new System.Windows.Forms.TextBox();
            this.TB_Description = new System.Windows.Forms.TextBox();
            this.TB_QTE_Stock = new System.Windows.Forms.TextBox();
            this.TB_QTE_Minimum = new System.Windows.Forms.TextBox();
            this.TB_QTE_Maximum = new System.Windows.Forms.TextBox();
            this.CB_ID_Fournisseur = new System.Windows.Forms.ComboBox();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Annuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_ID_Inventaire
            // 
            this.LBL_ID_Inventaire.AutoSize = true;
            this.LBL_ID_Inventaire.Location = new System.Drawing.Point(16, 22);
            this.LBL_ID_Inventaire.Name = "LBL_ID_Inventaire";
            this.LBL_ID_Inventaire.Size = new System.Drawing.Size(14, 13);
            this.LBL_ID_Inventaire.TabIndex = 0;
            this.LBL_ID_Inventaire.Text = "#";
            // 
            // LBL_Description
            // 
            this.LBL_Description.AutoSize = true;
            this.LBL_Description.Location = new System.Drawing.Point(16, 49);
            this.LBL_Description.Name = "LBL_Description";
            this.LBL_Description.Size = new System.Drawing.Size(60, 13);
            this.LBL_Description.TabIndex = 1;
            this.LBL_Description.Text = "Description";
            // 
            // LBL_ID_Fournisseur
            // 
            this.LBL_ID_Fournisseur.AutoSize = true;
            this.LBL_ID_Fournisseur.Location = new System.Drawing.Point(16, 122);
            this.LBL_ID_Fournisseur.Name = "LBL_ID_Fournisseur";
            this.LBL_ID_Fournisseur.Size = new System.Drawing.Size(61, 13);
            this.LBL_ID_Fournisseur.TabIndex = 2;
            this.LBL_ID_Fournisseur.Text = "Fournisseur";
            // 
            // LBL_QTE_Stock
            // 
            this.LBL_QTE_Stock.AutoSize = true;
            this.LBL_QTE_Stock.Location = new System.Drawing.Point(16, 150);
            this.LBL_QTE_Stock.Name = "LBL_QTE_Stock";
            this.LBL_QTE_Stock.Size = new System.Drawing.Size(76, 13);
            this.LBL_QTE_Stock.TabIndex = 3;
            this.LBL_QTE_Stock.Text = "Quantité stock";
            // 
            // LBL_QTE_Minimum
            // 
            this.LBL_QTE_Minimum.AutoSize = true;
            this.LBL_QTE_Minimum.Location = new System.Drawing.Point(16, 176);
            this.LBL_QTE_Minimum.Name = "LBL_QTE_Minimum";
            this.LBL_QTE_Minimum.Size = new System.Drawing.Size(90, 13);
            this.LBL_QTE_Minimum.TabIndex = 4;
            this.LBL_QTE_Minimum.Text = "Quantité minimum";
            // 
            // LBL_QTE_Maximum
            // 
            this.LBL_QTE_Maximum.AutoSize = true;
            this.LBL_QTE_Maximum.Location = new System.Drawing.Point(16, 202);
            this.LBL_QTE_Maximum.Name = "LBL_QTE_Maximum";
            this.LBL_QTE_Maximum.Size = new System.Drawing.Size(93, 13);
            this.LBL_QTE_Maximum.TabIndex = 5;
            this.LBL_QTE_Maximum.Text = "Quantité maximum";
            // 
            // TB_ID_Inventaire
            // 
            this.TB_ID_Inventaire.Enabled = false;
            this.TB_ID_Inventaire.Location = new System.Drawing.Point(126, 19);
            this.TB_ID_Inventaire.Name = "TB_ID_Inventaire";
            this.TB_ID_Inventaire.Size = new System.Drawing.Size(44, 20);
            this.TB_ID_Inventaire.TabIndex = 6;
            // 
            // TB_Description
            // 
            this.TB_Description.Location = new System.Drawing.Point(126, 46);
            this.TB_Description.Multiline = true;
            this.TB_Description.Name = "TB_Description";
            this.TB_Description.Size = new System.Drawing.Size(170, 67);
            this.TB_Description.TabIndex = 7;
            this.TB_Description.TextChanged += new System.EventHandler(this.TB_Description_TextChanged);
            // 
            // TB_QTE_Stock
            // 
            this.TB_QTE_Stock.Location = new System.Drawing.Point(126, 147);
            this.TB_QTE_Stock.Name = "TB_QTE_Stock";
            this.TB_QTE_Stock.Size = new System.Drawing.Size(170, 20);
            this.TB_QTE_Stock.TabIndex = 8;
            this.TB_QTE_Stock.TextChanged += new System.EventHandler(this.TB_QTE_Stock_TextChanged);
            this.TB_QTE_Stock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB__KeyPress);
            // 
            // TB_QTE_Minimum
            // 
            this.TB_QTE_Minimum.Location = new System.Drawing.Point(126, 173);
            this.TB_QTE_Minimum.Name = "TB_QTE_Minimum";
            this.TB_QTE_Minimum.Size = new System.Drawing.Size(170, 20);
            this.TB_QTE_Minimum.TabIndex = 9;
            this.TB_QTE_Minimum.TextChanged += new System.EventHandler(this.TB_QTE_Minimum_TextChanged);
            // 
            // TB_QTE_Maximum
            // 
            this.TB_QTE_Maximum.Location = new System.Drawing.Point(126, 199);
            this.TB_QTE_Maximum.Name = "TB_QTE_Maximum";
            this.TB_QTE_Maximum.Size = new System.Drawing.Size(170, 20);
            this.TB_QTE_Maximum.TabIndex = 10;
            this.TB_QTE_Maximum.TextChanged += new System.EventHandler(this.TB_QTE_Maximum_TextChanged);
            // 
            // CB_ID_Fournisseur
            // 
            this.CB_ID_Fournisseur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_ID_Fournisseur.FormattingEnabled = true;
            this.CB_ID_Fournisseur.Location = new System.Drawing.Point(126, 119);
            this.CB_ID_Fournisseur.Name = "CB_ID_Fournisseur";
            this.CB_ID_Fournisseur.Size = new System.Drawing.Size(170, 21);
            this.CB_ID_Fournisseur.TabIndex = 11;
            this.CB_ID_Fournisseur.SelectedIndexChanged += new System.EventHandler(this.CB_ID_Fournisseur_SelectedIndexChanged);
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_OK.Enabled = false;
            this.BTN_OK.Location = new System.Drawing.Point(140, 240);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 12;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Annuler.Location = new System.Drawing.Point(221, 240);
            this.BTN_Annuler.Name = "BTN_Annuler";
            this.BTN_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BTN_Annuler.TabIndex = 13;
            this.BTN_Annuler.Text = "Annuler";
            this.BTN_Annuler.UseVisualStyleBackColor = true;
            // 
            // FORM_Inventaire
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Annuler;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Controls.Add(this.BTN_Annuler);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.CB_ID_Fournisseur);
            this.Controls.Add(this.TB_QTE_Maximum);
            this.Controls.Add(this.TB_QTE_Minimum);
            this.Controls.Add(this.TB_QTE_Stock);
            this.Controls.Add(this.TB_Description);
            this.Controls.Add(this.TB_ID_Inventaire);
            this.Controls.Add(this.LBL_QTE_Maximum);
            this.Controls.Add(this.LBL_QTE_Minimum);
            this.Controls.Add(this.LBL_QTE_Stock);
            this.Controls.Add(this.LBL_ID_Fournisseur);
            this.Controls.Add(this.LBL_Description);
            this.Controls.Add(this.LBL_ID_Inventaire);
            this.Name = "FORM_Inventaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FORM_Inventaire_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_ID_Inventaire;
        private System.Windows.Forms.Label LBL_Description;
        private System.Windows.Forms.Label LBL_ID_Fournisseur;
        private System.Windows.Forms.Label LBL_QTE_Stock;
        private System.Windows.Forms.Label LBL_QTE_Minimum;
        private System.Windows.Forms.Label LBL_QTE_Maximum;
        private System.Windows.Forms.TextBox TB_ID_Inventaire;
        private System.Windows.Forms.TextBox TB_Description;
        private System.Windows.Forms.TextBox TB_QTE_Stock;
        private System.Windows.Forms.TextBox TB_QTE_Minimum;
        private System.Windows.Forms.TextBox TB_QTE_Maximum;
        private System.Windows.Forms.ComboBox CB_ID_Fournisseur;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Annuler;
    }
}