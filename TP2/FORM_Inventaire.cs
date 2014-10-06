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
    public partial class FORM_Inventaire : Form
    {
        public SqlConnection conn = null;
        public string Titre
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public int ID
        {
            get
            {
                return Int32.Parse(TB_ID_Inventaire.Text);
            }
            set
            {
                TB_ID_Inventaire.Text = value.ToString();
            }
        }

        public string Description
        {
            get
            {
                return TB_Description.Text;
            }
            set
            {
                TB_Description.Text = value;
            }
        }

        public string IDFournisseur
        {
            get
            {
                string[] TAB_Num = CB_ID_Fournisseur.Text.Split('-');
                return TAB_Num[0].Trim();
            }
            set
            {
                CB_ID_Fournisseur.Text = value.ToString();
            }
        }

        public double QteStock
        {
            get
            {
                return Double.Parse(TB_QTE_Stock.Text);
            }
            set
            {
                TB_QTE_Stock.Text = value.ToString();
            }
        }

        public double QteMinimum
        {
            get
            {
                return Double.Parse(TB_QTE_Minimum.Text);
            }
            set
            {
                TB_QTE_Minimum.Text = value.ToString();
            }
        }

        public double QteMaximum
        {
            get
            {
                return Double.Parse(TB_QTE_Maximum.Text);
            }
            set
            {
                TB_QTE_Maximum.Text = value.ToString();
            }
        }

        private void updateControls()
        {
            if (Description != "" && CB_ID_Fournisseur.Text != "" && TB_QTE_Stock.Text != "" && TB_QTE_Minimum.Text != "" && TB_QTE_Maximum.Text != "")
                BTN_OK.Enabled = true;
            else
                BTN_OK.Enabled = false;
        }

        private string buildMessageErreur()
        {
            string message = "La quantité";
            int count = 0;
            // Minimum
            if (QteMinimum >= QteMaximum)
            {
                message += " minimum";
                count++;
            }

            // Stock
            if (QteStock > QteMaximum)
            {
                if (message.Trim().Length == 10)
                    message += " stock";
                else
                    message += ", stock";
                count++;
            }
            // Maximum
            if (QteMaximum <= QteMinimum || QteMaximum < QteStock)
            {
                if (message.Trim().Length == 10)
                    message += " maximum";
                else
                    message += " et maximum";
                count++;
            }
            // Length
            if (count == 0)
                message = "";
            else if (count == 1)
                message += " est inadéquate";
            else if (count > 1)
                message += " sont inadéquates"; 

            return message;
        }

        private void TB_Description_TextChanged(object sender, EventArgs e)
        {
            updateControls();
        }

        private void CB_ID_Fournisseur_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateControls();
        }

        private void TB_QTE_Stock_TextChanged(object sender, EventArgs e)
        {
            updateControls();
        }

        private void TB_QTE_Minimum_TextChanged(object sender, EventArgs e)
        {
            updateControls();
        }

        private void TB_QTE_Maximum_TextChanged(object sender, EventArgs e)
        {
            updateControls();
        }

        public FORM_Inventaire()
        {
            InitializeComponent();
        }
        private void FORM_Inventaire_Load(object sender, EventArgs e)
        {
            SqlCommand SqlSelect = conn.CreateCommand();
            SqlSelect.CommandText = "SELECT idfournisseur,nomfournisseur FROM fournisseur";
            using (SqlDataReader SqlReader = SqlSelect.ExecuteReader())
            {
                while (SqlReader.Read())
                {
                    CB_ID_Fournisseur.Items.Add(SqlReader.GetInt32(0).ToString() + " - " + SqlReader.GetString(1));
                }
            }
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            if (buildMessageErreur() != "")
            {
                MessageBox.Show(buildMessageErreur());
                this.DialogResult = DialogResult.None;
            }
        }

        private void TB__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}