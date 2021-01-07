using Data;
using Modèle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        Manager Man => (App.Current as App).LeManager; //Propriété calculée sur le manager 
        
        public Accueil()
        {
            InitializeComponent();
            AffichageAssoc.DataContext = Man; //On set Man comme DataContext à la liste box "AffichageAssoc"
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        /// <summary>
        /// Quand on clique sur une association cette méthode est appelée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Evenements events = new Evenements(); //On instancie une fenêtre Evenements 
            // on set Man comme DataContext à la fenêtre events.
            events.DataContext = Man; 
            events.Show(); //On affiche
            this.Close(); //On ferme la fenêtre courante.
        }
    }
}
 