using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XFAzureMapTrial.Models;
using XFAzureMapTrial.Services;

namespace XFAzureMapTrial
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly string azureKey = "";

        public MainPage()
        {
            InitializeComponent();
            Device.BeginInvokeOnMainThread(async () => {
                await SearchForAddress("400 Broad St, Seattle, WA 98109&typeahead=true");
            });
        }

        public async Task SearchForAddress(string address)
        {
            StringBuilder stringUri = new StringBuilder();
            stringUri.Append("https://us.atlas.microsoft.com/search/address/json?");
            stringUri.Append("api-version=1.0&subscription-key=");
            stringUri.Append(azureKey);
            stringUri.Append("&query=");
            stringUri.Append(address);
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try {
                    var result = await RequestProvider.Instance.GetAsync<Temperatures>(stringUri.ToString());
                    if (result != null && result.Results != null && result.Results.Count > 0)
                    {
                        Xamarin.Forms.Maps.Position pos = new Xamarin.Forms.Maps.Position(result.Results[0].Position.Lat, result.Results[0].Position.Lon);
                        this.gMap.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(1.0)));

                        foreach (Result res in result.Results)
                            AddPinToMap(res.Position, res.Address.LocalName ,res.Address.FreeformAddress);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private void AddPinToMap(XFAzureMapTrial.Models.Position pos, string label ,string address)
        {
            Pin pin = new Pin
            {
                Type = PinType.Place,
                Label = label,
                Address = address,
                Position = new Xamarin.Forms.Maps.Position(pos.Lat, pos.Lon)
            };

            this.gMap.Pins.Add(pin);
        }

    }
}
