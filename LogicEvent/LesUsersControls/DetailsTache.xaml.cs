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

namespace LogicEvent
{
    /// <summary>
    /// Logique d'interaction pour DetailsTache.xaml
    /// </summary>
    public partial class DetailsTache : UserControl
    {
        Manager man => (App.Current as App).LeManager; //Propriété calculée sur le Manager
        public DetailsTache()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Méthode qui est lancée quand on clique sur le bouton modifier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            ModifTache modifierTache = new ModifTache();

            modifierTache.DataContext = (Tache)this.DataContext;
            modifierTache.Show();
            
            
        }

        /// <summary>
        /// Méthode qui est appelée quand on clique sur le bouton supprimer d'une tâche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Etes vous sur de vouloir supprimer?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) //Affichage d'une message box qui confirme la suppression ou non.
            {
               man.AssociationSelectionne.SupprimerUneTache(man.EvenementSelectionne, (Tache)this.DataContext); //Appel de la méthode de suppression de la tâche en lui passant en paramètre l'evenement selectionné dans le Manager, et le data context transtypé en Tache
                man.SauvegarderFichier(); //On sauvegarde le fichier.
               this.Visibility = Visibility.Collapsed; //On met la visibilité à collapsed.
            }
        }
    }
}
