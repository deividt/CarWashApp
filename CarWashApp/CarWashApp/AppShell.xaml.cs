// ----------------------------------------------------------------------
// <copyright file="AppShell.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp
{
    using CarWashApp.Views;
    using Xamarin.Forms;

    /// <summary>
    /// Classe <see cref="AppShell"/>
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="AppShell" />
        /// </summary>
        public AppShell()
        {
            this.InitializeComponent();
            this.BindingContext = this;

            // Registra outras rotas
            Routing.RegisterRoute(nameof(RegistrarUsuarioPage), typeof(RegistrarUsuarioPage));
            Routing.RegisterRoute(nameof(RelacaoServicosPage), typeof(RelacaoServicosPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(SobrePage), typeof(SobrePage));
            Routing.RegisterRoute(nameof(DefaultPage), typeof(DefaultPage));
        }

        /// <summary>
        /// Adicionar mensagem à lista de notificações
        /// </summary>
        /// <param name="message">Mensagem</param>
        public void AddMessage(string message)
        {
            /*Device.BeginInvokeOnMainThread(() =>
            {
                if (messageDisplay.Children.OfType<Label>().Where(c => c.Text == message).Any())
                {
                    // Do nothing, an identical message already exists
                }
                else
                {
                    Label label = new Label()
                    {
                        Text = message,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.Start
                    };
                    messageDisplay.Children.Add(label);
                }
            });*/
        }
    }
}