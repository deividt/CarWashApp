// ----------------------------------------------------------------------
// <copyright file="Servico.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Models
{
    using Amazon.DynamoDBv2.DataModel;

    /// <summary>
    ///  Classe <see cref="Servico"/>
    /// </summary>
    [DynamoDBTable("carwashdb")]
    public class Servico
    {
        #region Constantes
        /// <summary>
        /// Obtém PkChave
        /// </summary>
        public static string TabelaNome { get => "carwashdb"; }

        /// <summary>
        /// Obtém PkChave
        /// </summary>
        public static string PkChave { get => "SERVICO"; }

        /// <summary>
        /// Obtém SkChave
        /// </summary>
        public static string SkChave { get => "MERCADORIA#"; }
        #endregion

        #region Propriedades
        #region Mapeadas
        /// <summary>
        /// Obtém ou define Partition Key
        /// </summary>
        [DynamoDBHashKey("PK")]
        public string PK
        {
            get; set;
        }

        /// <summary>
        /// Obtém ou define Sort key
        /// </summary>
        [DynamoDBRangeKey("SK")]
        public string SK
        {
            get; set;
        }

        /// <summary>
        /// Obtém ou define Descricao
        /// </summary>
        [DynamoDBProperty("descricao")]
        public string Descricao
        {
            get; set;
        }

        /// <summary>
        /// Obtém ou define Status
        /// </summary>
        [DynamoDBProperty("status")]
        public string Status
        {
            get; set;
        }

        /// <summary>
        /// Obtém ou define Valor
        /// </summary>
        [DynamoDBProperty("valor")]
        public double Valor
        {
            get; set;
        }
        #endregion

        #region Ignoradas
        /// <summary>
        /// Obtém um valor que indica se PropriedadeIgnorada
        /// </summary>
        [DynamoDBIgnore]
        public bool PropriedadeIgnorada
        {
            get => true;
        }
        #endregion
        #endregion
    }
}