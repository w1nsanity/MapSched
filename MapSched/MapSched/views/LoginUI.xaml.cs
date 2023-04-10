using MapSched.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapSched.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
        }


        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "1234")
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync("//main");
            }
        }
    }
}