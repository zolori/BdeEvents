using Modèle;
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

namespace LogicEvent
{
    /// <summary>
    /// Logique d'interaction pour PartieDroiteAjoutEventUC.xaml
    /// </summary>
    public partial class PartieDroiteAjoutEventUC : UserControl
    {
        public Manager Man => (App.Current as App).LeManager; //propriété calculée 
        public PartieDroiteAjoutEventUC()
        {
            InitializeComponent();
          
        }
        /// <summary>
        /// Méthode appelée quand on clique sur le bouton ajouter une tâche. Une fenêtre AjoutTache est instanciée et affichée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AjoutTache ajout = new AjoutTache();
            ajout.Show();
        }

      /*
        /// <summary>
        /// Quand on clique sur valider, on met à visible la visibily du user control courant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Valider(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed; 
        }*/
        /// <summary>
        /// Méthode qui est lancée quand on clique sur une tâche dans le stack panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(!DetailsTache.IsVisible) //Si le user control DetailsTache n'est pas visible.
            {
                DetailsTache.DataContext = Man.TacheSelectionne; //On set Man.TacheSelectionne comme data context du UC  DetailsTaches
                DetailsTache.Visibility = Visibility.Visible; //On met à visible la visibilité du UC.
            }
            else 
                DetailsTache.Visibility = Visibility.Collapsed;  //Sinon la visibilité est à collapsed.

            if(!AffichageParticipants.IsVisible)  //Si la ListBox AffichageParticipants n'est pas visiblé 
            {
                AffichageParticipants.DataContext = Man.TacheSelectionne; //On set le DataContext
                AffichageParticipants.Visibility = Visibility.Visible; //On met la visibilité à Visible.
            }
            else
                AffichageParticipants.Visibility = Visibility.Collapsed; //Sinon visibilité à collapsed.
        }

        
    }
}
