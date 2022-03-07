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
    public class MemberMetier
    {
        public int ID { get; private set; }
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime CreateAt { get; private set; }

        public MemberMetier(string company, string civility, string surname, string name, string email, string address, DateTime createAt)
        {
            Company = company;
            Civility = civility;
            Surname = surname;
            Name = name;
            Email = email;
            Address = address;
            CreateAt = createAt;
        }
        public MemberMetier(int id, string company, string civility, string surname, string name, string email, string address, DateTime createAt)
        {
            ID = id;
            Company = company;
            Civility = civility;
            Surname = surname;
            Name = name;
            Email = email;
            Address = address;
            CreateAt = createAt;
        }

    }
}
