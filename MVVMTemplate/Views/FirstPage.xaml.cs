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

            ViewModel = new FirstPageViewModel();
            BindingContext = ViewModel;

            ViewModel.AddNewPage += (sender, args) => AddPage(args.Page);

        }

        private void AddPage(Page page)
        {
            Navigation.PushAsync(page);
        }
    }
}
