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
    public partial class FORM_Fournisseur : Form
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
        public int Id
        {
            get
            {
                return Int32.Parse(TB_ID.Text);
            }
            set
            {
                TB_ID.Text = value.ToString() ;
            }
        }
        public string Nom
        {
            get
            {
                return TB_Nom.Text;
            }
            set
            {
                TB_Nom.Text = value;
            }
        }
        public string Adresse
        {
            get
            {
                return TB_Adresse.Text;
            }
            set
            {
                TB_Adresse.Text = value;
            }
        }
        public string Ville
        {
            get
            {
                return TB_Ville.Text;
            }
            set
            {
                TB_Ville.Text = value;
            }
        }
        public string CodePostal
        {
            get
            {
                return TB_CP.Text;
            }
            set
            {
                TB_CP.Text = value;
            }
        }

        public string Telephone
        {
            get
            {
                return TB_Tel.Text;
            }
            set
            {
                TB_Tel.Text = value;
            }
        }
        public double Solde
        {
            get
            {
                return Double.Parse(TB_Solde.Text);
            }
            set
            {
                TB_Solde.Text = value.ToString();
            }
        }
        public string Courriel
        {
            get
            {
                return TB_Courriel.Text;
            }
            set
            {
                TB_Courriel.Text = value;
            }
        }

        public FORM_Fournisseur()
        {
            InitializeComponent();
        }

        private void TB_Solde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void updateControls()
        {
            // Alan est fatiguant en esti
            if (TB_Nom.Text.Trim() == "")
                BTN_OK.Enabled = false;
            else
                BTN_OK.Enabled = true;
        }

        private void TB_Nom_TextChanged(object sender, EventArgs e)
        {
            updateControls();
        }

        private void TB_Solde_TextChanged(object sender, EventArgs e)
        {
            updateControls();
        }

        private void FORM_Fournisseur_Load(object sender, EventArgs e)
        {
            updateControls();
        }
    }
}
