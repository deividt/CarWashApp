// ----------------------------------------------------------------------
// <copyright file="AppConstants.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp
{
    /// <summary>
    /// Classe <see cref="AppConstants" />
    /// </summary>
    public static class AppConstants
    {
        #region Usuário
        /// <summary>
        /// Obtém PreferenceUserToken
        /// </summary>
        public static string PreferenceUserToken { get => "PreferenceUserToken"; }

        /// <summary>
        /// Obtém PreferenceUsername
        /// </summary>
        public static string PreferenceUsername { get => "PreferenceUsername"; }
        #endregion

        #region SyncFusion
        /// <summary>
        /// Obtém SyncfusionLicense - 18.4.0.43
        /// </summary>
        public static string SyncfusionLicense { get => "<PUT_YOUR_SYNCFUSION_LICENSE_HERE>"; }
        #endregion

        #region Notification
        /// <summary>
        /// Obtém NotificationChannelName
        /// </summary>
        public static string NotificationChannelName { get => "CarWashAppNotifyChannel"; }
        /// <summary>
        /// Obtém DebugTag
        /// </summary>
        public static string DebugTag { get => "XamarinNotify"; }
        /// <summary>
        /// Obtém SubscriptionTags
        /// </summary>
        public static string[] SubscriptionTags { get; } = { "default" };
        #endregion
    }
}