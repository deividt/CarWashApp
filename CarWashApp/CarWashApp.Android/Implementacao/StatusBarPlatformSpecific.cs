// ----------------------------------------------------------------------
// <copyright file="StatusBarPlatformSpecific.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

[assembly: Xamarin.Forms.Dependency(typeof(CarWashApp.Droid.Implementacao.StatusBarPlatformSpecific))]

namespace CarWashApp.Droid.Implementacao
{
    using CarWashApp.Interfaces;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// Classe <see cref="StatusBarPlatformSpecific" />
    /// </summary>
    public class StatusBarPlatformSpecific : IStatusBarPlatformSpecific
    {
        /// <inheritdoc/>
        public void SetStatusBarColor(Color color)
        {
            Xamarin.Essentials.Platform.CurrentActivity.Window.SetStatusBarColor(color.AddLuminosity(-0.1).ToAndroid());
        }
    }
}