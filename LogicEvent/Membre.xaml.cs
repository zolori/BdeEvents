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
using Test;

namespace LogicEvent
{
    /// <summary>
    /// Logique d'interaction pour Membre.xaml
    /// </summary>
    public partial class Membre : Window
    {
        public Association association { get; set; }
        public Membre()
        {
            InitializeComponent();
            this.association = Stub.CreerUneAssociation();
            AffichageMembres.DataContext = association;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Evenements events = new Evenements();
            events.Show();
            this.Close();
        }

        private void Button_AddMembre(object sender, RoutedEventArgs e)
        {
            AjoutMembre ajout = new AjoutMembre();
            ajout.Show();
        }
    }
}
