using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Modèle;



namespace Data
{

    public class Stub
    { /// <summary>
    /// Méthode de création d'une association. Elle retourne une association.
    /// Dans cette méthode des objets de type Membre, Evenement, Tache sont instanciés puis ajoutés à l'association.
    /// </summary>
    /// <returns></returns>
        public static Association CreerUneAssociation1() 
        {
            Association association = new Association("BDE Info", "https://pbs.twimg.com/profile_images/3543569677/588fac9844927df5d388677ca9473d9f_400x400.jpeg");

            //Déclaration et instanciation des membres.
            Membre membre = new Membre("François", "Peralde", Role.President, "Je suis le président", "0893848384", "../images/BradPitt.jpg", "Peralde@gmail.com");
            Membre membre1 = new Membre("Alexandre", "Golfier", Role.ResponsableCommunication, "Je suis le responsable communication entre les BDE", "07869859", "../images/BradPitt.jpg", "Golfier@gmail.com");
            Membre membre2 = new Membre("Yannis", "Etchbest", Role.VicePresident, "Je suis vice président", "0687950453", "https://www.friday-magazine.ch/assets/content/images/Articles-photos-2019/decembre/13/kaia-cheveux/_396xAUTO_fit_top-center_none/GettyImages-1175667994.jpg", "Etchebest@gmail.com");
            Membre membre3 = new Membre("Kamila", "Pitt", Role.Tresorier, "J'ai le rôle de trésorier", "0637884740", "https://www.friday-magazine.ch/assets/content/images/Articles-photos-2019/decembre/13/kaia-cheveux/_396xAUTO_fit_top-center_none/GettyImages-1175667994.jpg", "Pitt@gmail.com");
            Membre membre4 = new Membre("Clara", "Obama", Role.ViceTresorier, "j'ai le role de vice tresorière", "05508713743", "../images/BradPitt.jpg", "Obama@gmail.com");

            //Déclaration et instanciation des evenements.
            Evenement evenement = new Evenement("LaserGame", new DateTime(2020, 11, 05, 17, 30, 00), "Aubière", 22f, "https://img.grouponcdn.com/deal/24sH6M6RmzCc53CYjUhLnRnWZ3NQ/24-1120x672/v1/c700x420.jpg", "Le jeu consiste à mener une guerre fictive entre les différents participants (jusqu'à une trentaine de joueurs) qui sont équipés d'une arme factice disposant d'un pointeur laser ou infrarouge et d'un harnais muni de différents capteurs.");
            Evenement evenement1 = new Evenement("Wei", new DateTime(2020, 11, 05, 8, 0, 0), "Lac-Aydat", 50f, "https://www.pulainfo.hr/wp/wp-content/uploads/2019/05/party-600x400.jpg", "Week end d'intégration dans un camping");
           Evenement evenement2 = new Evenement("Distribution de crêpes", new DateTime(2020, 5, 05, 10, 0, 0), "Aubière", 0, "https://img-3.journaldesfemmes.fr/nRH0FhvU75eTlwoseA8E04j61Fc=/750x/smart/a5181741d55b4b3d8b54bda593ff87f5/recipe-jdf/10021667.jpg", "Distribution des crêpes par votre BDE préféré");

            //Déclaration et instanciation des tâches.

            Tache tache = new Tache("Nouriture", "Prévoir la juste quantité de nourriture\nPrévoir la chaine du froid si besoin\nAcheter la nourriture");
            Tache tache1 = new Tache("Boissons", "Prévoir la juste quantité de boisson\n");
            Tache tache2 = new Tache("Activités", "Décider de la nature des activités\nPrévoir la durée globale et unitaire des activités\nDécider du nombre d'équipes");
            Tache tache3 = new Tache("Sécurité", "Evaluer la dangerosité de chaque activité ou évenements de la journée");
            Tache tache4 = new Tache("Sponsor", "Trouver et contacter un sponsor");
            Tache tache5 = new Tache("Lots", "Trouver et acheter des lots pour les gagnants");

            try
            { //Ajout des membres à l'association.
                association.AjouterUnMembre(membre);
                association.AjouterUnMembre(membre1);
                association.AjouterUnMembre(membre2);
                association.AjouterUnMembre(membre3);
                association.AjouterUnMembre(membre4);

                //Ajout des événements à l'association.
                 association.AjouterEvenement(evenement);
                association.AjouterEvenement(evenement1);
                association.AjouterEvenement(evenement2);

                //Ajout des tâches aux différents événements de l'association.
                association.AjouterUneTache(evenement, tache);
                association.AjouterUneTache(evenement1, tache1);
                association.AjouterUneTache(evenement1, tache2);
                association.AjouterUneTache(evenement2, tache3);
                association.AjouterUneTache(evenement2, tache4);
                 //Ajout des participants aux différentes tâches de l'association.
                association.AjouterUnParticipant(membre, tache, evenement);
                association.AjouterUnParticipant(membre1, tache, evenement);
                association.AjouterUnParticipant(membre, tache1, evenement1);
                association.AjouterUnParticipant(membre1, tache1, evenement1);
                association.AjouterUnParticipant(membre3, tache1, evenement1);
                association.AjouterUnParticipant(membre1, tache2, evenement1);
                association.AjouterUnParticipant(membre3, tache2, evenement1);
                association.AjouterUnParticipant(membre2, tache2, evenement1);
                association.AjouterUnParticipant(membre4, tache2, evenement1);
                association.AjouterUnParticipant(membre, tache3, evenement2);
                association.AjouterUnParticipant(membre1, tache3, evenement2);
                association.AjouterUnParticipant(membre4, tache3, evenement2);
                association.AjouterUnParticipant(membre2, tache3, evenement2);
                association.AjouterUnParticipant(membre3, tache4, evenement2);
                association.AjouterUnParticipant(membre2, tache4, evenement2);
                association.AjouterUnParticipant(membre4, tache4, evenement2);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return association;
        }
        /// <summary>
        /// Méthode de creation d'une association. Elle retourne une association.
        /// </summary>
        /// <returns></returns>
        public static Association CreerAssociation2()
        {
            Association association = new Association("BDE du dept biologique", "https://www.fneb.fr//wp-content/uploads/2013/06/MAJ-Bio-lille.jpg"); //Instanciation d'une association "Bde dept bio"

            //Déclaration et instanciation des objets de type membre
            Membre membre1 = new Membre("David", "Roux", Role.VicePresident, "Je suis vide-trésorier", "0459859", "../images/BradPitt.jpg", "Roux@gmail.com");
            Membre membre2 = new Membre("Martin", "Petit", Role.President, "Je suis en deuxième année à l'iut de clermont-ferrand dans le dept bio", "07869859", "../images/BradPitt.jpg", "Petit@gmail.com");
            Membre membre3  = new Membre("Michel", "Leroy", Role.Secretaire, "Je suis secrétaire au bde BIO", "09869859", "../images/BradPitt.jpg", "Petit@gmail.com");
            Membre membre4 = new Membre("Vincent", "Girard", Role.ViceSecretaire, "Je suis vice-secrétaire au bde BIO", "09869859", "../images/BradPitt.jpg", "girard@gmail.com");

            //Déclaration et instanciations des objets de type Evenement.
            Evenement evenement = new Evenement("Journée Aquarium", new DateTime(2020, 11, 05, 17, 30, 00), "Clermont-Ferrand", 20f, "https://img.grouponcdn.com/deal/24sH6M6RmzCc53CYjUhLnRnWZ3NQ/24-1120x672/v1/c700x420.jpg", "Il s'agit d'une excursion à l'aquarium de Clermont-Ferrand.");
            Evenement evenement1 = new Evenement("Visite d'une exposition", new DateTime(2020, 11, 05, 20,30, 00), "ASM Experience",0, "https://img.grouponcdn.com/deal/24sH6M6RmzCc53CYjUhLnRnWZ3NQ/24-1120x672/v1/c700x420.jpg", "Visite d'une galerie d'expériences scientifiques.");
            Evenement evenement2 = new Evenement("Boite de nuit", new DateTime(2020, 4, 06, 20, 30, 00),"L'Appart",8f, "https://www.cozycozy.com/fr/ou-dormir/wp-content/uploads/biarritz-boite-de-nuit.jpg","Sortie en boite de nuit") ;   
            
            //Ajout des membres à l'association et ajout des evenements.
            association.AjouterUnMembre(membre1);
            association.AjouterUnMembre(membre2);
            association.AjouterUnMembre(membre3);
            association.AjouterUnMembre(membre4);

            association.AjouterEvenement(evenement);
            association.AjouterEvenement(evenement1);
            association.AjouterEvenement(evenement2);

            //Création, ajout des tâches et des participants pour l'événement 1 

            Tache tache = new Tache("Participation", "Encourager les étudiants à participer.\nNoter les noms et prénoms des participants.");
            Tache tache1 = new Tache("Déplacement","Prévoir une voiture ou un bus pour ceux qui n'ont pas de moyen d'aller au lieu de rdv.");
            Tache tache2 = new Tache("Billeterie", "Aller chercher un poster et les billets d'entrée pour le nombre de participants notés auprès de la récéption de l'aquarium");

            Tache tache3 = new Tache("Déplacement", "Prévoir un bus pour les personnes qui ne peuvent pas se déplacer");
            Tache tache4 = new Tache("Récéption", "Un stand devant la récéption pour recevoir les étudiants de l'iut.");
            
            association.AjouterUneTache(evenement,tache);
            association.AjouterUneTache(evenement,tache1);

            association.AjouterUneTache(evenement1,tache2);
            association.AjouterUneTache(evenement, tache2);

            association.AjouterUneTache(evenement2, tache3);
            association.AjouterUneTache(evenement2, tache2);

            association.AjouterUnParticipant(membre1, tache, evenement);
            association.AjouterUnParticipant(membre2, tache, evenement);
            association.AjouterUnParticipant(membre4, tache, evenement);
            association.AjouterUnParticipant(membre1, tache1, evenement);
            association.AjouterUnParticipant(membre2, tache1, evenement);
            association.AjouterUnParticipant(membre3, tache1, evenement);
       
            Console.Write(association);


            return association;
        }
        public static ObservableCollection<Tache> CreerDesTachesEtDesParticipants()
        {
            Association association = CreerUneAssociation1();
            Tache tache = new Tache("Acheter la garniture des crêpes.", "Acheter du nutella, de la confiture, sucre, autre..");
            Tache tache1 = new Tache("Ramener les couverts et serviette pour le service des crêpes", "Couverts, gobelets, serviettes à acheter.");

            Evenement evenement = association.ListeEvenements[2]; //Je n'arrive pas à récuperer un événement à partir de la liste donc j'ai utilisé l'indexe mais à revoir.
            Console.WriteLine(evenement);

            try
            {
                association.AjouterEvenement(evenement); //Data de doublon, ça marche.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // ----Ajout des tâches à l'événement des crêpes -------- // 

            association.AjouterUneTache(evenement, tache);
            association.AjouterUneTache(evenement, tache1);
            // association.AjouterUneTache(evenement, tache1); Data de doublon, ça marche.

            // ----Ajout de participants à la tâche 1 ----- //
            association.AjouterUnParticipant(association.Membres[0], tache1, evenement); //Bof ce code mais c'est pour pouvoir tester avec le binding mais je n'arrive tjrs pas à recuperer un membre en passant par exemple son nom ou autre.
            association.AjouterUnParticipant(association.Membres[1], tache1, evenement);
            association.AjouterUnParticipant(association.Membres[2], tache1, evenement);

            Console.Write(association.Membres[0]);
            Console.WriteLine($"---------Tâches de l'événement {evenement.Nom} --------");

           


            

            return evenement.Taches;

        }

        public static Association CreerAssociation3()
        {
            Association assoc = new Association("BDE du dpt mesures physiques", "../images/BDE.png");
            Membre membre1 = new Membre("Laurine", "LeFevbre", Role.VicePresident, "Je suis vide-trésorier", "0459859", "../images/BradPitt.jpg", "Laurine@gmail.com");
            Membre membre2 = new Membre("Vince", "Fournier", Role.President, "Je suis en deuxième année à l'iut de clermont-ferrand dans le dept bio", "07869859", "../images/BradPitt.jpg", "fournierVince@gmail.com");
            Membre membre3 = new Membre("Richard ", "Martinez", Role.Secretaire, "Je suis secrétaire au bde BIO", "09869859", "../images/BradPitt.jpg", "ririMartinez@gmail.com");
            Membre membre4 = new Membre(" Thibault", "LeDuc", Role.ViceSecretaire, "Je suis vice-secrétaire au bde BIO", "09869859", "../images/BradPitt.jpg", "leDucT@gmail.com");

            Evenement evenement = new Evenement("Journée Aquarium", new DateTime(2020, 11, 05, 17, 30, 00), "Clermont-Ferrand", 20f, "https://img.grouponcdn.com/deal/24sH6M6RmzCc53CYjUhLnRnWZ3NQ/24-1120x672/v1/c700x420.jpg", "Il s'agit d'une excursion à l'aquarium de Clermont-Ferrand.");
            Evenement evenement1 = new Evenement("Visite d'une exposition", new DateTime(2020, 11, 05, 20, 30, 00), "ASM Experience", 0, "https://www.roz-sur-couesnon.fr/wp-content/uploads/2016/03/Evt-770x470.png", "Visite d'une galerie d'expériences scientifiques.");
            Evenement evenement2 = new Evenement("Boite de nuit", new DateTime(2020, 4, 06, 20, 30, 00), "L'Appart", 8f, "https://www.cozycozy.com/fr/ou-dormir/wp-content/uploads/biarritz-boite-de-nuit.jpg", "Sortie en boite de nuit");

            assoc.AjouterEvenement(evenement);
            assoc.AjouterUnMembre(membre1);
            assoc.AjouterUnMembre(membre2);
            assoc.AjouterUnMembre(membre3);
            assoc.AjouterUnMembre(membre4);
            return assoc;
        }
        public static ObservableCollection<Association> CreationDesAssociations()
        {
            ObservableCollection<Association> listeAssociations = new ObservableCollection<Association>();

            Association association= association = CreerUneAssociation1();
            Association assoc2 = CreerAssociation2();
            Association assoc3 = CreerAssociation3();
            listeAssociations.Add(association);
            listeAssociations.Add(assoc2);
            listeAssociations.Add(assoc3);


            



            return listeAssociations;



        }
    }
}
