// ----------------------------------------------------------------------
// <copyright file="RelacaoServicosViewModel.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using Amazon.DynamoDBv2.Model;
    using CarWashApp.Exceptions;
    using CarWashApp.Helpers;
    using CarWashApp.Models;
    using CarWashApp.Services;
    using Xamarin.CommunityToolkit.ObjectModel;

    /// <summary>
    ///  Classe <see cref="RelacaoServicosViewModel"/>
    /// </summary>
    public class RelacaoServicosViewModel : BaseViewModel
    {
        #region Campos
        /// <summary>
        /// Campo listaServicos
        /// </summary>
        private ObservableRangeCollection<Servico> listaServicos;
        #endregion

        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="RelacaoServicosViewModel" />
        /// </summary>
        public RelacaoServicosViewModel()
        {
            // Título
            this.Title = "Relação de Serviços";

            // Comando para obter a relação de serviços
            this.ObterRelacaoServicosCommand = new AsyncCommand(this.ObterRelacaoServicosAsync, allowsMultipleExecutions: false);
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém ListaServicos
        /// </summary>
        public ObservableRangeCollection<Servico> ListaServicos
        {
            get
            {
                if (this.listaServicos == null)
                {
                    this.listaServicos = new ObservableRangeCollection<Servico>();
                }

                return this.listaServicos;
            }
        }

        /// <summary>
        /// Obtém ObterRelacaoServicosCommand
        /// </summary>
        public IAsyncCommand ObterRelacaoServicosCommand { get; }
        #endregion

        #region Métodos
        /// <summary>
        /// Click do botão Login
        /// </summary>
        private async Task ObterRelacaoServicosAsync()
        {
            try
            {
                // Mostra a tela de aguarde
                MessagingCenterHelper.TelaAguardeMostrar(this);

                // Verifica se o token do usuário logado ainda é válido
                await LoginService.VerifyIdToken();

                // Obtém dados do DynamoDB
                AmazonDynamoDBClient client = AwsHelper.AmazonDynamoDBClient;
                DynamoDBContext context = AwsHelper.DynamoDBContext;

                QueryRequest request = new QueryRequest
                {
                    TableName = Servico.TabelaNome,
                    KeyConditionExpression = "(PK = :v_PK) AND begins_with(SK, :v_SK)",
                    ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                        {
                            { ":v_PK", new AttributeValue { S = Servico.PkChave } },
                            { ":v_SK", new AttributeValue { S = Servico.SkChave } }
                        }
                };

                // Retorno
                QueryResponse response = await client.QueryAsync(request);

                // Converte o retorno para lista de objetos
                List<Servico> listaRetorno = new List<Servico>();
                foreach (Dictionary<string, AttributeValue> item in response.Items)
                {
                    listaRetorno.Add(context.FromDocument<Servico>(Document.FromAttributeMap(item)));
                }

                // Atualiza a lista
                this.ListaServicos.AddRange(listaRetorno.OrderBy(x => x.Descricao));
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
        #endregion
    }
}