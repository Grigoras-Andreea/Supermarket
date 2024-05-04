using Supermarket.Helpers;
using Supermarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class CasierVM : BaseVM
    {
        private ProduseBLL produseBLL;

        private ShoppingListBLL shoppingListBLL;

        public ICommand GetProductsByNameCommand { get; set; }
        public ICommand GetProductsByCodeCommand { get; set; }
        public ICommand GetProductsByExpiringDateCommand { get; set; }
        public ICommand GetProductsByProducerCommand { get; set; }
        public ICommand GetProductsByCategoryCommand { get; set; }




        public ICommand AddProductToShoppingListCommand { get; set; }
        public ICommand FinishShoppingListCommand { get; set; }


        public CasierVM()
        {
            produseBLL = new ProduseBLL();
            shoppingListBLL = new ShoppingListBLL();

            GetProductsByNameCommand = new RelayCommand(GetProductsByName);
            GetProductsByCodeCommand = new RelayCommand(GetProductsByCode);
            GetProductsByExpiringDateCommand = new RelayCommand(GetProductsByExpiringDate);
            GetProductsByProducerCommand = new RelayCommand(GetProductsByProducer);
            GetProductsByCategoryCommand = new RelayCommand(GetProductsByCategory);

            AddProductToShoppingListCommand = new RelayCommand(AddProduct);
            FinishShoppingListCommand = new RelayCommand(FinishShoppingList);

        }

        private ObservableCollection<Tuple<string, string, string, int>> productsList;
        public ObservableCollection<Tuple<string, string, string, int>> ProductsList
        {
            get
            {
                return productsList;
            }
            set
            {
                productsList = value;
                NotifyPropertyChanged("ProductsList");
            }
        }

        private ObservableCollection<Tuple<int, string, double>> shoppingList;
        public ObservableCollection<Tuple<int, string, double>> ShoppingList
        {
            get
            {
                return shoppingList;
            }
            set
            {
                shoppingList = value;
                NotifyPropertyChanged("ShoppingList");
            }
        }

        private ObservableCollection<Tuple<string, int, double, int>> finalShoppinList;
        public ObservableCollection<Tuple<string, int, double, int>> FinalShoppingList
        {
            get
            {
                return finalShoppinList;
            }
            set
            {
                finalShoppinList = value;
                NotifyPropertyChanged("FinalShoppingList");
            }
        }

        private double totalPrice;
        public double TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                NotifyPropertyChanged("TotalPrice");
            }
        }

        private void GetProductsByName(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                ProductsList = produseBLL.GetAllProductsByName(obj.ToString());
            }
        }

        private void GetProductsByCode(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                ProductsList = produseBLL.GetAllProductsByCode(obj.ToString());
            }
        }

        private void GetProductsByExpiringDate(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                ProductsList = produseBLL.GetAllProductsByDataExpirare((DateTime)obj);
            }
        }

        private void GetProductsByProducer(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                ProductsList = produseBLL.GetAllProductsByCompany(obj.ToString());
            }
        }

        private void GetProductsByCategory(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("Invalid input.");
            }
            else
            {
                ProductsList = produseBLL.GetAllProductsByCategory(obj.ToString());
            }
        }

        //--------------------------------------------

        private void AddProduct(object obj)
        {
            var code = obj?.ToString(); // Null check for input code
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            var product = shoppingListBLL.GetShoppingListElement(code);
            if (product != null)
            {
                if (ShoppingList == null)
                {
                    ShoppingList = new ObservableCollection<Tuple<int, string, double>>();
                }
                ShoppingList.Add(product);
            }
        }

        private void FinishShoppingList(object obj)
        {
            if (ShoppingList == null || ShoppingList.Count == 0)
            {
                MessageBox.Show("The shopping list is empty.");
                return;
            }

            Tuple<ObservableCollection<Tuple<string, int, double, int>>, double> result = shoppingListBLL.FinishShoppingList(ShoppingList, 2);

            FinalShoppingList = result.Item1;
            TotalPrice = result.Item2;

            ShoppingList.Clear();
        }
    }
}
