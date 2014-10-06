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
    public partial class FORM_Rapport : Form
    {
        public FORM_Rapport()
        {
            InitializeComponent();
        }

        // ---------- VARIABLES
        public SqlConnection conn = null;
        public int codeRapport = -1;
        // codeRapport: 0 -- Fournisseurs
        //              1 -- Fournisseurs (publipostage)
        //              2 -- Fournisseurs (produits)
        //              3 -- Fournisseurs (quantité minimum)
    }
}
