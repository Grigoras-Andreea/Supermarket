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

        public ICommand GetProductsByNameCommand { get; set; }
        public ICommand GetProductsByCodeCommand { get; set; }
        public ICommand GetProductsByExpiringDateCommand { get; set; }
        public ICommand GetProductsByProducerCommand { get; set; }
        public ICommand GetProductsByCategoryCommand { get; set; }


        public CasierVM()
        {
            produseBLL = new ProduseBLL();

            GetProductsByNameCommand = new RelayCommand(GetProductsByName);
            GetProductsByCodeCommand = new RelayCommand(GetProductsByCode);
            GetProductsByExpiringDateCommand = new RelayCommand(GetProductsByExpiringDate);
            GetProductsByProducerCommand = new RelayCommand(GetProductsByProducer);
            GetProductsByCategoryCommand = new RelayCommand(GetProductsByCategory);

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
    }
}
