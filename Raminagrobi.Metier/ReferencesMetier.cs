#pragma warning disable CS0234 // Le nom de type ou d'espace de noms 'DAL' n'existe pas dans l'espace de noms 'Raminagrobis' (vous manque-t-il une référence d'assembly ?)
using Raminagrobis.DAL;
#pragma warning restore CS0234 // Le nom de type ou d'espace de noms 'DAL' n'existe pas dans l'espace de noms 'Raminagrobis' (vous manque-t-il une référence d'assembly ?)
#pragma warning disable CS0246 // Le nom de type ou d'espace de noms 'Depot' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
using Depot.DAL.Depot;
#pragma warning restore CS0246 // Le nom de type ou d'espace de noms 'Depot' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Raminagrobis.Metier
{
    public class ReferencesMetier
    {
        public int ID { get; set; }
        public string References { get; private set; }
        public string Wording { get; private set; }
        public string Brand { get; private set; }
        public bool Status { get; private set; }

        public ReferencesMetier(string references, string wording, string brand, bool status)
        {
            References = references;
            Wording = wording;
            Brand = brand;
            Status = status;
        }

        public ReferencesMetier(int id, string references, string wording, string brand, bool status)
        {
            ID = id;
            References = references;
            Wording = wording;
            Brand = brand;
            Status = status;
        }

        public string GetReferences()
        {
            return References;
        }

        public string GetWoreding()
        {
            return Wording;
        }

        public string GetBrand()
        {
            return Brand;
        }
    }
}