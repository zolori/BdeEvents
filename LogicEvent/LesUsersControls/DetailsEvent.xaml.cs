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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modèle;
using Data;

namespace LogicEvent
{
    /// <summary>
    /// Logique d'interaction pour DetailsEvent.xaml
    /// </summary>
    public partial class DetailsEvent : UserControl
    {
        public Manager Man => (App.Current as App).LeManager; //Propriété calculée sur le Manager.

        public DetailsEvent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Méthode qui est appelée quand on clique sur le petit "X" dans le textBlock, la visibilité du UC courant est à hidden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Méthode qui est appelée quand on clique sur le bouton supprimer d'un événement.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Supp(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Etes vous sur de vouloir supprimer?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Man.AssociationSelectionne.SupprimerUnEvenement((Evenement)DataContext); //On appele la fonction SupprimerUnEvenement et on lui passe en paramètres le datacontext transtypé en Evenement)
                Man.SauvegarderFichier(); //On sauvegarde le fichier.
                Visibility = Visibility.Hidden; //Le UC courant disparait. 
            }
        }
        /// <summary>
        /// Méthode qui est appelée quand on clique sur l'icone modifier de l'uc courant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modifier(object sender, RoutedEventArgs e)
        {
            Man.modif = true; //On met le booléen modif à true pour dire qu'il y a une modification en cours.
            AjoutEvent ajout = new AjoutEvent(); //On instancie une nouvelle fenêtre AjoutEvent et on l'affiche.
            ajout.Show();
            Visibility = Visibility.Hidden;

            ajout.DataContext = Man; //On set Man comme DataContext 
        }
    }
}
