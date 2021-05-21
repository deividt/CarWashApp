// ----------------------------------------------------------------------
// <copyright file="SettingsHelper.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Helpers
{
    using Xamarin.Essentials;

    /// <summary>
    /// Classe <see cref="SettingsHelper" />
    /// </summary>
    public static class SettingsHelper
    {
        /// <summary>
        /// Constante que armazena a aparência
        /// 0 - padrão, 1 = clara, 2 = escura
        /// </summary>
        private const int APARENCIA = 0;

        /// <summary>
        /// Obtém ou define a aparência
        /// </summary>
        public static int Aparencia
        {
            get => Preferences.Get(nameof(Aparencia), APARENCIA);
            set => Preferences.Set(nameof(Aparencia), value);
        }
    }
}