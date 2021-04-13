// ----------------------------------------------------------------------
// <copyright file="BaseView.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views.Base
{
    using System.Linq;
    using CarWashApp.Helpers;
    using CarWashApp.ViewModels;
    using Rg.Plugins.Popup.Services;
    using Xamarin.Forms;

    /// <summary>
    /// Classe <see cref="BaseView"/>
    /// </summary>
    public abstract class BaseView : ContentPage
    {
        #region Métodos
        #region Override
        /// <inheritdoc/>
        protected override void OnAppearing()
        {
            // Executa o base
            base.OnAppearing();

            // Registra os eventos para o MessagingCenter
            this.RegistrarMensagens();
        }

        /// <inheritdoc/>
        protected override void OnDisappearing()
        {
            // Executa o base
            base.OnDisappearing();

            // Cancela o registro de eventos para o MessagingCenter
            this.CancelarRegistroMensagens();
        }

        #endregion

        #region Protegidos
        /// <summary>
        /// Registra os eventos para o MessagingCenter
        /// </summary>
        protected void RegistrarMensagens()
        {
            // Mensagem de alerta
            MessagingCenter.Subscribe<string, MessageBox.TipoMensagem>(
                this,
                MessagingCenterHelper.MENSAGEM_ALERTA,
                async (mensagem, tipoMensagem) =>
                {
                    await MessageBox.Show(this, tipoMensagem, mensagem);
                });

            // Desabilitar ToolbarItems
            MessagingCenter.Subscribe<object>(
                this,
                MessagingCenterHelper.DESABILITAR_TOOLBARITEMS,
                (desabilitar) =>
                {
                    this.ToolbarItems.ToList().ForEach(x => x.IsEnabled = !(bool)desabilitar);
                });

            // Exibir TelaAguarde
            MessagingCenter.Subscribe<BaseViewModel>(
                this,
                MessagingCenterHelper.TELA_AGUARDE_MOSTRAR,
                async (sender) =>
                {
                    sender.IsBusy = true;

                    if (PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        await PopupNavigation.Instance.PopAllAsync();
                    }

                    await PopupNavigation.Instance.PushAsync(new TelaAguardeView());
                });

            // Fechar TelaAguarde
            MessagingCenter.Subscribe<BaseViewModel>(
                this,
                MessagingCenterHelper.TELA_AGUARDE_FECHAR,
                async (sender) =>
                {
                    sender.IsBusy = false;

                    if (PopupNavigation.Instance.PopupStack.Count <= 0)
                    {
                        return;
                    }

                    await PopupNavigation.Instance.PopAllAsync();
                });
        }

        /// <summary>
        /// Cancela o registro de eventos para o MessagingCenter
        /// </summary>
        protected void CancelarRegistroMensagens()
        {
            MessagingCenter.Unsubscribe<string, MessageBox.TipoMensagem>(this, MessagingCenterHelper.MENSAGEM_ALERTA);
            MessagingCenter.Unsubscribe<object>(this, MessagingCenterHelper.DESABILITAR_TOOLBARITEMS);
            MessagingCenter.Unsubscribe<BaseViewModel>(this, MessagingCenterHelper.TELA_AGUARDE_MOSTRAR);
            MessagingCenter.Unsubscribe<BaseViewModel>(this, MessagingCenterHelper.TELA_AGUARDE_FECHAR);
        }
        #endregion
        #endregion
    }
}