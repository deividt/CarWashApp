// ----------------------------------------------------------------------
// <copyright file="MainActivity.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Droid
{
    using System;
    using Android.App;
    using Android.Content;
    using Android.Content.PM;
    using Android.Gms.Common;
    using Android.OS;
    using Android.Runtime;
    using Android.Util;

    /// <summary>
    /// Classe <see cref="MainActivity"/>
    /// </summary>
    [Activity(Label = "CarWashApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region Métodos
        #region Públicos
        /// <inheritdoc/>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <inheritdoc/>
        public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
        }

        /// <inheritdoc/>
        protected override void OnResume()
        {
            base.OnResume();

            Xamarin.Essentials.Platform.OnResume();
        }
        #endregion

        #region Protegidos
        /// <inheritdoc/>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // Popup Plugin
            Rg.Plugins.Popup.Popup.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            this.LoadApplication(new App());

            // Valida se o dispositivo suporta Google Play Services
            if (!this.IsPlayServiceAvailable())
            {
                throw new Exception("This device does not have Google Play Services and cannot receive push notifications.");
            }

            // Cria canal para notificações
            this.CreateNotificationChannel();
        }

        /// <inheritdoc/>
        protected override void OnNewIntent(Intent intent)
        {
            if (intent.Extras != null)
            {
                var message = intent.GetStringExtra("message");
                (App.Current.MainPage as AppShell)?.AddMessage(message);
            }

            base.OnNewIntent(intent);
        }
        #endregion

        #region Privados
        /// <summary>
        /// Valida se o dispositivo suporta Google Play Service
        /// </summary>
        /// <returns>True se ok</returns>
        private bool IsPlayServiceAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                // Log
                Log.Debug(AppConstants.DebugTag, GoogleApiAvailability.Instance.IsUserResolvableError(resultCode) ? GoogleApiAvailability.Instance.GetErrorString(resultCode) : "This device is not supported");

                // Retorno
                return false;
            }

            // Retorno
            return true;
        }

        /// <summary>
        /// Cria canal para notificações
        /// </summary>
        private void CreateNotificationChannel()
        {
            // Notification channels are new as of "Oreo".
            // There is no need to create a notification channel on older versions of Android.
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                return;
            }

            var channelName = AppConstants.NotificationChannelName;
            var channelDescription = string.Empty;
            var channel = new NotificationChannel(channelName, channelName, NotificationImportance.Default)
            {
                Description = channelDescription
            };

            var notificationManager = (NotificationManager)this.GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
        #endregion
        #endregion
    }
}