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
                in_kmRodado.Text = in_kmRodado.Text.Replace('.', ',');
                in_listrosGasto.Text = in_listrosGasto.Text.Replace('.', ',');
                
                double kmrodado = Double.Parse(in_kmRodado.Text);
                double litrosGastos = Double.Parse(in_listrosGasto.Text);
                double resultado = kmrodado/litrosGastos;
                tb_info.Text = "Consumo = " + resultado + " KM/L";
                in_consumo.Text = "" + resultado;
            }
            catch (FormatException e1)
            {
                tb_info.Text = "Valor passado não é válido.";
            }
            
        }

        private void bt_alcool_x_gasolina(object sender, RoutedEventArgs e)
        {
            try
            {
                in_Gasolina.Text = in_Gasolina.Text.Replace('.', ',');
                in_alcool.Text = in_alcool.Text.Replace('.', ',');
                double gasolina = Double.Parse(in_Gasolina.Text);
                double alcool = Double.Parse(in_alcool.Text);

                double porcento = 100 - ((alcool*100)/gasolina);

                if (porcento > 30)
                {
                    tb_info.Text = "Abastecer alcool é mais lucrativo. \nalcool está = " + porcento +
                                   "% mais em conta.";
                }
                else
                {
                    tb_info.Text = "Abastecer gasolina é mais lucrativo.\nAlcool está apenas = " + porcento + "% mais em conta.\n" +
                                   "O alcool só compençará se estiver acima de 30% mais barato.";
                }
            }
            catch (FormatException e1)
            {
                tb_info.Text = "Valor passado não é válido.";
            }
           
        }

        private void bt_calcular_viagem(object sender, RoutedEventArgs e)
        {
            try
            {
                in_distancia.Text = in_distancia.Text.Replace('.', ',');
                in_consumo.Text = in_consumo.Text.Replace('.', ',');

                double distancia = Double.Parse(in_distancia.Text);
                double consumo = Double.Parse(in_consumo.Text);
                tb_info.Text = "Para viajar " + in_distancia.Text + " KM é necessário " + distancia/consumo +
                    " litros de combustivel.";
            }
            catch (FormatException e1)
            {
                tb_info.Text = "Valor passado não é válido.";
            }
            
        }
    }
}
