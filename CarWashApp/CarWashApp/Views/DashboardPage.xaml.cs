// ----------------------------------------------------------------------
// <copyright file="DashboardPage.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views
{
    using CarWashApp.ViewModels;
    using CarWashApp.Views.Base;

    /// <summary>
    ///  Classe <see cref="DashboardPage"/>
    /// </summary>
    public partial class DashboardPage : BaseView
    {
        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="DashboardPage" />
        /// </summary>
        public DashboardPage()
        {
            // Inicializa os componentes
            this.InitializeComponent();
        }
        #endregion

        #region Métodos
        /// <inheritdoc/>
        protected async override void OnAppearing()
        {
            // Executa o base
            base.OnAppearing();

            // Define o nome do usuário
            await ((DashboardViewModel)this.BindingContext).ObterUsernameCommand.ExecuteAsync().ConfigureAwait(false);
        }
        #endregion
    }
}