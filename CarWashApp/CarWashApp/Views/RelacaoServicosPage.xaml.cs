// ----------------------------------------------------------------------
// <copyright file="RelacaoServicosPage.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views
{
    using CarWashApp.ViewModels;
    using CarWashApp.Views.Base;
    using Xamarin.Forms.Xaml;

    /// <summary>
    ///  Classe <see cref="RelacaoServicosPage"/>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RelacaoServicosPage : BaseView
    {
        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="RelacaoServicosPage" />
        /// </summary>
        public RelacaoServicosPage()
        {
            // Inicializa os componentes
            this.InitializeComponent();
        }
        #endregion

        #region Métodos
        /// <inheritdoc/>
        protected override void OnAppearing()
        {
            // Base
            base.OnAppearing();

            ((RelacaoServicosViewModel)this.BindingContext).ObterRelacaoServicosCommand.ExecuteAsync().ConfigureAwait(false);
        }
        #endregion
    }
}