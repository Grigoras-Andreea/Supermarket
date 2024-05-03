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
    internal class ModifyVM
    {
        private ProducatoriBLL producatoriBLL;
        private ProduseBLL produseBLL;
        private StocuriBLL stocuriBLL;
        private OferteBLL oferteBLL;


        public ModifyVM()
        {
            producatoriBLL = new ProducatoriBLL();
            ModifyNumeProducatorCommand = new RelayCommand(ModifyNumeProducator);
            ModifyTaraProducatorCommand = new RelayCommand(ModifyTaraProducator);
            CompaniesList = producatoriBLL.GetAllProducatori();

            produseBLL = new ProduseBLL();
            ModifyNumeProdusCommand = new RelayCommand(ModifyNumeProdus);
            ModifyCategorieProdusCommand = new RelayCommand(ModifyCategorieProdus);
            ProductsList = produseBLL.GetAllProduse();

            stocuriBLL = new StocuriBLL();
            ModifyCantitateStocCommand = new RelayCommand(ModifyCantitateStoc);
            ModifyUnitateStocCommand = new RelayCommand(ModifyUnitateStoc);
            ModifyPretInStocCommand = new RelayCommand(ModifyPretInStoc);
            StocksList = stocuriBLL.GetAllStocks();
            Stocks2List = stocuriBLL.GetAllStocks2();

            oferteBLL = new OferteBLL();
            ModifyMotivOfertaCommand = new RelayCommand(ModifyMotivOferta);
            ModifyProcentOfertaCommand = new RelayCommand(ModifyProcentOferta);
            OfertaList = oferteBLL.GetAllOferte();
        }

        public ObservableCollection<Tuple<int, string>> CompaniesList { get; private set; }
        public ObservableCollection<Tuple<int, string>> ProductsList { get; private set; }
        public ObservableCollection<Tuple<int, int, DateTime, int, string>> StocksList { get; private set; }
        public ObservableCollection<Tuple<int, string, int, double, double, string>> Stocks2List { get; private set; }
        public ObservableCollection<Tuple<int, string, int, string>> OfertaList { get; private set; }

        public RelayCommand ModifyNumeProducatorCommand { get; set; }
        public RelayCommand ModifyTaraProducatorCommand { get; set; }

        public RelayCommand ModifyNumeProdusCommand { get; set; }
        public RelayCommand ModifyCategorieProdusCommand { get; set; }
        public RelayCommand ModifyCantitateStocCommand { get; set; }
        public RelayCommand ModifyUnitateStocCommand { get; set; }
        public RelayCommand ModifyPretInStocCommand { get; set; }

        public RelayCommand ModifyMotivOfertaCommand { get; set; }
        public RelayCommand ModifyProcentOfertaCommand { get; set; }

        
        public void ModifyNumeProducator(object obj)
        {
            if (obj == null || !(obj is Tuple<int, string>))
            {
                return;
            }

            var result = obj as Tuple<int, string>;
            var id_producator = result.Item1;
            bool CompanyIDExists = CompaniesList.Any(x => x.Item1 == id_producator);
            var nume = result.Item2;
            bool CompanyNameExists = CompaniesList.Any(x => x.Item2 == nume);
            if (CompanyNameExists)
            {
                MessageBox.Show("Company already exists.");
                return;
            }
            else if(!CompanyIDExists)
            {
                MessageBox.Show("Company ID does not exist.");
                return;
            }
            else if (nume == "")
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            producatoriBLL.ModifyNumeProducator(id_producator, nume);
        }

        public void ModifyTaraProducator(object obj)
        {
            if (obj == null || !(obj is Tuple<int, string>))
            {
                return;
            }

            var result = obj as Tuple<int, string>;
            var id_producator = result.Item1;
            bool CompanyIDExists = CompaniesList.Any(x => x.Item1 == id_producator);
            var tara = result.Item2;
            if(tara == "")
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            else if (!CompanyIDExists)
            {
                MessageBox.Show("Company ID does not exist.");
                return;
            }
            producatoriBLL.ModifyTaraProducator(id_producator, tara);
        }

        public void ModifyNumeProdus(object obj)
        {
            if (obj == null || !(obj is Tuple<int, string>))
            {
                return;
            }

            var result = obj as Tuple<int, string>;
            var id_produs = result.Item1;
            bool ProductIDExists = ProductsList.Any(x => x.Item1 == id_produs);
            var nume = result.Item2;
            bool ProductNameExists = ProductsList.Any(x => x.Item2 == nume);
            if (ProductNameExists)
            {
                MessageBox.Show("Product already exists.");
                return;
            }
            else if (!ProductIDExists)
            {
                MessageBox.Show("Product ID does not exist.");
                return;
            }
            else if (nume == "")
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            produseBLL.ModifyNumeProdus(id_produs, nume);
        }

        public void ModifyCategorieProdus(object obj)
        {
            if (obj == null || !(obj is Tuple<int, string>))
            {
                return;
            }

            var result = obj as Tuple<int, string>;
            var id_produs = result.Item1;
            bool ProductIDExists = ProductsList.Any(x => x.Item1 == id_produs);
            var categorie = result.Item2;
            if (categorie == "")
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            else if (!ProductIDExists)
            {
                MessageBox.Show("Product ID does not exist.");
                return;
            }
            produseBLL.ModifyCategorieProdus(id_produs, categorie);
        }

        public void ModifyCantitateStoc(object obj)
        {
            if (obj == null || !(obj is Tuple<int, int>))
            {
                return;
            }

            var result = obj as Tuple<int, int>;
            var id_stoc = result.Item1;
            bool StockIDExists = Stocks2List.Any(x => x.Item1 == id_stoc);
            var cantitate = result.Item2;
            if (cantitate < 0)
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            else if (!StockIDExists)
            {
                MessageBox.Show("Stock ID does not exist.");
                return;
            }
            stocuriBLL.ModifyCantitateStoc(id_stoc, cantitate);
        }

        public void ModifyUnitateStoc(object obj)
        {
            if (obj == null || !(obj is Tuple<int, string>))
            {
                return;
            }

            var result = obj as Tuple<int, string>;
            var id_stoc = result.Item1;
            bool StockIDExists = Stocks2List.Any(x => x.Item1 == id_stoc);
            var unitate = result.Item2;
            if (unitate == "")
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            else if (!StockIDExists)
            {
                MessageBox.Show("Stock ID does not exist.");
                return;
            }
            stocuriBLL.ModifyUnitateStoc(id_stoc, unitate);
        }

        public void ModifyPretInStoc(object obj)
        {
            if (obj == null || !(obj is Tuple<int, double>))
            {
                return;
            }

            var result = obj as Tuple<int, double>;
            var id_stoc = result.Item1;
            bool StockIDExists = Stocks2List.Any(x => x.Item1 == id_stoc);
            //get pret_achizitie from Stocks2List
            var pret_achizitie = Stocks2List.Where(x => x.Item1 == id_stoc).Select(x => x.Item4).FirstOrDefault();
            var pret = result.Item2;
            if (pret < 0)
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            else if (!StockIDExists)
            {
                MessageBox.Show("Stock ID does not exist.");
                return;
            }
            else if (pret < pret_achizitie)
            {
                MessageBox.Show("Invalid pret.");
                return;
            }
            stocuriBLL.ModifyPretInStoc(id_stoc, pret);
        }

        public void ModifyMotivOferta(object obj)
        {
            if (obj == null || !(obj is Tuple<int, string>))
            {
                return;
            }

            var result = obj as Tuple<int, string>;
            var id_oferta = result.Item1;
            bool OfferIDExists = OfertaList.Any(x => x.Item1 == id_oferta);
            var motiv = result.Item2;
            if (motiv == "")
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            else if (!OfferIDExists)
            {
                MessageBox.Show("Offer ID does not exist.");
                return;
            }
            else if (motiv != "expirare" && motiv != "cantitate")
            {
                MessageBox.Show("Motiv incorect");
                return;
            }

            oferteBLL.ModifyMotivOferta(id_oferta, motiv);
        }

        public void ModifyProcentOferta(object obj)
        {
            if (obj == null || !(obj is Tuple<int, string>))
            {
                return;
            }

            var result = obj as Tuple<int, int>;
            var id_oferta = result.Item1;
            bool OfferIDExists = OfertaList.Any(x => x.Item1 == id_oferta);
            var procent = result.Item2;
            if (procent < 0)
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            else if (!OfferIDExists)
            {
                MessageBox.Show("Offer ID does not exist.");
                return;
            }

            oferteBLL.ModifyProcentOferta(id_oferta, procent);
        }
    }
}
