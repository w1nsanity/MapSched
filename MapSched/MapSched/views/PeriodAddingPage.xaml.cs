using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MapSched.models;
using Android.Content;
using static Android.Renderscripts.Sampler;
using Android.App;

namespace MapSched.views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PeriodAddingPage : ContentPage
    {
        double lat;
        double lng;

        public string ItemId
        {
            set
            {
                LoadPeriod(value);
            }
        }

        private async void LoadPeriod(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                Period period = await App.SchedDB.GetPeriodAsync(id);

                BindingContext = period;
            }
            catch { }
        }

        public PeriodAddingPage()
        {
            InitializeComponent();

            BindingContext = new Period();
        }

        //public PeriodAddingPage(Period period)
        //{
        //    InitializeComponent();
        //}

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Period period = (Period)BindingContext;

            if (!string.IsNullOrWhiteSpace(period.title)
                && time_picker.SelectedIndex != -1
                && building_picker.SelectedIndex != -1
                && dayofweek_picker.SelectedIndex != -1
                && weeknumber_picker.SelectedIndex != -1)
            {
                period.title = period.title.ToUpper();
                period.start_time = time_picker.SelectedItem.ToString();
                period.building = building_picker.SelectedItem.ToString();
                period.week_number = weeknumber_picker.SelectedItem.ToString();
                period.day_of_week = dayofweek_picker.SelectedItem.ToString();

                await App.SchedDB.SavePeriodAsync(period);
                await Shell.Current.GoToAsync("..");
            } else
            {
                await DisplayAlert("", "Не все поля заполнены!", "OK");
            }
        }

        private async void OnDeleteButton_Clicked(Object sender, EventArgs e)
        {
            Period period = (Period)BindingContext;

            await App.SchedDB.DeletePeriodAsync(period);

            await Shell.Current.GoToAsync("..");
        }

        private async void MoveToMapPage(Object sender, EventArgs e)
        {
            Period period = (Period)BindingContext;

            if (period.building == "0") //А
            {
                lat = 55.79471;
                lng = 49.138044;
            }
            else if (period.building == "1") //Б
            {
                lat = 55.794467420919155;
                lng = 49.14124712606008;
            }
            else if (period.building == "2") //В
            {
                lat = 55.79383277438815;
                lng = 49.14052829404409;
            }
            else if (period.building == "3") //Г
            {
                lat = 55.80956043100068;
                lng = 49.18434578649728;
            }
            else if (period.building == "4") //Д
            {
                lat = 55.807531269679785;
                lng = 49.184435058197025;
            }
            else if (period.building == "5") //Е
            {
                lat = 55.80708112562264;
                lng = 49.18560986574552;
            }
            else if (period.building == "6") //И
            {
                lat = 55.82349592908324;
                lng = 49.18172655952453;
            }
            else if (period.building == "7") //К
            {
                lat = 55.79355316163664;
                lng = 49.138649023556155;
            }
            else if (period.building == "8") //Л
            {
                lat = 55.80757658590598;
                lng = 49.18603901918794;
            }
            else if (period.building == "9") //М
            {
                lat = 55.80671153221856;
                lng = 49.18682045582482;
            }
            else if (period.building == "10") //О
            {
                lat = 55.79451275241682;
                lng = 49.14005622525748;
            }
            else if (period.building == "11") //Т
            {
                lat = 55.792179;
                lng = 49.139328;
            }
            else if (period.building == "12") //У
            {
                lat = 55.787088;
                lng = 49.119781;
            }

            //SettingLatLongValue();

            if (string.IsNullOrEmpty(period.building))
            {
                await DisplayAlert("", "Не указан корпус!", "Ок");
            }
            else
            {
                await Navigation.PushAsync(new Map_PAGE(lat, lng));
                await Shell.Current.GoToAsync("//SchedulePage");
                await Shell.Current.GoToAsync("//MapPage");
            }
        }
    }
}