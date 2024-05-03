using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    internal class AddSaleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null)
            {
                int id_stoc = 0;
                if (!int.TryParse(values[0].ToString(), out id_stoc))
                {
                    return null;
                }
                string motiv = values[1].ToString();
                int discount = 0;
                if (!int.TryParse(values[2].ToString(), out discount))
                {
                    return null;
                }

                return Tuple.Create(id_stoc, motiv, discount);
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = value as Tuple<int, string, int>;
            return new object[] { result.Item1, result.Item2, result.Item3 };
        }
    }
}
