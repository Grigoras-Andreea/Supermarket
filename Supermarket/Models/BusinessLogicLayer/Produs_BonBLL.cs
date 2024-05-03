using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class Produs_BonBLL
    {
        private supermarketDBEntities2 context = new supermarketDBEntities2();
        public ObservableCollection<Produs_Bon> Produs_BonList { get; set; }
        public string ErrorMessage { get; set; }
    }
}
