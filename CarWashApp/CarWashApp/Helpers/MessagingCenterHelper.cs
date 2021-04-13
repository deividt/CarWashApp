// ----------------------------------------------------------------------
// <copyright file="MessagingCenterHelper.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Helpers
{
    using CarWashApp.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Classe <see cref="MessagingCenterHelper"/>
    /// </summary>
    public static class MessagingCenterHelper
    {
        #region Constantes
        /// <summary>
        /// MessagingCenter MENSAGEM_ALERTA
        /// </summary>
        public const string MENSAGEM_ALERTA = "MSGCTR_MENSAGEM_ALERTA";

        /// <summary>
        /// MessagingCenter DESABILITAR_TOOLBARITEMS
        /// </summary>
        public const string DESABILITAR_TOOLBARITEMS = "MSGCTR_DESABILITAR_TOOLBARITEMS";

        /// <summary>
        /// MessagingCenter TELA_AGUARDE_MOSTRAR
        /// </summary>
        public const string TELA_AGUARDE_MOSTRAR = "MSGCTR_TELA_AGUARDE_MOSTRAR";

        /// <summary>
        /// MessagingCenter TELA_AGUARDE_FECHAR
        /// </summary>
        public const string TELA_AGUARDE_FECHAR = "MSGCTR_TELA_AGUARDE_FECHAR";
        #endregion

        #region Métodos
        /// <summary>
        /// Exibe mensagem
        /// </summary>
        /// <param name="mensagem">Mensagem a ser exibida</param>
        /// <param name="tipoMensagem">Tipo da mensagem a ser exibida</param>
        public static void ExibirMensagem(string mensagem, MessageBox.TipoMensagem tipoMensagem = MessageBox.TipoMensagem.Aviso)
        {
            MessagingCenter.Send<string, MessageBox.TipoMensagem>(mensagem, MessagingCenterHelper.MENSAGEM_ALERTA, tipoMensagem);
        }

        /// <summary>
        /// Mostra TelaAguardeView
        /// </summary>
        /// <param name="viewModel">ViewModel que está bindada à view</param>
        public static void TelaAguardeMostrar(BaseViewModel viewModel)
        {
            MessagingCenter.Send<BaseViewModel>(viewModel, MessagingCenterHelper.TELA_AGUARDE_MOSTRAR);
        }

        /// <summary>
        /// Fecha TelaAguardeView
        /// </summary>
        /// <param name="viewModel">ViewModel que está bindada à view</param>
        public static void TelaAguardeFechar(BaseViewModel viewModel)
        {
            MessagingCenter.Send<BaseViewModel>(viewModel, MessagingCenterHelper.TELA_AGUARDE_FECHAR);
        }
        #endregion
    }
}