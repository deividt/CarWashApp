// ----------------------------------------------------------------------
// <copyright file="MobileErrorException.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Microsoft.AppCenter.Crashes;

    /// <summary>
    /// Classe <see cref="MobileErrorException"/>
    /// </summary>
    [Serializable]
    public class MobileErrorException : ErrorException
    {
        #region Construtores
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="MobileErrorException"/>
        /// </summary>
        public MobileErrorException()
        {
        }

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="MobileErrorException"/>
        /// </summary>
        /// <param name="message">A mensagem</param>
        public MobileErrorException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="MobileErrorException"/>
        /// </summary>
        /// <param name="message">A mensagem</param>
        /// <param name="innerException">The inner exception</param>
        public MobileErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="MobileErrorException"/>
        /// </summary>
        /// <param name="info">The object that holds the serialized object data</param>
        /// <param name="context">The contextual information about the source or destination of the exception</param>
        protected MobileErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Envia o erro gerado para o AppCenter
        /// </summary>
        /// <param name="exception">Parâmetro Exception</param>
        /// <param name="informacoesAdicionais">Informações adicionais do erro</param>
        public static void EnviarErroAppCenter(Exception exception, Dictionary<string, string> informacoesAdicionais = null)
        {
            Crashes.TrackError(exception, informacoesAdicionais);
        }
        #endregion
    }
}
