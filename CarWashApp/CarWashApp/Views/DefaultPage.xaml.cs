// ----------------------------------------------------------------------
// <copyright file="DefaultPage.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    ///  Classe <see cref="DefaultPage"/>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultPage : ContentPage
    {
        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="DefaultPage" />
        /// </summary>
        public DefaultPage()
        {
            this.InitializeComponent();
        }
        #endregion
    }
}