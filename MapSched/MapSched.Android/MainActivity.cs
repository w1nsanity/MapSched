﻿using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using Xamarin.Essentials;
using Plugin.CurrentActivity;
using MapSched.views;
using Android.Gms.Maps.Model;
using Android.Gms.Maps;

namespace MapSched.Droid
{
    [Activity(Label = "MapSched", Icon = "@drawable/map_sched_logo_desktop_test", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation,
        };

        protected override async void OnStart()
        {
            base.OnStart();

            if((int)Build.VERSION.SdkInt >= 23)
            {
                if(CheckSelfPermission(Manifest.Permission.AccessFineLocation)
                    != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    //await App.Current.MainPage.DisplayAlert("", "Включите геолокацию и передачу данных, для доступа ко всем функциям приложения", "OK");
                }
            }
        }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            if (requestCode == RequestLocationId)
            {
                if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
                {
                    //App.Current.MainPage.DisplayAlert("", "Permission granted", "OK");
                }
                else
                {
                    //App.Current.MainPage.DisplayAlert("", "Permission denied", "OK");
                }
            }
            else
            {
                Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}