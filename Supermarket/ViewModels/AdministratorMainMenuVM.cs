using Supermarket.Helpers;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class AdministratorMainMenuVM
    {
        //--------------------Commands For Admin Main Menu--------------------
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        //--------------------Commands For Admin Add Menu--------------------
        public ICommand AddManufacturerCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand AddStocksCommand { get; set; }
        public ICommand AddUsersCommand { get; set; }
        public ICommand AddSalesCommand { get; set; }

        //--------------------Commands For Admin Delete Menu--------------------
        public ICommand DeleteProductCommand { get; set; }
        public ICommand DeleteStockCommand { get; set; }
        public ICommand DeleteOfferCommand { get; set; }

        //--------------------Commands For Admin Edit Menu--------------------

        public ICommand EditManufacturerCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand EditStocksCommand { get; set; }
        public ICommand EditSalesCommand { get; set; }

        //--------------------Constructor--------------------


        public AdministratorMainMenuVM()
        {
            AddCommand = new RelayCommand(AddWindow);
            EditCommand = new RelayCommand(EditWindow);
            DeleteCommand = new RelayCommand(DeleteWindow);
            SearchCommand = new RelayCommand(SearchWindow);

            AddManufacturerCommand = new RelayCommand(AddManufacturerWindow);
            AddProductCommand = new RelayCommand(AddProductWindow);
            AddStocksCommand = new RelayCommand(AddStocksWindow);
            AddUsersCommand = new RelayCommand(AddUsersWindow);
            AddSalesCommand = new RelayCommand(AddSalesWindow);

            DeleteProductCommand = new RelayCommand(DeleteProductWindow);
            DeleteStockCommand = new RelayCommand(DeleteStockWindow);
            DeleteOfferCommand = new RelayCommand(DeleteOfferWindow);

            EditManufacturerCommand = new RelayCommand(EditManufacturerWindow);
            EditProductCommand = new RelayCommand(EditProductWindow);
            EditStocksCommand = new RelayCommand(EditStocksWindow);
            EditSalesCommand = new RelayCommand(EditSalesWindow);
        }

        private void AddWindow(object obj)
        {
            var addWindow = new Administrator_Add_Menu();
            addWindow.Show();
        }
        private void EditWindow(object obj)
        {
            var editWindow = new Administrator_Modify_Menu();
            editWindow.Show();
        }

        private void DeleteWindow(object obj)
        {
            var deleteWindow = new Administrator_Delete_Menu();
            deleteWindow.Show();
        }

        private void SearchWindow(object obj)
        {
            var searchWindow = new Administrator_Search_Menu();
            searchWindow.Show();
        }

        //--------------------Add Menu--------------------

        private void AddManufacturerWindow(object obj)
        {
            var addManufacturerWindow = new Add_Manufacturer_Page();
            addManufacturerWindow.Show();
        }

        private void AddProductWindow(object obj)
        {
            var addProductWindow = new Add_Products_Page();
            addProductWindow.Show();
        }

        private void AddStocksWindow(object obj)
        {
            var addStocksWindow = new Add_Stocks_Page();
            addStocksWindow.Show();
        }

        private void AddUsersWindow(object obj)
        {
            var addUsersWindow = new Add_Users_Page();
            addUsersWindow.Show();
        }

        private void AddSalesWindow(object obj)
        {
            var addSalesWindow = new Add_Sales_Page();
            addSalesWindow.Show();
        }

        
        //--------------------Delete Menu--------------------

        private void DeleteProductWindow(object obj)
        {
            var deleteProductWindow = new Delete_Product_Page();
            deleteProductWindow.Show();
        }

        private void DeleteStockWindow(object obj)
        {
            var deleteStockWindow = new Delete_Stock_Page();
            deleteStockWindow.Show();
        }

        //--------------------Edit Menu--------------------

        private void EditManufacturerWindow(object obj)
        {
            var editManufacturerWindow = new Modify_Producers_Page();
            editManufacturerWindow.Show();
        }

        private void EditProductWindow(object obj)
        {
            var editProductWindow = new Modify_Products_Page();
            editProductWindow.Show();
        }

        private void EditStocksWindow(object obj)
        {
            var editStocksWindow = new Modify_Stock_Page();
            editStocksWindow.Show();
        }

        private void EditSalesWindow(object obj)
        {
            var editSalesWindow = new Modify_Sales_Page();
            editSalesWindow.Show();
        }

        private void DeleteOfferWindow(object obj)
        {
            var deleteOfferWindow = new Delete_Oferta_Page();
            deleteOfferWindow.Show();
        }
    }
}
