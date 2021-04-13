// ----------------------------------------------------------------------
// <copyright file="WebAuthenticationCallbackActivity.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Droid
{
    using Android.App;
    using Android.Content.PM;

    /// <summary>
    /// Classe <see cref="WebAuthenticationCallbackActivity" />
    /// </summary>
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(
        new[] { Android.Content.Intent.ActionView },
        Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
        DataScheme = "carwashapp")]
    public class WebAuthenticationCallbackActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
    }
}