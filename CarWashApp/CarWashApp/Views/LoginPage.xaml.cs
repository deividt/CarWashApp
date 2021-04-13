// ----------------------------------------------------------------------
// <copyright file="LoginPage.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views
{
    using CarWashApp.Converters;
    using CarWashApp.Services;
    using CarWashApp.Views.Base;
    using Syncfusion.XForms.Border;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    ///  Classe <see cref="LoginPage"/>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : BaseView
    {
        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="LoginPage" />
        /// </summary>
        public LoginPage()
        {
            // Inicializa os componentes
            this.InitializeComponent();

            // Define os bindings
            this.DefinirBindings();
        }
        #endregion

        #region Métodos
        /// <inheritdoc/>
        protected async override void OnAppearing()
        {
            // Verifica se usuário está autenticado
            if (LoginService.IsUsuarioAutenticadoOffline())
            {
                await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                return;
            }

            // Executa o base
            base.OnAppearing();
        }

        /// <summary>
        /// Definir bindings
        /// </summary>
        private void DefinirBindings()
        {
            // Bindings
            this.borderUsuario.SetBinding(
                SfBorder.BorderColorProperty,
                new Binding(
                    nameof(this.entryUsuario.IsFocused),
                    converter: new ErrorValidationColorConverter(),
                    converterParameter: this.entryUsuario,
                    source: this.entryUsuario));

            this.borderSenha.SetBinding(
                SfBorder.BorderColorProperty,
                new Binding(
                    nameof(this.entrySenha.IsFocused),
                    converter: new BooleanToColorConverter(),
                    converterParameter: 3,
                    source: this.entrySenha));
        }
        #endregion
    }
}