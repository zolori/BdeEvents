using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Modèle
{
    /// <summary>
    /// Classe des événements
    /// </summary>
    [DataContract] //La classe Eenement est sérialisable.
    public class Evenement : IEquatable<Evenement>, INotifyPropertyChanged
    { //La classe implémente deux interfaces.
        /// <summary>
        /// Pour implémenter l'interface INotifyPropertyChanged il faut avoir cet evenement, il est invoqué à chaque fois qu'une propriété change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
      /// Méthode qui invoque l'événement PropertyChanged, elle prend en paramètre le nom de la propriété qui va changer. "CallerMemberName" permet d'obtenir le type de
        /// la propriété qui appelle cettte méthode dans son set.
        /// </summary 
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Image de l'événement.
        /// </summary>
        [DataMember]
        public string Image { get; set; }

        /// <summary>
        /// Nom de l'événement
        /// </summary>
        [DataMember]
        public string Nom
        {
            get { return nom; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le nom de l'événement ne peut être nul, vide ou constitué de caractères vides.");
                else if (nom != value)
                {
                    nom = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string nom;

        /// <summary>
        /// Date à laquelle se déroule l'événement.
        /// </summary>
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value == null)
                    throw new ArgumentException("La date doit être spécifiée.");
                else if (date != value)
                {
                    date = value;
                    NotifyPropertyChanged(); //Appel de la méthode afin que tout les éléments qui sont bindés sur la date "entendent" l'événement.
                }
            }
        }
        private DateTime date;

        /// <summary>
        /// Lieu où se déroule l'événement.
        /// </summary>
        [DataMember]
        public string Lieu
        {
            get { return lieu; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le lieu de l'evenement ne peut être nul, vide ou constitué de caractères vides.");
                else if (lieu != value)
                {
                    lieu = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string lieu;

        /// <summary>
        /// Description de l'événement.
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string description;

        /// <summary>
        /// Prix d'entrée de l'événement.
        /// </summary>
        [DataMember]
        public float Prix
        {
            get { return prix; }
            set
            {
                if (float.IsNaN(value))
                    throw new ArgumentException("Le lieu de l'evenement ne peut être nul, vide ou constitué de caractères vides.");
                else if (prix != value)
                {
                    prix = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private float prix;

        /// <summary>
        /// Liste des taches à accomplir pour l'événement.
        /// </summary>
        [DataMember]
        public ObservableCollection<Tache> Taches
        {
            get { return taches; }
            set
            {
                if (taches != value)
                { taches = value; NotifyPropertyChanged(); }
            }
        }
        public ObservableCollection<Tache> taches;

        /// <summary>
        /// Identificateur de l'événement.
        /// Il est unique.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// constructeur de classe.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="date"></param>
        /// <param name="lieu"></param>
        /// <param name="prix"></param>
        /// <param name="image"></param>
        /// <param name="description"></param>
        public Evenement(string nom, DateTime date, string lieu, float prix, string image, string description)
        {
            Nom = nom;
            Date = date;
            Lieu = lieu;
            Prix = prix;
            Image = image;
            Description = description;
            Taches = new ObservableCollection<Tache>();
            Guid = Guid.NewGuid();
        }

        /// <summary>
        /// Constructeur de classe.
        /// Utiliser lors de la création d'un événement, afin de pouvoir remplir sa liste de taches sans avoir encore validé sa création.
        /// </summary>
        /// <param name="image"></param>
        public Evenement(string image)
        {
            Image = image;
            Date = DateTime.Now.Date;
            Taches = new ObservableCollection<Tache>();
            Guid = Guid.NewGuid();
        }

        /// <summary>
        /// Protocole d'égalité de base.
        /// Appelé généralement si les 2 objets sont de type différents.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, null)) return false;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as Evenement);
        }

        /// <summary>
        /// Protocole d'égalité sur 2 événements.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Evenement other)
        {
            return Guid.Equals(other.Guid);
        }

        /// <summary>
        /// Retourne un id
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Methode décrivant l'événement.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" {Nom} : Il va avoir lieu à {Lieu} à {Date}. ";
        }
    }
}

