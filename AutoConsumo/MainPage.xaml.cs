using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AutoConsumo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void bt_calcular(object sender, RoutedEventArgs e)
        {
            try
            {
                double kmrodado = Double.Parse(in_kmRodado.Text);
                double litrosGastos = Double.Parse(in_LitrosGastos.Text);
                tb_kmPorLitro.Text = kmrodado/litrosGastos + "KM/L";
            }
            catch (FormatException e1)
            {
                tb_kmPorLitro.Text = "Valor passado não é válido.";
            }
            catch (OverflowException e1)
            {
                tb_kmPorLitro.Text = "Valor Passado ultrapassa o limite.";
            }
            
        }
    }
}
