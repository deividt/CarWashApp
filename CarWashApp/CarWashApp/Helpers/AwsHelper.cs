// ----------------------------------------------------------------------
// <copyright file="AwsHelper.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Helpers
{
    using Amazon;
    using Amazon.CognitoIdentity;
    using Amazon.CognitoIdentityProvider;
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.Extensions.CognitoAuthentication;

    /// <summary>
    /// Classe <see cref="AwsHelper" />
    /// </summary>
    public static class AwsHelper
    {
        #region Constantes
        /// <summary>
        /// Define Identity Pool Id
        /// </summary>
        public const string COGNITO_IDENTITY_POOL_ID = "<PUT_YOUR_IDENTITY_POOL_ID_HERE>";

        /// <summary>
        /// Define Cognito Pool Id
        /// </summary>
        public const string COGNITO_POOL_ID = "<PUT_YOUR_COGNITO_POOL_ID_HERE>";

        /// <summary>
        /// Define Cognito App Client Id
        /// </summary>
        public const string COGNITO_APP_CLIENT_ID = "<PUT_YOUR_COGNITO_APP_CLIENT_HERE>";

        /// <summary>
        /// Define Cognito Redirect Uri
        /// </summary>
        public const string COGNITO_REDIRECT_URI = "<PUT_YOUR_COGNITO_REDIRECT_URI_HERE>";

        /// <summary>
        /// Define Amazon Cognito domain
        /// </summary>
        public const string COGNITO_DOMAIN = "<PUT_YOUR_COGNITO_DOMAIN_HERE>";

        /// <summary>
        /// Deefine Cognito Region
        /// </summary>
        private static readonly RegionEndpoint CognitoRegion = RegionEndpoint.SAEast1;

        /// <summary>
        /// Define DynamoDB Region
        /// </summary>
        private static readonly RegionEndpoint DynamoDbRegion = RegionEndpoint.SAEast1;
        #endregion

        #region Campos
        /// <summary>
        /// Campo CognitoAWSCredentials
        /// </summary>
        private static CognitoAWSCredentials cognitoAWSCredentials;

        /// <summary>
        /// Campo AmazonDynamoDBClient
        /// </summary>
        private static AmazonDynamoDBClient amazonDynamoDBClient;

        /// <summary>
        /// Campo DynamoDBContext
        /// </summary>
        private static DynamoDBContext dynamoDBContext;

        /// <summary>
        /// Campo AmazonCognitoIdentityProviderClient
        /// </summary>
        private static AmazonCognitoIdentityProviderClient identityClientProvider;

        /// <summary>
        /// Campo CognitoUserPool
        /// </summary>
        private static CognitoUserPool cognitoUserPool;
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém CognitoAWSCredentials
        /// </summary>
        public static CognitoAWSCredentials CognitoAWSCredentials
        {
            get
            {
                if (cognitoAWSCredentials == null)
                {
                    cognitoAWSCredentials = new CognitoAWSCredentials(COGNITO_IDENTITY_POOL_ID, CognitoRegion);
                }

                return cognitoAWSCredentials;
            }
        }

        /// <summary>
        /// Obtém AmazonDynamoDBClient
        /// </summary>
        public static AmazonDynamoDBClient AmazonDynamoDBClient
        {
            get
            {
                if (amazonDynamoDBClient == null)
                {
                    amazonDynamoDBClient = new AmazonDynamoDBClient(CognitoAWSCredentials, DynamoDbRegion);
                }

                return amazonDynamoDBClient;
            }
        }

        /// <summary>
        /// Obtém DynamoDBContext
        /// </summary>
        public static DynamoDBContext DynamoDBContext
        {
            get
            {
                if (dynamoDBContext == null)
                {
                    dynamoDBContext = new DynamoDBContext(AmazonDynamoDBClient);
                }

                return dynamoDBContext;
            }
        }

        /// <summary>
        /// Obtém IdentityClientProvider
        /// </summary>
        public static AmazonCognitoIdentityProviderClient IdentityClientProvider
        {
            get
            {
                if (identityClientProvider == null)
                {
                    identityClientProvider = new AmazonCognitoIdentityProviderClient(CognitoAWSCredentials);
                }

                return identityClientProvider;
            }
        }

        /// <summary>
        /// Obtém CognitoUserPool
        /// </summary>
        public static CognitoUserPool CognitoUserPool
        {
            get
            {
                if (cognitoUserPool == null)
                {
                    cognitoUserPool = new CognitoUserPool(AwsHelper.COGNITO_POOL_ID, AwsHelper.COGNITO_APP_CLIENT_ID, IdentityClientProvider);
                }

                return cognitoUserPool;
            }
        }
        #endregion
    }
}