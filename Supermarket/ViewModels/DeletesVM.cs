using Supermarket.Helpers;
using Supermarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.ViewModels
{
    internal class DeletesVM
    {
        private ProduseBLL produseBLL;
        private StocuriBLL stocuriBLL;
        private OferteBLL oferteBLL;

        public DeletesVM()
        {
            produseBLL = new ProduseBLL();
            DeleteProdusCommand = new RelayCommand(DeleteProdus);
            ProductsList = produseBLL.GetAllProduse();

            stocuriBLL = new StocuriBLL();
            DeleteStocCommand = new RelayCommand(DeleteStoc);
            StocksList = stocuriBLL.GetAllStocks();

            oferteBLL = new OferteBLL();
            DeleteOfertaCommand = new RelayCommand(DeleteOferta);
            OfertaList = oferteBLL.GetAllOferte();
        }

        public ObservableCollection<Tuple<int, string>> ProductsList { get; private set; }
        public ObservableCollection<Tuple<int, int, DateTime, int, string>> StocksList { get; private set; }
        public ObservableCollection<Tuple<int, string, int, string>> OfertaList { get; private set; }

        public RelayCommand DeleteProdusCommand { get; set; }
        public RelayCommand DeleteStocCommand { get; set; }
        public RelayCommand DeleteOfertaCommand { get; set; }

        public void DeleteProdus(object obj)
        {
            if (obj == null || !(obj is int))
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            int productId = (int)obj;
            bool IdExists = ProductsList.Any(x => x.Item1 == productId);
            if (!IdExists)
            {
                MessageBox.Show("The product ID does not exist.");
                return;
            }
            else
            {
                MessageBox.Show("The product was deleted successfully.");
                produseBLL.DeleteProdus(productId);
                stocuriBLL.DeleteStocAfterProdus(productId);
                oferteBLL.DeleteOfertaAfterProduct(productId);
            }
        }

        public void DeleteStoc(object obj)
        {
            if (obj == null || !(obj is int))
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            int stockId = (int)obj;
            bool IdExists = StocksList.Any(x => x.Item1 == stockId);
            if (!IdExists)
            {
                MessageBox.Show("The stock ID does not exist.");
                return;
            }
            else
            {
                MessageBox.Show("The stock was deleted successfully.");
                stocuriBLL.DeleteStoc(stockId);
                oferteBLL.DeleteOfertaAfterStock(stockId);

            }
        }

        public void DeleteOferta(object obj)
        {
            if (obj == null || !(obj is int))
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            int offerId = (int)obj;
            bool IdExists = OfertaList.Any(x => x.Item1 == offerId);
            if (!IdExists)
            {
                MessageBox.Show("The offer ID does not exist.");
                return;
            }
            else
            {
                MessageBox.Show("The offer was deleted successfully.");
                oferteBLL.DeleteOferta(offerId);
            }
        }

    }
}
