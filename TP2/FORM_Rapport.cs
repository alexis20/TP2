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


        private void listerTousFournisseurs()
        {
            try
            {
                string sql = "SELECT IDFournisseur, NomFournisseur, AdFournisseur, VilleFournisseur, CPFournisseur, TelFournisseur, " +
                             "SoldeFournisseur, CourrielFournisseur FROM Fournisseur";
                string path = "..\\..\\CRYSTAL_Fournisseurs.rpt";
                SqlDataAdapter monDataAdapter = new SqlDataAdapter();
                ReportDocument monRapport = new ReportDocument();

                monDataSet = new DataSet("Fournisseurs");
                monDataAdapter.SelectCommand = new SqlCommand(sql, conn);
                monDataAdapter.Fill(monDataSet, "Fournisseurs");

                monRapport.Load(path);
                monRapport.SetDataSource(monDataSet.Tables["Fournisseurs"]);

                CRV_Rapport.ReportSource = monRapport;
                CRV_Rapport.Refresh();

                monDataSet.Clear();
                monDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
