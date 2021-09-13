using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFTimeTable.Converters
{
    public class BindingToContentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                if (values[0] is FrameworkElement element && values[1] is BindingBase binding)
                {
                    DependencyProperty contentProperty = null;
                    if (element is ContentPresenter)
                    {
                        contentProperty = ContentPresenter.ContentProperty;
                    }
                    else if (element is ContentControl)
                    {
                        contentProperty = ContentControl.ContentProperty;
                    }

                    if (contentProperty != null)
                    {
                        _ = element.SetBinding(contentProperty, binding);
                    }
                }
            }
            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static BindingToContentConverter Instance { get; } = new BindingToContentConverter();
    }

    [MarkupExtensionReturnType(typeof(BindingToContentConverter))]
    public class BindingToContentConverterExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
            => BindingToContentConverter.Instance;
    }
}
