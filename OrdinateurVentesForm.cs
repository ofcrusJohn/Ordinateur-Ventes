using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordinateur_Ventes
{
    public partial class VoitureVentesForm : Form
    {
        public VoitureVentesForm()
        {
            InitializeComponent();
        }
       

        private void VoitureVentesForm_Load(object sender, EventArgs e)
        {
            CultureInfo culture =new CultureInfo("fr-CA");
            dateTextBox.Text = DateTime.Now.ToString("MMMM dd, yyyy",culture);
            dateTextBox.Text = char.ToUpper(dateTextBox.Text[0]) + dateTextBox.Text.Substring(1);
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DateTime date = ValiderDate(dateTextBox.Text);

            MessageBox.Show(date.ToShortDateString());
        }


        private DateTime ValiderDate(string dateTexte)
        {
            DateTime dateValide;


            if (!DateTime.TryParse(dateTexte, out dateValide))
            {
                dateValide = DateTime.Now;
            }

            return dateValide;
        }
    }
}
