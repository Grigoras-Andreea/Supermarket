using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class StocuriBLL
    {
        private supermarketDBEntities2 context = new supermarketDBEntities2();
        public ObservableCollection<Stocuri> StocuriList { get; set; }
        public string ErrorMessage { get; set; }

        public void AddStoc(object obj)
        {
            var result = obj as Tuple<int, string, DateTime, DateTime, float, int>;
            var cantitate = result.Item1;
            var unitate = result.Item2;
            var data_in = result.Item3;
            var data_out = result.Item4;
            var pret = result.Item5;
            var id_produs = result.Item6;

            // Call the stored procedure to add a new stock
            var rowsAffected = context.AddStoc(cantitate, unitate, data_in, data_out, pret, id_produs);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while adding the stock.";
            }
            else
            {
                ErrorMessage = "The stock was added successfully.";
            }
        }

        public ObservableCollection<Tuple<int, int, DateTime, int, string>> GetAllStocks()
        {
            List<GetAllStocks_Result> stocks = context.GetAllStocks().ToList();
            ObservableCollection<Tuple<int, int, DateTime, int, string>> result = new ObservableCollection<Tuple<int, int, DateTime, int, string>>();
            foreach (var stock in stocks)
            {
                result.Add(new Tuple<int, int, DateTime, int, string>(stock.id_stoc, stock.cantitate, (DateTime)stock.data_expirare, stock.id_produs, stock.nume));
            }
            return result;
        }

        internal void DeleteStoc(int stockId)
        {
            var rowsAffected = context.DeleteStocks(stockId);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while deleting the stock.";
            }
            else
            {
                ErrorMessage = "The stock was deleted successfully.";
            }
        }

        internal void DeleteStocAfterProdus(int productId)
        {
            var rowsAffected = context.DeleteStocksAfterProducts(productId);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while deleting the stock.";
            }
            else
            {
                ErrorMessage = "The stock was deleted successfully.";
            }
        }

        public ObservableCollection<Tuple<int, string, int, double, double, string>> GetAllStocks2()
        {
            List<GetAllStocks2_Result> stocks = context.GetAllStocks2().ToList();
            ObservableCollection<Tuple<int, string, int, double, double, string>> result = new ObservableCollection<Tuple<int, string, int, double, double, string>>();
            foreach (var stock in stocks)
            {
                result.Add(new Tuple<int, string, int, double, double, string>(stock.id_stoc, stock.unitate_masura, stock.cantitate, stock.pret_achizitie, stock.pret_vanzare, stock.nume));
            }
            return result;
        }

        internal void ModifyCantitateStoc(int id_stoc, int cantitate)
        {
            var rowsAffected = context.ModifyCantitateStoc(id_stoc, cantitate);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the stock.";
            }
            else
            {
                ErrorMessage = "The stock was modified successfully.";
            }
        }

        internal void ModifyUnitateStoc(int id_stoc, string unitate)
        {
            var rowsAffected = context.ModifyUnitateStoc(id_stoc, unitate);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the stock.";
            }
            else
            {
                ErrorMessage = "The stock was modified successfully.";
            }
        }

        internal void ModifyPretInStoc(int id_stoc, double pret)
        {
            var rowsAffected = context.ModifyPretStoc(id_stoc, pret);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the stock.";
            }
            else
            {
                ErrorMessage = "The stock was modified successfully.";
            }
        }

        //-----------------------------------------------------------------------------------

        public ObservableCollection<Tuple<int, int, DateTime, double, string>> GetAllStocksForSum()
        {
            List<GetAllStocksForSum_Result> stocks = context.GetAllStocksForSum().ToList();
            ObservableCollection<Tuple<int, int, DateTime, double, string>> result = new ObservableCollection<Tuple<int, int, DateTime, double, string>>();
            foreach (var stock in stocks)
            {
                result.Add(new Tuple<int, int, DateTime, double, string>(stock.id_stoc, stock.cantitate, (DateTime)stock.data_expirare, stock.pret_vanzare, stock.categorie));
            }
            return result;
        }

        public ObservableCollection<Tuple<int, string, int>> GetAllOferte2()
        {
            List<GetAllOffersForSum_Result> oferte = context.GetAllOffersForSum().ToList();
            ObservableCollection<Tuple<int, string, int>> result = new ObservableCollection<Tuple<int, string, int>>();
            foreach (var oferta in oferte)
            {
                result.Add(new Tuple<int, string, int>(oferta.id_stoc, oferta.motiv, oferta.procent_reducere));
            }
            return result;
        }

        public bool IsOfferAvailable(int cantitate, DateTime data_expirare, string motiv)
        {
            if(motiv == "expirare")
            {
                // check if current date is less than 3 days before the expiration date
                if (data_expirare.Subtract(DateTime.Now).Days <= 3)
                {
                    return true;
                }
            }
            else if(motiv == "cantitate")
            {
                if (cantitate <= 10)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetHighestOffer(int id_stoc, int cantitate, DateTime data_expirare, ObservableCollection<Tuple<int, string, int>> offers)
        {
            List<int> offersForStock = new List<int>();
            foreach (var offer in offers)
            {
                if (offer.Item1 == id_stoc && IsOfferAvailable(cantitate, data_expirare, offer.Item2) == true)
                {
                    offersForStock.Add(offer.Item3);
                }
            }
            if (offersForStock.Count == 0)
            {
                return 0;
            }
            return offersForStock.Max();
        }

        public ObservableCollection<Tuple<string, double>> GetSumByCategory()
        {
            ObservableCollection<Tuple<string, double>> sumByCategory = new ObservableCollection<Tuple<string, double>>();

            // Get all stocks
            var allStocks = GetAllStocksForSum();

            // Get all offers
            var allOffers = GetAllOferte2();

            // Group stocks by category
            var groupedStocks = allStocks.GroupBy(stock => stock.Item5);

            foreach (var group in groupedStocks)
            {
                string category = group.Key;
                double totalSum = 0;

                // Iterate through stocks in the category
                foreach (var stock in group)
                {
                    int id_stoc = stock.Item1;
                    int cantitate = stock.Item2;
                    DateTime data_expirare = stock.Item3;

                    // Get the highest available offer for the stock
                    int highestOffer = GetHighestOffer(id_stoc, cantitate, data_expirare, allOffers);

                    // Calculate the discounted price
                    double pret_vanzare = stock.Item4;
                    double discountedPrice = pret_vanzare * (1 - highestOffer / 100.0);
                    double stockSum = discountedPrice * cantitate;

                    // Add the discounted price to the total sum
                    totalSum += stockSum;
                }

                // Add the category and total sum to the result
                sumByCategory.Add(new Tuple<string, double>(category, totalSum));
            }

            return sumByCategory;
        }

        //-----------------------------------------------------------------------------------
    }
}
