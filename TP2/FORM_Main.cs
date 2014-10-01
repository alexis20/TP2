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

        FORM_Inventaire FI;

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
            FI = new FORM_Inventaire();
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
            }
            TSMI_Connexion.Enabled = false;
            TSMI_Deconnexion.Enabled = true;
        }

        private void BTN_AJTER_Fournisseur_Click(object sender, EventArgs e)
        {
            FORM_Fournisseur FF = new FORM_Fournisseur();
            FF.Titre = "Ajouter";
            if(FF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "insert into Fournisseur (NomFournisseur,AdFournisseur,VilleFournisseur,CPFournisseur,TelFournisseur,SoldeFournisseur,CourrielFournisseur)" +
                    " VALUES(@NomFournisseur,@AdFournisseur,@VilleFournisseur,@CPFournisseur,@TelFournisseur,@SoldeFournisseur,@CourrielFournisseur)";
                try
                {
                    SqlCommand sqlAjout = new SqlCommand(sql, conn);

                    SqlParameter SQLParaNom = new SqlParameter("@NomFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamad = new SqlParameter("@AdFournisseur", SqlDbType.VarChar, 50);
                    SqlParameter SQLParamVille= new SqlParameter("@VilleFournisseur", SqlDbType.VarChar, 50);  //Ajout
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
            SqlSelect.CommandText = "SELECT nomfournisseur,adfournisseur,villefournisseur,cpfournisseur,telfournisseur,soldefournisseur,courrielfournisseur from Fournisseur";

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlSelect);
            FournisseurDataSet = new DataSet();
            SqlAdapter.Fill(FournisseurDataSet);
            DGV_Fournisseur.DataSource = FournisseurDataSet.Tables[0];

            if (lastIndex > -1 && DGV_Fournisseur.Rows.Count > 0) DGV_Fournisseur.Rows[Math.Min(lastIndex, DGV_Fournisseur.Rows.Count - 1)].Selected = true;

            updateControls();
        }

        private void updateControls()
        {

        }

        private void BTN_MODIF_Fournisseur_Click(object sender, EventArgs e)
        {

        }
    }
}
