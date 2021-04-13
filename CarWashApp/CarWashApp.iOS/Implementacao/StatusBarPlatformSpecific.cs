// ----------------------------------------------------------------------
// <copyright file="StatusBarPlatformSpecific.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

[assembly: Xamarin.Forms.Dependency(typeof(CarWashApp.iOS.Implementacao.StatusBarPlatformSpecific))]

namespace CarWashApp.iOS.Implementacao
{
    using CarWashApp.Interfaces;
    using Xamarin.Forms;

    /// <summary>
    /// Classe <see cref="StatusBarPlatformSpecific" />
    /// </summary>
    public class StatusBarPlatformSpecific : IStatusBarPlatformSpecific
    {
        /// <inheritdoc/>
        public void SetStatusBarColor(Color color)
        {
            // Se fosse necessária implementação, este é um exemplo. (Não foi testado se funciona)
            /*
            UIView statusBar = UIApplication.SharedApplication.ValueForKey(
            new NSString("statusBar")) as UIView;
            if (statusBar != null && statusBar.RespondsToSelector(
            new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = color.ToUIColor();
            }
             */

            // Implementação não necessária para iOS
            return;
        }
    }
}