using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_MVVM_Demo.Views
{
    //This is a Converter used to assist the manipulation of values when binding.
    //For this example we have a boolean but want to use it to display a Visibility enum value instead.
    //See the IsLoading binding in the PersonsView for usage of this example.
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolean)
            {
                return boolean ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //This is used for reverse binding.  It can be implemented here but for simplicity note it isn't always used as in this case.
            throw new NotImplementedException();
        }
    }
}
