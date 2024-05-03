using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class OferteBLL
    {
        private supermarketDBEntities2 context = new supermarketDBEntities2();
        public ObservableCollection<Oferte> OferteList { get; set; }
        public string ErrorMessage { get; set; }

        public void AddOferta(object obj)
        {
            var result = obj as Tuple<int, string, int>;
            var id_stoc = result.Item1;
            var motiv = result.Item2;
            var discount = result.Item3;
            var expirationDateResult = context.GetExpirationDate(id_stoc);

            var data_sfarsit = expirationDateResult.FirstOrDefault();

            // Call the stored procedure to add a new offer
            var rowsAffected = context.AddOferta2(id_stoc, motiv, discount, data_sfarsit);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while adding the offer.";
            }
            else
            {
                ErrorMessage = "The offer was added successfully.";
            }
        }

        public void DeleteOferta(int offerId)
        {
            var rowsAffected = context.DeleteOferta(offerId);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while deleting the offer.";
            }
            else
            {
                ErrorMessage = "The offer was deleted successfully.";
            }
        }

        public void DeleteOfertaAfterStock(int stockId)
        {
            var rowsAffected = context.DeleteOfertaAfterStock(stockId);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while deleting the offer.";
            }
            else
            {
                ErrorMessage = "The offer was deleted successfully.";
            }
        }

        public void DeleteOfertaAfterProduct(int productId)
        {
            var rowsAffected = context.DeleteOfertaAfterProdus(productId);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while deleting the offer.";
            }
            else
            {
                ErrorMessage = "The offer was deleted successfully.";
            }
        }

        public ObservableCollection<Tuple<int, string, int, string>> GetAllOferte()
        {
            List<GetAllOferte2_Result> oferte = context.GetAllOferte2().ToList();
            ObservableCollection<Tuple<int, string, int, string>> result = new ObservableCollection<Tuple<int, string, int, string>>();
            foreach (var oferta in oferte)
            {
                result.Add(new Tuple<int, string, int, string>(oferta.id_oferta, oferta.motiv, oferta.procent_reducere, oferta.nume));
            }
            return result;
        }

        internal void ModifyMotivOferta(int id_oferta, string motiv)
        {
            var rowsAffected = context.ModifyMotivOferta(id_oferta, motiv);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the offer.";
            }
            else
            {
                ErrorMessage = "The offer was modified successfully.";
            }
        }

        internal void ModifyProcentOferta(int id_oferta, int procent)
        {
            var rowsAffected = context.ModifyProcentOferta(id_oferta, procent);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the offer.";
            }
            else
            {
                ErrorMessage = "The offer was modified successfully.";
            }
        }

        
    }
}
