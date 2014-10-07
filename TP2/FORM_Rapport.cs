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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace TP2
{
    public partial class FORM_Rapport : Form
    {
        public FORM_Rapport()
        {
            InitializeComponent();
        }

        // ---------- VARIABLES
        public SqlConnection conn = null;
        private DataSet monDataSet = null;
        public int codeRapport = -1;
        // codeRapport: 0 -- Fournisseurs
        //              1 -- Fournisseurs (publipostage)
        //              2 -- Fournisseurs (produits)
        //              3 -- Fournisseurs (quantité minimale)


        private void FORM_Rapport_Load(object sender, EventArgs e)
        {
            switch (codeRapport)
            {
                case 0:
                    listerTousFournisseurs();
                    break;
                case 1:
                    listerPourPublipostage();
                    break;
                case 2:
                    listerAvecProduits();
                    break;
                case 3:
                    listerQteMin();
                    break;
                default:
                    MessageBox.Show("Aucun rapport à afficher");
                    break;
            }
        }

        private void listerTousFournisseurs()
        {
            try
            {
                string sql = "SELECT * FROM Fournisseur ORDER BY IDFournisseur";
                SqlDataAdapter monDataAdapter = new SqlDataAdapter();
                ReportDocument monRapport = new ReportDocument();

                monDataSet = new DataSet("dataFournisseurs");
                monDataAdapter.SelectCommand = new SqlCommand(sql, conn);
                monDataAdapter.Fill(monDataSet, "dataFournisseurs");

                if (this.BindingContext[monDataSet, "dataFournisseurs"].Count > 0)
                {
                    string path = "..\\..\\CRYSTAL_Fournisseurs.rpt";
                    monRapport.Load(path);
                    monRapport.SetDataSource(monDataSet.Tables["Fournisseurs"]);
                    CRV_Rapport.ReportSource = monRapport;

                    CRV_Rapport.Refresh();
                    monDataSet.Clear();
                    monDataAdapter.Dispose();
                }
                else
                    MessageBox.Show("Il n'y a aucun fournisseur disponible");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void listerPourPublipostage()
        {
            try
            {
                string sql = "SELECT * FROM Fournisseur ORDER BY IDFournisseur";
                SqlDataAdapter monDataAdapter = new SqlDataAdapter();
                ReportDocument monRapport = new ReportDocument();

                monDataSet = new DataSet("dataFournisseurs");
                monDataAdapter.SelectCommand = new SqlCommand(sql, conn);
                monDataAdapter.Fill(monDataSet, "dataFournisseurs");

                if (this.BindingContext[monDataSet, "dataFournisseurs"].Count > 0)
                {
                    string path = "..\\..\\CRYSTAL_Publipostage.rpt";
                    monRapport.Load(path);
                    monRapport.SetDataSource(monDataSet.Tables["Fournisseurs"]);
                    CRV_Rapport.ReportSource = monRapport;

                    CRV_Rapport.Refresh();
                    monDataSet.Clear();
                    monDataAdapter.Dispose();
                }
                else
                    MessageBox.Show("Il n'y a aucun fournisseur disponible");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void listerAvecProduits()
        {
            try
            {
                string sql = "SELECT F.IDFournisseur, NomFournisseur, DescriptionInventaire, QteStock, QteMinimum, QteMaximum " +
                             " FROM Fournisseur F INNER JOIN Inventaire I ON F.IDFournisseur = I.IDFournisseur ORDER BY F.IDFournisseur";
                SqlDataAdapter monDataAdapter = new SqlDataAdapter();
                ReportDocument monRapport = new ReportDocument();

                monDataSet = new DataSet("dataFournisseurs");
                monDataAdapter.SelectCommand = new SqlCommand(sql, conn);
                monDataAdapter.Fill(monDataSet, "dataFournisseurs");

                if (this.BindingContext[monDataSet, "dataFournisseurs"].Count > 0)
                {
                    string path = "..\\..\\CRYSTAL_Produits.rpt";
                    monRapport.Load(path);
                    monRapport.SetDataSource(monDataSet.Tables["Fournisseurs"]);
                    CRV_Rapport.ReportSource = monRapport;

                    CRV_Rapport.Refresh();
                    monDataSet.Clear();
                    monDataAdapter.Dispose();
                }
                else
                    MessageBox.Show("Il n'y a aucun produit disponible");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void listerQteMin()
        {
            try
            {
                string sql = "SELECT F.IDFournisseur, NomFournisseur, DescriptionInventaire, QteMaximum-QteStock " +
                "FROM Inventaire I INNER JOIN Fournisseur F ON I.IDFournisseur = F.IDFournisseur WHERE QteStock <= QteMinimum" +
                " ORDER BY F.IDFournisseur";
                SqlDataAdapter monDataAdapter = new SqlDataAdapter();
                ReportDocument monRapport = new ReportDocument();

                monDataSet = new DataSet("dataFournisseurs");
                monDataAdapter.SelectCommand = new SqlCommand(sql, conn);
                monDataAdapter.Fill(monDataSet, "dataFournisseurs");

                if (this.BindingContext[monDataSet, "dataFournisseurs"].Count > 0)
                {
                    string path = "..\\..\\CRYSTAL_QteMin.rpt";
                    monRapport.Load(path);
                    monRapport.SetDataSource(monDataSet.Tables["Fournisseurs"]);
                    CRV_Rapport.ReportSource = monRapport;

                    CRV_Rapport.Refresh();
                    monDataSet.Clear();
                    monDataAdapter.Dispose();
                }
                else
                    MessageBox.Show("Il n'y a aucun produit disponible");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
