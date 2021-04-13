// ----------------------------------------------------------------------
// <copyright file="ErrorException.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///  Classe <see cref="ErrorException" />
    /// </summary>
    [Serializable]
    public abstract class ErrorException : Exception
    {
        #region Campos
        /// <summary>
        /// Campo mensagem interna
        /// </summary>
        private readonly string message;
        #endregion

        #region Construtores
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="ErrorException" />
        /// </summary>
        public ErrorException()
        {
            this.message = string.Empty;
        }

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="ErrorException" />
        /// </summary>
        /// <param name="message">A mensagem</param>
        public ErrorException(string message)
            : base(message)
        {
            this.message = message;
        }

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="ErrorException" />
        /// </summary>
        /// <param name="message">A mensagem</param>
        /// <param name="innerException">The inner exception</param>
        public ErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.message = message;
        }

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="ErrorException" />
        /// </summary>
        /// <param name="info">The object that holds the serialized object data</param>
        /// <param name="context">The contextual information about the source or destination of the exception</param>
        protected ErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.message = (string)info.GetValue("message", typeof(string));
        }
        #endregion

        #region Propriedades
        /// <inheritdoc/>
        public override string Message
        {
            get { return this.message; }
        }
        #endregion

        #region Métodos
        #region Públicos
        /// <summary>
        /// Ignorar erro - Para não mostrar "Warning" em desenvolvimento
        /// </summary>
        public static void IgnorarErro()
        {
            return;
        }

        /// <summary>
        /// Retorna a mensagem completa da exceção
        /// </summary>
        /// <param name="exception">Parametro Exception</param>
        /// <param name="stackTrace">Retornar StackTrace</param>
        /// <returns>Mensagem do erro</returns>
        public static string GetMessageFull(Exception exception, bool stackTrace)
        {
            // Mensagem
            string erroMsg = exception?.Message;

            // Mensagens (Inner)
            while (exception.InnerException != null)
            {
                erroMsg += string.Format("{0}{1}", Environment.NewLine, exception.InnerException.Message);
                exception = exception.InnerException;
            }

            // Sem StackTrace
            if (!stackTrace)
            {
                return erroMsg;
            }

            // Com StackTrace
            return string.Format(
                "[ERRO]{0}{1}{0}{0}[StackTrace]{0}{2}", Environment.NewLine, erroMsg, ErrorException.GetStackTraceFull(exception));
        }

        /// <summary>
        /// Retorna a mensagem completa da exceção - Sem StackTrace
        /// </summary>
        /// <param name="exception">Parametro Exception</param>
        /// <returns>Mensagem do erro</returns>
        public static string GetMessageFull(Exception exception)
        {
            return ErrorException.GetMessageFull(exception, false);
        }

        /// <summary>
        /// Retorna o StackTrace completo da exceção
        /// </summary>
        /// <param name="exception">Parametro Exception</param>
        /// <returns>StackTrace do erro</returns>
        public static string GetStackTraceFull(Exception exception)
        {
            // StackTrace
            string stackMsg = exception?.StackTrace;

            // StackTrace (Inner)
            while (exception.InnerException != null)
            {
                stackMsg += string.Format("{0}{1}", Environment.NewLine, exception.InnerException.StackTrace);
                exception = exception.InnerException;
            }

            return stackMsg;
        }

        /// <summary>
        /// Gravar Log no "console" - Erro gerado (Mensagem + StackTrace)
        /// </summary>
        /// <param name="exp">Exception a ser avaliada</param>
        /// <param name="stackTrace">Gerar StackTrace</param>
        /// <param name="adicional">Informações adicionais a serem incluídas no início da mensagem</param>
        public static void GravarLogConsole(Exception exp, bool stackTrace, string adicional)
        {
            Console.WriteLine(
                string.Format(
                "{0}{1}",
                string.IsNullOrEmpty(adicional) ? string.Empty : string.Format("{0}{1}", adicional, Environment.NewLine),
                ErrorException.GetMessageFull(exp, stackTrace)));
        }

        /// <summary>
        /// Gravar Log no "console"
        /// </summary>
        /// <param name="mensagem">Mensagem a ser gravada</param>
        /// <param name="adicional">Informações adicionais a serem incluídas no início da mensagem</param>
        public static void GravarLogConsole(string mensagem, string adicional)
        {
            Console.WriteLine(
                string.Format(
                "{0}{1}",
                string.IsNullOrEmpty(adicional) ? string.Empty : string.Format("{0}{1}", adicional, Environment.NewLine),
                mensagem));
        }

        /// <summary>
        /// Gravar Log no "console"
        /// </summary>
        /// <param name="mensagem">Mensagem a ser gravada</param>
        public static void GravarLogConsole(string mensagem)
        {
            ErrorException.GravarLogConsole(mensagem, null);
        }
        #endregion

        #region ISerializable Members
        /// <inheritdoc/>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("message", this.message);
        }
        #endregion
        #endregion
    }
}