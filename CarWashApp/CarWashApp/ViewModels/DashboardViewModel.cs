// ----------------------------------------------------------------------
// <copyright file="DashboardViewModel.cs" company="Deividt Gemeli">
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
    ///  Classe <see cref="DashboardViewModel"/>
    /// </summary>
    public class DashboardViewModel : BaseViewModel
    {
        #region Campos
        /// <summary>
        /// Campo username
        /// </summary>
        private string username;
        #endregion

        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="DashboardViewModel" />
        /// </summary>
        public DashboardViewModel()
        {
            // Título
            this.Title = "Dashboard";

            // Nome do usuário logado
            this.ObterUsernameCommand = new AsyncCommand(this.GetUsername, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);

            // Toolbaritem Settings
            this.SettingsCommand =
                new AsyncCommand(this.CallSettings, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);

            // Botão Tela Aguarde
            this.TelaAguardeCommand =
                new AsyncCommand(this.CallTelaAguarde, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);

            // Botão Relação de Serviços
            this.GetRelacaoServicosCommand =
                new AsyncCommand(this.CallRelacaoServicos, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);

            // Botão LogoutCommand
            this.LogoutCommand =
                new AsyncCommand(this.Logout, () => { return !this.IsBusy; }, allowsMultipleExecutions: false);
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém Username
        /// </summary>
        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                this.SetProperty(ref this.username, value);
            }
        }

        /// <summary>
        /// Obtém ObterUsernameCommand
        /// </summary>
        public IAsyncCommand ObterUsernameCommand { get; }

        /// <summary>
        /// Obtém SettingsCommand
        /// </summary>
        public IAsyncCommand SettingsCommand { get; }

        /// <summary>
        /// Obtém TelaAguardeCommand
        /// </summary>
        public IAsyncCommand TelaAguardeCommand { get; }

        /// <summary>
        /// Obtém OpenWebCommand
        /// </summary>
        public IAsyncCommand GetRelacaoServicosCommand { get; }

        /// <summary>
        /// Obtém LogoutCommand
        /// </summary>
        public IAsyncCommand LogoutCommand { get; }
        #endregion

        #region Métodos
        /// <summary>
        /// CallSettings
        /// </summary>
        /// <returns>Task</returns>
        private async Task GetUsername()
        {
            try
            {
                this.Username = await Task.Run(() => LoginService.GetActiveUsername());
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

        #region Privados
        /// <summary>
        /// CallSettings
        /// </summary>
        /// <returns>Task</returns>
        private async Task CallSettings()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(SettingsPage)}");
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
            finally
            {
                MessagingCenterHelper.TelaAguardeFechar(this);
            }
        }

        /// <summary>
        /// CallTelaAguarde
        /// </summary>
        /// <returns>Task</returns>
        private async Task CallTelaAguarde()
        {
            try
            {
                // Mostra a tela de aguarde
                MessagingCenterHelper.TelaAguardeMostrar(this);

                // Aguarda 2 segundos
                await Task.Delay(TimeSpan.FromSeconds(5));
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
            finally
            {
                MessagingCenterHelper.TelaAguardeFechar(this);
            }
        }

        /// <summary>
        /// Método CallRelacaoServicos
        /// </summary>
        /// <returns>Task</returns>
        private async Task CallRelacaoServicos()
        {
            try
            {
                // Navega para a relação de serviços
                await Shell.Current.GoToAsync($"{nameof(RelacaoServicosPage)}");
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
            finally
            {
                MessagingCenterHelper.TelaAguardeFechar(this);
            }
        }

        /// <summary>
        /// Método Logout
        /// </summary>
        /// <returns>Task</returns>
        private async Task Logout()
        {
            try
            {
                LoginService.UsuarioLogout();
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
        #endregion
        #endregion
    }
}