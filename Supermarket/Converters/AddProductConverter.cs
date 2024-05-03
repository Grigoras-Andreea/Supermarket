using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    internal class AddProductConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Verifică dacă valorile sunt diferite de null și sunt de tipul corect
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                string nume = values[0].ToString();
                string codBare = values[1].ToString();
                string categorie = values[2].ToString();
                int idProducator;
                if (!int.TryParse(values[3].ToString(), out idProducator))
                {
                    // Tratează cazul în care id-ul producătorului nu poate fi convertit în int
                    return null;
                }

                // Creează și returnează tuplul
                return Tuple.Create(nume, codBare, categorie, idProducator);
            }
            else
            {
                // Dacă cel puțin una dintre valorile este null, returnează null
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
