// ----------------------------------------------------------------------
// <copyright file="TelaAguardeView.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views.Base
{
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Classe <see cref="TelaAguardeView"/>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelaAguardeView : Rg.Plugins.Popup.Pages.PopupPage
    {
        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="TelaAguardeView" />
        /// </summary>
        public TelaAguardeView()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Métodos
        /// <inheritdoc/>
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        #endregion
    }
}