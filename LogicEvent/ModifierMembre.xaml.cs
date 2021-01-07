using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour ModifierMembre.xaml
    /// </summary>
    public partial class ModifierMembre : Window
    {
        /// <summary>
        /// Propriété calculée Man
        /// </summary>
        private readonly Manager Man = (App.Current as App).LeManager;

        /// <summary>
        /// variable Membre servant de sauvegarde dans le cas où l'utilisateur souhaite annuler ses changements
        /// </summary>
        private readonly Membre membreEnCours;
        string img1;
        string image;

        public ModifierMembre()
        {
            InitializeComponent();
            ComboRoles.ItemsSource = Enum.GetValues(typeof(Role)); //Je récupère les valeurs du type Enum et je les définis à la propriété ItemsSource de ma Combo Box "ComboRoles"
            membreEnCours = Man.CreateCopy2();
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton retour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Retour(object sender, RoutedEventArgs e)
        {
            int pos = Man.AssociationSelectionne.Membres.IndexOf(Man.MembreSelectionne);
            Man.AssociationSelectionne.Membres[pos] = membreEnCours;
            Man.MembreSelectionne = membreEnCours;
            Close();
        }

        /// <summary>
        /// Méthode qui est appelée quand on clique sur le bouton modifier d'un membre. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Modifier(object sender, RoutedEventArgs e)
        {
            if (Nom.Text == null || ComboRoles.SelectedValue == null)//Si le texte et la valeur selectionnée dans la combobox sont nulls.            
                MessageBox.Show("Le nom ou le rôle ne peut être null ou constitué de caractères vides.", "Impossible", MessageBoxButton.OK, MessageBoxImage.Warning); //Une message box est affichée.            
            if (img1 != null) //Si img n'est pas nulle
            {
                image = img1;
                Man.MembreSelectionne.Image = image; //Set l'image du MembreSelectionne par la nouvelle image.
            }
            // L'appel de la méthode SauvegarderFichier() permet de sauvegarder les modifications qui ont été saisies. Puis ça ferme la fenêtre courante.
            Man.SauvegarderFichier();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
