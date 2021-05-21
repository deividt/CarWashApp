// ----------------------------------------------------------------------
// <copyright file="SettingsPage.xaml.cs" company="Deividt Gemeli">
// Copyright (c) Deividt Gemeli.
// </copyright>
// ----------------------------------------------------------------------

namespace CarWashApp.Views
{
    using CarWashApp.Helpers;
    using CarWashApp.Views.Base;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    ///  Classe <see cref="SettingsPage"/>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : BaseView
    {
        #region Construtor
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="SettingsPage" />
        /// </summary>
        public SettingsPage()
        {
            // Inicializa os componentes
            this.InitializeComponent();

            switch (SettingsHelper.Aparencia)
            {
                case 0:
                    this.radioButtonPadrao.IsChecked = true;
                    break;

                case 1:
                    this.radioButtonClaro.IsChecked = true;
                    break;

                case 2:
                    this.radioButtonEscuro.IsChecked = true;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Altera a aparência do app conforme selecionado
        /// </summary>
        /// <param name="sender">Objeto sender</param>
        /// <param name="e">Parâmetro e</param>
        private void radioButtonAparencia_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!e.Value)
            {
                return;
            }

            // Obtém valor selecionado
            string val = (sender as RadioButton)?.Content as string;
            if (string.IsNullOrWhiteSpace(val))
            {
                return;
            }

            switch (val)
            {
                // Aparência clara
                case "Claro":
                    SettingsHelper.Aparencia = 1;
                    break;

                // Aparência escura
                case "Escuro":
                    SettingsHelper.Aparencia = 2;
                    break;

                // Aparência do sistema/padrão
                default:
                    SettingsHelper.Aparencia = 0;
                    break;
            }

            // Aplicar aparência
            AparenciaHelper.AplicarAparencia();
        }
    }
}