using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MapSched.views;

namespace MapSched
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(PeriodAddingPage), typeof(PeriodAddingPage));
            Routing.RegisterRoute(nameof(LoginUI), typeof(LoginUI));
        }
    }
}