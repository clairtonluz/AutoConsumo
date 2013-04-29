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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace AutoConsumo
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : AutoConsumo.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            if (pageState != null && pageState.ContainsKey("in_kmRodado"))
            {
                in_kmRodado.Text = pageState["in_kmRodado"].ToString();
            }

            if (pageState != null && pageState.ContainsKey("in_litrosGasto"))
            {
                in_listrosGasto.Text = pageState["in_litrosGasto"].ToString();
            }

            if (pageState != null && pageState.ContainsKey("in_distancia"))
            {
                in_distancia.Text = pageState["in_distancia"].ToString();
            }

            Windows.Storage.ApplicationDataContainer roamingSettings =
                Windows.Storage.ApplicationData.Current.RoamingSettings;
            if (roamingSettings.Values.ContainsKey("in_consumo"))
            {
                in_consumo.Text = roamingSettings.Values["in_consumo"].ToString();
            }

            if (roamingSettings.Values.ContainsKey("in_gasolina"))
            {
                in_gasolina.Text = roamingSettings.Values["in_gasolina"].ToString();
            }

            if (roamingSettings.Values.ContainsKey("in_alcool"))
            {
                in_alcool.Text = roamingSettings.Values["in_alcool"].ToString();
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            pageState["in_kmRodado"] = in_kmRodado.Text;
            pageState["in_litrosGasto"] = in_listrosGasto.Text;
            pageState["in_distancia"] = in_distancia.Text;
        }

        private void bt_calcular(object sender, RoutedEventArgs e)
        {
            try
            {
                in_kmRodado.Text = in_kmRodado.Text.Replace('.', ',');
                in_listrosGasto.Text = in_listrosGasto.Text.Replace('.', ',');

                double kmrodado = Double.Parse(in_kmRodado.Text);
                double litrosGastos = Double.Parse(in_listrosGasto.Text);
                double resultado = kmrodado / litrosGastos;
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
                in_gasolina.Text = in_gasolina.Text.Replace('.', ',');
                in_alcool.Text = in_alcool.Text.Replace('.', ',');
                double gasolina = Double.Parse(in_gasolina.Text);
                double alcool = Double.Parse(in_alcool.Text);

                double porcento = 100 - ((alcool * 100) / gasolina);

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
                tb_info.Text = "Para viajar " + in_distancia.Text + " KM é necessário " + distancia / consumo +
                    " litros de combustivel.";
            }
            catch (FormatException e1)
            {
                tb_info.Text = "Valor passado não é válido.";
            }

        }

        
        private void in_consumo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer roamingSettings =
                Windows.Storage.ApplicationData.Current.RoamingSettings;
            roamingSettings.Values["in_consumo"] = in_consumo.Text;
        }

        private void in_alcool_TextChanged(object sender, TextChangedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer roamingSettings =
                Windows.Storage.ApplicationData.Current.RoamingSettings;
            roamingSettings.Values["in_alcool"] = in_alcool.Text;
        }

        private void in_gasolina_TextChanged(object sender, TextChangedEventArgs e)
        {
            Windows.Storage.ApplicationDataContainer roamingSettings =
                Windows.Storage.ApplicationData.Current.RoamingSettings;
            roamingSettings.Values["in_gasolina"] = in_gasolina.Text;
        }
    }
}
