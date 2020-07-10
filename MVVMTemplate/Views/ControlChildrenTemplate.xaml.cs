using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MVVMTemplate.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMTemplate.Views
{
    public partial class ControlChildrenTemplate : ContentPage
    {
        private ControlChildrenTemplateViewModel ViewModel { get; set; }
        public StackLayout StackLayout;


        public ControlChildrenTemplate()
        {
            InitializeComponent();

            ViewModel = new ControlChildrenTemplateViewModel();
            BindingContext = ViewModel;

            StackLayout = ExampleStackLayout;

            ViewModel.AddNewControl += (sender, args) => RefreshStackLayout(args.ChildrenControls);
        }

        private void RefreshStackLayout(IList<View> childrenControls)
        {
            // Remove all the StackLayout Children
            foreach (var control in ExampleStackLayout.Children)
            {
                ExampleStackLayout.Children.Remove(control);
            }

            // loop through all the controls in the list
            foreach (var control in childrenControls)
            {
                // Set the Binding Context
                control.BindingContext = ViewModel;

                // Add the control to the view
                ExampleStackLayout.Children.Add(control);
            }
        }
    }
}
