using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Modèle
{
    /// <summary>
    /// Classe Manager.
    /// Sert d'intermédiaire entre la vue et le modèle.
    /// </summary>
    [DataContract]
    public class Manager
    {
        /// <summary>
        /// Propriété qui stocke la tâche selectionnée.
        /// </summary>
        public Tache TacheSelectionne { get; set; }

        /// <summary>
        /// Propriété qui stocke l'Evenement courant 
        /// </summary>
        public Evenement EvenementSelectionne { get; set; }

        /// <summary>
        /// Propriété qui stocke le membre courant
        /// </summary>
        public Membre MembreSelectionne { get; set; }

        /// <summary>
        /// ¨Propriété qui stocke l'association courante.
        /// </summary>
        public Association AssociationSelectionne { get; set; }

        /// <summary>
        /// Propriété qui stocke la liste des participants de la tâche courante.
        /// </summary>
        public List<Membre> ParticipantsSelectionne { get; set; }

        /// <summary>
        /// Propriété sur une liste d'associations.
        /// </summary>
        [DataMember]
        public ObservableCollection<Association> Associations { get; set; }

        /// <summary>
        /// Attribut de type IPersistance.
        /// Sert à pouvoir appeler les methodes de l'interface.
        /// </summary>
        IPersistance persistance;

        /// <summary>
        /// Nom de la base de données
        /// </summary>
        public static readonly string NOM = "BDD.json";

        /// <summary>
        /// Booléen qui permet de déterminer si on est en train de modifier l'évent ou non.
        /// </summary>
        public bool modif;

        /// <summary>
        /// Constructeur de Manager qui prend en paramètre un membre de type IPersistance.
        /// </summary>
        /// <param name="pers"></param>
        public Manager(IPersistance pers)
        {
            persistance = pers;

            ChargerFichier();
        }

        /// <summary>
        /// Constructeur de Manager.
        /// Sert uniquement dans le cas où le stub doit servir pour le chargement de nouvelles données.
        /// </summary>
        /// <param name="pers"></param>
        /// <param name="associations"></param>
        public Manager(IPersistance pers, ObservableCollection<Association> associations)
        {
            Associations = associations;
            persistance = pers;
            SauvegarderFichier();
        }

        /// <summary>
        /// Methode utilisant la fonction de chargement de l'interface IPersistance.
        /// </summary>
        public void ChargerFichier()
        {
            Associations = persistance.Charger(NOM);
        }

        /// <summary>
        /// Methode utilisant la fonction de sauvegarde de l'interface IPersistance.
        /// </summary>
        public void SauvegarderFichier()
        {
            persistance.Sauvegarder(NOM, Associations);
        }

        /// <summary>
        /// Trie la liste d'événement de l'association selectionnée selon ce qui est passé en paramètre.
        /// </summary>
        /// <param name="nom"></param>
        public void TriEvent(string nom)
        {
            ObservableCollection<Evenement> listeE = null;

            if (nom == "Prix")
                listeE = new ObservableCollection<Evenement>(AssociationSelectionne.ListeEvenements.OrderBy(Evenement => Evenement.Prix));
            if (nom == "Nom")
                listeE = new ObservableCollection<Evenement>(AssociationSelectionne.ListeEvenements.OrderBy(Evenement => Evenement.Nom));
            if (nom == "Nom (Z-A)")
                listeE = new ObservableCollection<Evenement>(AssociationSelectionne.ListeEvenements.OrderByDescending(Evenement => Evenement.Nom));
            if (nom == "Date")
                listeE = new ObservableCollection<Evenement>(AssociationSelectionne.ListeEvenements.OrderBy(Evenement => Evenement.Date));

            AssociationSelectionne.ListeEvenements.Clear();
            foreach (Evenement e in listeE)
                AssociationSelectionne.ListeEvenements.Add(e);
        }
        /// <summary>
        /// Trie la liste de membre de l'association selectionnée selon ce qui est passé en paramètre.
        /// </summary>
        /// <param name="nom"></param>
        public void TriMembre(string nom)
        {
            ObservableCollection<Membre> listeE = null;

            if (nom == "Nom (Z-A)")
                listeE = new ObservableCollection<Membre>(AssociationSelectionne.Membres.OrderByDescending(Membre => Membre.Nom));
            if (nom == "Nom")
                listeE = new ObservableCollection<Membre>(AssociationSelectionne.Membres.OrderBy(Membre => Membre.Nom));


            AssociationSelectionne.Membres.Clear();
            foreach (Membre e in listeE)
                AssociationSelectionne.Membres.Add(e);
        }
        
        /// <summary>
        /// Crée une copie de l'événement séléctionné et la retourne.
        /// </summary>
        /// <returns></returns>
        public Evenement CreateCopy()
        {
            Evenement EventenCours;
            string description = EvenementSelectionne.Description;
            DateTime date = EvenementSelectionne.Date;
            string lieu = EvenementSelectionne.Lieu;
            string nom = EvenementSelectionne.Nom;
            float prix = EvenementSelectionne.Prix;
            string image = EvenementSelectionne.Image;
            ObservableCollection<Tache> taches = EvenementSelectionne.Taches;
            EventenCours = new Evenement(nom, date, lieu, prix, image, description);
            EventenCours.Taches = taches;

            return EventenCours;
        }

        public Membre CreateCopy2()
        {
            Membre membreEnCours;
            string prenom = MembreSelectionne.Prenom;
            string nom = MembreSelectionne.Nom;
            Role role = MembreSelectionne.Role;
            string desc = MembreSelectionne.Description;
            string tel = MembreSelectionne.TelephoneNum;
            string image = MembreSelectionne.Image;
            string email = MembreSelectionne.Email;
            membreEnCours = new Membre(prenom, nom, role, desc, tel, image, email);

            return membreEnCours;
        }

        public Membre CreateCopyMembre()
        {
            Membre membreEnCours;
            string description = MembreSelectionne.Description;
            string email = MembreSelectionne.Email;
            string nom = MembreSelectionne.Nom;
            Role role = MembreSelectionne.Role;
            string prenom = MembreSelectionne.Prenom;
            string num = MembreSelectionne.TelephoneNum;
            string image = MembreSelectionne.Image;
            ObservableCollection<Tache> taches = EvenementSelectionne.Taches;
            membreEnCours = new Membre(prenom, nom, role, description, num, image, email);

            return membreEnCours;
        }
    }
}
