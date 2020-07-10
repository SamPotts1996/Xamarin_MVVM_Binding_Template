using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using MVVMTemplate.Views;
using Phylogenetic_1_0.Helpers;
using Phylogenetic_1_0.Helpers.EventArgsClasses;
using Xamarin.Forms;

namespace MVVMTemplate.ViewModels
{
    public class FirstPageViewModel : INotifyPropertyChanged
    {
        private readonly ForwardingCommand _addControlChildrenCommand;
        public ICommand AddControlChildrenCommand => _addControlChildrenCommand;


        // Create a EventHandler with a custom implementation of the EventArgs class, so that parameters can be passed on the Invoke statement. 
        public EventHandler<PageEventArgs> AddNewPage;


        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public FirstPageViewModel()
        {
            // Initialize the ICommand with the ForwardingCommand class, this is to check first if a command 'Can' be executed and if true allows the execution or 'Do'. 
            _addControlChildrenCommand = new ForwardingCommand(CanControlChildren, DoControlChildren);

            // Set the Title
            Title = "Select An Example";

        }

        // Check if the command CAN execute. 
        public bool CanControlChildren(object _)
        {
            return true;
        }

        // Execute the Control Children command.
        public void DoControlChildren(object _)
        {
            // Initialize the page variable
            Page page = new ControlChildrenTemplate();

            // Invoke the AddNewPage Event with the page as a parameter
            AddNewPage?.Invoke(this, new PageEventArgs(page));
        }


        /// <summary>
        /// Automatically generated code to allow for refreshing of the data on the View, you can see that the title of this page is bound to the Title variable and OnPropertyChanged();
        /// is used; which is the command used to refresh a variable when it should update.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
