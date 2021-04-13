// ----------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.ViewModels
{
    using Xamarin.CommunityToolkit.ObjectModel;

    /// <summary>
    ///  Classe <see cref="BaseViewModel"/>
    /// </summary>
    public class BaseViewModel : ObservableObject
    {
        #region Campos
        /// <summary>
        /// Campo title
        /// </summary>
        private string title = string.Empty;

        /// <summary>
        /// Campo isBusy
        /// </summary>
        private bool isBusy = false;
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém ou define Title
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }

        /// <summary>
        /// Obtém ou define um valor que indica se IsBusy
        /// </summary>
        public bool IsBusy
        {
            get { return this.isBusy; }
            set { this.SetProperty(ref this.isBusy, value); }
        }
        #endregion
    }
}