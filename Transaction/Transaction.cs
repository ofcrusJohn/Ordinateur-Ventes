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
                    // Compter le nombre de lignes
                    List<string> modeles = new List<string>();
                    List<decimal> prix = new List<decimal>();

                    string ligne;
                    while ((ligne = reader.ReadLine()) != null)
                    {
                        string[] parties = ligne.Split(';');
                        if (parties.Length >= 2)
                        {
                            modeles.Add(parties[0].Trim());
                            prix.Add(decimal.Parse(parties[1].Trim(), CultureInfo.GetCultureInfo("en-CA")));
                        }
                    }

                    tOrdinateurs = modeles.ToArray();
                    tPrix = prix.ToArray();
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

        /// <summary>
        /// Obtient le prix pour un ordinateur spécifique (par nom)
        /// </summary>
        /// <param name="ordinateur">Ordinateur sous forme de chaîne</param>
        /// <returns>Prix correspondant</returns>
        public decimal GetPrix(string ordinateur)
        {
            int index = Array.IndexOf(tOrdinateurs, ordinateur);

            if (index == -1)
            {
                throw new ArgumentException("Ordinateur invalide.", nameof(ordinateur));
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

        /// <summary>
        /// Constructeur avec paramètres pour initialiser une transaction complète
        /// </summary>
        public Transaction(string nom, string date, string vendeur, string ordinateur, decimal prix)
        {
            // Génération automatique de l'ID
            idInt = new Random().Next(1000, 9999);

            // Initialisation des tableaux et messages d'erreurs
            InitMessagesErreurs();
            InitVendeurs();
            InitOrdinateurs();

            // Initialisation via les propriétés (avec validation)
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
        }

        #endregion

        #region Méthodes d'enregistrement

        /// <summary>
        /// Enregistre la transaction courante dans le système
        /// </summary>
        public void Enregistrer()
        {
            try
            {
                // Incrémenter le nombre de transactions
                NombreTransactions++;

                // Écrire dans le fichier Transactions.data
                string ligne = $"{Nom};{DateTransaction.ToShortDateString()};{Vendeur};{Ordinateur};{Prix.ToString("F2", CultureInfo.GetCultureInfo("en-CA"))}";

                using (StreamWriter writer = new StreamWriter("..\\..\\Data\\Transactions.data", true, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine(ligne);
                }

                Console.WriteLine("=== Transaction Enregistrée ===");
                Console.WriteLine($"ID: {ID}");
                Console.WriteLine($"Client: {Nom}");
                Console.WriteLine($"Date: {DateTransaction.ToShortDateString()}");
                Console.WriteLine($"Vendeur: {Vendeur}");
                Console.WriteLine($"Ordinateur: {Ordinateur}");
                Console.WriteLine($"Prix total: {Prix.ToString("C", CultureInfo.GetCultureInfo("en-CA"))}");
                Console.WriteLine("==============================");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'enregistrement : {ex.Message}");
            }
        }

        /// <summary>
        /// Enregistre une transaction avec les paramètres fournis
        /// </summary>
        public void Enregistrer(string nom, string date, string vendeur, string ordinateur, decimal prix)
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

            // Appel de la méthode Enregistrer sans paramètre
            Enregistrer();
        }
        /** Pour la personne qui doit faire sa
        /// <summary>
        /// Affiche le contenu du fichier Transactions.data
        /// </summary>
        public void Imprimer()
        {
            try
            {
                string chemin = "..\\..\\Data\\Transactions.data";
                if (!File.Exists(chemin))
                {
                    throw new FileNotFoundException("Aucune transaction enregistrée.");
                }

                Console.WriteLine("=== LISTE DES TRANSACTIONS ===");
                Console.WriteLine("Client | Date | Vendeur | Ordinateur | Prix");
                Console.WriteLine("--------------------------------------------");

                decimal totalVentes = 0;
                int count = 0;
                using (StreamReader reader = new StreamReader(chemin, System.Text.Encoding.UTF8))
                {
                    string ligne;
                    while ((ligne = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(ligne);
                        string[] parties = ligne.Split(';');
                        if (parties.Length >= 5 && decimal.TryParse(parties[4], NumberStyles.Any, CultureInfo.GetCultureInfo("en-CA"), out decimal prix))
                        {
                            totalVentes += prix;
                            count++;
                        }
                    }
                }

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Total des ventes: {totalVentes.ToString("C", CultureInfo.GetCultureInfo("en-CA"))}");
                Console.WriteLine($"Nombre de transactions: {count}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'impression : {ex.Message}");
            }
        }*/

        #endregion
    }
}