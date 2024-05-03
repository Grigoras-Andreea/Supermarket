using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    internal class SumUserConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null)
            {
                int id_utilizator = 0;
                if (!int.TryParse(values[0].ToString(), out id_utilizator))
                {
                    return null;
                }
                int an = 0;
                if (!int.TryParse(values[1].ToString(), out an))
                {
                    return null;
                }
                int luna = 0;
                if (!int.TryParse(values[2].ToString(), out luna))
                {
                    return null;
                }
                return Tuple.Create(id_utilizator, an, luna);
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
