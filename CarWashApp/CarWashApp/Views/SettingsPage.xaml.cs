// ----------------------------------------------------------------------
// <copyright file="SettingsPage.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views
{
    using CarWashApp.Views.Base;
    using Xamarin.Forms.Xaml;

    /// <summary>
    ///  Classe <see cref="SettingsPage"/>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : BaseView
    {
        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="SettingsPage" />
        /// </summary>
        public SettingsPage()
        {
            // Inicializa os componentes
            this.InitializeComponent();
        }
        #endregion
    }
}