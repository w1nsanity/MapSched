//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("MapSched.views.PeriodAddingPage.xaml", "views/PeriodAddingPage.xaml", typeof(global::MapSched.views.PeriodAddingPage))]

namespace MapSched.views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("views\\PeriodAddingPage.xaml")]
    public partial class PeriodAddingPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Picker time_picker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Picker building_picker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(PeriodAddingPage));
            time_picker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Picker>(this, "time_picker");
            building_picker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Picker>(this, "building_picker");
        }
    }
}