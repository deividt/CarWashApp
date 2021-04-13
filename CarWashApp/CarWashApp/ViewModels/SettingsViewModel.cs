// ----------------------------------------------------------------------
// <copyright file="SettingsViewModel.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using CarWashApp.Exceptions;
    using CarWashApp.Helpers;
    using CarWashApp.Services;
    using CarWashApp.Views;
    using Xamarin.CommunityToolkit.ObjectModel;
    using Xamarin.Forms;

    /// <summary>
    ///  Classe <see cref="SettingsViewModel"/>
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="SettingsViewModel" />
        /// </summary>
        public SettingsViewModel()
        {
            // Título
            this.Title = "Settings";

            // Editar Perfil
            this.EditarPerfilCommand =
                new AsyncCommand(this.EditarPerfil, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);

            // Trocar Senha
            this.TrocarSenhaCommand =
                new AsyncCommand(this.TrocarSenha, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);

            // Sobre Nós
            this.SobreNosCommand =
                new AsyncCommand(this.SobreNos, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);

            // Ajuda
            this.AjudaCommand =
                new AsyncCommand(this.Ajuda, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);

            // Botão LogoutCommand
            this.LogoutCommand =
                new AsyncCommand(this.Logout, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém EditarPerfilCommand
        /// </summary>
        public IAsyncCommand EditarPerfilCommand { get; }

        /// <summary>
        /// Obtém TrocarSenhaCommand
        /// </summary>
        public IAsyncCommand TrocarSenhaCommand { get; }

        /// <summary>
        /// Obtém SobreNosCommand
        /// </summary>
        public IAsyncCommand SobreNosCommand { get; }

        /// <summary>
        /// Obtém AjudaCommand
        /// </summary>
        public IAsyncCommand AjudaCommand { get; }

        /// <summary>
        /// Obtém LogoutCommand
        /// </summary>
        public IAsyncCommand LogoutCommand { get; }
        #endregion

        #region Métodos
        /// <summary>
        /// Método Logout
        /// </summary>
        /// <returns>Task</returns>
        private async Task Logout()
        {
            try
            {
                LoginService.UsuarioLogout();
                await Shell.Current.GoToAsync("..");
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            catch (MobileErrorException e)
            {
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e), MessageBox.TipoMensagem.Atencao);
            }
            catch (Exception e)
            {
                MobileErrorException.EnviarErroAppCenter(e);
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e, true), MessageBox.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Método EditarPerfil
        /// </summary>
        /// <returns>Task</returns>
        private async Task EditarPerfil()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(DefaultPage)}");
            }
            catch (MobileErrorException e)
            {
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e), MessageBox.TipoMensagem.Atencao);
            }
            catch (Exception e)
            {
                MobileErrorException.EnviarErroAppCenter(e);
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e, true), MessageBox.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Método TrocarSenha
        /// </summary>
        /// <returns>Task</returns>
        private async Task TrocarSenha()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(DefaultPage)}");
            }
            catch (MobileErrorException e)
            {
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e), MessageBox.TipoMensagem.Atencao);
            }
            catch (Exception e)
            {
                MobileErrorException.EnviarErroAppCenter(e);
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e, true), MessageBox.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Método SobreNos
        /// </summary>
        /// <returns>Task</returns>
        private async Task SobreNos()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(DefaultPage)}");
            }
            catch (MobileErrorException e)
            {
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e), MessageBox.TipoMensagem.Atencao);
            }
            catch (Exception e)
            {
                MobileErrorException.EnviarErroAppCenter(e);
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e, true), MessageBox.TipoMensagem.Erro);
            }
        }

        /// <summary>
        /// Método Ajuda
        /// </summary>
        /// <returns>Task</returns>
        private async Task Ajuda()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(DefaultPage)}");
            }
            catch (MobileErrorException e)
            {
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e), MessageBox.TipoMensagem.Atencao);
            }
            catch (Exception e)
            {
                MobileErrorException.EnviarErroAppCenter(e);
                MessagingCenterHelper.ExibirMensagem(MobileErrorException.GetMessageFull(e, true), MessageBox.TipoMensagem.Erro);
            }
        }
        #endregion
    }
}