using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ProducatoriBLL
    {
        private supermarketDBEntities2 context = new supermarketDBEntities2();
        public ObservableCollection<Producatori> ProducatoriList { get; set; }
        public string ErrorMessage { get; set; }

        public void AddProducator(object obj)
        {
            var result = obj as Tuple<string, string>;
            var nume = result.Item1;
            var tara = result.Item2;

            // Call the stored procedure to add a new producer
            var rowsAffected = context.AddProducator(nume, tara);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while adding the producer.";
            }
            else
            {
                ErrorMessage = "The producer was added successfully.";
            }
        }

        public ObservableCollection<Tuple<int, string>> GetAllProducatori()
        {
            List<GetAllProducatori_Result> producatori = context.GetAllProducatori().ToList();
            ObservableCollection<Tuple<int, string>> result = new ObservableCollection<Tuple<int, string>>();
            foreach (var producator in producatori)
            {
                result.Add(new Tuple<int, string>(producator.id_producator, producator.nume_producator));
            }
            return result;
        }

        internal void ModifyNumeProducator(int id_producator, string nume)
        {
            var rowsAffected = context.ModifyNumeProducator(id_producator, nume);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the producer.";
            }
            else
            {
                ErrorMessage = "The producer was modified successfully.";
            }
        }

        internal void ModifyTaraProducator(int id_producator, string tara)
        {
            var rowsAffected = context.ModifyTaraProducator(id_producator, tara);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the producer.";
            }
            else
            {
                ErrorMessage = "The producer was modified successfully.";
            }
        }
    }
}
