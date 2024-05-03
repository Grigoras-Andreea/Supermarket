using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class BonBLL
    {
        private supermarketDBEntities2 context = new supermarketDBEntities2();
        public ObservableCollection<Bonuri> BonList { get; set; }
        public string ErrorMessage { get; set; }

        public ObservableCollection<Tuple<int, DateTime, int, double>> GetHighestBon(DateTime date)
        {
            List<GetMaxTotalOnDay_Result> bonuri = context.GetMaxTotalOnDay(date).ToList();
            ObservableCollection<Tuple<int, DateTime, int, double>> result = new ObservableCollection<Tuple<int, DateTime, int, double>>();
            foreach (var bon in bonuri)
            {
                result.Add(new Tuple<int, DateTime, int, double>(bon.id_bon, bon.data_eliberare, bon.id_casier, bon.total));
            }
            return result;
        }
    }
}
