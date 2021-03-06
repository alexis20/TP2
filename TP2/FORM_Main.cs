﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    public partial class FORM_Main : Form
    {
        SqlConnection conn = null;
        DataSet FournisseurDataSet = null;
        DataSet InventaireDataSet = null;
        DataSet QteMinDataSet = null;


        public FORM_Main()
        {
            InitializeComponent();
        }

        private void TB_RECHERCHE_Fournisseur_TextChanged(object sender, EventArgs e)
        {
            if (TB_RECHERCHE_Fournisseur.Text != "")
            {
                ReloadDGVFournisseur(TB_RECHERCHE_Fournisseur.Text);
                ReloadDGVInventaire();
            }
            else
            {
                ReloadDGVFournisseur();
                ReloadDGVInventaire();
            }
        }

        private void FORM_Main_Load(object sender, EventArgs e)
        {
            Connection();
            ReloadDGVFournisseur();
            ReloadDGVInventaire();
            ReloadDGVQteMin();
        }

        private void Connection()
        {
            String connexionChaine;
            connexionChaine = "Data Source=localhost\\SQLEXPRESS2012;Initial Catalog=bdOperation;User ID=conOperation;Password=conOperation";
            conn = new SqlConnection(connexionChaine);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                TSMI_Connexion.Enabled = true;
                TSMI_Deconnexion.Enabled = false;
                updateControls();
                BTN_AJTER_Fournisseur.Enabled = false;
            }
            if (conn.State.ToString() == "Open")
            {
                TSMI_Connexion.Enabled = false;
                TSMI_Deconnexion.Enabled = true;
            }
        }

        private void BTN_AJTER_Fournisseur_Click(object sender, EventArgs e)
        {
            FORM_Fournisseur FF = new FORM_Fournisseur();
            FF.Titre = "Ajout";
            if (FF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "insert into Fournisseur (NomFournisseur,AdFournisseur,VilleFournisseur,CPFournisseur,TelFournisseur,SoldeFournisseur,CourrielFournisseur)" +
                    " VALUES(@NomFournisseur,@AdFournisseur,@VilleFournisseur,@CPFournisseur,@TelFournisseur,@SoldeFournisseur,@CourrielFournisseur)";
                try
                {
                    SqlCommand sqlAjout = new SqlCommand(sql, conn);

                    SqlParameter SQLParaNom = new SqlParameter("@NomFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamad = new SqlParameter("@AdFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamVille = new SqlParameter("@VilleFournisseur", SqlDbType.VarChar, 50);  //Ajout
                    SqlParameter SQLParamCP = new SqlParameter("@CPFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamTel = new SqlParameter("@TelFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamSolde = new SqlParameter("@SoldeFournisseur", SqlDbType.Int, 6);
                    SqlParameter SQLParamCourriel = new SqlParameter("@CourrielFournisseur", SqlDbType.VarChar, 50);

                    SQLParaNom.Value = FF.Nom;
                    SQLParamad.Value = FF.Adresse;
                    SQLParamVille.Value = FF.Ville;
                    SQLParamCP.Value = FF.CodePostal;
                    SQLParamTel.Value = FF.Telephone;
                    SQLParamSolde.Value = FF.Solde;
                    SQLParamCourriel.Value = FF.Courriel;

                    sqlAjout.Parameters.Add(SQLParaNom);
                    sqlAjout.Parameters.Add(SQLParamad);
                    sqlAjout.Parameters.Add(SQLParamVille);
                    sqlAjout.Parameters.Add(SQLParamCP);
                    sqlAjout.Parameters.Add(SQLParamTel);
                    sqlAjout.Parameters.Add(SQLParamSolde);
                    sqlAjout.Parameters.Add(SQLParamCourriel);

                    sqlAjout.ExecuteNonQuery();

                    ReloadDGVFournisseur();
                }
                catch (SqlException ex)
                {
                    if(ex.Number == 2627)
                    {
                        MessageBox.Show("Le nom du fournisseur doit etre unique", "Erreur 2627", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                            MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void TSMI_Connexion_Click(object sender, EventArgs e)
        {
            Connection();
            ReloadDGVFournisseur();
            ReloadDGVInventaire();
            ReloadDGVQteMin();
            BTN_AJTER_Fournisseur.Enabled = true;
        }

        private void TSMI_Deconnexion_Click(object sender, EventArgs e)
        {
            TSMI_Deconnexion.Enabled = false;
            TSMI_Connexion.Enabled = true;
            DGV_Inventaire.DataSource = null;
            DGV_Fournisseur.DataSource = null;
            DGV_QTE_Minimum.DataSource = null;
            BTN_AJTER_Fournisseur.Enabled = false;
            updateControls();
            conn.Close();
        }

        private void TSMI_Quitter_Click(object sender, EventArgs e)
        {
            conn.Close();
            Application.Exit();
        }

        private void FORM_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void ReloadDGVFournisseur()
        {
            int lastIndex = -1;
            if (DGV_Fournisseur.SelectedRows.Count > 0) lastIndex = DGV_Fournisseur.SelectedRows[0].Index;

            SqlCommand SqlSelect = conn.CreateCommand();
            SqlSelect.CommandText = "SELECT idfournisseur as ID ,nomfournisseur as NOM,adfournisseur as ADRESSE,villefournisseur as VILLE,cpfournisseur as CP,telfournisseur as TEL, " +
                                        "soldefournisseur as SOLDE,courrielfournisseur as COURRIEL from Fournisseur";

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlSelect);
            FournisseurDataSet = new DataSet();
            SqlAdapter.Fill(FournisseurDataSet);
            DGV_Fournisseur.DataSource = FournisseurDataSet.Tables[0];

            if (lastIndex > -1 && DGV_Fournisseur.Rows.Count > 0) DGV_Fournisseur.Rows[Math.Min(lastIndex, DGV_Fournisseur.Rows.Count - 1)].Selected = true;
            updateControls();

        }
        private void ReloadDGVFournisseur(string value)
        {
            int lastIndex = -1;
            if (DGV_Fournisseur.SelectedRows.Count > 0) lastIndex = DGV_Fournisseur.SelectedRows[0].Index;

            SqlCommand SqlSelect = conn.CreateCommand();
            SqlSelect.CommandText = "SELECT idfournisseur as ID ,nomfournisseur as NOM,adfournisseur as ADRESSE,villefournisseur as VILLE,cpfournisseur as CP,telfournisseur as TEL, " +
                                        "soldefournisseur as SOLDE,courrielfournisseur as COURRIEL from Fournisseur where nomfournisseur like '%" + value + "%'";

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlSelect);
            FournisseurDataSet = new DataSet();
            SqlAdapter.Fill(FournisseurDataSet);
            DGV_Fournisseur.DataSource = FournisseurDataSet.Tables[0];

            if (lastIndex > -1 && DGV_Fournisseur.Rows.Count > 0) DGV_Fournisseur.Rows[Math.Min(lastIndex, DGV_Fournisseur.Rows.Count - 1)].Selected = true;
            updateControls();

        }

        private void ReloadDGVInventaire()
        {
            int lastIndex = -1;
            if (DGV_Inventaire.SelectedRows.Count > 0) lastIndex = DGV_Inventaire.SelectedRows[0].Index;

            SqlCommand SqlSelect = conn.CreateCommand();
            SqlSelect.CommandText = "SELECT idinventaire as ID ,descriptioninventaire as Description,qtestock as QTESTOCK,QteMinimum as QTEMIN," +
                "QteMaximum as QTEMAX from Inventaire WHERE IDFournisseur=" + DGV_Fournisseur.SelectedRows[0].Cells[0].Value.ToString();

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlSelect);
            InventaireDataSet = new DataSet();
            SqlAdapter.Fill(InventaireDataSet);
            DGV_Inventaire.DataSource = InventaireDataSet.Tables[0];

            if (lastIndex > -1 && DGV_Inventaire.Rows.Count > 0) DGV_Inventaire.Rows[Math.Min(lastIndex, DGV_Inventaire.Rows.Count - 1)].Selected = true;
            updateControls();
        }
        private void ReloadDGVInventaire(string value)
        {
            int lastIndex = -1;
            if (DGV_Inventaire.SelectedRows.Count > 0) lastIndex = DGV_Inventaire.SelectedRows[0].Index;

            SqlCommand SqlSelect = conn.CreateCommand();
            SqlSelect.CommandText = "SELECT idinventaire as ID ,descriptioninventaire as Description,qtestock as QTESTOCK,QteMinimum as QTEMIN," +
                "QteMaximum as QTEMAX from Inventaire WHERE IDFournisseur=" + DGV_Fournisseur.SelectedRows[0].Cells[0].Value.ToString() + " and  descriptioninventaire like '%" + value + "%'";

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlSelect);
            InventaireDataSet = new DataSet();
            SqlAdapter.Fill(InventaireDataSet);
            DGV_Inventaire.DataSource = InventaireDataSet.Tables[0];

            if (lastIndex > -1 && DGV_Inventaire.Rows.Count > 0) DGV_Inventaire.Rows[Math.Min(lastIndex, DGV_Inventaire.Rows.Count - 1)].Selected = true;
            updateControls();
        }

        private void ReloadDGVQteMin()
        {
            SqlCommand SqlSelect = conn.CreateCommand();
            SqlSelect.CommandText = "select nomfournisseur as FOURNISSEUR, descriptioninventaire as DESCRIPTION, QteMaximum-QteStock as NBACOMMANDER " +
                "from inventaire i inner join fournisseur f on i.IDFournisseur = f.IDFournisseur where QteStock <= QteMinimum";

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlSelect);
            QteMinDataSet = new DataSet();
            SqlAdapter.Fill(QteMinDataSet);
            DGV_QTE_Minimum.DataSource = QteMinDataSet.Tables[0];
        }

        private void updateControls()
        {
            if (DGV_Fournisseur.RowCount > 0)
            {
                BTN_MODIF_Fournisseur.Enabled = true;
                BTN_SUP_Fournisseur.Enabled = true;
                BTN_AJTER_Inventaire.Enabled = true;
                if (DGV_Inventaire.RowCount > 0)
                {
                    BTN_MODIF_Inventaire.Enabled = true;
                    BTN_SUP_Inventaire.Enabled = true;
                }
                else
                {
                    BTN_MODIF_Inventaire.Enabled = false;
                    BTN_SUP_Inventaire.Enabled = false;
                }
            }
            else
            {
                BTN_MODIF_Fournisseur.Enabled = false;
                BTN_SUP_Fournisseur.Enabled = false;
                BTN_AJTER_Inventaire.Enabled = false;
                BTN_MODIF_Inventaire.Enabled = false;
                BTN_SUP_Inventaire.Enabled = false;
            }
        }

        private void BTN_MODIF_Fournisseur_Click(object sender, EventArgs e)
        {
            FORM_Fournisseur FF = new FORM_Fournisseur();
            FF.Titre = "Modification";
            FF.Id = (int)DGV_Fournisseur.SelectedRows[0].Cells[0].Value;
            FF.Nom = DGV_Fournisseur.SelectedRows[0].Cells[1].Value.ToString();
            FF.Adresse = DGV_Fournisseur.SelectedRows[0].Cells[2].Value.ToString();
            FF.Ville = DGV_Fournisseur.SelectedRows[0].Cells[3].Value.ToString();
            FF.CodePostal = DGV_Fournisseur.SelectedRows[0].Cells[4].Value.ToString();
            FF.Telephone = DGV_Fournisseur.SelectedRows[0].Cells[5].Value.ToString();
            FF.Solde = Double.Parse(DGV_Fournisseur.SelectedRows[0].Cells[6].Value.ToString());
            FF.Courriel = DGV_Fournisseur.SelectedRows[0].Cells[7].Value.ToString();


            if (FF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "update Fournisseur set NomFournisseur = @NomFournisseur,AdFournisseur=@AdFournisseur," +
                    "VilleFournisseur=@VilleFournisseur,CPFournisseur= @CPFournisseur,TelFournisseur=@TelFournisseur," +
                    "SoldeFournisseur=@SoldeFournisseur,CourrielFournisseur=@CourrielFournisseur where idfournisseur = @idfournisseur";
                try
                {
                    SqlCommand sqlmodifier = new SqlCommand(sql, conn);

                    SqlParameter SQLParaNom = new SqlParameter("@NomFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamad = new SqlParameter("@AdFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamVille = new SqlParameter("@VilleFournisseur", SqlDbType.VarChar, 50);  //Ajout
                    SqlParameter SQLParamCP = new SqlParameter("@CPFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamTel = new SqlParameter("@TelFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamSolde = new SqlParameter("@SoldeFournisseur", SqlDbType.Int, 6);
                    SqlParameter SQLParamCourriel = new SqlParameter("@CourrielFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamid = new SqlParameter("@idfournisseur", SqlDbType.Int, 10);

                    SQLParaNom.Value = FF.Nom;
                    SQLParamad.Value = FF.Adresse;
                    SQLParamVille.Value = FF.Ville;
                    SQLParamCP.Value = FF.CodePostal;
                    SQLParamTel.Value = FF.Telephone;
                    SQLParamSolde.Value = FF.Solde;
                    SQLParamCourriel.Value = FF.Courriel;
                    SQLParamid.Value = FF.Id;

                    sqlmodifier.Parameters.Add(SQLParaNom);
                    sqlmodifier.Parameters.Add(SQLParamad);
                    sqlmodifier.Parameters.Add(SQLParamVille);
                    sqlmodifier.Parameters.Add(SQLParamCP);
                    sqlmodifier.Parameters.Add(SQLParamTel);
                    sqlmodifier.Parameters.Add(SQLParamSolde);
                    sqlmodifier.Parameters.Add(SQLParamCourriel);
                    sqlmodifier.Parameters.Add(SQLParamid);

                    sqlmodifier.ExecuteNonQuery();

                    ReloadDGVFournisseur();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Le fournisseur ne doit pas contenir d'inventaire.", "Erreur 547", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void BTN_SUP_Fournisseur_Click(object sender, EventArgs e)
        {
            DialogResult Confirmation = MessageBox.Show("Voulez-vous vraiment effacer cette entrée ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Confirmation == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    SqlParameter paramNomDivision = new SqlParameter("@IDFournisseur", SqlDbType.Int, 10);
                    paramNomDivision.Value = (int)DGV_Fournisseur.SelectedRows[0].Cells[0].Value;
                    string strDelete = "Delete from Fournisseur Where IDFournisseur =@IDFournisseur";
                    SqlCommand sqlDelete = new SqlCommand(strDelete, conn);

                    sqlDelete.Parameters.Add(paramNomDivision);
                    sqlDelete.ExecuteNonQuery();
                    ReloadDGVFournisseur();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Le fournisseur ne doit pas contenir d'inventaire.", "Erreur 547", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void BTN_AJTER_Inventaire_Click(object sender, EventArgs e)
        {
            FORM_Inventaire FI = new FORM_Inventaire();
            FI.Titre = "Ajout";
            FI.conn = this.conn;
            if (FI.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "insert into Inventaire (DescriptionInventaire,IDFournisseur,QteStock,QteMinimum,QteMaximum)" +
                    " VALUES(@DescriptionInventaire,@IDFournisseur,@QteStock,@QteMinimum,@QteMaximum)";
                try
                {
                    SqlCommand sqlAjout = new SqlCommand(sql, conn);

                    SqlParameter SQLParaDesc = new SqlParameter("@DescriptionInventaire", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamIDF = new SqlParameter("@IDFournisseur", SqlDbType.Int);
                    SqlParameter SQLParamStock = new SqlParameter("@QteStock", SqlDbType.Int);
                    SqlParameter SQLParamMin = new SqlParameter("@QteMinimum", SqlDbType.Int);
                    SqlParameter SQLParamMax = new SqlParameter("@QteMaximum", SqlDbType.Int);

                    SQLParaDesc.Value = FI.Description;
                    SQLParamIDF.Value = FI.IDFournisseur;
                    SQLParamStock.Value = FI.QteStock;
                    SQLParamMin.Value = FI.QteMinimum;
                    SQLParamMax.Value = FI.QteMaximum;

                    sqlAjout.Parameters.Add(SQLParaDesc);
                    sqlAjout.Parameters.Add(SQLParamIDF);
                    sqlAjout.Parameters.Add(SQLParamStock);
                    sqlAjout.Parameters.Add(SQLParamMin);
                    sqlAjout.Parameters.Add(SQLParamMax);

                    sqlAjout.ExecuteNonQuery();

                    ReloadDGVInventaire();
                    ReloadDGVQteMin();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BTN_MODIF_Inventaire_Click(object sender, EventArgs e)
        {
            FORM_Inventaire FI = new FORM_Inventaire();
            FI.conn = this.conn;
            FI.Titre = "Modification";
            FI.ID = (int)DGV_Inventaire.SelectedRows[0].Cells[0].Value;
            FI.Description = DGV_Inventaire.SelectedRows[0].Cells[1].Value.ToString();
            FI.IDFournisseur = DGV_Fournisseur.SelectedRows[0].Cells[0].Value.ToString() + " - " + DGV_Fournisseur.SelectedRows[0].Cells[1].Value.ToString();
            FI.QteStock = Double.Parse(DGV_Inventaire.SelectedRows[0].Cells[2].Value.ToString());
            FI.QteMinimum = Double.Parse(DGV_Inventaire.SelectedRows[0].Cells[3].Value.ToString());
            FI.QteMaximum = Double.Parse(DGV_Inventaire.SelectedRows[0].Cells[4].Value.ToString());

            if (FI.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "update inventaire set DescriptionInventaire = @DescriptionInventaire, IDFournisseur = @IDFournisseur," +
                    "QteStock = @QteStock, QteMinimum = @QteMinimum, QteMaximum = @QteMaximum where IDInventaire = @IDInventaire";
                try
                {
                    SqlCommand sqlModifier = new SqlCommand(sql, conn);

                    SqlParameter SQLParaDesc = new SqlParameter("@DescriptionInventaire", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamIDF = new SqlParameter("@IDFournisseur", SqlDbType.Int);
                    SqlParameter SQLParamStock = new SqlParameter("@QteStock", SqlDbType.Int);
                    SqlParameter SQLParamMin = new SqlParameter("@QteMinimum", SqlDbType.Int);
                    SqlParameter SQLParamMax = new SqlParameter("@QteMaximum", SqlDbType.Int);
                    SqlParameter SQLParamID = new SqlParameter("@IDInventaire", SqlDbType.Int, 10);

                    SQLParaDesc.Value = FI.Description;
                    SQLParamIDF.Value = Int32.Parse(FI.IDFournisseur);
                    SQLParamStock.Value = FI.QteStock;
                    SQLParamMin.Value = FI.QteMinimum;
                    SQLParamMax.Value = FI.QteMaximum;
                    SQLParamID.Value = FI.ID;

                    sqlModifier.Parameters.Add(SQLParaDesc);
                    sqlModifier.Parameters.Add(SQLParamIDF);
                    sqlModifier.Parameters.Add(SQLParamStock);
                    sqlModifier.Parameters.Add(SQLParamMin);
                    sqlModifier.Parameters.Add(SQLParamMax);
                    sqlModifier.Parameters.Add(SQLParamID);

                    sqlModifier.ExecuteNonQuery();

                    ReloadDGVInventaire();
                    ReloadDGVQteMin();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BTN_SUP_Inventaire_Click(object sender, EventArgs e)
        {
            DialogResult Confirmation = MessageBox.Show("Voulez-vous vraiment effacer cette entrée ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Confirmation == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    SqlParameter paramIDInventaire = new SqlParameter("@IDInventaire", SqlDbType.Int, 10);
                    paramIDInventaire.Value = (int)DGV_Inventaire.SelectedRows[0].Cells[0].Value;
                    string strDelete = "Delete from Inventaire Where IDInventaire =@IDInventaire";
                    SqlCommand sqlDelete = new SqlCommand(strDelete, conn);

                    sqlDelete.Parameters.Add(paramIDInventaire);
                    sqlDelete.ExecuteNonQuery();
                    ReloadDGVInventaire();
                    ReloadDGVQteMin();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void DGV_Fournisseur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ReloadDGVInventaire();
        }

        private void TB_RECHERCHE_Inventaire_TextChanged(object sender, EventArgs e)
        {
            if (TB_RECHERCHE_Inventaire.Text != "")
                ReloadDGVInventaire(TB_RECHERCHE_Inventaire.Text);
            else
                ReloadDGVInventaire();
        }

        private void TSMI_LIST_Clients_Click(object sender, EventArgs e)
        {
            FORM_Lister FL = new FORM_Lister();
            FL.Text = "Tous les clients";
            FL.codeListe = 0;
            FL.conn = this.conn;
            FL.ShowDialog();
        }

        private void TSMI_LIST_Factures_Click(object sender, EventArgs e)
        {
            FORM_Lister FL = new FORM_Lister();
            FL.Text = "Toutes les factures";
            FL.codeListe = 1;
            FL.conn = this.conn;
            FL.ShowDialog();
        }

        private void TSMI_LIST_CL_Factures_Click(object sender, EventArgs e)
        {
            FORM_Lister FL = new FORM_Lister();
            FL.Text = "Toutes les factures d'un client";
            FL.codeListe = 2;
            FL.conn = this.conn;
            FL.ShowDialog();
        }

        private void TSMI_Dangereux_Click(object sender, EventArgs e)
        {
            FORM_Dangereux FD = new FORM_Dangereux();
            FD.Text = "Lister les produits dangereux";
            FD.codeListe = 0;
            FD.ShowDialog();
        }

        private void TSMI_NonDangereux_Click(object sender, EventArgs e)
        {
            FORM_Dangereux FD = new FORM_Dangereux();
            FD.Text = "Lister les produits non dangereux";
            FD.codeListe = 1;
            FD.ShowDialog();
        }

        private void TSMI_Tout_Click(object sender, EventArgs e)
        {
            FORM_Dangereux FD = new FORM_Dangereux();
            FD.Text = "Lister tous les produits";
            FD.codeListe = 2;
            FD.ShowDialog();
        }
    }
}