// ----------------------------------------------------------------------
// <copyright file="MessageBox.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using CarWashApp.Enumeradores;
    using CarWashApp.Helpers;
    using CarWashApp.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Classe <see cref="MessageBox"/>
    /// </summary>
    public abstract class MessageBox
    {
        #region Enumeradores
        /// <summary>
        /// Enumerador com opção de Entidade
        /// </summary>
        public enum TipoMensagem
        {
            /// <summary>
            /// Opção Aviso
            /// </summary>
            [Display(Description = "Aviso")]
            Aviso = 0,

            /// <summary>
            /// Opção Atenção
            /// </summary>
            [Display(Description = "Atenção")]
            Atencao = 1,

            /// <summary>
            /// Opção Erro
            /// </summary>
            [Display(Description = "Erro")]
            Erro = 2
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Enviar mensagem
        /// </summary>
        /// <param name="view">View a qual a mensagem será apresentada</param>
        /// <param name="tipo">Tipo da mensagem</param>
        /// <param name="mensagem">Mensagem a ser exibida</param>
        /// <param name="descricaoConfirmar">Botão confirmar - Descrição</param>
        /// <param name="descricaoCancelar">Botão cancelar - Descrição</param>
        /// <returns>True se foi confirmado</returns>
        public static async Task<bool> Show(Page view, TipoMensagem tipo, string mensagem, string descricaoConfirmar, string descricaoCancelar)
        {
            if (string.IsNullOrWhiteSpace(descricaoCancelar))
            {
                descricaoCancelar = "OK";
            }

            if (string.IsNullOrWhiteSpace(descricaoConfirmar))
            {
                MessagingCenterHelper.TelaAguardeFechar((BaseViewModel)view?.BindingContext);
                await view?.DisplayAlert(Enumerador.ObterDescricao(tipo), mensagem, descricaoCancelar);
                return false;
            }

            // Tratar retorno
            MessagingCenterHelper.TelaAguardeFechar((BaseViewModel)view?.BindingContext);
            return await view?.DisplayAlert(Enumerador.ObterDescricao(tipo), mensagem, descricaoConfirmar, descricaoCancelar);
        }

        /// <summary>
        /// Enviar mensagem
        /// </summary>
        /// <param name="view">View a qual a mensagem será apresentada</param>
        /// <param name="tipo">Tipo da mensagem</param>
        /// <param name="mensagem">Mensagem a ser exibida</param>
        /// <param name="descricaoBotao">Descrição do botão</param>
        /// <returns>async Task</returns>
        public static async Task Show(Page view, TipoMensagem tipo, string mensagem, string descricaoBotao)
        {
            await MessageBox.Show(view, tipo, mensagem, null, descricaoBotao);
        }

        /// <summary>
        /// Enviar mensagem (Botão OK)
        /// </summary>
        /// <param name="view">View a qual a mensagem será apresentada</param>
        /// <param name="tipo">Tipo da mensagem</param>
        /// <param name="mensagem">Mensagem a ser exibida</param>
        /// <returns>async Task</returns>
        public static async Task Show(Page view, TipoMensagem tipo, string mensagem)
        {
            await MessageBox.Show(view, tipo, mensagem, null, "OK");
        }
        #endregion
    }
}