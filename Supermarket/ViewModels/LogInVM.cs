using Supermarket.Helpers;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class LogInVM
    {
        private UtilizatoriBLL utilizatorBLL;


        public LogInVM()
        {
            utilizatorBLL = new UtilizatoriBLL();
            LoginCommand = new RelayCommand(Login);
        }

        public ICommand LoginCommand { get; set; }
        public (int id_utilizator, string tip) FindUser(object obj)
        {
            return utilizatorBLL.Login(obj);
        }

        private void Login(object obj)
        {

            var user = FindUser(obj);

            if(user == (-1, null))
            {
                MessageBox.Show("Invalid credentials");
            }
            else
            {
                if(user.tip == "admin")
                {
                    utilizatorBLL.UpdateIsActive();
                    var adminWindow = new PaginaAdministrator();
                    adminWindow.Show();
                }
                else if (user.tip == "casier")
                {
                    utilizatorBLL.UpdateIsActive();
                    var userWindow = new PaginaCasier();
                    userWindow.Show();
                }
            }
        }
    }
}
