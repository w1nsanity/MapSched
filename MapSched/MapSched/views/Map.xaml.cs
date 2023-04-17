using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace MapSched.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        public Map()
        {
            InitializeComponent();
            ZoomOnCurrentLocation();
        }

        public async void ZoomOnCurrentLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMeters(300)));
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("", "Включите геолокацию и передачу данных, для доступа ко всем функциям приложения", "OK");
            }
        }


    }
}