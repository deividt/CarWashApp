// ----------------------------------------------------------------------
// <copyright file="ErrorValidationColorConverter.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Converters
{
    using System;
    using System.Globalization;
    using CarWashApp.Controls;
    using CarWashApp.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    /// <summary>
    /// This class have methods to convert the Boolean values to color objects
    /// This is needed to validate in the Entry controls. If the validation is failed, it will return the color code of error, otherwise it will be transparent
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ErrorValidationColorConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the bool to color
        /// </summary>
        /// <param name="value">Gets the value</param>
        /// <param name="targetType">Gets the target type</param>
        /// <param name="parameter">Gets the parameter</param>
        /// <param name="culture">Gets the culture</param>
        /// <returns>Returns the color.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var emailEntry = parameter as BorderlessEntry;

            if (emailEntry?.BindingContext is RegistrarUsuarioViewModel bindingContextRegistrar)
            {
                var isFocused1 = (bool)value;
                bindingContextRegistrar.IsInvalidEmail = !isFocused1 && !Util.CheckValidEmail(bindingContextRegistrar.Email);

                if (isFocused1)
                {
                    return Color.FromHex("#959eac");
                }

                return bindingContextRegistrar.IsInvalidEmail ? Color.FromHex("#FF4A4A") : Color.FromHex("#ced2d9");
            }

            return Color.FromHex("#ced2d9");
        }

        /// <summary>
        /// This method is used to convert the color to bool
        /// </summary>
        /// <param name="value">Gets the value</param>
        /// <param name="targetType">Gets the target type</param>
        /// <param name="parameter">Gets the parameter</param>
        /// <param name="culture">Gets the culture</param>
        /// <returns>Returns the string.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}