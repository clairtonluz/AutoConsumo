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
    public sealed partial class Consumo : AutoConsumo.Common.LayoutAwarePage
    {
        public Consumo()
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
                String resultString = String.Format("{0:0.00}", resultado);
                tb_info.Text = "Consumo = " + resultString + " KM/L";


                in_kmRodado.Text = String.Format("{0:0.00}", kmrodado);
                in_listrosGasto.Text = String.Format("{0:0.00}", litrosGastos);

                Windows.Storage.ApplicationDataContainer roamingSettings =
                Windows.Storage.ApplicationData.Current.RoamingSettings;
                roamingSettings.Values["in_consumo"] = resultString;
            }
            catch (FormatException e1)
            {
                tb_info.Text = "Valor passado não é válido.";
            }

        }
    }
}
