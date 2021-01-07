using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modèle
{
    /// <summary>
    /// interface pour la persistance de l'application
    /// </summary>
    public interface IPersistance
    {
        /// <summary>
        /// Methode abstraite du chargement de la base de données
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        ObservableCollection<Association> Charger(String s);

        /// <summary>
        /// Methode abstraite de la sauvegarde dans la base de données
        /// </summary>
        /// <param name="s"></param>
        /// <param name="association"></param>
        /// <returns></returns>
        bool Sauvegarder(String s, ObservableCollection<Association> association);
    }
}
