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
                TB_Nom.Text = value.ToString() ;
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
                TB_Nom.Text = value;
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
        public int Solde
        {
            get
            {
                return Int32.Parse(TB_Solde.Text);
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

        private void BTN_OK_Click(object sender, EventArgs e)
        {

        }
    }
}
