using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Data;
using Modèle;
using System.IO;
using Persistance;
using System.Collections.ObjectModel;

namespace LogicEvent
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initialise le chemin où aller chercher la bdd.
        /// </summary>
        public static readonly string CHEMIN = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\bdd");

        /// <summary>
        /// Instancie le manager dans la vue avec les données du Json.
        /// </summary>
        public Manager LeManager = new Manager(new JsonPersistance(CHEMIN));
        
        /// <summary>
        /// Instancie le manager dans la vue avec les données du stub.  
        /// </summary>
        ///public Manager LeManager = new Manager(new JsonPersistance(CHEMIN), Stub.CreationDesAssociations());


    }
}
