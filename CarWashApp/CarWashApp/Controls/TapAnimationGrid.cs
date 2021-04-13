// ----------------------------------------------------------------------
// <copyright file="TapAnimationGrid.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Controls
{
    using System.Threading.Tasks;
    using Xamarin.CommunityToolkit.ObjectModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    /// <summary>
    /// classe <see cref="TapAnimationGrid" />
    /// </summary>
    [Preserve(AllMembers = true)]
    public class TapAnimationGrid : Grid
    {
        #region Campos
        /// <summary>
        /// Gets or sets the CommandProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandProperty =
           BindableProperty.Create(nameof(Command), typeof(IAsyncCommand), typeof(TapAnimationGrid), null);

        /// <summary>
        /// Gets or sets the CommandParameterProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(TapAnimationGrid), null);

        /// <summary>
        /// Gets or sets the TappedProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty TappedProperty =
            BindableProperty.Create(nameof(Tapped), typeof(bool), typeof(TapAnimationGrid), false, BindingMode.TwoWay, null, propertyChanged: OnTapped);

        /// <summary>
        /// Campo tappedCommand
        /// </summary>
        private IAsyncCommand tappedCommand;
        #endregion

        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="TapAnimationGrid" />
        /// </summary>
        public TapAnimationGrid() => this.Initialize();
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém ou define
        /// </summary>
        public IAsyncCommand Command
        {
            get => (IAsyncCommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Obtém ou define
        /// </summary>
        public object CommandParameter
        {
            get => this.GetValue(CommandParameterProperty);
            set => this.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Obtém ou define um valor que indica se Tapped
        /// </summary>
        public bool Tapped
        {
            get => (bool)this.GetValue(TappedProperty);
            set => this.SetValue(TappedProperty, value);
        }

        /// <summary>
        /// Obtém TappedCommand
        /// </summary>
        public IAsyncCommand TappedCommand => this.tappedCommand
            ?? (this.tappedCommand = new AsyncCommand(async () =>
            {
                this.Tapped = !this.Tapped;

                if (this.Command != null)
                {
                    this.CommandParameter = this.CommandParameter;
                    await this.Command.ExecuteAsync();
                }
            }));
        #endregion

        #region Métodos
        /// <summary>
        /// Método executado ao pressionar item
        /// </summary>
        /// <param name="bindable">Parâmetro BindableObject</param>
        /// <param name="oldValue">Objeto old</param>
        /// <param name="newValue">Objeto new</param>
        public static async void OnTapped(BindableObject bindable, object oldValue, object newValue)
        {
            var grid = (TapAnimationGrid)bindable;
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            grid.BackgroundColor = (Color)retVal;

            // To make the selected item color changes for 100 milliseconds.
            await Task.Delay(100);
            Application.Current.Resources.TryGetValue("Gray-White", out var retValue);
            grid.BackgroundColor = (Color)retValue;
        }

        /// <summary>
        /// Invoked when control is initialized.
        /// </summary>
        public void Initialize()
        {
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = this.TappedCommand
            });
        }
        #endregion
    }
}