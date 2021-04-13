// ----------------------------------------------------------------------
// <copyright file="BorderlessEntryRenderer.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

[assembly: Xamarin.Forms.ExportRenderer(typeof(CarWashApp.Controls.BorderlessEntry), typeof(CarWashApp.Droid.Renderers.BorderlessEntryRenderer))]

namespace CarWashApp.Droid.Renderers
{
    using Android.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using Application = Android.App.Application;

    /// <summary>
    /// Implementation of Borderless editor control.
    /// </summary>
    public class BorderlessEntryRenderer : EntryRenderer
    {
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="BorderlessEntryRenderer" />
        /// </summary>
        public BorderlessEntryRenderer()
            : base(Application.Context)
        {
        }

        /// <summary>
        /// Método OnElementChanged
        /// </summary>
        /// <param name="e">Parâmetro e</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.SetBackground(null);
                this.Control.Gravity = GravityFlags.CenterVertical;
                this.Control.SetPadding(0, 0, 0, 0);
            }
        }
    }
}