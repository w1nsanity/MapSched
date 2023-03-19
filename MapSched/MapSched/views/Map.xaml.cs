using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
//using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace MapSched.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        private Position _position = new Position(55.80790313783872, 49.18497260575529);

        //public async void GetPosition()
        //{
        //    var locator = CrossGeolocator.Current;
        //    locator.DesiredAccuracy = 50;
        //    var myPosition = await locator.GetPositionAsync();
        //    _position = new Position(myPosition.Latitude, myPosition.Longitude);
        //}

        public Map()
        {
            InitializeComponent();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(_position, Distance.FromMeters(500)));
        }
    }
}