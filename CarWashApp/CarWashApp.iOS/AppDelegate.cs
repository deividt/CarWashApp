// ----------------------------------------------------------------------
// <copyright file="AppDelegate.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.iOS
{
    using Foundation;
    using Syncfusion.ListView.XForms.iOS;
    using Syncfusion.SfBusyIndicator.XForms.iOS;
    using Syncfusion.XForms.iOS.Border;
    using Syncfusion.XForms.iOS.Buttons;
    using UIKit;
    using Xamarin.Essentials;

    /// <summary>
    /// The UIApplicationDelegate for the application. This class is responsible for launching the
    /// User Interface of the application, as well as listening (and optionally responding) to
    /// application events from iOS.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        /// <summary>
        /// This method is invoked when the application has loaded and is ready to run. In this
        /// method you should instantiate the window, load the UI into it and then make the window
        /// visible.
        /// You have 17 seconds to return from this method, or iOS will terminate your application.
        /// </summary>
        /// <param name="app">Parâmetro app</param>
        /// <param name="options">Parâmetro options</param>
        /// <returns>True se FinishedLaunching</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();

            // Popup Plugin
            Rg.Plugins.Popup.Popup.Init();

            // Inicializa Syncfusion Renders
            new SfBusyIndicatorRenderer();
            SfListViewRenderer.Init();
            SfBorderRenderer.Init();
            SfButtonRenderer.Init();

            // Carrega aplicação
            this.LoadApplication(new App());

            // Retorno
            return base.FinishedLaunching(app, options);
        }

        /// <inheritdoc/>
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            if (Platform.OpenUrl(app, url, options))
            {
                return true;
            }

            // Retorno
            return base.OpenUrl(app, url, options);
        }

        /// <inheritdoc/>
        public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
        {
            if (Platform.ContinueUserActivity(application, userActivity, completionHandler))
            {
                return true;
            }

            // Retorno
            return base.ContinueUserActivity(application, userActivity, completionHandler);
        }
    }
}