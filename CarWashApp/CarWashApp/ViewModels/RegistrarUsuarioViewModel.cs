// ----------------------------------------------------------------------
// <copyright file="RegistrarUsuarioViewModel.cs" company="Deividt Gemeli">
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
    ///  Classe <see cref="RegistrarUsuarioViewModel"/>
    /// </summary>
    public class RegistrarUsuarioViewModel : BaseViewModel
    {
        #region Campos
        /// <summary>
        /// Campo usuario
        /// </summary>
        private string usuario;

        /// <summary>
        /// Campo email
        /// </summary>
        private string email;

        /// <summary>
        /// Campo isInvalidEmail
        /// </summary>
        private bool isInvalidEmail;

        /// <summary>
        /// Campo senha
        /// </summary>
        private string senha;

        /// <summary>
        /// Campo confirmarSenha
        /// </summary>
        private string confirmarSenha;
        #endregion

        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="RegistrarUsuarioViewModel" />
        /// </summary>
        public RegistrarUsuarioViewModel()
        {
            // Título
            this.Title = "Senha";

            // Botão Registrar
            this.RegistrarCommand = new AsyncCommand(this.OnRegistrarClicked, () => { return this.HabilitarRegistrar; }, allowsMultipleExecutions: false);

            // Botão Login
            this.LoginCommand = new AsyncCommand(this.OnLoginClicked, allowsMultipleExecutions: false);

            // Botão Registrar Web
            this.RegistrarWebCommand = new AsyncCommand(this.OnRegistrarWeb);
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
                ((AsyncCommand)this.RegistrarCommand).ChangeCanExecute();
            }
        }

        /// <summary>
        /// Obtém ou define Email
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.SetProperty(ref this.email, value);
                ((AsyncCommand)this.RegistrarCommand).ChangeCanExecute();
            }
        }

        /// <summary>
        /// Obtém ou define um valor que indica se IsInvalidEmail
        /// </summary>
        public bool IsInvalidEmail
        {
            get
            {
                return this.isInvalidEmail;
            }

            set
            {
                this.SetProperty(ref this.isInvalidEmail, value);
                ((AsyncCommand)this.RegistrarCommand).ChangeCanExecute();
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
                ((AsyncCommand)this.RegistrarCommand).ChangeCanExecute();
            }
        }

        /// <summary>
        /// Obtém ou define ConfirmarSenha
        /// </summary>
        public string ConfirmarSenha
        {
            get
            {
                return this.confirmarSenha;
            }

            set
            {
                this.SetProperty(ref this.confirmarSenha, value);
                ((AsyncCommand)this.RegistrarCommand).ChangeCanExecute();
            }
        }

        /// <summary>
        /// Obtém um valor que indica se o botão para registrar o usuário estará habilitado
        /// </summary>
        public bool HabilitarRegistrar
        {
            get => !string.IsNullOrWhiteSpace(this.Usuario) &&
                !string.IsNullOrWhiteSpace(this.Email) &&
                !string.IsNullOrWhiteSpace(this.Senha) &&
                !string.IsNullOrWhiteSpace(this.ConfirmarSenha) &&
                (this.Senha == this.ConfirmarSenha) &&
                !this.IsInvalidEmail &&
                !this.IsBusy;
        }

        /// <summary>
        /// Obtém RegistrarCommand
        /// </summary>
        public IAsyncCommand RegistrarCommand { get; }

        /// <summary>
        /// Obtém LoginCommand
        /// </summary>
        public IAsyncCommand LoginCommand { get; }

        /// <summary>
        /// Obtém RegistrarWebCommand
        /// </summary>
        public IAsyncCommand RegistrarWebCommand { get; }
        #endregion

        #region Métodos
        /// <summary>
        /// Click do botão Registrar
        /// </summary>
        private async Task OnRegistrarClicked()
        {
            try
            {
                // Mostra a tela de aguarde
                MessagingCenterHelper.TelaAguardeMostrar(this);

                // Efetuar Login
                await LoginService.RegistrarUsuario(this.Usuario, this.Email, this.Senha);

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
        /// Click do botão Login
        /// </summary>
        private async Task OnLoginClicked()
        {
            try
            {
                await Shell.Current.GoToAsync("..");
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
        /// Click do botão Registrar pela web
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
            this.Email = string.Empty;
            this.IsInvalidEmail = false;
            this.Senha = string.Empty;
            this.ConfirmarSenha = string.Empty;
        }
        #endregion
    }
}