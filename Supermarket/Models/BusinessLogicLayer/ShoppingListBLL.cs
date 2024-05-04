using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ShoppingListBLL
    {
        private supermarketDBEntities2 context = new supermarketDBEntities2();

        public Tuple<int, string, int, int, DateTime, double> GetStockFromCode(string code)
        {
            var stock = context.GetStockFromCode(code).FirstOrDefault();
            if (stock != null)
            {
                return new Tuple<int, string, int, int, DateTime, double>(stock.id_produs, stock.nume, stock.id_stoc, stock.cantitate, (DateTime)stock.data_expirare, stock.pret_vanzare);
            }
            return null;
        }

        public ObservableCollection<Tuple<string, int>> GetOferteForStock(int stockId)
        {
            List<GetOfertaForStock_Result> oferte = context.GetOfertaForStock(stockId).ToList();
            ObservableCollection<Tuple<string, int>> result = new ObservableCollection<Tuple<string, int>>();
            foreach (var oferta in oferte)
            {
                result.Add(new Tuple<string, int>(oferta.motiv, oferta.procent_reducere));
            }
            return result;
        }

        public bool IsOfferAvailable(int cantitate, DateTime data_expirare, string motiv)
        {
            if (motiv == "expirare")
            {
                // check if current date is less than 3 days before the expiration date
                if (data_expirare.Subtract(DateTime.Now).Days <= 3)
                {
                    return true;
                }
            }
            else if (motiv == "cantitate")
            {
                if (cantitate <= 10)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetHighestOffer(int id_stoc, int cantitate, DateTime data_expirare, ObservableCollection<Tuple<string, int>> offers)
        {
            List<int> offersForStock = new List<int>();
            foreach (var offer in offers)
            {
                if (IsOfferAvailable(cantitate, data_expirare, offer.Item1) == true)
                {
                    offersForStock.Add(offer.Item2);
                }
            }
            if (offersForStock.Count == 0)
            {
                return 0;
            }
            return offersForStock.Max();
        }

        public Tuple<int, string, double> GetShoppingListElement(string code)
        {
            var stockInfo = GetStockFromCode(code);
            if (stockInfo != null)
            {
                SubstractFromStock(stockInfo.Item3);

                int productId = stockInfo.Item1;
                string productName = stockInfo.Item2;
                double price = stockInfo.Item6;

                var offers = GetOferteForStock(stockInfo.Item3);

                int highestOffer = GetHighestOffer(stockInfo.Item3, stockInfo.Item4, stockInfo.Item5, offers);

                double discountedPrice = price * (1 - highestOffer / 100.0);

                return new Tuple<int, string, double>(productId, productName, discountedPrice);
            }
            return null;
        }

        public void SubstractFromStock(int stockId)
        {
            var rowsAffected = context.SubstractQuantityFromStock(stockId);

        }

        //--------------------------------------------------------------------------------

        public Tuple<ObservableCollection<Tuple<string, int, double, int>>, double> FinishShoppingList(ObservableCollection<Tuple<int, string, double>> shoppingList, int IdCasier )
        {
            List<Tuple<string, int, double, int>> shoppingListWithPrices = new List<Tuple<string, int, double, int>>();
            double totalPrice = 0;

            foreach(var item in shoppingList)
            {
                if (shoppingListWithPrices.Any(x => x.Item1 == item.Item2))
                {
                    // Item with the same name already exists, update its quantity and price
                    var existingItemIndex = shoppingListWithPrices.FindIndex(x => x.Item1 == item.Item2);
                    var existingItem = shoppingListWithPrices[existingItemIndex];
                    var updatedItem = Tuple.Create(existingItem.Item1, existingItem.Item2 + 1, existingItem.Item3 + item.Item3, existingItem.Item4);
                    shoppingListWithPrices[existingItemIndex] = updatedItem;
                }
                else
                {
                    // Item doesn't exist in shoppingListWithPrices, add it
                    shoppingListWithPrices.Add(Tuple.Create(item.Item2, 1, item.Item3, item.Item1));
                }

                totalPrice += item.Item3;
            }

            if(shoppingListWithPrices.Count != 0)
            {

                context.InsertBon(IdCasier, totalPrice);

                int lastBonId = context.GetBonLastID().FirstOrDefault().Value;

                foreach (var item in shoppingListWithPrices)
                {
                    context.InsertIntoProdusBon(item.Item4, lastBonId, item.Item2, item.Item3);
                }

            }
            return Tuple.Create(new ObservableCollection<Tuple<string, int, double, int>>(shoppingListWithPrices), totalPrice);
        }
    }
}
