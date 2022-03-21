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
using Raminagrobis.Metier;
using Raminagrobis.Api.Contracts.Requests;

namespace Raminagrobi.Metier.Services
{
    public class MtmPr
    {
        public List<MtmPrMetier> GetAll()
        {
            var all = new List<MtmPrMetier>();
            var dep = new Mtm_pr_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new MtmPrMetier(item.ID, item.Id_references, item.Id_supplier));
            }
            return all;
        }

        public MtmPrMetier GetByID(int id)
        {
            var dep = new Mtm_pr_DAL_Depot();
            var mtmpr = dep.GetByID(id);
            return new MtmPrMetier(mtmpr.ID, mtmpr.Id_references, mtmpr.Id_supplier);
        }

        public void Insert(MtmPrRequest input)
        {
            var dep = new Mtm_pr_DAL_Depot();
            var mtmpr = new Mtm_pr_DAL(input.IdReferences, input.IdSupplier);
            dep.Insert(mtmpr);
        }

        public void Update(int id, MtmPrRequest input)
        {
            var dep = new Mtm_pr_DAL_Depot();
            var member = new Mtm_pr_DAL(id, input.IdReferences, input.IdSupplier);
            dep.Update(member);
        }

        public void Delete(int id)
        {
            Mtm_pr_DAL mtmpr;
            Mtm_pr_DAL_Depot dep = new Mtm_pr_DAL_Depot();
            mtmpr = dep.GetByID(id);
            dep.Delete(mtmpr);
        }
    }
}
