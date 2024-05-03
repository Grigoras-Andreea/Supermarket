using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    internal class AddStockConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null && values[5] != null)
            {
                int cantitate = 0;
                if (!int.TryParse(values[0].ToString(), out cantitate))
                {
                    return null;
                }
                string unitate = values[1].ToString();
                DateTime data_in = (DateTime)values[2];
                DateTime data_out = (DateTime)values[3];
                float pret = 0;
                if (!float.TryParse(values[4].ToString(), out pret))
                {
                    return null;
                }
                int id_produs = 0;
                if (!int.TryParse(values[5].ToString(), out id_produs))
                {
                    return null;
                }

                return Tuple.Create(cantitate, unitate, data_in, data_out, pret, id_produs);
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = value as Tuple<int, string, DateTime, DateTime, int, int>;
            return new object[] { result.Item1, result.Item2, result.Item3, result.Item4, result.Item5, result.Item6 };
        }
    }
}
