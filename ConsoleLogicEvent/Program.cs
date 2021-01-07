using System;
using Modèle;
using Data;
using System.Collections.ObjectModel;

namespace Test 
{
    class Program
    {
        static void Main(string[] args)
        {

            Association association = Stub.CreerAssociation2();
            //Console.WriteLine(association);
            ObservableCollection<Association> liste = Stub.CreationDesAssociations();
            foreach(Association e in liste)
            {
                Console.WriteLine(e.Nom);
            }
            
        }
    }
}
