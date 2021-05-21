// ----------------------------------------------------------------------
// <copyright file="AparenciaHelper.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Helpers
{
    using Xamarin.Forms;

    /// <summary>
    /// Classe <see cref="AparenciaHelper" />
    /// </summary>
    public static class AparenciaHelper
    {
        /// <summary>
        /// Aplica a aparência indicada
        /// </summary>
        public static void AplicarAparencia()
        {
            switch (SettingsHelper.Aparencia)
            {
                // Aparência do sistema
                case 0:
                default:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;

                // Aparência clara
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;

                // Aparência escura
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
        }
    }
}