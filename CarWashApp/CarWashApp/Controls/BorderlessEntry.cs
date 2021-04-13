// ----------------------------------------------------------------------
// <copyright file="BorderlessEntry.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Controls
{
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    /// <summary>
    ///  Classe <see cref="BorderlessEntry"/>
    ///  This class is inherited from Xamarin.Forms.Entry to remove the border for Entry control in the Android platform
    /// </summary>
    [Preserve(AllMembers = true)]
    public class BorderlessEntry : Entry
    {
    }
}