using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    internal class ToFloatConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2)
            {
                return null;
            }

            if (int.TryParse(values[0].ToString(), out int intValue) && float.TryParse(values[1].ToString(), out float floatValue))
            {
                return new Tuple<int, float>(intValue, floatValue);
            }

            return null; // Return null if conversion fails
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
