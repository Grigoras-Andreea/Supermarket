using Supermarket.Helpers;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.ViewModels
{
    internal class AddsVM
    {
        private ProducatoriBLL producatoriBLL;
        private ProduseBLL produseBLL;
        private StocuriBLL stocuriBLL;
        private OferteBLL oferteBLL;
        private UtilizatoriBLL utilizatoriBLL;

        public AddsVM()
        {
            producatoriBLL = new ProducatoriBLL();
            AddProducatorCommand = new RelayCommand(AddProducator);
            CompaniesList = producatoriBLL.GetAllProducatori();

            produseBLL = new ProduseBLL();
            AddProdusCommand = new RelayCommand(AddProdus);
            ProductsList = produseBLL.GetAllProduse();
            CodeList = produseBLL.GetAllProductCodes();

            stocuriBLL = new StocuriBLL();
            AddStocCommand = new RelayCommand(AddStoc);
            StocksList = stocuriBLL.GetAllStocks();
            Stocks2List = stocuriBLL.GetAllStocks2();

            oferteBLL = new OferteBLL();
            AddOfertaCommand = new RelayCommand(AddOferta);

            utilizatoriBLL = new UtilizatoriBLL();
            AddUsersCommand = new RelayCommand(AddUsers);
            UsernamesList = utilizatoriBLL.GetAllUsernames();
        }

        public ObservableCollection<Tuple<int, string>> CompaniesList { get; private set; }
        public ObservableCollection<Tuple<int, string>> ProductsList { get; private set; }
        public ObservableCollection<Tuple<int, int, DateTime, int, string>> StocksList { get; private set; }
        public ObservableCollection<Tuple<int, string, int, double, double, string>> Stocks2List { get; private set; }
        public ObservableCollection<string> CodeList { get; private set; }
        public ObservableCollection<string> UsernamesList { get; private set; }

        public RelayCommand AddProducatorCommand { get; set; }

        public void AddProducator(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            var result = obj as Tuple<string, string>;
            var ComapnyName = result.Item1;
            bool CompanyNameExists = CompaniesList.Any(x => x.Item2 == ComapnyName);
            if(CompanyNameExists)
            {
                MessageBox.Show("Company already exists.");
            }
            else if(result.Item1 == "" || result.Item2 == "")
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                producatoriBLL.AddProducator(result);
                MessageBox.Show("Company added successfully.");
            }
        }

        public RelayCommand AddProdusCommand { get; set; }

        public void AddProdus(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            var result = obj as Tuple<string, string, string, int>;
            var ProductName = result.Item1;
            var CompanyID = result.Item4;
            var ProductCode = result.Item2;
            bool ProductNameExists = ProductsList.Any(x => x.Item2 == ProductName);
            bool CompanyIDExists = CompaniesList.Any(x => x.Item1 == CompanyID);
            bool ProductCodeExists = CodeList.Any(x => x == ProductCode);

            if (ProductNameExists)
            {
                MessageBox.Show("Product already exists.");
            }
            else if (ProductCodeExists)
            {
                MessageBox.Show("Product code already exists.");
            }
            else if(ProductCode.Length != 8)
            {
                MessageBox.Show("Product code must have 8 characters.");
            }
            else if (!CompanyIDExists)
            {
                MessageBox.Show("Company does not exist.");
            }
            else if (result.Item1 == "" || result.Item2 == "" || result.Item3 == "")
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                produseBLL.AddProdus(result);
                MessageBox.Show("Product added successfully.");
            }
        }

        public RelayCommand AddStocCommand { get; set; }

        public void AddStoc(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }
            var result = obj as Tuple<int, string, DateTime, DateTime, float, int>;
            var ProductID = result.Item6;
            bool ProductIDExists = ProductsList.Any(x => x.Item1 == ProductID);
            if (!ProductIDExists)
            {
                MessageBox.Show("Product does not exist.");
            }
            else if (result.Item1 <= 0 || result.Item5 <= 0)
            {
                MessageBox.Show("Invalid input.");
            }
            else if(result.Item2 == "")
            {
                MessageBox.Show("Invalid input.");
            }
            else if(result.Item3 > result.Item4)
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                stocuriBLL.AddStoc(result);
                MessageBox.Show("Stock added successfully.");
            }
        }

        public RelayCommand AddOfertaCommand { get; set; }

        public void AddOferta(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            var result = obj as Tuple<int, string, int>;
            var StockID = result.Item1;
            bool StockIDExists = StocksList.Any(x => x.Item1 == StockID);
            if (!StockIDExists)
            {
                MessageBox.Show("Stock does not exist.");
            }
            else if (result.Item2 == "")
            {
                MessageBox.Show("Invalid input.");
            }
            else if (result.Item3 <= 0)
            {
                MessageBox.Show("Invalid input.");
            }
            else if (result.Item2 != "expirare" && result.Item2 != "cantitate")
            {
                MessageBox.Show("Motiv incorect");
            }
            else
            {
                var pret_achizitie = StocksList.FirstOrDefault(x => x.Item1 == StockID)?.Item4 ?? 0;

                var procent_reducere = (double)result.Item3 / 100;
                var pret_vanzare = pret_achizitie * 1.3;

                if (pret_vanzare * (1-procent_reducere) >= pret_achizitie)
                {
                    oferteBLL.AddOferta(result);
                    MessageBox.Show("Offer added successfully.");
                }
                else
                {
                    MessageBox.Show("Selling price cannot be lower than purchase price.");
                }
            }
        }

        public RelayCommand AddUsersCommand { get; set; }

        public void AddUsers(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            var result = obj as Tuple<string, string, string>;
            var Username = result.Item1;
            bool UsernameExists = UsernamesList.Any(x => x == Username);
            if (UsernameExists)
            {
                MessageBox.Show("Username already exists.");
            }
            else if (result.Item1 == "" || result.Item2 == "" || result.Item3 == "")
            {
                MessageBox.Show("Invalid input.");
            }
            else if (result.Item3 != "admin" && result.Item3 != "casier")
            {
                MessageBox.Show("Invalid type.");
            }
            else
            {
                utilizatoriBLL.AddUser(result);
                MessageBox.Show("User added successfully.");
            }
        }
    }
}
