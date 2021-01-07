using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// <summary>
    /// Logique d'interaction pour ModifTache.xaml
    /// </summary>
    public partial class Evenements : Window
    {
        public Manager Man => (App.Current as App).LeManager; //Propriété Calculée sur le manager.
        public Evenements()
        {
            InitializeComponent();
            string img = Man.AssociationSelectionne.Image;
            Image.Source= new BitmapImage(new Uri(@img, UriKind.RelativeOrAbsolute));
            AffichageEvenements.DataContext = Man; //Set du Man  comme  DataContext de la ListBox "AffichageEvenements" 
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Event_MouseUp(object sender, MouseButtonEventArgs e) //Evenement MouseUp sur un evenement.
        {
            if (DetailsEvent.IsVisible)  //Si le UC "DetailsEvent" is Visible
                DetailsEvent.Visibility = Visibility.Hidden;  //On set la Visibily à Hidden.
            else
            {
                DetailsEvent.DataContext = Man.EvenementSelectionne; //Sinon on set Man.EvenementSelectionne comme datacontext du user control et on met la visibily à visible.
                DetailsEvent.Visibility = Visibility.Visible; 
            }
        }

        /// <summary>
        /// Méthode qui est appelée quand on clique sur l'icône des membres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Membre(object sender, RoutedEventArgs e) 
        {
            FenetreMembres membre = new FenetreMembres(); //On instancie une nouvelle fenêtre FenêtresMembres on l'affiche et on ferme la fenêtre courante.
            membre.Show(); 
            this.Close();
        }
        /// <summary>
        /// Méthode qui est appelée quand on clique sur l'icone "ajouter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddEvent(object sender, RoutedEventArgs e) 
        {
            AjoutEvent ajout = new AjoutEvent();

            ajout.Show();
            ajout.DataContext = Man;

            //On instancie une fenêtre AjoutEvent, on l'affiche et on set le Man comme DataContext à cette dernière.
        }
        /// <summary>
        /// Méthode appelée quand on clique sur le bouton d'accueil dans le menu. Elle instancie une feneêtre Accueil, l'affiche et ferme la fenêtre courante.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Accueil(object sender, RoutedEventArgs e)
        {
            Accueil acc = new Accueil();
            acc.Show();
            Close();
        }
        /// <summary>
        /// Méthode appelée quand la selection de la comboBox est changée. On downcast le sender en ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = (sender as ComboBox); //DownCast du sender en ComboBox 
            Man.TriEvent(((TextBlock)c.SelectedValue).Text); //Appel de la méthode tri du Man et lui passe en paramètres la valeur selectionnée dans la combobox transtypée en un string.
        }

        private void ComboBox_Background(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = (sender as ComboBox); //DownCast du sender en ComboBox 

            if ("AliceBlue" == ((TextBlock)c.SelectedValue).Text)
            {
                border1.Background = Brushes.AliceBlue;
                border2.Background = Brushes.AliceBlue;
                border3.Background = Brushes.AliceBlue;
                AffichageEvenements.Background = Brushes.AliceBlue;
            }
            if ("LightCoral" == ((TextBlock)c.SelectedValue).Text)
            {
                border1.Background = Brushes.LightCoral;
                border2.Background = Brushes.LightCoral;
                border3.Background = Brushes.LightCoral;
                AffichageEvenements.Background = Brushes.LightCoral;
            }
            if ("LemonChiffon" == ((TextBlock)c.SelectedValue).Text)
            {
                border1.Background = Brushes.LemonChiffon;
                border2.Background = Brushes.LemonChiffon;
                border3.Background = Brushes.LemonChiffon;
                AffichageEvenements.Background = Brushes.LemonChiffon;
            }
        }
    }
}

