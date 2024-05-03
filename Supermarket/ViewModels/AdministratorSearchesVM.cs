using Supermarket.Helpers;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class AdministratorSearchesVM : BaseVM
    {
        private ProducatoriBLL producatoriBLL;
        private ProduseBLL produseBLL;
        private StocuriBLL stocuriBLL;
        private UtilizatoriBLL utilizatoriBLL;
        private BonBLL bonBLL;
        private int id_producator;


        public ICommand SearchCompanyCommand { get; set;}
        public ICommand ShowProductsAndCategoryCommand { get; set; }
        public ICommand ShowCategoriesSumCommand { get; set; }

        public ICommand ShowUserSumCommand { get; set; }

        public ICommand ShowUserSumPageCommand { get; set; }

        public ICommand ShowHighestInvoiceCommand { get; set; }

        public ICommand ShowHighestInvoicePageCommand { get; set; }

        public AdministratorSearchesVM()
        {
            SearchCompanyCommand = new RelayCommand(SearchCompany);

            ShowCategoriesSumCommand = new RelayCommand(ShowCategoriesSum);

            ShowUserSumPageCommand = new RelayCommand(ShowUserSumPage);

            ShowHighestInvoicePageCommand = new RelayCommand(ShowHighestInvoicePage);


            producatoriBLL = new ProducatoriBLL();
            CompaniesList = producatoriBLL.GetAllProducatori();

            produseBLL = new ProduseBLL();
            ShowProductsAndCategoryCommand = new RelayCommand(ShowProductsAndCategory);

            stocuriBLL = new StocuriBLL();
            CategoriesSumList = stocuriBLL.GetSumByCategory();

            utilizatoriBLL = new UtilizatoriBLL();
            UserList = utilizatoriBLL.GetAllUsers();
            ShowUserSumCommand = new RelayCommand(ShowUserSum);

            bonBLL = new BonBLL();
            ShowHighestInvoiceCommand = new RelayCommand(ShowHighestInvoice);
        }

        public ObservableCollection<Tuple<int, string>> CompaniesList { get; private set; }
        private ObservableCollection<Tuple<string, string>> productsByCategory;
        public ObservableCollection<Tuple<string, string>> ProductsByCategory 
        {
            get => productsByCategory;
            set
            {
                productsByCategory = value;
                NotifyPropertyChanged("ProductsByCategory");
            }
        }

        private ObservableCollection<Tuple<int, double>> userSum;
        public ObservableCollection<Tuple<int, double>> UserSum
        {
            get => userSum;
            set
            {
                userSum = value;
                NotifyPropertyChanged("UserSum");
            }
        }

        private ObservableCollection<Tuple<int, DateTime, int, double>> highestInvoice;
        public ObservableCollection<Tuple<int, DateTime, int, double>> HighestInvoice
        {
            get => highestInvoice;
            set
            {
                highestInvoice = value;
                NotifyPropertyChanged("HighestInvoice");
            }
        }

        public ObservableCollection<Tuple<int, string>> UserList { get; private set; }

        public ObservableCollection<Tuple<string, double>> CategoriesSumList { get; private set;}
        

        private void SearchCompany(object obj)
        {
            var search = new Search_Company_For_Categories_Page();
            search.Show();
        }

        private void ShowProductsAndCategory(object obj)
        {
            if (obj != null && obj is int id)
            {
                id_producator = id;
                ProductsByCategory = produseBLL.GetAllProductsFromCompanySortedByCategory(id_producator);
            }
        }

        private void ShowCategoriesSum(object obj)
        {
            var CategoriesSum = new Categories_Sum_Page();
            CategoriesSum.Show();
        }

        private void ShowUserSumPage(object obj)
        {
            var UserSumPage = new Sum_User_Page();
            UserSumPage.Show();
        }

        private void ShowUserSum(object obj)
        {
            if (obj != null)
            {
                var result = obj as Tuple<int, int, int>;
                var id = result.Item1;
                var an = result.Item2;
                var luna = result.Item3;
                UserSum = utilizatoriBLL.GetSumOfUser(an, luna, id);
            }
        }

        private void ShowHighestInvoice(object obj)
        {
            if (obj != null)
            {
                var date = obj as DateTime?;
                HighestInvoice = bonBLL.GetHighestBon(date.Value);
            }
        }

        private void ShowHighestInvoicePage(object obj)
        {
            var HighestInvoicePage = new Highest_Day_Invoice();
            HighestInvoicePage.Show();
        }
    }
}
