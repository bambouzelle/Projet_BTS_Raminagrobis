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

namespace Raminagrobi.Metier.Services
{
    public class CartDetails
    {

        public List<CartDetailsMetier> GetAll()
        {
            var all = new List<CartDetailsMetier>();
            var dep = new Cart_details_DAL_Depot();
            foreach (var item in dep.GetAll())
            {
                all.Add(new CartDetailsMetier(item.ID, item.Id_cart, item.Id_references, item.Id_global_details, item.Quantity));
            }
            return all;
        }

        public CartDetailsMetier GetByID(int id)
        {
            var dep = new Cart_details_DAL_Depot();
            var cart = dep.GetByID(id);
            return new CartDetailsMetier(cart.Id_cart, cart.Id_references, cart.Id_global_details, cart.Quantity);
        }

        public void Insert(CartDetailsResponse input)
        {
            var dep = new Cart_details_DAL_Depot();
            var cart = new Cart_details_DAL(input.IdCart, input.IdReferences, input.IdGlobalDetails, input.Quantity);
            dep.Insert(cart);
        }

        public void Update(int id, CartDetailsResponse input)
        {
            var dep = new Cart_details_DAL_Depot();
            var cart = new Cart_details_DAL(input.IdCart, input.IdReferences, input.IdGlobalDetails, input.Quantity);
            dep.Update(cart);
        }

        public void Delete(int id)
        {
            Cart_details_DAL cart;
            Cart_details_DAL_Depot dep = new Cart_details_DAL_Depot();
            cart = dep.GetByID(id);
            dep.Delete(cart);
        }
    }
}
