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
                in_kmRodado.Text = in_kmRodado.Text.Replace(',', '.');
                in_listrosGasto.Text = in_listrosGasto.Text.Replace(',', '.');
                
                double kmrodado = Double.Parse(in_kmRodado.Text);
                double litrosGastos = Double.Parse(in_listrosGasto.Text);
                tb_info.Text = "Consumo = " + kmrodado/litrosGastos + " KM/L";
            }
            catch (FormatException e1)
            {
                tb_info.Text = "Valor passado não é válido.";
            }
            catch (OverflowException e1)
            {
                tb_info.Text = "Valor Passado ultrapassa o limite.";
            }
            
        }

        private void bt_alcool_x_gasolina(object sender, RoutedEventArgs e)
        {
            try
            {
                in_Gasolina.Text = in_Gasolina.Text.Replace(',', '.');
                in_alcool.Text = in_alcool.Text.Replace(',', '.');
                double gasolina = Double.Parse(in_Gasolina.Text);
                double alcool = Double.Parse(in_alcool.Text);

                double porcento = 100 - ((alcool*100)/gasolina);

                if (porcento > 30)
                {
                    tb_info.Text = "Abastecer alcool é mais lucrativo. \n alcool está = " + porcento +
                                   "% mais em conta.";
                }
                else
                {
                    tb_info.Text = "Abastecer gasolina é mais lucrativo. \nAlcool está apenas = " + porcento + "% mais em conta. \n" +
                                   "o alcool só compençará se estiver acima de 30% mais barato.";
                }
            }
            catch (FormatException e1)
            {
                tb_info.Text = "Valor passado não é válido.";
            }
            catch (OverflowException e1)
            {
                tb_info.Text = "Valor Passado ultrapassa o limite.";
            }
        }
    }
}
