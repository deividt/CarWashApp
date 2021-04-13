// ----------------------------------------------------------------------
// <copyright file="Enumerador.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Enumeradores
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;

    /// <summary>
    /// Classe <see cref="Enumerador"/>
    /// </summary>
    public static class Enumerador
    {
        /// <summary>
        /// Obtém a lista de valores de um enumerador
        /// </summary>
        /// <typeparam name="T">Tipo do retorno</typeparam>
        /// <returns>Lista com os valores do enumerador</returns>
        public static IList<T> ObterValores<T>()
        {
            return Enum.GetValues(typeof(T)).OfType<T>().ToList();
        }

        /// <summary>
        /// Obtém a descrição de um determinado Enumerador
        /// </summary>
        /// <param name="valor">Enumerador que terá a descrição obtida</param>
        /// <returns>String com a descrição do Enumerador</returns>
        public static string ObterDescricao(Enum valor)
        {
            if (valor == null)
            {
                return string.Empty;
            }

            try
            {
                FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());
                DisplayAttribute[] atributos =
                    (DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
                return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
            }
            catch
            {
                try
                {
                    FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());
                    DescriptionAttribute[] atributos =
                        (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Obtém o enumerador a partir da descrição do enumerador
        /// </summary>
        /// <param name="valor">Valor a ser procurado</param>
        /// <param name="tipo">Tipo do enumerador</param>
        /// <returns>Enumerador encontrado</returns>
        public static Enum ObterEnumerador(string valor, Type tipo)
        {
            foreach (Enum enumerador in Enum.GetValues(tipo))
            {
                if (!ObterDescricao(enumerador).ToUpper().Equals(valor.ToUpper()))
                {
                    continue;
                }

                return enumerador;
            }

            return null;
        }

        /// <summary>
        /// Obtém o atributo customizado de um determinado Enumerador.
        /// </summary>
        /// <param name="valor">Enumerador que terá o abributo obtido</param>
        /// <returns>String com a descrição do atributo do Enumerador.</returns>
        public static string ObterValorAtributo(Enum valor)
        {
            try
            {
                // Obtém o nome do enumerador
                string nome = Enum.GetName(valor?.GetType(), valor);

                // Obtém os atributos
                List<EnumMemberAttribute> atributos =
                    valor.GetType().GetField(nome).GetCustomAttributes(false).OfType<EnumMemberAttribute>().ToList();
                if ((atributos == null) || (atributos.Count == 0))
                {
                    return string.Empty;
                }

                // Retorna o valor do primeiro atributo
                return atributos[0].Value;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Retorna uma lista com os valores de um determinado enumerador - KeyValuePair(valor do enumerador, descrição).
        /// </summary>
        /// <param name="tipo">Enumerador que terá os valores listados</param>
        /// <returns>Lista com os valores do Enumerador.</returns>
        public static IList Listar(Type tipo)
        {
            List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();
            foreach (Enum valor in Enum.GetValues(tipo))
            {
                lista.Add(new KeyValuePair<int, string>((int)Enum.Parse(tipo, valor.ToString()), ObterDescricao(valor)));
            }

            return lista;
        }

        /// <summary>
        /// Retorna uma lista com os valores de um determinado enumerador - KeyValuePair(valor do enumerador em string, descrição).
        /// </summary>
        /// <param name="tipo">Enumerador que terá os valores listados</param>
        /// <returns>Lista com os valores do Enumerador.</returns>
        public static IList ListarToString(Type tipo)
        {
            List<KeyValuePair<string, string>> lista = new List<KeyValuePair<string, string>>();
            foreach (Enum valor in Enum.GetValues(tipo))
            {
                lista.Add(new KeyValuePair<string, string>(((int)Enum.Parse(tipo, valor.ToString())).ToString(), ObterDescricao(valor)));
            }

            return lista;
        }

        /// <summary>
        /// Retorna uma lista com os valores de um determinado enumerador - KeyValuePair(nome do enumerador, descrição).
        /// </summary>
        /// <param name="tipo">Enumerador que terá os valores listados</param>
        /// <returns>Lista com os valores do Enumerador.</returns>
        public static IList ListarToNomeString(Type tipo)
        {
            List<KeyValuePair<string, string>> lista = new List<KeyValuePair<string, string>>();
            foreach (Enum valor in Enum.GetValues(tipo))
            {
                lista.Add(new KeyValuePair<string, string>(valor.ToString(), ObterDescricao(valor)));
            }

            return lista;
        }

        /// <summary>
        /// Retorna uma lista com os valores de um determinado enumerador - KeyValuePair(enumerador, descrição).
        /// </summary>
        /// <param name="tipo">Enumerador que terá os valores listados</param>
        /// <returns>Lista com os valores do Enumerador.</returns>
        public static IList ListarToEnum(Type tipo)
        {
            List<KeyValuePair<Enum, string>> lista = new List<KeyValuePair<Enum, string>>();
            foreach (Enum valor in Enum.GetValues(tipo))
            {
                lista.Add(new KeyValuePair<Enum, string>(valor, ObterDescricao(valor)));
            }

            return lista;
        }
    }
}
