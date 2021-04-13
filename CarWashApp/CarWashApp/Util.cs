// ----------------------------------------------------------------------
// <copyright file="Util.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Classe <see cref="Util"/>
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Validates the email
        /// </summary>
        /// <param name="email">Gets the email</param>
        /// <returns>Returns the boolean value</returns>
        public static bool CheckValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return true;
            }

            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return regex.IsMatch(email) && !email.EndsWith(".");
        }
    }
}