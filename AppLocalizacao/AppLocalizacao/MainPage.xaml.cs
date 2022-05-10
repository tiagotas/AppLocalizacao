using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Essentials;

namespace AppLocalizacao
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("OBTENDO A LOCALIZAÇÃO...");

                var requisicao = new GeolocationRequest(GeolocationAccuracy.Best);
                var localizacao = await Geolocation.GetLocationAsync(requisicao);

                lbl_altitude.Text = localizacao.Altitude.ToString();
                lbl_latitude.Text = localizacao.Latitude.ToString();
                lbl_longitude.Text = localizacao.Longitude.ToString();

            } catch (FeatureNotSupportedException fex)
            {
                await DisplayAlert("Erro Suporte", fex.Message, "OK");

            } catch (PermissionException pex)
            {
                await DisplayAlert("Erro Permissão", pex.Message, "OK");

            } catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
