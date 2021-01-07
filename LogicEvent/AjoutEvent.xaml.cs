using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Modèle;
using Data;
using System.Collections.ObjectModel;

namespace LogicEvent
{
    public partial class AjoutEvent : Window
    {
        Manager Man => (App.Current as App).LeManager;
        private readonly Evenement EventenCours; // Evenement de sauvegarde pour le bouton retour
        private readonly Evenement evenement; // Evenement crée en avance pour l'ajout de taches
        private readonly bool modif2 = false; //Booléen qui permet de voir si une modif est en cours ou pas.
        public AjoutEvent()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Si modif == true, alors la fenêtre passe en mode modification
            // Le seul changement graphique est le changement de bouton
            if (Man.modif)
            {
                modif2 = true;
                Bouton_Valider.Visibility = Visibility.Hidden; //On met la visibilité à hidden au bouton "valider"
                Bouton_Modifier.Visibility = Visibility.Visible; //On la visibilité à visible au bouton "modifier"
                EventenCours = Man.CreateCopy(); // Crée une copie de l'évent avant modification au cas où, pour le bouton retour
            }
            // Sinon, on entre en mode Ajout d'événement
            else
            {
                Man.EvenementSelectionne = null; // On ne veut rien afficher dans les textbox, donc on enlève tout.

                // On crée un nouvel événement pour pouvoir ajouter des taches dans la liste de taches sans avoir à quitter la page d'abord.
                evenement = new Evenement("https://www.roz-sur-couesnon.fr/wp-content/uploads/2016/03/Evt-770x470.png");
                Man.AssociationSelectionne.AjouterEvenement(evenement);
                // l'ajout de tache se fait sur l'évvénements séléctionné, donc il faut le set avec le nouvel évent crée pour ça.
                Man.EvenementSelectionne = evenement; ;
            }
            Man.modif = false;
        }

        /// <summary>
        /// Sert quand on veut annuler toute modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            if (!modif2) //Si on est pas en mode ajout, evenement n'a pas été créé donc il ne faut pas essayer de le suppriemr de la liste.
                Man.AssociationSelectionne.SupprimerUnEvenement(evenement); //On supprime l'evenement
            // Pour modifier les changements déjà effectuer par l'interface INotifyPropertyChanged, il faut aller chercher l'événement modifié et le set avec l'événement crée pour ça. 
            else
            {
                int pos = Man.AssociationSelectionne.ListeEvenements.IndexOf(Man.EvenementSelectionne);
                Man.AssociationSelectionne.ListeEvenements[pos] = EventenCours;
            }
            // On modifie aussi EvenementSelectionne pour que le datacontexte du détail soit directement à jour.
            Man.EvenementSelectionne = EventenCours;
            Close();

        }

        /// <summary>
        /// Méthode qui est appelée quand on clique sur le bouton valider de l'ajout de l'événement.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton_ValiderAjoutEvent(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Man.EvenementSelectionne.Nom)) //Si le nom ou le lieu est null ou contient des espaces on affiche une message box.
                MessageBox.Show("Le nom ne peut être null ou constitué de caractères vides.", "Impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            { //Sinon on sauvegarde et on ferme la fenêtre courante.
                Man.SauvegarderFichier();
                Close();
            }
        }

        /// <summary>
        /// Méthode qui est appelée quand on clique sur le bouton Modifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modifier(object sender, RoutedEventArgs e)
        {
            //On sauvegarde le fichier et on ferme la fenêtre

            Man.SauvegarderFichier();
            Close();
        }


    }
}
