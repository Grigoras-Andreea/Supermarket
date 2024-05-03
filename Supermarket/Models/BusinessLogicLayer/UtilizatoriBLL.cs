using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class UtilizatoriBLL
    {
        private supermarketDBEntities2 context = new supermarketDBEntities2();
        public ObservableCollection<Utilizatori> UtilizatoriList { get; set; }
        public string ErrorMessage { get; set; }

        public (int id_utilizator, string tip) Login(object obj)
        {
            var result = obj as Tuple<string, string>;
            if (result == null)
            {
                return (-1, null);
            }
            var username = result.Item1;
            var password = result.Item2;

            // Call the stored procedure to verify credentials
            var user = context.spLogIn_Verification_2(username, password).FirstOrDefault();
            if (user == null)
            {
                return (-1, null);
            }
            else
            {
                return (user.id_utilizator, user.tip);

            }
            
        }

        public void AddUser(object obj)
        {
            var result = obj as Tuple<string, string, string>;
            var nume = result.Item1;
            var password = result.Item2;
            var tip = result.Item3;

            // Call the stored procedure to add a new user
            var rowsAffected = context.AddUser(nume, password, tip);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while adding the user.";
            }
            else
            {
                ErrorMessage = "The user was added successfully.";
            }
        }

        public ObservableCollection<string> GetAllUsernames()
        {
            List<string> usernames = context.GetAllUsernames().ToList();
            return new ObservableCollection<string>(usernames);
        }

        public ObservableCollection<Tuple<int, string>> GetAllUsers()
        {
            List<GetAllUsers_Result> users = context.GetAllUsers().ToList();
            ObservableCollection<Tuple<int, string>> result = new ObservableCollection<Tuple<int, string>>();
            foreach (var user in users)
            {
                result.Add(new Tuple<int, string>(user.id_utilizator, user.nume));
            }
            return result;
        }

        public ObservableCollection<Tuple<int, double>> GetSumOfUser(int an, int luna, int id)
        {
            List<GetSumOfUserOfMonth_Result> sum = context.GetSumOfUserOfMonth(an, luna, id).ToList();
            ObservableCollection<Tuple<int, double>> result = new ObservableCollection<Tuple<int, double>>();
            foreach (var s in sum)
            {
                result.Add(new Tuple<int, double>((int)s.Ziua, (double)s.Suma));
            }
            return result;
        }


        //--------------------------------------------------------------------------------
        public void UpdateIsActive()
        {
            var rowsAffected2 = context.UpdateStocuri();
            var rowsAffected = context.UpdateOferte();
            var rowsAffected3 = context.UpdateProduct();
            if (rowsAffected == -1 || rowsAffected2 == -1 || rowsAffected3 == -1)
            {
                ErrorMessage = "An error occurred while updating the stock.";
            }
            else
            {
                ErrorMessage = "The stock was updated successfully.";
            }
        }

        //--------------------------------------------------------------------------------
    }

}
