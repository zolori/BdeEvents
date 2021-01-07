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
    /// Classe des taches.
    /// </summary>
    [DataContract]
    public class Tache : IEquatable<Tache>, INotifyPropertyChanged
    {
        /// <summary>
        /// Nom de la tache.
        /// </summary>
        [DataMember]
        public string NomT
        {
            get
            {
                return nomT;
            }
            set
            { 
                nomT = value;
                NotifyPropertyChanged();
            }
            }

        public string nomT;

        /// <summary>
        /// description de la tache.
        /// </summary>
        [DataMember]
        public string DescriptionT
        {
            get
            {
                return descriptionT;
            }
            set
            {
                descriptionT = value;
                NotifyPropertyChanged();
            }
        }
        public string descriptionT;
        /// <summary>
        /// Booléen indiquant si la tache est terminée.
        /// </summary>
       

        /// <summary>
        /// Liste de membre participants à la réalisation de la tache.
        /// </summary>
        [DataMember]
        public ObservableCollection<Membre> MembresParticipants 
        { 
            get
            {
                return membresParticipants;
            }
            set
            {
                membresParticipants = value;
                NotifyPropertyChanged();
            } 

        }
        public ObservableCollection<Membre> membresParticipants;
        /// <summary>
        /// Constructeur de Tache.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="description"></param>
        public Tache(string nom, string description)
        {
            NomT = nom;
            DescriptionT = description;
            membresParticipants = new ObservableCollection<Membre>(); 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Protocole d'égalité de base.
        /// Appelé généralement si les 2 objets sont de type différent.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == null) return false;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as Tache);
        }

        /// <summary>
        /// protocole d'égalité sur 2 taches.
        /// </summary>
        public bool Equals(Tache other)
        {
            return NomT.Equals(other.NomT);
        }

        /// <summary>
        /// retourne un id.
        /// </summary>
        public override int GetHashCode()
        {
            return NomT.GetHashCode();
        }

        /// <summary>
        /// Retourne une string décrivant la tache.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" * {NomT}  : {DescriptionT} ";
        }

    }

   



}
