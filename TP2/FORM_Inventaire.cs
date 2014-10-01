using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    public partial class FORM_Inventaire : Form
    {
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

        public int IDFournisseur
        {
            get
            {
                string[] TAB_Num = CB_ID_Fournisseur.Text.Split('-');
                return Int32.Parse(TAB_Num[0].Trim());
            }
            set
            {
                CB_ID_Fournisseur.Text = value.ToString();
            }
        }

        public int QteStock
        {
            get
            {
                return Int32.Parse(TB_QTE_Stock.Text);
            }
            set
            {
                TB_QTE_Stock.Text = value.ToString();
            }
        }

        public int QteMinimum
        {
            get
            {
                return Int32.Parse(TB_QTE_Minimum.Text);
            }
            set
            {
                TB_QTE_Minimum.Text = value.ToString();
            }
        }

        public int QteMaximum
        {
            get
            {
                return Int32.Parse(TB_QTE_Maximum.Text);
            }
            set
            {
                TB_QTE_Maximum.Text = value.ToString();
            }
        }

        void updateControls()
        {
            if (Description != "" && IDFournisseur != -1 && QteStock != null && QteMinimum != null && QteMaximum != null)
                BTN_OK.Enabled = true;
            else
                BTN_OK.Enabled = false;
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

        public void ajouterFournisseurs(string value)
        {
            CB_ID_Fournisseur.Items.Add(value);
        }
    }
}