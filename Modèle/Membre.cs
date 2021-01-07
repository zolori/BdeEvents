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
    /// Classe des membres, elle est sérialisable.
    /// </summary>
    [DataContract]
    public class Membre : IEquatable<Membre>, INotifyPropertyChanged
    {
        /// <summary>
        /// Pour implémenter l'interface INotifyPropertyChanged il faut avoir cet evenement, il est invoqué à chaque fois qu'une propriété change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode qui invoque l'événement PropertyChanged, elle prend en paramètre le nom de la propriété qui va changer. "CallerMemberName" permet d'obtenir le type de 
        /// la propriété qui appelle cettte méthode dans son set.
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Identificateur de l'événement.
        /// Il est unique.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Nom du membre.
        /// </summary>
        [DataMember]
        public string Nom
        {
            get { 
                return nom; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le nom du membre ne peut être nul, vide ou constitué de caractères vides");
                else if (nom != value)
                {
                    nom = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string nom;

        /// <summary>
        /// Propriété : prenom du membre.
        /// </summary>
        [DataMember]
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le prénom du membre ne peut être nul, vide ou constitué de caractères vides");
                else
                {
                    prenom = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string prenom;

        /// <summary>
        /// Role du membre dans l'association.
        /// </summary>
        [DataMember]
        public Role Role
        {
            get { return role; }
            set
            {
                if (!Enum.IsDefined(typeof(Role), value))
                    throw new ArgumentException("Le rôle saisi doit être un rôle qui existe dans la liste Enum.");
                else
                {
                    role = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Role role;

        /// <summary>
        /// Photo de profil du membre.
        /// </summary>
        [DataMember]
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                NotifyPropertyChanged();
            }
        }
        public string image;

        /// <summary>
        /// Description du membre.
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }
        public string description;

        /// <summary>
        /// Numéro de téléphone du membre.
        /// </summary>
        [DataMember]
        public string TelephoneNum
        {
            get { return tel; }
            set
            {
                tel = value;
                NotifyPropertyChanged();
            }
        }
        public string tel;

        /// <summary>
        /// Adresse éléctronique du membre.
        /// </summary>
        [DataMember]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged();
            }
        }
        public string email;

        /// <summary>
        /// Constructeur de Membre.
        /// </summary>
        /// <param name="prenom"></param>
        /// <param name="nom"></param>
        /// <param name="role"></param>
        /// <param name="description"></param>
        /// <param name="numeroTel"></param>
        /// <param name="image"></param>
        /// <param name="email"></param>
        public Membre(string prenom, string nom, Role role, string description, string numeroTel, string image, string email)
        {
            Prenom = prenom;
            Nom = nom;
            Role = role;
            Description = description;
            TelephoneNum = numeroTel;
            Image = image;
            Email = email;
            Guid = Guid.NewGuid();
        }

        /// <summary>
        /// Protocole d'égalité de base.
        /// Appelé généralement si les 2 objets sont de types différents.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == null) return false;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as Membre);
        }
        /// <summary>
        /// Protocole d'égalité sur des types Membre.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Membre other)
        {
            return Guid.Equals(other.Guid);
        }

        /// <summary>
        /// Retourne un id.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Retourne une string décrivant le membre.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" {Prenom} {Nom} qui a le rôle de {Role} dans l'association.\n";
        }
    }
}

