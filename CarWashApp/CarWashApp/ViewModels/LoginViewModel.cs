// ----------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="Deividt Gemeli">
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
    ///  Classe <see cref="LoginViewModel"/>
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Campos
        /// <summary>
        /// Campo usuario
        /// </summary>
        private string usuario;

        /// <summary>
        /// Campo senha
        /// </summary>
        private string senha;
        #endregion

        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="LoginViewModel" />
        /// </summary>
        public LoginViewModel()
        {
            // Título
            this.Title = "Login";

            // Botão Login
            this.LoginCommand = new AsyncCommand(this.OnLoginClicked, () => { return this.HabilitarLogin; }, allowsMultipleExecutions: false);

            // Botão Registrar
            this.RegistrarWebCommand = new AsyncCommand(this.OnRegistrarWeb);

            // Botão LoginWeb
            this.LoginWebCommand = new AsyncCommand(this.OnLoginWeb);
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém ou define Usuario
        /// </summary>
        public string Usuario
        {
            get
            {
                return this.usuario;
            }

            set
            {
                this.SetProperty(ref this.usuario, value);
                ((AsyncCommand)this.LoginCommand).ChangeCanExecute();
            }
        }

        /// <summary>
        /// Obtém ou define Senha
        /// </summary>
        public string Senha
        {
            get
            {
                return this.senha;
            }

            set
            {
                this.SetProperty(ref this.senha, value);
                ((AsyncCommand)this.LoginCommand).ChangeCanExecute();
            }
        }

        /// <summary>
        /// Obtém LoginCommand
        /// </summary>
        public IAsyncCommand LoginCommand { get; }

        /// <summary>
        /// Obtém RegistrarWebCommand
        /// </summary>
        public IAsyncCommand RegistrarWebCommand { get; }

        /// <summary>
        /// Obtém LoginWebCommand
        /// </summary>
        public IAsyncCommand LoginWebCommand { get; }

        /// <summary>
        /// Obtém um valor que indica se o botão para login estará habilitado
        /// </summary>
        public bool HabilitarLogin
        {
            get => !string.IsNullOrWhiteSpace(this.Usuario) && !string.IsNullOrWhiteSpace(this.Senha) && !this.IsBusy;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Click do botão Login
        /// </summary>
        private async Task OnLoginClicked()
        {
            try
            {
                // Mostra a tela de aguarde
                MessagingCenterHelper.TelaAguardeMostrar(this);

                // Efetuar Login
                await LoginService.EfetuarLogin(this.Usuario, this.Senha);

                // Limpa os dados informados
                this.LimparDadosInformados();

                // Fecha a tela de aguarde
                MessagingCenterHelper.TelaAguardeFechar(this);

                // Navega para a tela principal
                await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
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
        /// Click do botão Login Web
        /// </summary>
        private async Task OnLoginWeb()
        {
            try
            {
                // Efetua o login pela web
                await LoginService.EfetuarLoginWeb();

                // Limpa os dados informados
                this.LimparDadosInformados();

                // Navega para a tela principal
                await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
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
        /// Click do botão Registrar
        /// </summary>
        private async Task OnRegistrarWeb()
        {
            try
            {
                await LoginService.RegistrarUsuarioWeb();

                // Limpa os dados informados
                this.LimparDadosInformados();

                // Navega para a tela principal
                await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
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
        /// Limpa os dados informados
        /// </summary>
        private void LimparDadosInformados()
        {
            this.Usuario = string.Empty;
            this.Senha = string.Empty;
        }
        #endregion
    }
}