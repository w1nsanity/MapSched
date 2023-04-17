using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MapSched.models;

namespace MapSched.views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PeriodAddingPage : ContentPage
    {
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

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Period period = (Period)BindingContext;

            if (!string.IsNullOrWhiteSpace(period.title)
                && time_picker.SelectedIndex != -1
                && building_picker.SelectedIndex != -1)
            {
                period.start_time = time_picker.SelectedItem.ToString();
                period.building = building_picker.SelectedItem.ToString();

                await App.SchedDB.SavePeriodAsync(period);
                //Period.count++;
                await Shell.Current.GoToAsync("..");
            } else
            {
                await DisplayAlert("Alert", "there are blank space in the form!", "OK");
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
            await Shell.Current.GoToAsync("//MapPage");
        }
    }
}