using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Runtime.Serialization;


namespace Modèle
{
    /// <summary>
    /// Classe des Associations
    /// Contient une liste de membres et d'événements.
    /// </summary>
    [DataContract]
    public class Association
    {
        /// <summary>
        /// Liste des membres de l'association.
        /// </summary>
        [DataMember]
        public ObservableCollection<Membre> Membres { get; private set; }

        /// <summary>
        /// Liste d'événements de l'association.
        /// </summary>
        [DataMember]
        public ObservableCollection<Evenement> ListeEvenements { get; private set; }

        /// <summary>
        /// Nom de l'association
        /// </summary>
        [DataMember]
        public string Nom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Image { get; set; }

        /// <summary>
        /// Constructeur de la classe Association.
        /// </summary>
        /// <param name="nom"></param>
        public Association(string nom,string image)
        {
            Nom = nom;
            Image = image;
            Membres = new ObservableCollection<Membre>();
            ListeEvenements = new ObservableCollection<Evenement>();
        }

        /// <summary>
        /// Méthode d'ajout d'un événement dans la liste d'événements de l'association.
        /// </summary>
        /// <param name="evenement"></param>
        public void AjouterEvenement(Evenement evenement)
        {
            if (ListeEvenements.Contains(evenement))  
                throw new Exception("Cet événement existe dejà");
            //Si la liste d'evenements de l'association contient déjà l'événement passé en paramètre, une exception est levé.
            else
                ListeEvenements.Add(evenement);
            //Sinon l'événement est ajouté.
        }

        /// <summary>
        /// Methode de suppression d'un événement dans la liste d'événements de l'association.
        /// </summary>
        /// <param name="evenement"></param>
        public void SupprimerUnEvenement(Evenement evenement)
        {
            if (ListeEvenements.Contains(evenement)) 
                ListeEvenements.Remove(evenement);
            //Si l'événement passé en paramètre existe dans la liste des événements de l'association : il est alors supprimé
            else
                throw new Exception("Cet evenement ne peut pas être supprime car il n'existe pas dans la liste.");
            //Sinon une exception est levé.
        }

        /// <summary>
        /// Methode d'ajout d'un membre dans la liste de membre de l'association.
        /// </summary>
        /// <param name="membre"></param>
        public void AjouterUnMembre(Membre membre)
        {
            if (Membres.Contains(membre))
                throw new Exception("Ce membre figure dejà dans la liste des Membres de l'association.");
            //Si le membre passé en paramètre existe dans la liste de membres de l'association, une exception est levé.
            else
                Membres.Add(membre); //Sinon il est ajouté à la liste des membres.
        }

        /// <summary>
        /// Methode de suppression d'un membre dans la liste de membre de l'association.
        /// </summary>
        /// <param name="membre"></param>
        public void SupprimerMembre(Membre membre)
        {
            if (Membres.Contains(membre)) 
                Membres.Remove(membre);
            //Si le membre passé en paramètre existe dans la liste des membres il est alors supprimé.
            else
                throw new Exception("Ce membre n'existe pas pour être supprimé.");
            
        }

        /// <summary>
        /// Methode d'ajout d'une tache dans la liste des taches de l'événement passé en paramètre.
        /// </summary>
        /// <param name="evenement"></param>
        /// <param name="tache"></param>
        public void AjouterUneTache(Evenement evenement, Tache tache)
        {
            if (ListeEvenements.Contains(evenement)) //Je vérifie si l'événement passé en paramètres existe dans la liste des evenements.
                if (!evenement.Taches.Contains(tache)) //Si la tache existe pas dans la liste de Taches de l'evenement passé en paramètres.
                    evenement.Taches.Add(tache); //Il est alors ajouté.
                else
                    throw new Exception("Cette tache existe deja et ne peut donc être ajoutée");
            else
                throw new Exception("Cet événement n'existe pas.");
        }

        /// <summary>
        /// Methode de suppression d'une tache dans la liste des taches de l'événement passé en paramètre.
        /// </summary>
        /// <param name="evenement"></param>
        /// <param name="tache"></param>
        public void SupprimerUneTache(Evenement evenement, Tache tache)
        {
            if (ListeEvenements.Contains(evenement)) 
                if (evenement.Taches.Contains(tache)) //Si la liste des tâches de l'événement contient la tache passé en param
                        evenement.Taches.Remove(tache); //Elle est supprimée de la liste des tâches de l'événement.
                else
                    throw new Exception("Cette tache n'existe pas et ne peut donc être modifiée.");
            else
                throw new Exception("Cet evenement n'existe pas.");
        }

        /// <summary>
        /// Methode d'ajout d'un participant à la liste des participants de la tache passée en paramètre.
        /// Cette tache fait partie de la liste de taches de l'événement passé en paramètre.
        /// </summary>
        /// <param name="membre"></param>
        /// <param name="tache"></param>
        /// <param name="evenement"></param>
        public void AjouterUnParticipant(Membre membre, Tache tache, Evenement evenement)
        {
            if (Membres.Contains(membre)) 

                if (ListeEvenements.Contains(evenement))

                    if (evenement.Taches.Contains(tache))

                        if (tache.membresParticipants.Contains(membre)) //Je vérifie si le membre figure déjà dans la liste des participants de la tâche afin de lever une exception.

                            throw new Exception("Ce membre figure déjà dans la liste des participants");
                        else
                            tache.membresParticipants.Add(membre); //Sinon le membre passé en paramètre devient un participant à la tâche passée en paramètres.
                    else
                        throw new Exception($"Cette tâche n'existe pas pour que  {membre} y participe");
                else
                    throw new Exception("L'événement aucquel vous voulez ajouter un participant n'existe pas");
            else
                throw new Exception("Le membre n'existe pas.");
        }

        /// <summary>
        /// Méthode d'ajout d'un participant à la liste des participants de la tache passée en paramètre.
        /// Cette tache fait partie de la liste de taches de l'événement passé en paramètre.
        /// </summary>
        /// <param name="membre"></param>
        /// <param name="tache"></param>
        /// <param name="evenement"></param>
        public void SupprimerUnParticipant(Membre membre, Tache tache, Evenement evenement)
        {
            if (Membres.Contains(membre)) //Verifier que le membre existe dans la liste de Membres de l'association 
                if (ListeEvenements.Contains(evenement)) //Verifier que l'événement qui contient les Taches existe.
                    if (evenement.Taches.Contains(tache)) //verifier que la tache existe parmis les Taches a faire pour l'événement
                        if (tache.membresParticipants.Contains(membre))
                        {
                            tache.membresParticipants.Remove(membre); // tester si les Membres d'une tache se supprime automatiquement avec la supression d'une tache ! 
                            evenement.Taches.Remove(tache);
                        }
                        else
                            throw new Exception("Ce membre ne participe pas à la tâche pour être supprimé des participants.");
                    else
                        throw new Exception($"Cette tâche n'existe pas pour que  {membre} y participe");
                else
                    throw new Exception("L'événement aucquel vous voulez ajouter un participant n'existe pas");
            else
                throw new Exception("Le membre n'existe pas.");
        }

        /// <summary>
        /// Methode réecrite qui retourne une chaine de caractères décrivant l'association, ses événements et ses membres.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"L'association : {Nom} organise les événements suivants :\n");
            foreach (Evenement e in ListeEvenements)            
                sb.Append($"{e}\n");            
            sb.Append("Elle contient les Membres suivants : \n");
            foreach (Membre m in Membres)            
                sb.Append($"{m}");            
            return sb.ToString();
        }
    }
}
