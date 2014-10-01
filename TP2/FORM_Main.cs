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
        FORM_Fournisseur FF;
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
            FF = new FORM_Fournisseur();
            FI = new FORM_Inventaire();
        }

        private void UpdateControls()
        {

        }

        private void Connection()
        {
            String connexionChaine;
            connexionChaine = "Data Source=DAREN511-ASUS\\SQLEXPRESS2012;Initial Catalog=MaNouvelleBd;User ID=MonAutreConnexion;Password=MonAutreConnexion";
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

                    SQLParaNom.Value = FF.TB_Nom.Text;
                    SQLParamad.Value = FF.TB_Adresse.Text;
                    SQLParamVille.Value = FF.TB_Ville.Text;
                    SQLParamCP.Value = FF.TB_CP.Text;
                    SQLParamTel.Value = FF.TB_Tel.Text;
                    SQLParamSolde.Value = Int32.Parse(FF.TB_Solde.Text);
                    SQLParamCourriel.Value = FF.TB_Courriel.Text;

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
    }
}
