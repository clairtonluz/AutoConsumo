﻿using System;
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
    public sealed partial class CombustivelViagem : AutoConsumo.Common.LayoutAwarePage
    {
        public CombustivelViagem()
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
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            pageState["in_distancia"] = in_distancia.Text;
        }


        private void bt_calcular_viagem(object sender, RoutedEventArgs e)
        {
            try
            {
                in_distancia.Text = in_distancia.Text.Replace('.', ',');
                in_consumo.Text = in_consumo.Text.Replace('.', ',');

                double distancia = Double.Parse(in_distancia.Text);
                double consumo = Double.Parse(in_consumo.Text);
                

                in_distancia.Text = String.Format("{0:0.00}", distancia);
                in_consumo.Text = String.Format("{0:0.00}", consumo);

                tb_info.Text = "Para viajar " + in_distancia.Text + " KM é necessário " + String.Format("{0:0.00}", (distancia / consumo)) +
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
    }
}
