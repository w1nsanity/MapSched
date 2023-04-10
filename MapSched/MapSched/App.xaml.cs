using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MapSched.data;
using System.IO;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using MapSched.views;
using Xamarin.Essentials;

namespace MapSched
{
    public partial class App : Application
    {
        static SchedDB schedDB;

        public static SchedDB SchedDB
        {
            get
            {
                if(schedDB == null)
                {
                    schedDB = new SchedDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "SchedDatabase.db3"));
                }
                return schedDB;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new NavigationPage(new LoginUI());

            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            var isLoogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            if (isLoogged == "1")
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginUI();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
