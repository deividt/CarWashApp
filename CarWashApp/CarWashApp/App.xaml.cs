// ----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp
{
    using System.Globalization;
    using System.Threading;
    using Amazon;
    using CarWashApp.Helpers;
    using CarWashApp.Interfaces;
    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Analytics;
    using Microsoft.AppCenter.Crashes;
    using Syncfusion.Licensing;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    /// <summary>
    /// Classe <see cref="App"/>
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="App" />
        /// </summary>
        public App()
        {
            // Define a cultura
            CultureInfo userCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = userCulture;
            Thread.CurrentThread.CurrentCulture = userCulture;
            Thread.CurrentThread.CurrentUICulture = userCulture;

            // Register Syncfusion license
            SyncfusionLicenseProvider.RegisterLicense(AppConstants.SyncfusionLicense);

            // Light/Dark Theme
            Xamarin.Forms.Device.SetFlags(new string[] { "AppTheme_Experimental" });

            // Inicializa componentes
            this.InitializeComponent();

            // Aplica a aparência
            AparenciaHelper.AplicarAparencia();

            // Define a cor da barra de status, de acordo com a platafaorma e tema
            DependencyService.Get<IStatusBarPlatformSpecific>().SetStatusBarColor(
                Application.Current.RequestedTheme == OSAppTheme.Light ?
                (Color)Application.Current.Resources["HeaderBarBackgroundColorLight"] :
                (Color)Application.Current.Resources["HeaderBarBackgroundColorDark"]);

            // Define a região default para os serviços da AWS
            AWSConfigs.AWSRegion = RegionEndpoint.SAEast1.SystemName;

            // Página principal
            this.MainPage = new AppShell();
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
            // Base
            base.OnStart();

            // AppCenter
            AppCenter.Start("android=61507457-be5d-4fde-bb0d-bc8d26893980;ios=c3c46c19-279a-4721-bd0d-8ac4c837b04f", typeof(Analytics), typeof(Crashes));

            // Chama o método OnResume
            this.OnResume();
        }

        /// <inheritdoc/>
        protected override void OnSleep()
        {
            AparenciaHelper.AplicarAparencia();
            this.RequestedThemeChanged -= this.App_RequestedThemeChanged;
        }

        /// <inheritdoc/>
        protected override void OnResume()
        {
            // Aplica a aparência
            AparenciaHelper.AplicarAparencia();
            this.RequestedThemeChanged += this.App_RequestedThemeChanged;
        }

        /// <summary>
        /// Evento para trocar a aparência do app de acordo com o estado deste
        /// </summary>
        /// <param name="sender">Objeto sender</param>
        /// <param name="e">Parâmetro e</param>
        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                AparenciaHelper.AplicarAparencia();
            });
        }
    }
}