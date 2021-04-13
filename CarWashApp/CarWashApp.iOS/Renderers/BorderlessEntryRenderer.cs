// ----------------------------------------------------------------------
// <copyright file="BorderlessEntryRenderer.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

[assembly: Xamarin.Forms.ExportRenderer(typeof(CarWashApp.Controls.BorderlessEntry), typeof(CarWashApp.iOS.Renderes.BorderlessEntryRenderer))]

namespace CarWashApp.iOS.Renderes
{
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    /// <summary>
    /// Classe <see cref="BorderlessEntryRenderer" />
    /// </summary>
    public class BorderlessEntryRenderer : EntryRenderer
    {
        /// <summary>
        /// Método OnElementChanged
        /// </summary>
        /// <param name="e">Parâmetro e</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}