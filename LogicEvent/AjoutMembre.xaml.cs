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
    /// Logique d'interaction pour AjoutMembre.xaml
    /// </summary>
    public partial class AjoutMembre : Window
    {

        
        Manager Man => (App.Current as App).LeManager; //Propriété calculée du manager.
        private string img1;
        public AjoutMembre()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ComboRoles.ItemsSource = Enum.GetValues(typeof(Role)); //Je récupère les valeurs du type Enum et je les définis à la propriété ItemsSource de ma Combo Box "ComboRoles"
        }

        /// <summary>
        /// Méthode qui est appelée quand on clique sur le bouton retour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            Close(); //Ferme la fenêtre courante.
        }
        /// <summary>
        /// Méthode qui est appelée quand on clique sur le bouton valider l'ajout du membre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Valider(object sender, RoutedEventArgs e)
        {
            if (Nom.Text == null || ComboRoles.SelectedValue == null) //Si le texte et la valeur selectionnée dans la combobox sont nulls.
            {
                MessageBox.Show("Le nom ou le rôle ne peut être null ou constitué de caractères vides.", "Impossible", MessageBoxButton.OK, MessageBoxImage.Warning); //Une messageBox est affichée.
            }
            else if (img1 == null || Numero.Text == null) //Si l'image ou le numero de téléphone sont nulls 
            {
                MessageBox.Show("Veuillez selectionner une image ou bien le numéro ne peut être null ou constitué de caractères vides.", "Impossible", MessageBoxButton.OK, MessageBoxImage.Warning); 
                //Une messageBox est affichée.
            }


            else //Sinon je récupère les valeurs saisies dans les différentes TextBox.
            {
                string prenom = Prenom.Text.ToString();
                string nom = Nom.Text.ToString();
                string image = img1;
                Role role1 = (Role)ComboRoles.SelectedValue;
                string description = Description.Text.ToString();
                string numTel = Numero.Text.ToString();
                string mail = Mail.Text.ToString();

                Membre m = new Membre(prenom, nom, role1, description, numTel, image, mail); //Je crée un Membre m avec les informations récupérées.
                Man.AssociationSelectionne.AjouterUnMembre(m); //J'ajoute le membre à la liste des membres de l'association.
                Man.SauvegarderFichier(); //Je sauvegarde le fichier
                Close(); //Je ferme la fenêtre courante
            }
        }
        /// <summary>
        /// Méthode appelée quand on clique sur l'icone modifier un membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modifier(object sender, RoutedEventArgs e)
        {
            Man.SauvegarderFichier(); //Appel de la méthode de sauvegarde.
            Close(); //Ferme la fenêtre courante.
        }       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog //On ouvre une boite de dialogue qui invite l'utilisateur à choisir un fichier.
            {
                InitialDirectory = @"C:\Users\Public\Pictures", //Définit le répértoire d'images par défaut
                DefaultExt = ".jpg | .gif | .png" //Définit les filtres d'extensions des images
            };

            bool? result = dialog.ShowDialog();  //On voit si le dialogue a été affiché 
            if (result == true) //Si oui
            {
            
                img1 = dialog.FileName; //Set du FileName à img1.
                img.Source = new BitmapImage(new Uri(img1, UriKind.Absolute)); //On récupère l'image source de l'image 
            }
        }
    }
    
}
