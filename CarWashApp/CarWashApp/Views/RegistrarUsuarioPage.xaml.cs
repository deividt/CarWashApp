// ----------------------------------------------------------------------
// <copyright file="RegistrarUsuarioPage.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views
{
    using CarWashApp.Converters;
    using CarWashApp.ViewModels;
    using CarWashApp.Views.Base;
    using Syncfusion.XForms.Border;
    using Syncfusion.XForms.Buttons;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    ///  Classe <see cref="RegistrarUsuarioPage"/>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarUsuarioPage : BaseView
    {
        #region Campos
        /// <summary>
        /// Campo contexto
        /// </summary>
        private RegistrarUsuarioViewModel contexto;
        #endregion

        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="RegistrarUsuarioPage" />
        /// </summary>
        public RegistrarUsuarioPage()
        {
            // Inicializa os componentes
            this.InitializeComponent();

            // Define os bindings
            this.DefinirBindings();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Definir bindings
        /// </summary>
        private void DefinirBindings()
        {
            // Define o Binding Context
            this.contexto = new RegistrarUsuarioViewModel();
            this.BindingContext = this.contexto;

            // Bindings
            this.entryUsuario.SetBinding(Entry.TextProperty, nameof(this.contexto.Usuario));
            this.borderUsuario.SetBinding(
                SfBorder.BorderColorProperty,
                new Binding(
                    nameof(this.entryUsuario.IsFocused),
                    converter: new ErrorValidationColorConverter(),
                    converterParameter: this.entryUsuario,
                    source: this.entryUsuario));
            this.entryEmail.SetBinding(Entry.TextProperty, nameof(this.contexto.Email));
            this.borderEmail.SetBinding(
                SfBorder.BorderColorProperty,
                new Binding(
                    nameof(this.entryEmail.IsFocused),
                    converter: new ErrorValidationColorConverter(),
                    converterParameter: this.entryEmail,
                    source: this.entryEmail));
            this.labelValidationEmail.SetBinding(
                Label.IsVisibleProperty,
                new Binding(
                    nameof(this.entryEmail.IsFocused),
                    converter: new StringToBooleanConverter(),
                    converterParameter: this.entryEmail,
                    source: this.entryEmail));
            this.labelIconValidationEmail.SetBinding(
                Label.IsVisibleProperty,
                new Binding(
                    nameof(this.entryEmail.IsFocused),
                    converter: new StringToBooleanConverter(),
                    converterParameter: this.entryEmail,
                    source: this.entryEmail));

            this.borderSenha.SetBinding(SfBorder.BorderColorProperty, new Binding(nameof(this.entrySenha.IsFocused), converter: new BooleanToColorConverter(), converterParameter: 3, source: this.entrySenha));
            this.entrySenha.SetBinding(Entry.TextProperty, nameof(this.contexto.Senha));
            this.borderConfirmarSenha.SetBinding(SfBorder.BorderColorProperty, new Binding(nameof(this.entryConfirmarSenha.IsFocused), converter: new BooleanToColorConverter(), converterParameter: 3, source: this.entryConfirmarSenha));
            this.entryConfirmarSenha.SetBinding(Entry.TextProperty, nameof(this.contexto.ConfirmarSenha));
            this.btnRegistrar.SetBinding(SfButton.CommandProperty, nameof(this.contexto.RegistrarCommand));
            this.btnLogin.SetBinding(SfButton.CommandProperty, nameof(this.contexto.LoginCommand));
            this.btnRegistrarWeb.SetBinding(SfButton.CommandProperty, nameof(this.contexto.RegistrarWebCommand));
        }
        #endregion
    }
}