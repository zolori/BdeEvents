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
using Data;

namespace LogicEvent
{
    /// <summary>
    /// Logique d'interaction pour FenetreMembres.xaml
    /// </summary>
    public partial class FenetreMembres : Window
    { /// <summary>
    /// Propriété calculée Manager.
    /// </summary>
        public Manager Man => (App.Current as App).LeManager;  //Propriété calculée sur le Manager

        public FenetreMembres()
        {
            InitializeComponent();
            AffichageMembres.DataContext = Man; //Set du DataContexte de la listeBox AffichagesMembres au Manager.
            string img = Man.AssociationSelectionne.Image;
            Image.Source = new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Evenements events = new Evenements(); //On instancie une fenêtre Evenements, on l'affiche et on close la fenêtre courante.
            events.Show();
            this.Close();
        }

        private void Button_Accueil(object sender, RoutedEventArgs e)
        {
            //On instancie une fenêtre Accueil on l'affiche et on close la fenêtre courante 
            Accueil acc = new Accueil();
            acc.Show();
            Close();
        }

        private void Button_AddMembre(object sender, RoutedEventArgs e)
        {
            AjoutMembre ajout = new AjoutMembre(); //On instancie une fenêtre ajout et on l'affiche.
            ajout.Show();
        }
        /// <summary>
        /// Méthode appelée quand la selection de la comboBox est changée;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            ComboBox c = (sender as ComboBox); //On downCast le sender en ComboxBox et on la récupère dans une ComboBox c
            Man.TriMembre(((TextBlock)c.SelectedValue).Text); //Appel de la méthode TriMembre. et on lui passe en paramètres la valeur selectionnée de la combobox transtypée en TextBlock.
        }
    }
}
