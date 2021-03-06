// ----------------------------------------------------------------------
// <copyright file="Application.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.iOS
{
    using UIKit;

    /// <summary>
    /// Classe <see cref="Application"/>
    /// </summary>
    public class Application
    {
        /// <summary>
        /// This is the main entry point of the application.
        /// </summary>
        /// <param name="args">Parâmetro args</param>
        public static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate" you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}