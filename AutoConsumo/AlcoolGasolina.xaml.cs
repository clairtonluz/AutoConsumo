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
    public sealed partial class AlcoolGasolina : AutoConsumo.Common.LayoutAwarePage
    {
        public AlcoolGasolina()
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
            Windows.Storage.ApplicationDataContainer roamingSettings =
                Windows.Storage.ApplicationData.Current.RoamingSettings;
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

                in_gasolina.Text = String.Format("{0:0.00}", gasolina);
                in_alcool.Text = String.Format("{0:0.00}", alcool);
                if (porcento > 30)
                {
                    tb_info.Text = "Abastecer alcool é mais lucrativo.";
                }
                else
                {
                    tb_info.Text = "Abastecer gasolina é mais lucrativo.";
                }
            }
            catch (FormatException e1)
            {
                tb_info.Text = "Valor passado não é válido.";
            }

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
