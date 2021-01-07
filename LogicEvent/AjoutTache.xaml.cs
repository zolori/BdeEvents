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
    /// Logique d'interaction pour AjoutTache.xaml
    /// </summary>
    public partial class AjoutTache : Window
    {
        
        Manager Man => (App.Current as App).LeManager; //Propriété calculée sur le Manager.
        public AjoutTache()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ListeMembres.DataContext = Man.AssociationSelectionne; //Set Man.AssociationSelectionne comme DataContext de la liste Box "ListeMembres"
            Man.ParticipantsSelectionne = new List<Membre>(); 

        }
        /// <summary>
        /// Méthode appelée quand on clique sur le bouton de retour. La fenêtre courante est fermée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Méthodée qppelée quand on clique sur le bouton valider l'ajout d'une tâche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Valider(object sender, RoutedEventArgs e)
        {

            //Le texte saisi dans les differentes textbox est récupéré dans des variables de type string.
            string nameTache = nomTache.Text.ToString(); 
            string description = DescriptionTache.Text.ToString();

            Tache tache = new Tache(nameTache, description); //On crée une tâche avec les informations saisies comme paramètres.

            Man.AssociationSelectionne.AjouterUneTache(Man.EvenementSelectionne, tache); //On ajoute cette tâche à l'evenement selectionné.
            foreach (Membre m in Man.ParticipantsSelectionne)
                Man.AssociationSelectionne.AjouterUnParticipant(m, tache, Man.EvenementSelectionne); //On ajoute chaque membre dans la liste "Man.ParticipantsSelectionne" à la liste des participants de la tache "tache"
            Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Cette ligne sert à ce qu'on puisse faire .IsChecked sur le sender
            CheckBox c = (sender as CheckBox);

            bool isChecked = false;

            if (c.IsChecked.HasValue && c.IsChecked.Value) isChecked = true;

            if (isChecked)
                Man.ParticipantsSelectionne.Add((Membre)c.DataContext);
            else
                Man.ParticipantsSelectionne.Remove((Membre)c.DataContext);
        }
    }
}
