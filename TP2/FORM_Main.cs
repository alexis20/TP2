using System;
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


        public FORM_Main()
        {
            InitializeComponent();
        }

        private void TB_RECHERCHE_Fournisseur_TextChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void DGV_Inventaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FORM_Main_Load(object sender, EventArgs e)
        {
            Connection();
            ReloadDGV();
        }

        private void UpdateControls()
        {

        }

        private void Connection()
        {
            String connexionChaine;
            connexionChaine = "Data Source=DAREN511-ASUS\\SQLEXPRESS2012;Initial Catalog=bdOperation;User ID=conOperation;Password=conOperation";
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

                    ReloadDGV();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void TSMI_Connexion_Click(object sender, EventArgs e)
        {
            Connection();
        }

        private void TSMI_Deconnexion_Click(object sender, EventArgs e)
        {
            conn.Close();
            TSMI_Deconnexion.Enabled = false;
            TSMI_Connexion.Enabled = true;
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

        private void ReloadDGV()
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
            updateControlsFournisseur();
        }

        private void updateControlsFournisseur()
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
            FF.Solde = (int)DGV_Fournisseur.SelectedRows[0].Cells[6].Value;
            FF.Courriel = DGV_Fournisseur.SelectedRows[0].Cells[7].Value.ToString();


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
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
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
                    ReloadDGV();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2292)
                    {
                        MessageBox.Show("La division ne doit pas contenir d'équipe.", "Erreur 2292", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void populerIDFournisseurs(FORM_Inventaire FI)
        {
            for (int i = 0; i < DGV_Fournisseur.RowCount; i++)
                FI.ajouterFournisseurs(DGV_Fournisseur.Rows[i].Cells[0].ToString());
        }

        private void BTN_AJTER_Inventaire_Click(object sender, EventArgs e)
        {
            FORM_Inventaire FI = new FORM_Inventaire();
            FI.Titre = "Ajout";
            populerIDFournisseurs(FI);
        }

        private void BTN_MODIF_Inventaire_Click(object sender, EventArgs e)
        {
            FORM_Inventaire FI = new FORM_Inventaire();
            FI.Titre = "Modification";
            populerIDFournisseurs(FI);
        }
    }
}
