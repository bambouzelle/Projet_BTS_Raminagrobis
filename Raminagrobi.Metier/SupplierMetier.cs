﻿#pragma warning disable CS0234 // Le nom de type ou d'espace de noms 'DAL' n'existe pas dans l'espace de noms 'Raminagrobis' (vous manque-t-il une référence d'assembly ?)
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
using System.IO;

namespace Raminagrobis.Metier
{
    public class SupplierMetier
    {        
        public int ID { get; set; }
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime Create_at { get; private set; }

        public List<ReferencesMetier> References { get; private set; }

        public SupplierMetier(string company, string civility, string surname, string name, string email, string address, DateTime create_at)
        { 
            Company = company;
            Civility = civility; 
            Surname = surname;
            Name = name;
            Email = email;
            Address = address;
            Create_at = create_at;
            References = new List<ReferencesMetier>();
        }

        public SupplierMetier(int id, string company, string civility, string surname, string name, string email, string address, DateTime create_at)
        {
            ID = id;
            Company = company;
            Civility = civility;
            Surname = surname;
            Name = name;
            Email = email;
            Address = address;
            Create_at = create_at;
            References = new List<ReferencesMetier>();
        }
        public void AddReferences(List<ReferencesMetier> references)
        {
            foreach (var item in references)
            {
                References.Add(item);
            }
        }

        public void AddReferencesFromCSV(StreamReader file)
        {
            var getline = file.ReadLine();
            var columnName = getline.Split(";");

            if (columnName.Length == 3)
            {
                while (!file.EndOfStream)
                {
                    var getcolumn = file.ReadLine().Split(";");
                    string Refrences = "";
                    string Wording = "";
                    string Brand = "";

                    for (int i = 0; i < 3; i++)
                    {
                        switch (columnName[i])
                        {
                            case "reference":
                                Refrences = getcolumn[i];
                                break;
                            case "libelle":
                                Wording = getcolumn[i];
                                break;
                            case "marque":
                                Brand = getcolumn[i];
                                break;
                            default:
                                throw new Exception($"le csv n'est pas lisible");

                        }
                    }
                    if (Refrences == "" || Wording == "" || Brand == "")
                    {
                        throw new Exception("Le CSV est Vide");
                    }
                    else
                    {
                        this.AddReferences(new ReferencesMetier (Refrences, Wording, Brand, true));
                    }
                }
            }
            else
            {
                throw new Exception("Le CSV est dans le mauvais format");
            }
        }

        private void AddReferences(ReferencesMetier references)
        {
            References.Add(references);
        }
    }
}
