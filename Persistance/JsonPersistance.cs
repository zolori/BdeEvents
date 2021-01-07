using Data;
using Modèle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
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

namespace Persistance
{
    /// <summary>
    /// Classe gérant la persistance en Json.
    /// </summary>
    public class JsonPersistance : IPersistance
    {
        /// <summary>
        /// Définie le répertoire au bout du chemin passé en paramètre comme répertoire courant.
        /// </summary>
        /// <param name="chemin"></param>
        public JsonPersistance(string chemin)
        {
            Directory.SetCurrentDirectory(chemin);
        }

        /// <summary>
        /// Charge les données depuis la base de donnée.
        /// </summary>
        /// <param name="chemin"></param>
        /// <returns></returns>
        public ObservableCollection<Association> Charger(string chemin)
        {
            ObservableCollection<Association> assoc = new ObservableCollection<Association>();
            Stream fs = File.OpenRead(chemin);
           // assoc = Stub.CreationDesAssociations();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ObservableCollection<Association>));
            assoc = ser.ReadObject(fs) as ObservableCollection<Association>;
            fs.Close();
            return assoc;
        }

        /// <summary>
        /// Sauvegarde les données dans la base de donnée en Json.
        /// </summary>
        /// <param name="chemin"></param>
        /// <param name="assoc"></param>
        /// <returns></returns>
        public bool Sauvegarder(string chemin, ObservableCollection<Association> assoc)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ObservableCollection<Association>));
            Stream fs = File.Create(chemin);
            ser.WriteObject(fs, assoc);
            fs.Close();
            return true;
        }
    }
}
