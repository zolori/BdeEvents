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
namespace LogicEvent
{
    /// <summary>
    /// Logique d'interaction pour ModifTache.xaml
    /// </summary>
    public partial class ModifTache : Window
    {
        //Propriété calculée sur le Manager.
        Manager Man => (App.Current as App).LeManager;

        public ModifTache()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ListeMembres.DataContext = Man.AssociationSelectionne; //Set Man.AssociationSelectionne comme DataContext de la liste Box "ListeMembres"
            Man.ParticipantsSelectionne = new List<Membre>();
        }

        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Méthodée appelée quand on clique sur le bouton valider l'ajout d'une tâche.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modifier(object sender, RoutedEventArgs e)
        {
            Man.TacheSelectionne.membresParticipants.Clear();
            foreach (Membre m in Man.ParticipantsSelectionne)
                Man.AssociationSelectionne.AjouterUnParticipant(m, Man.TacheSelectionne, Man.EvenementSelectionne);
            Man.SauvegarderFichier();
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
