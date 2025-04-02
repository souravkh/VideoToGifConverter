using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace VideoToGifConverter.Converter
{
    /// <summary>
    /// A value converter that converts a boolean value to a <see cref="Visibility"/> value and vice versa.
    /// </summary>
    internal class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <param name="targetType">The target type of the conversion (should be <see cref="Visibility"/>).</param>
        /// <param name="parameter">Optional parameter for additional conversion logic.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>
        /// <see cref="Visibility.Visible"/> if the boolean value is <c>true</c>; 
        /// <see cref="Visibility.Collapsed"/> if <c>false</c> or if the value is not a boolean.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
                return boolValue ? Visibility.Visible : Visibility.Collapsed;

            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a <see cref="Visibility"/> value back to a boolean value.
        /// </summary>
        /// <param name="value">The <see cref="Visibility"/> value to convert.</param>
        /// <param name="targetType">The target type of the conversion (should be <see cref="bool"/>).</param>
        /// <param name="parameter">Optional parameter for additional conversion logic.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>
        /// <c>true</c> if the <see cref="Visibility"/> is <see cref="Visibility.Visible"/>; 
        /// <c>false</c> if it is <see cref="Visibility.Collapsed"/> or any other value.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility visibility && visibility == Visibility.Visible;
        }
    }
}
