using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using System.Reflection;

namespace MapSched.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map_PAGE : ContentPage
    {
        public Map_PAGE(double lat, double lng)
        {
            InitializeComponent();
            ZoomOnCurrentLocation();
            NavigateToBuilding(lat, lng);
        }

        public Map_PAGE()
        {
            InitializeComponent();
            ZoomOnCurrentLocation();

            Pin pinA = new Pin
            {
                Label = "Корпус A",
                Type = PinType.Place,
                Position = new Position(55.79471, 49.138044),
            };
            Pin pinB = new Pin
            {
                Label = "Корпус Б",
                Type = PinType.Place,
                Position = new Position(55.794467420919155, 49.14124712606008)
            };
            Pin pinV = new Pin
            {
                Label = "Корпус В",
                Type = PinType.Place,
                Position = new Position(55.79383277438815, 49.14052829404409)
            };
            Pin pinG = new Pin
            {
                Label = "Корпус Г",
                Type = PinType.Place,
                Position = new Position(55.80956043100068, 49.18434578649728)
            };
            Pin pinD = new Pin
            {
                Label = "Корпус Д",
                Type = PinType.Place,
                Position = new Position(55.807531269679785, 49.184435058197025)
            };
            Pin pinE = new Pin
            {
                Label = "Корпус Е",
                Type = PinType.Place,
                Position = new Position(55.80708112562264, 49.18560986574552)
            };
            Pin pinI = new Pin
            {
                Label = "Корпус И",
                Type = PinType.Place,
                Position = new Position(55.82349592908324, 49.18172655952453)
            };
            Pin pinK = new Pin
            {
                Label = "Корпус К",
                Type = PinType.Place,
                Position = new Position(55.79355316163664, 49.138649023556155)
            };
            Pin pinL = new Pin
            {
                Label = "Корпус Л",
                Type = PinType.Place,
                Position = new Position(55.80757658590598, 49.18603901918794)
            };
            Pin pinM = new Pin
            {
                Label = "Корпус М",
                Type = PinType.Place,
                Position = new Position(55.80671153221856, 49.18682045582482)
            };
            Pin pinO = new Pin
            {
                Label = "Корпус О",
                Type = PinType.Place,
                Position = new Position(55.79451275241682, 49.14005622525748)
            };
            Pin pinT = new Pin
            {
                Label = "Корпус Т",
                Type = PinType.Place,
                Position = new Position(55.792179, 49.139328)
            };
            Pin pinU = new Pin
            {
                Label = "Корпус У",
                Type = PinType.Place,
                Position = new Position(55.787088, 49.119781)
            };

            map.Pins.Add(pinA);
            map.Pins.Add(pinB);
            map.Pins.Add(pinV);
            map.Pins.Add(pinG);
            map.Pins.Add(pinD);
            map.Pins.Add(pinE);
            map.Pins.Add(pinI);
            map.Pins.Add(pinK);
            map.Pins.Add(pinL);
            map.Pins.Add(pinM);
            map.Pins.Add(pinO);
            map.Pins.Add(pinT);
            map.Pins.Add(pinU);
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

        public async Task NavigateToBuilding(double lat, double lng)
        {
            var location = new Location(lat, lng);
            var options = new MapLaunchOptions
            {
                NavigationMode = NavigationMode.Transit
            };
            try
            {
                await Xamarin.Essentials.Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("", "askjdskaljda", "OK");
            }
        }
    }
}