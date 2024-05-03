using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    internal class AddUserConverter : IMultiValueConverter
    {
        //Converts the values from the AddUserWindow into a Tuple
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null)
            {
                return Tuple.Create(values[0].ToString(), values[1].ToString(), values[2].ToString());
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = value as Tuple<string, string, string>;
            return new object[] { result.Item1, result.Item2, result.Item3 };
        }
    }
}
