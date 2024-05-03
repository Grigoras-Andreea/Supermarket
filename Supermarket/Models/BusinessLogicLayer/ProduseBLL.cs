using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ProduseBLL
    {
        private supermarketDBEntities2 context = new supermarketDBEntities2();
        public ObservableCollection<Produse> ProduseList { get; set; }
        public string ErrorMessage { get; set; }

        public void AddProdus(object obj)
        {
            var result = obj as Tuple<string, string, string, int>;
            var nume = result.Item1;
            var cod = result.Item2;
            var categorie = result.Item3;
            var id_producator = result.Item4;

            // Call the stored procedure to add a new product
            var rowsAffected = context.AddProdus(nume, cod, categorie, id_producator);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while adding the product.";
            }
            else
            {
                ErrorMessage = "The product was added successfully.";
            }
        }

        public ObservableCollection<Tuple<int, string>> GetAllProduse()
        {
            List<GetAllProduse2_Result> produse = context.GetAllProduse2().ToList();
            ObservableCollection<Tuple<int, string>> result = new ObservableCollection<Tuple<int, string>>();
            foreach (var produs in produse)
            {
                result.Add(new Tuple<int, string>(produs.id_produs, produs.nume));
            }
            return result;
        }

        public ObservableCollection<string> GetAllProductCodes()
        {
            List<string> coduri = context.GetAllProductCodes().ToList();
            return new ObservableCollection<string>(coduri);
        }

        internal void DeleteProdus(int productId)
        {
            var rowsAffected = context.DeleteProducts(productId);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while deleting the product.";
            }
            else
            {
                ErrorMessage = "The product was deleted successfully.";
            }
        }

        internal void ModifyNumeProdus(int id_produs, string nume)
        {
            var rowsAffected = context.ModifyNumeProdus(id_produs, nume);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the product.";
            }
            else
            {
                ErrorMessage = "The product was modified successfully.";
            }
        }

        internal void ModifyCategorieProdus(int id_produs, string categorie)
        {
            var rowsAffected = context.ModifyCategorieProdus(id_produs, categorie);
            if (rowsAffected == -1)
            {
                ErrorMessage = "An error occurred while modifying the product.";
            }
            else
            {
                ErrorMessage = "The product was modified successfully.";
            }
        }

        public ObservableCollection<Tuple<string, string>> GetAllProductsFromCompanySortedByCategory(int id_producator)
        {
            List<GetAllProductsFromCompanySortedByCategory_Result> produse = context.GetAllProductsFromCompanySortedByCategory(id_producator).ToList();
            ObservableCollection<Tuple<string, string>> result = new ObservableCollection<Tuple<string, string>>();
            if (produse.Any())
            {
                string previousCategory = produse.First().categorie; // Initialize with the category of the first product

                foreach (var produs in produse)
                {
                    if (produs.categorie != previousCategory)
                    {
                        result.Add(new Tuple<string, string>("", ""));
                        previousCategory = produs.categorie; 
                    }

                    result.Add(new Tuple<string, string>(produs.categorie, produs.nume));
                }
            }
            return result;
        }

        
    }
}
