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
    public partial class FORM_Lister : Form
    {
        //---------- VARIABLES
        public SqlConnection conn = null;
        public int codeListe = -1;
        // codeListe: 0 -- Clients
        //            1 -- Factures
        //            2 -- Factures d'un client


        public FORM_Lister()
        {
            InitializeComponent();
        }

        private void FORM_Lister_Load(object sender, EventArgs e)
        {
            if (codeListe == 2)
            {
                remplirCB();
                CB_Client.Visible = true;
            }
            lister();
        }

        private void remplirCB()
        {
            SqlCommand SqlSelect = conn.CreateCommand();
            SqlSelect.CommandText = "SELECT NomClient FROM Client";
            using (SqlDataReader SqlReader = SqlSelect.ExecuteReader())
            {
                while (SqlReader.Read())
                {
                    CB_Client.Items.Add(SqlReader.GetString(0));
                }
            }
            CB_Client.SelectedIndex = CB_Client.Items.Count - 1;
        }

        private void lister()
        {
            switch (codeListe)
            {
                case 0:
                    listerClients();
                    break;
                case 1:
                    listerFactures();
                    break;
                case 2:
                    listerClientFact();
                    break;
            }
        }

        private void listerClients()
        {
            MonDataSet monDataSet = new MonDataSet();
            SqlCommand maCommande = new SqlCommand();
            maCommande.CommandText = "listerClients";
            maCommande.CommandType = CommandType.StoredProcedure;
            maCommande.Connection = conn;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(maCommande);
            dataAdapter.Fill(monDataSet, "Item");
            if (DGV_Liste.BindingContext[monDataSet].Count > 0)
            {
                BindingSource source = new BindingSource(monDataSet, "Item");
                DGV_Liste.DataSource = source;
            }
            else
                MessageBox.Show("Il n'y a pas de clients");
        }

        private void listerFactures()
        {
            MonDataSet monDataSet = new MonDataSet();
            SqlCommand maCommande = new SqlCommand();
            maCommande.CommandText = "listerFactures";
            maCommande.CommandType = CommandType.StoredProcedure;
            maCommande.Connection = conn;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(maCommande);
            dataAdapter.Fill(monDataSet, "Item");
            if (DGV_Liste.BindingContext[monDataSet].Count > 0)
            {
                BindingSource source = new BindingSource(monDataSet, "Item");
                DGV_Liste.DataSource = source;
            }
            else
                MessageBox.Show("Il n'y a pas de factures");
        }

        private void listerClientFact()
        {
            MonDataSet monDataSet = new MonDataSet();
            SqlCommand maCommande = new SqlCommand();
            maCommande.CommandText = "listerClientFact";
            maCommande.CommandType = CommandType.StoredProcedure;
            maCommande.Connection = conn;
            maCommande.Parameters.Add(new SqlParameter("@NomClient", SqlDbType.VarChar, 50)).Direction = ParameterDirection.Input;
            maCommande.Parameters["@NomClient"].Value = CB_Client.Text;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(maCommande);
            dataAdapter.Fill(monDataSet, "Item");
            if (DGV_Liste.BindingContext[monDataSet].Count > 0)
            {
                BindingSource source = new BindingSource(monDataSet, "Item");
                DGV_Liste.DataSource = source;
            }
            else
                MessageBox.Show("Il n'y a pas de factures");
        }

        private void CB_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            lister();
        }
    }
}
