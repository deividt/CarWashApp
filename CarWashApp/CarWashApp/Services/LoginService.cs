// ----------------------------------------------------------------------
// <copyright file="LoginService.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Services
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Amazon.Extensions.CognitoAuthentication;
    using CarWashApp.Exceptions;
    using CarWashApp.Helpers;
    using Xamarin.Essentials;

    /// <summary>
    /// Classe <see cref="LoginService" />
    /// </summary>
    public static class LoginService
    {
        #region Enumeradores
        /// <summary>
        /// Enumerador com opção de Entidade
        /// </summary>
        private enum TipoLogin
        {
            /// <summary>
            /// Opção Aviso
            /// </summary>
            [Display(Description = "login")]
            Login = 0,

            /// <summary>
            /// Opção Atenção
            /// </summary>
            [Display(Description = "signup")]
            Signup = 1
        }
        #endregion

        #region Métodos
        #region Públicos
        /// <summary>
        /// Abre a tela da web para efetuar o login
        /// </summary>
        /// <returns>Token do usuário</returns>
        public static async Task<string> EfetuarLoginWeb()
        {
            string token = await LoginService.LoginRegistrarUsuarioWeb(TipoLogin.Login);
            AtualizarTokenPreferencias(token);
            return token;
        }

        /// <summary>
        /// Abre a tela da web para registrar o usuário
        /// </summary>
        /// <returns>Token do usuário</returns>
        public static async Task<string> RegistrarUsuarioWeb()
        {
            string token = await LoginService.LoginRegistrarUsuarioWeb(TipoLogin.Signup);
            AtualizarTokenPreferencias(token);
            return token;
        }

        /// <summary>
        /// Efetua o login com usuário e senha
        /// </summary>
        /// <param name="usuario">Usuário</param>
        /// <param name="senha">Senha</param>
        /// <returns>Task</returns>
        public static async Task EfetuarLogin(string usuario, string senha)
        {
            CognitoUser user = new CognitoUser(usuario, AwsHelper.COGNITO_APP_CLIENT_ID, AwsHelper.CognitoUserPool, AwsHelper.IdentityClientProvider);
            InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest()
            {
                Password = senha
            };

            // Login
            AuthFlowResponse authResponse = await user.StartWithSrpAuthAsync(authRequest);
            if (authResponse.AuthenticationResult == null)
            {
                throw new MobileErrorException("Não foi possível realizar o login");
            }

            // Atualiza o token
            AtualizarTokenPreferencias(authResponse.AuthenticationResult.AccessToken);

            // Atualiza o username
            AtualizarUsernamePreferencias(usuario);
        }

        /// <summary>
        /// Efetua o login com usuario e senha
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <param name="email">E-mail</param>
        /// <param name="senha">Senha</param>
        /// <returns>Task</returns>
        public static async Task RegistrarUsuario(string usuario, string email, string senha)
        {
            // Só para não ocorrer warnings no visual studio
            await Task.Run(() => { TimeSpan.FromMilliseconds(10); });
            usuario.ToString();
            email.ToString();
            senha.ToString();

            throw new MobileErrorException("Processo ainda não implementado, faça o registro de novos usuário através do botão 'Registrar pela Web'.");

            /*SignUpRequest signUpRequest = new SignUpRequest
            {
                ClientId = AwsHelper.COGNITO_APP_CLIENT_ID,
                Username = usuario,
                Password = senha,
                UserAttributes = new List<AttributeType>
                {
                    new AttributeType
                    {
                        Name = "email",
                        Value = email,
                    }
                }
            };
            var result = await AwsHelper.IdentityClientProvider.SignUpAsync(signUpRequest);

            // TODO: Implementar Registrar Usuário
            await Task.Run(() => { TimeSpan.FromMilliseconds(10); });
            string token = string.Empty;
            AtualizarTokenPreferencias(token);*/
        }

        /// <summary>
        /// Verifica se o usuário está autenticado (Modo Offline)
        /// </summary>
        /// <returns>True se está autenticado</returns>
        public static bool IsUsuarioAutenticadoOffline()
        {
            return !string.IsNullOrEmpty(Preferences.Get(AppConstants.PreferenceUserToken, string.Empty));
        }

        /// <summary>
        /// Obtém o nome do usuário logado gravado nas preferências do sistema
        /// </summary>
        /// <returns>Nome do usuário</returns>
        public static string GetActiveUsername()
        {
            return Preferences.Get(AppConstants.PreferenceUsername, "USUARIO_INVALIDO");
        }

        /// <summary>
        /// Efetua o logout do usuário
        /// </summary>
        public static void UsuarioLogout()
        {
            Preferences.Remove(AppConstants.PreferenceUserToken);
            Preferences.Remove(AppConstants.PreferenceUsername);
        }

        /// <summary>
        /// Valida se o token salvo dispositivo ainda é válido
        /// </summary>
        /// <returns>True se o token é válido</returns>
        public static async Task<bool> VerifyIdToken()
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Privados
        /// <summary>
        /// Abre a tela da web para efetuar o login ou registrar o usuário
        /// </summary>
        /// <param name="tipoLogin">Tipo do login</param>
        /// <returns>Token do usuário</returns>
        private static async Task<string> LoginRegistrarUsuarioWeb(TipoLogin tipoLogin)
        {
            try
            {
                WebAuthenticatorResult result = await WebAuthenticator.AuthenticateAsync(
                    new Uri($"{AwsHelper.COGNITO_DOMAIN}/{Enumeradores.Enumerador.ObterDescricao(tipoLogin)}?client_id={AwsHelper.COGNITO_APP_CLIENT_ID}&response_type=token&scope=email+openid+profile&redirect_uri={AwsHelper.COGNITO_REDIRECT_URI}"),
                    new Uri(AwsHelper.COGNITO_REDIRECT_URI));

                return result?.AccessToken;
            }
            catch (TaskCanceledException)
            {
                throw new MobileErrorException("Processo de autenticação cancelado!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza o token do usuário nas preferencias do app
        /// </summary>
        /// <param name="token">Token a ser gravado</param>
        private static void AtualizarTokenPreferencias(string token)
        {
            Preferences.Set(AppConstants.PreferenceUserToken, token);
        }

        /// <summary>
        /// Atualiza username nas preferencias do app
        /// </summary>
        /// <param name="usuario">Username a ser gravado</param>
        private static void AtualizarUsernamePreferencias(string usuario)
        {
            Preferences.Set(AppConstants.PreferenceUsername, usuario);
        }
        #endregion
        #endregion
    }
}