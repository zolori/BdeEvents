//using System;
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

namespace LogicEvent
{
    /// <summary>
    /// Logique d'interaction pour MembreUC.xaml
    /// </summary>
    public partial class MembreUC : UserControl
    {
        public Manager Man => (App.Current as App).LeManager; //Propriété calculée sur le manager

        public MembreUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton supprimer d'un membre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment supprimer ce membre ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Man.AssociationSelectionne.SupprimerMembre((Membre)this.DataContext); //Appel de la méthode de suppression d'un membre et on lui passe en paramètres le datacontext courant transtypé en Membre.
            }
        }
        /// <summary>
        /// Méthode qui est appelée quand on clique sur le bouton modifier d'un membre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ModifMembre(object sender, RoutedEventArgs e)
        {
            Man.MembreSelectionne = (Membre)DataContext; //On dit que le MembreSelectionne c'est le dataContext courant transtypé en Membre
            ModifierMembre modif = new ModifierMembre(); //On instancie une nouvelle fenêtre et on l'affiche.
            modif.Show();

            modif.DataContext = Man;
        }
    }
}
