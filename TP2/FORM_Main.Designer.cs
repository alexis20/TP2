namespace TP2
{
    partial class FORM_Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGV_Fournisseur = new System.Windows.Forms.DataGridView();
            this.DGV_Inventaire = new System.Windows.Forms.DataGridView();
            this.BTN_AJTER_Fournisseur = new System.Windows.Forms.Button();
            this.BTN_MODIF_Fournisseur = new System.Windows.Forms.Button();
            this.BTN_SUP_Fournisseur = new System.Windows.Forms.Button();
            this.LBL_RECHERCHE_Fournisseur = new System.Windows.Forms.Label();
            this.MS_Menu = new System.Windows.Forms.MenuStrip();
            this.TSMI_Fichier = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Deconnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Quitter = new System.Windows.Forms.ToolStripMenuItem();
            this.TB_RECHERCHE_Fournisseur = new System.Windows.Forms.TextBox();
            this.LBL_RECHERCHE_Inventaire = new System.Windows.Forms.Label();
            this.TB_RECHERCHE_Inventaire = new System.Windows.Forms.TextBox();
            this.GB_FOURNISSEUR = new System.Windows.Forms.GroupBox();
            this.GB_INVENTAIRE = new System.Windows.Forms.GroupBox();
            this.BTN_SUP_Inventaire = new System.Windows.Forms.Button();
            this.BTN_MODIF_Inventaire = new System.Windows.Forms.Button();
            this.BTN_AJTER_Inventaire = new System.Windows.Forms.Button();
            this.DGV_QTE_Minimum = new System.Windows.Forms.DataGridView();
            this.TSMI_Connexion = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Fournisseur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Inventaire)).BeginInit();
            this.MS_Menu.SuspendLayout();
            this.GB_FOURNISSEUR.SuspendLayout();
            this.GB_INVENTAIRE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_QTE_Minimum)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Fournisseur
            // 
            this.DGV_Fournisseur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Fournisseur.Location = new System.Drawing.Point(6, 39);
            this.DGV_Fournisseur.Name = "DGV_Fournisseur";
            this.DGV_Fournisseur.Size = new System.Drawing.Size(345, 232);
            this.DGV_Fournisseur.TabIndex = 0;
            // 
            // DGV_Inventaire
            // 
            this.DGV_Inventaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Inventaire.Location = new System.Drawing.Point(6, 39);
            this.DGV_Inventaire.Name = "DGV_Inventaire";
            this.DGV_Inventaire.Size = new System.Drawing.Size(345, 232);
            this.DGV_Inventaire.TabIndex = 1;
            this.DGV_Inventaire.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Inventaire_CellContentClick);
            // 
            // BTN_AJTER_Fournisseur
            // 
            this.BTN_AJTER_Fournisseur.Location = new System.Drawing.Point(6, 277);
            this.BTN_AJTER_Fournisseur.Name = "BTN_AJTER_Fournisseur";
            this.BTN_AJTER_Fournisseur.Size = new System.Drawing.Size(111, 23);
            this.BTN_AJTER_Fournisseur.TabIndex = 2;
            this.BTN_AJTER_Fournisseur.Text = "Ajouter";
            this.BTN_AJTER_Fournisseur.UseVisualStyleBackColor = true;
            this.BTN_AJTER_Fournisseur.Click += new System.EventHandler(this.BTN_AJTER_Fournisseur_Click);
            // 
            // BTN_MODIF_Fournisseur
            // 
            this.BTN_MODIF_Fournisseur.Location = new System.Drawing.Point(123, 277);
            this.BTN_MODIF_Fournisseur.Name = "BTN_MODIF_Fournisseur";
            this.BTN_MODIF_Fournisseur.Size = new System.Drawing.Size(111, 23);
            this.BTN_MODIF_Fournisseur.TabIndex = 3;
            this.BTN_MODIF_Fournisseur.Text = "Modifier";
            this.BTN_MODIF_Fournisseur.UseVisualStyleBackColor = true;
            // 
            // BTN_SUP_Fournisseur
            // 
            this.BTN_SUP_Fournisseur.Location = new System.Drawing.Point(240, 277);
            this.BTN_SUP_Fournisseur.Name = "BTN_SUP_Fournisseur";
            this.BTN_SUP_Fournisseur.Size = new System.Drawing.Size(111, 23);
            this.BTN_SUP_Fournisseur.TabIndex = 4;
            this.BTN_SUP_Fournisseur.Text = "Supprimer";
            this.BTN_SUP_Fournisseur.UseVisualStyleBackColor = true;
            // 
            // LBL_RECHERCHE_Fournisseur
            // 
            this.LBL_RECHERCHE_Fournisseur.AutoSize = true;
            this.LBL_RECHERCHE_Fournisseur.Location = new System.Drawing.Point(96, 16);
            this.LBL_RECHERCHE_Fournisseur.Name = "LBL_RECHERCHE_Fournisseur";
            this.LBL_RECHERCHE_Fournisseur.Size = new System.Drawing.Size(66, 13);
            this.LBL_RECHERCHE_Fournisseur.TabIndex = 5;
            this.LBL_RECHERCHE_Fournisseur.Text = "Recherche :";
            // 
            // MS_Menu
            // 
            this.MS_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Fichier});
            this.MS_Menu.Location = new System.Drawing.Point(0, 0);
            this.MS_Menu.Name = "MS_Menu";
            this.MS_Menu.Size = new System.Drawing.Size(763, 24);
            this.MS_Menu.TabIndex = 6;
            this.MS_Menu.Text = "menuStrip1";
            // 
            // TSMI_Fichier
            // 
            this.TSMI_Fichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Connexion,
            this.TSMI_Deconnexion,
            this.toolStripSeparator1,
            this.TSMI_Quitter});
            this.TSMI_Fichier.Name = "TSMI_Fichier";
            this.TSMI_Fichier.Size = new System.Drawing.Size(54, 20);
            this.TSMI_Fichier.Text = "Fichier";
            // 
            // TSMI_Deconnexion
            // 
            this.TSMI_Deconnexion.Name = "TSMI_Deconnexion";
            this.TSMI_Deconnexion.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Deconnexion.Text = "Déconnexion";
            this.TSMI_Deconnexion.Click += new System.EventHandler(this.TSMI_Deconnexion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // TSMI_Quitter
            // 
            this.TSMI_Quitter.Name = "TSMI_Quitter";
            this.TSMI_Quitter.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Quitter.Text = "Quitter";
            this.TSMI_Quitter.Click += new System.EventHandler(this.TSMI_Quitter_Click);
            // 
            // TB_RECHERCHE_Fournisseur
            // 
            this.TB_RECHERCHE_Fournisseur.Location = new System.Drawing.Point(168, 13);
            this.TB_RECHERCHE_Fournisseur.Name = "TB_RECHERCHE_Fournisseur";
            this.TB_RECHERCHE_Fournisseur.Size = new System.Drawing.Size(183, 20);
            this.TB_RECHERCHE_Fournisseur.TabIndex = 7;
            this.TB_RECHERCHE_Fournisseur.TextChanged += new System.EventHandler(this.TB_RECHERCHE_Fournisseur_TextChanged);
            // 
            // LBL_RECHERCHE_Inventaire
            // 
            this.LBL_RECHERCHE_Inventaire.AutoSize = true;
            this.LBL_RECHERCHE_Inventaire.Location = new System.Drawing.Point(96, 16);
            this.LBL_RECHERCHE_Inventaire.Name = "LBL_RECHERCHE_Inventaire";
            this.LBL_RECHERCHE_Inventaire.Size = new System.Drawing.Size(66, 13);
            this.LBL_RECHERCHE_Inventaire.TabIndex = 8;
            this.LBL_RECHERCHE_Inventaire.Text = "Recherche :";
            // 
            // TB_RECHERCHE_Inventaire
            // 
            this.TB_RECHERCHE_Inventaire.Location = new System.Drawing.Point(168, 13);
            this.TB_RECHERCHE_Inventaire.Name = "TB_RECHERCHE_Inventaire";
            this.TB_RECHERCHE_Inventaire.Size = new System.Drawing.Size(183, 20);
            this.TB_RECHERCHE_Inventaire.TabIndex = 9;
            // 
            // GB_FOURNISSEUR
            // 
            this.GB_FOURNISSEUR.Controls.Add(this.LBL_RECHERCHE_Fournisseur);
            this.GB_FOURNISSEUR.Controls.Add(this.TB_RECHERCHE_Fournisseur);
            this.GB_FOURNISSEUR.Controls.Add(this.DGV_Fournisseur);
            this.GB_FOURNISSEUR.Controls.Add(this.BTN_SUP_Fournisseur);
            this.GB_FOURNISSEUR.Controls.Add(this.BTN_AJTER_Fournisseur);
            this.GB_FOURNISSEUR.Controls.Add(this.BTN_MODIF_Fournisseur);
            this.GB_FOURNISSEUR.Location = new System.Drawing.Point(12, 27);
            this.GB_FOURNISSEUR.Name = "GB_FOURNISSEUR";
            this.GB_FOURNISSEUR.Size = new System.Drawing.Size(357, 310);
            this.GB_FOURNISSEUR.TabIndex = 10;
            this.GB_FOURNISSEUR.TabStop = false;
            this.GB_FOURNISSEUR.Text = "FOURNISSEUR";
            // 
            // GB_INVENTAIRE
            // 
            this.GB_INVENTAIRE.Controls.Add(this.BTN_SUP_Inventaire);
            this.GB_INVENTAIRE.Controls.Add(this.BTN_MODIF_Inventaire);
            this.GB_INVENTAIRE.Controls.Add(this.BTN_AJTER_Inventaire);
            this.GB_INVENTAIRE.Controls.Add(this.LBL_RECHERCHE_Inventaire);
            this.GB_INVENTAIRE.Controls.Add(this.TB_RECHERCHE_Inventaire);
            this.GB_INVENTAIRE.Controls.Add(this.DGV_Inventaire);
            this.GB_INVENTAIRE.Location = new System.Drawing.Point(393, 27);
            this.GB_INVENTAIRE.Name = "GB_INVENTAIRE";
            this.GB_INVENTAIRE.Size = new System.Drawing.Size(357, 310);
            this.GB_INVENTAIRE.TabIndex = 11;
            this.GB_INVENTAIRE.TabStop = false;
            this.GB_INVENTAIRE.Text = "INVENTAIRE";
            // 
            // BTN_SUP_Inventaire
            // 
            this.BTN_SUP_Inventaire.Location = new System.Drawing.Point(240, 277);
            this.BTN_SUP_Inventaire.Name = "BTN_SUP_Inventaire";
            this.BTN_SUP_Inventaire.Size = new System.Drawing.Size(111, 23);
            this.BTN_SUP_Inventaire.TabIndex = 12;
            this.BTN_SUP_Inventaire.Text = "Supprimer";
            this.BTN_SUP_Inventaire.UseVisualStyleBackColor = true;
            // 
            // BTN_MODIF_Inventaire
            // 
            this.BTN_MODIF_Inventaire.Location = new System.Drawing.Point(123, 277);
            this.BTN_MODIF_Inventaire.Name = "BTN_MODIF_Inventaire";
            this.BTN_MODIF_Inventaire.Size = new System.Drawing.Size(111, 23);
            this.BTN_MODIF_Inventaire.TabIndex = 11;
            this.BTN_MODIF_Inventaire.Text = "Modifier";
            this.BTN_MODIF_Inventaire.UseVisualStyleBackColor = true;
            // 
            // BTN_AJTER_Inventaire
            // 
            this.BTN_AJTER_Inventaire.Location = new System.Drawing.Point(6, 277);
            this.BTN_AJTER_Inventaire.Name = "BTN_AJTER_Inventaire";
            this.BTN_AJTER_Inventaire.Size = new System.Drawing.Size(111, 23);
            this.BTN_AJTER_Inventaire.TabIndex = 10;
            this.BTN_AJTER_Inventaire.Text = "Ajouter";
            this.BTN_AJTER_Inventaire.UseVisualStyleBackColor = true;
            // 
            // DGV_QTE_Minimum
            // 
            this.DGV_QTE_Minimum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_QTE_Minimum.Location = new System.Drawing.Point(18, 343);
            this.DGV_QTE_Minimum.Name = "DGV_QTE_Minimum";
            this.DGV_QTE_Minimum.Size = new System.Drawing.Size(726, 112);
            this.DGV_QTE_Minimum.TabIndex = 12;
            // 
            // TSMI_Connexion
            // 
            this.TSMI_Connexion.Name = "TSMI_Connexion";
            this.TSMI_Connexion.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Connexion.Text = "Connexion";
            this.TSMI_Connexion.Click += new System.EventHandler(this.TSMI_Connexion_Click);
            // 
            // FORM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 467);
            this.Controls.Add(this.DGV_QTE_Minimum);
            this.Controls.Add(this.GB_INVENTAIRE);
            this.Controls.Add(this.GB_FOURNISSEUR);
            this.Controls.Add(this.MS_Menu);
            this.MainMenuStrip = this.MS_Menu;
            this.Name = "FORM_Main";
            this.Text = "Àmoé";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FORM_Main_FormClosing);
            this.Load += new System.EventHandler(this.FORM_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Fournisseur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Inventaire)).EndInit();
            this.MS_Menu.ResumeLayout(false);
            this.MS_Menu.PerformLayout();
            this.GB_FOURNISSEUR.ResumeLayout(false);
            this.GB_FOURNISSEUR.PerformLayout();
            this.GB_INVENTAIRE.ResumeLayout(false);
            this.GB_INVENTAIRE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_QTE_Minimum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Fournisseur;
        private System.Windows.Forms.DataGridView DGV_Inventaire;
        private System.Windows.Forms.Button BTN_AJTER_Fournisseur;
        private System.Windows.Forms.Button BTN_MODIF_Fournisseur;
        private System.Windows.Forms.Button BTN_SUP_Fournisseur;
        private System.Windows.Forms.Label LBL_RECHERCHE_Fournisseur;
        private System.Windows.Forms.MenuStrip MS_Menu;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Fichier;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Deconnexion;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Quitter;
        private System.Windows.Forms.TextBox TB_RECHERCHE_Fournisseur;
        private System.Windows.Forms.Label LBL_RECHERCHE_Inventaire;
        private System.Windows.Forms.TextBox TB_RECHERCHE_Inventaire;
        private System.Windows.Forms.GroupBox GB_FOURNISSEUR;
        private System.Windows.Forms.GroupBox GB_INVENTAIRE;
        private System.Windows.Forms.Button BTN_SUP_Inventaire;
        private System.Windows.Forms.Button BTN_MODIF_Inventaire;
        private System.Windows.Forms.Button BTN_AJTER_Inventaire;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView DGV_QTE_Minimum;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Connexion;
    }
}

