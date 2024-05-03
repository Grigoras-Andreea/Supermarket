using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    internal class ToIntConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null || values.Length != 2)
            {
                return null;
            }

            if (int.TryParse(values[0].ToString(), out int intValue) && int.TryParse(values[1].ToString(), out int intValue2))
            {
                return new Tuple<int, int>(intValue, intValue2);
            }

            return null; // Return null if conversion fails
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
