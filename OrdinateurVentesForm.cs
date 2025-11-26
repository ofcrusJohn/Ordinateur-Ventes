using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransactionNS;


namespace Ordinateur_Ventes
{
    //ELimane test de commit 
    public partial class VoitureVentesForm : Form
    {

        // Déclaration des variables de classe
        private Transaction oTransaction;



        public VoitureVentesForm()
        {
            InitializeComponent();
        }

        #region Initialisation
        private void VoitureVentesForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialiser l'instance de Transaction
                oTransaction = new Transaction();

                // Peupler la ComboBox des vendeurs
                vendeurComboBox.Items.AddRange(oTransaction.GetVendeurs());

                // Peupler la ComboBox des ordinateurs
                ordinateursComboBox.Items.AddRange(oTransaction.GetOrdinateurs());

                // Définir les sélections par défaut
                if (vendeurComboBox.Items.Count > 0)
                    vendeurComboBox.SelectedIndex = 0;

                if (ordinateursComboBox.Items.Count > 0)
                    ordinateursComboBox.SelectedIndex = 0;

                // Définir la date courante par défaut
                dateTextBox.Text = DateTime.Now.ToShortDateString();

                // Mettre à jour les prix initiaux
                MettreAJourPrix();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Erreur de sélection: {ex.Message}", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Fichier non trouvé: {ex.Message}", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Met à jour les prix lorsqu'un ordinateur est sélectionné
        /// </summary>
        private void MettreAJourPrix()
        {
            try
            {
                if (ordinateursComboBox.SelectedIndex >= 0)
                {
                    // Obtenir le prix de base
                    decimal prixBase = oTransaction.GetPrix(ordinateursComboBox.SelectedIndex);

                    // Calculer le prix avec taxe (15%)
                    decimal prixAvecTaxe = prixBase * 1.15m;

                    // Afficher les prix
                    PrixSaisieLabel.Text = prixBase.ToString("C2", new CultureInfo("en-CA"));
                    totalPrixSaisieLabel.Text = prixAvecTaxe.ToString("C2", new CultureInfo("en-CA"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du calcul du prix: {ex.Message}", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }

}
