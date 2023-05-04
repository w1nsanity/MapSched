using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MapSched.models;
using static Android.Resource;
using System.Collections.ObjectModel;
using Android.Widget;
using Android;
using Org.W3c.Dom;

namespace MapSched.views
{
    public partial class Schedule : ContentPage
    {
        public Schedule()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            WeekNumberCheck();

            base.OnAppearing();
        }

        public async void WeekNumberCheck()
        {
            if (wn_picker.SelectedItem == "1")
            {
                collectionView_mon.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Понедельник", "1");
                collectionView_tue.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Вторник", "1");
                collectionView_wed.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Среда", "1");
                collectionView_thu.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Четверг", "1");
                collectionView_fri.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Пятница", "1");
                collectionView_sat.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Суббота", "1");
            }
            else if (wn_picker.SelectedItem == "2")
            {
                collectionView_mon.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Понедельник", "2");
                collectionView_tue.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Вторник", "2");
                collectionView_wed.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Среда", "2");
                collectionView_thu.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Четверг", "2");
                collectionView_fri.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Пятница", "2");
                collectionView_sat.ItemsSource = await App.SchedDB.GetPeriodsByDOWnWNAsync("Суббота", "2");
            }
            else
            {
                await DisplayAlert("", "Выберите неделю", "Ок");
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PeriodAddingPage));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection != null)
            {
                Period period = (Period)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync(
                    $"{nameof(PeriodAddingPage)}?{nameof(PeriodAddingPage.ItemId)}={period.ID.ToString()}");
            }
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchBar.Text.Length != 0)
            {
                collectionView.IsVisible = true;
                label_mon.IsVisible = false;
                collectionView_mon.IsVisible = false;
                label_tue.IsVisible = false;
                collectionView_tue.IsVisible = false;
                label_wed.IsVisible = false;
                collectionView_wed.IsVisible = false;
                label_thu.IsVisible = false;
                collectionView_thu.IsVisible = false;
                label_fri.IsVisible = false;
                collectionView_fri.IsVisible = false;
                label_sat.IsVisible = false;
                collectionView_sat.IsVisible = false;
                collectionView.ItemsSource = await App.SchedDB.Search(e.NewTextValue.ToUpper());
            }
            else
            {
                collectionView.IsVisible = false;
                label_mon.IsVisible = true;
                collectionView_mon.IsVisible = true;
                label_tue.IsVisible = true;
                collectionView_tue.IsVisible = true;
                label_wed.IsVisible = true;
                collectionView_wed.IsVisible = true;
                label_thu.IsVisible = true;
                collectionView_thu.IsVisible = true;
                label_fri.IsVisible = true;
                collectionView_fri.IsVisible = true;
                label_sat.IsVisible = true;
                collectionView_sat.IsVisible = true;
            }
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var per = item.CommandParameter as Period;
            var result = await DisplayAlert("Удаление", $"Удалить {per.title} из расписания?", "Да", "Нет");
            if (result)
            {
                await App.SchedDB.DeletePeriodAsync(per);

                WeekNumberCheck();
            }
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            double lat = 0;
            double lng = 0;

            var item = sender as SwipeItem;
            var per = item.CommandParameter as Period;

            if (per.building == "А") //А
            {
                lat = 55.79471;
                lng = 49.138044;
            }
            else if (per.building == "Б") //Б
            {
                lat = 55.794467420919155;
                lng = 49.14124712606008;
            }
            else if (per.building == "В") //В
            {
                lat = 55.79383277438815;
                lng = 49.14052829404409;
            }
            else if (per.building == "Г") //Г
            {
                lat = 55.80956043100068;
                lng = 49.18434578649728;
            }
            else if (per.building == "Д") //Д
            {
                lat = 55.807531269679785;
                lng = 49.184435058197025;
            }
            else if (per.building == "Е") //Е
            {
                lat = 55.80708112562264;
                lng = 49.18560986574552;
            }
            else if (per.building == "И") //И
            {
                lat = 55.82349592908324;
                lng = 49.18172655952453;
            }
            else if (per.building == "К") //К
            {
                lat = 55.79355316163664;
                lng = 49.138649023556155;
            }
            else if (per.building == "Л") //Л
            {
                lat = 55.80757658590598;
                lng = 49.18603901918794;
            }
            else if (per.building == "М") //М
            {
                lat = 55.80671153221856;
                lng = 49.18682045582482;
            }
            else if (per.building == "О") //О
            {
                lat = 55.79451275241682;
                lng = 49.14005622525748;
            }
            else if (per.building == "Т") //Т
            {
                lat = 55.792179;
                lng = 49.139328;
            }
            else if (per.building == "У") //У
            {
                lat = 55.787088;
                lng = 49.119781;
            }


            if (string.IsNullOrEmpty(per.building))
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

        private async void wn_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            WeekNumberCheck();
        }
    }
}