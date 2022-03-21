#pragma warning disable CS0234 // Le nom de type ou d'espace de noms 'DAL' n'existe pas dans l'espace de noms 'Raminagrobis' (vous manque-t-il une référence d'assembly ?)
using Raminagrobis.DAL;
#pragma warning restore CS0234 // Le nom de type ou d'espace de noms 'DAL' n'existe pas dans l'espace de noms 'Raminagrobis' (vous manque-t-il une référence d'assembly ?)
using Raminagrobis.Api.Contracts.Responses;
#pragma warning disable CS0246 // Le nom de type ou d'espace de noms 'Depot' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
using Depot.DAL.Depot;
#pragma warning restore CS0246 // Le nom de type ou d'espace de noms 'Depot' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Raminagrobis.Api.Contracts.Requests;

namespace Raminagrobis.Metier.Services
{
    public class References
    {

        public List<ReferencesMetier> GetAll()
        {
            var all = new List<ReferencesMetier>();
            var dep = new References_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new ReferencesMetier(item.ID, item.References, item.Wording, item.Brand, item.Status));
            }
            return all;
        }

        public ReferencesMetier GetByID(int id)
        {
            var dep = new References_DAL_Depot();
            var references = dep.GetByID(id);
            return new ReferencesMetier(references.ID, references.References, references.Wording, references.Brand, references.Status);
        }

        public void Insert(ReferencesRequest input)
        {
            var dep = new References_DAL_Depot();
            var references = new References_DAL(input.References, input.Wording, input.Brand, input.Status);
            dep.Insert(references);
        }

        public void Update(int id, ReferencesRequest input)
        {
            var dep = new References_DAL_Depot();
            var references = new References_DAL(id, input.References, input.Wording, input.Brand, input.Status);
            dep.Update(references);
        }

        public void Delete(int id)
        {
            References_DAL references;
            References_DAL_Depot dep = new References_DAL_Depot();
            references = dep.GetByID(id);
            dep.Delete(references);
        }
    }
}
