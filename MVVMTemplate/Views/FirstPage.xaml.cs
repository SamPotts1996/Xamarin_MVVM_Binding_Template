using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MVVMTemplate.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMTemplate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public FirstPageViewModel ViewModel { get; set; }

        public FirstPage()
        {
            InitializeComponent();

            // Initialize the ViewModel
            ViewModel = new FirstPageViewModel();

            // Set the Binding Context to the ViewModel
            BindingContext = ViewModel;


            // Handler of the Event invoked in the ViewModel 
            ViewModel.AddNewPage += (sender, args) => AddPage(args.Page);
        }

        // The Page is sent from the ViewModel 
        private void AddPage(Page page)
        {
            // The page is added to the navigation stack
            Navigation.PushAsync(page);
        }
    }
}
