// ----------------------------------------------------------------------
// <copyright file="IStatusBarPlatformSpecific.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Interfaces
{
    using Xamarin.Forms;

    /// <summary>
    /// Classe <see cref="IStatusBarPlatformSpecific" />
    /// </summary>
    public interface IStatusBarPlatformSpecific
    {
        /// <summary>
        /// Atribui para a barra de status a cor especificada
        /// </summary>
        /// <param name="color">Cor a ser aplicada</param>
        void SetStatusBarColor(Color color);
    }
}