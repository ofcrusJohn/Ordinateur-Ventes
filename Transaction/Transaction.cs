/*
    Programmeur:   Jean De La Croix Haba, Jerry Bostel Dountio Douanla, Ibrahima Elimane Dosso
    Date:           Novembre 2025

    Solution:     VentesOrdinateurs
    Projet:       VentesOrdinateurs.csproj

    Namespace:    TransactionNS
    
    Description:  Classe métier pour la gestion des 
                    transactions de vente d'ordinateurs
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TransactionNS
{
    /// <summary>
    /// Classe métier représentant une transaction de vente d'ordinateurs
    /// </summary>
    public class Transaction
    {
        #region Variables statiques pour tenir compte des numéros de transaction
        public static int NombreTransactions = 0;
        #endregion

        #region Énumération des codes d'erreurs
        private enum CodesErreurs
        {
            NomObligatoire,
            DateObligatoire,
            VendeurObligatoire,
            VendeurInvalide,
            OrdinateurObligatoire,
            OrdinateurInvalide,
            PrixInvalide,
            ErreurIndeterminee
        }
        #endregion

        #region Tableau des messages d'erreurs
        private string[] tMessagesErreurs;

        /// <summary>
        /// Initialise les messages d'erreurs correspondant aux codes d'erreurs
        /// </summary>
        private void InitMessagesErreurs()
        {
            tMessagesErreurs = new string[Enum.GetValues(typeof(CodesErreurs)).Length];

            tMessagesErreurs[(int)CodesErreurs.NomObligatoire] = "Le nom du client est obligatoire.";
            tMessagesErreurs[(int)CodesErreurs.DateObligatoire] = "La date est obligatoire.";
            tMessagesErreurs[(int)CodesErreurs.VendeurObligatoire] = "Le vendeur est obligatoire.";
            tMessagesErreurs[(int)CodesErreurs.VendeurInvalide] = "Le vendeur sélectionné n'est pas valide.";
            tMessagesErreurs[(int)CodesErreurs.OrdinateurObligatoire] = "L'ordinateur est obligatoire.";
            tMessagesErreurs[(int)CodesErreurs.OrdinateurInvalide] = "L'ordinateur sélectionné n'est pas valide.";
            tMessagesErreurs[(int)CodesErreurs.PrixInvalide] = "Le prix doit être un nombre positif supérieur à zéro.";
            tMessagesErreurs[(int)CodesErreurs.ErreurIndeterminee] = "Une erreur indéterminée s'est produite.";
        }
        #endregion

        #region Champs privés
        private int idInt;
        private string nomStr;
        private DateTime dateTransaction;
        private string vendeurStr;
        private string ordinateurStr;
        private decimal prixDecimal;

        private string[] tVendeurs;
        private string[] tOrdinateurs;
        private decimal[] tPrix;
        #endregion

        #region Initialisation des tableaux
        /// <summary>
        /// Initialise le tableau des vendeurs disponibles
        /// </summary>
        private void InitVendeurs()
        {
            try
            {
                string chemin = "..\\..\\Data\\Vendeurs.data";
                using (StreamReader reader = new StreamReader(chemin, System.Text.Encoding.UTF8))
                {
                    string ligne = reader.ReadLine();
                    int nombre = int.Parse(ligne);
                    tVendeurs = new string[nombre];
                    for (int i = 0; i < nombre; i++)
                    {
                        tVendeurs[i] = reader.ReadLine();
                    }
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Erreur dans le fichier Vendeurs", ex);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("Le fichier Vendeurs n'est pas disponible", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur indéterminée lors du chargement des vendeurs", ex);
            }
        }

        /// <summary>
        /// Initialise le tableau des ordinateurs disponibles
        /// </summary>
        private void InitOrdinateurs()
        {
            try
            {

                string chemin = "..\\..\\Data\\Ordinateurs.data";
                using (StreamReader reader = new StreamReader(chemin, System.Text.Encoding.UTF8))
                {
                    // Lire le nombre d'ordinateurs (première ligne)
                    int nombre = int.Parse(reader.ReadLine());

                    tOrdinateurs = new string[nombre];
                    tPrix = new decimal[nombre];

                    // Lire les données des ordinateurs
                    for (int i = 0; i < nombre; i++)
                    {
                        string ligne = reader.ReadLine();
                        string[] parties = ligne.Split(';');
                        tOrdinateurs[i] = parties[0].Trim();
                        tPrix[i] = decimal.Parse(parties[1].Trim(), CultureInfo.GetCultureInfo("en-CA"));
                    }
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Erreur dans le fichier Ordinateurs", ex);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("Le fichier Ordinateurs n'est pas disponible", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur indéterminée lors du chargement des ordinateurs", ex);
            }
        }
        #endregion

        #region Propriétés avec validation

        /// <summary>
        /// Obtient l'identifiant unique de la transaction (lecture seule)
        /// </summary>
        public int ID
        {
            get { return idInt; }
        }

        /// <summary>
        /// Obtient ou définit le nom du client (obligatoire, non vide)
        /// </summary>
        public string Nom
        {
            get
            {
                return nomStr;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (value != String.Empty)
                    {
                        nomStr = value;
                    }
                    else
                    {
                        throw new ArgumentException(tMessagesErreurs[(int)CodesErreurs.NomObligatoire]);
                    }
                }
                else
                {
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.NomObligatoire]);
                }
            }
        }

        /// <summary>
        /// Obtient ou définit la date de transaction
        /// </summary>
        public DateTime DateTransaction
        {
            get
            {
                return dateTransaction;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.DateObligatoire]);
                }
                dateTransaction = value;
            }
        }

        /// <summary>
        /// Obtient ou définit le vendeur sélectionné
        /// Doit correspondre à un vendeur valide dans le tableau
        /// </summary>
        public string Vendeur
        {
            get
            {
                return vendeurStr;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (Array.IndexOf(tVendeurs, value) != -1)
                    {
                        vendeurStr = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodesErreurs.VendeurInvalide]);
                    }
                }
                else
                {
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.VendeurObligatoire]);
                }
            }
        }

        /// <summary>
        /// Obtient ou définit l'ordinateur sélectionné
        /// Doit correspondre à un ordinateur valide dans le tableau
        /// </summary>
        public string Ordinateur
        {
            get
            {
                return ordinateurStr;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (Array.IndexOf(tOrdinateurs, value) != -1)
                    {
                        ordinateurStr = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodesErreurs.OrdinateurInvalide]);
                    }
                }
                else
                {
                    throw new ArgumentNullException(tMessagesErreurs[(int)CodesErreurs.OrdinateurObligatoire]);
                }
            }
        }

        /// <summary>
        /// Obtient ou définit le prix total de la transaction
        /// Le prix doit être positif et supérieur à zéro
        /// </summary>
        public decimal Prix
        {
            get
            {
                return prixDecimal;
            }
            set
            {
                if (value > 0)
                {
                    prixDecimal = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(tMessagesErreurs[(int)CodesErreurs.PrixInvalide]);
                }
            }
        }

        #endregion

        #region Méthodes auxiliaires

        /// <summary>
        /// Obtient le tableau des vendeurs disponibles
        /// </summary>
        public string[] GetVendeurs()
        {
            return tVendeurs;
        }

        /// <summary>
        /// Obtient le tableau des ordinateurs disponibles
        /// </summary>
        public string[] GetOrdinateurs()
        {
            return tOrdinateurs;
        }

        /// <summary>
        /// Obtient le prix pour un index d'ordinateur spécifique
        /// </summary>
        /// <param name="index">Index de l'ordinateur</param>
        /// <returns>Prix correspondant</returns>
        public decimal GetPrix(int index)
        {
            if (index < 0 || index >= tPrix.Length)
            {
                throw new ArgumentOutOfRangeException("L'index de l'ordinateur est erroné.");
            }

            return tPrix[index];
        }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// Initialise les tableaux et les messages d'erreurs
        /// </summary>
        public Transaction()
        {
            // Génération automatique de l'ID
            idInt = new Random().Next(1000, 9999);

            // Initialisation des tableaux
            InitMessagesErreurs();
            InitVendeurs();
            InitOrdinateurs();
        }

        #endregion

        #region Méthodes d'enregistrement


        /// <summary>
        /// Enregistre une transaction avec les paramètres fournis
        /// </summary>
        public void Enregistrer(string nom, string date, string vendeur, string ordinateur, decimal prix)
        {

            try
            {
                // Initialisation via les propriétés
                Nom = nom;
                Vendeur = vendeur;
                Ordinateur = ordinateur;
                Prix = prix;

                // Validation de la date
                if (!DateTime.TryParse(date, out DateTime dateValide))
                {
                    dateValide = DateTime.Now;
                }
                DateTransaction = dateValide;

                // Incrémenter le nombre de transactions
                NombreTransactions++;

                // Écrire dans le fichier Transactions.data
                string ligne = $"{Nom};{DateTransaction.ToShortDateString()};{Vendeur};{Ordinateur};{Prix.ToString("F2", CultureInfo.GetCultureInfo("en-CA"))}";

                using (StreamWriter writer = new StreamWriter("..\\..\\Data\\Transactions.data", true, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine(ligne);
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'enregistrement : {ex.Message}");
            }
        }
        #endregion

        #region Methode Imprimer
        public void Imprimer()
        {
            try
            {
                string chemin = "..\\..\\Data\\Transactions.data";
                if (!File.Exists(chemin))
                {
                    throw new FileNotFoundException("Aucune transaction enregistrée.");
                }

                Console.WriteLine("========================================== LISTE DES TRANSACTIONS ==========================================="+"\n");
                Console.WriteLine(string.Format(
                    "{0,-20} | {1,-12} | {2,-27} | {3,-20} | {4,10}",
                    "Client", "Date", "Vendeur", "Ordinateur", "Prix"
                ));

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

                decimal totalVentes = 0;
                int count = 0;

                using (StreamReader reader = new StreamReader(chemin, System.Text.Encoding.UTF8))
                {
                    string ligne;
                    while ((ligne = reader.ReadLine()) != null)
                    {
                        string[] p = ligne.Split(';');
                        if (p.Length < 5) continue;

                        string client = p[0];
                        string date = p[1];
                        string vendeur = p[2];
                        string ordinateur = p[3];
                        decimal prix = decimal.Parse(p[4], CultureInfo.GetCultureInfo("en-CA"));

                        totalVentes += prix;
                        count++;

                        // Affichage formaté
                        Console.WriteLine(string.Format(
                            "{0,-20} | {1,-12} | {2,-27} | {3,-20} | {4,10:C2}",
                            client, date, vendeur, ordinateur, prix
                        ));
                    }
                }

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Total des ventes : {totalVentes.ToString("C", CultureInfo.GetCultureInfo("en-CA"))}");
                Console.WriteLine($"Nombre de transactions : {count}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'impression : {ex.Message}");
            }
        }

        #endregion
    }
}