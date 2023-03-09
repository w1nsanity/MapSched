using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MapSched.data;
using System.IO;

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

            MainPage = new AppShell();
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
