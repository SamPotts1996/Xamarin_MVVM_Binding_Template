using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using MVVMTemplate.Annotations;
using Phylogenetic_1_0.Helpers;
using Phylogenetic_1_0.Helpers.EventArgsClasses;
using Xamarin.Forms;

namespace MVVMTemplate.ViewModels
{
    class ControlChildrenTemplateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ForwardingCommand _addControlCommand;
        public ICommand AddControlChildrenCommand => _addControlCommand;

        public EventHandler<ControlChildrenEventArgs> AddNewControl;

        public IList<View> StackLayoutControls { get; set; }

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
        private string _redButtonText;
        public string RedButtonText
        {
            get { return _redButtonText; }
            set
            {
                _redButtonText = value;
                OnPropertyChanged();
            }
        }

        public ControlChildrenTemplateViewModel()
        {
            // Initialize the ICommand with the ForwardingCommand class, this is to check first if a command 'Can' be executed and if true allows the execution or 'Do'. 
            _addControlCommand = new ForwardingCommand(CanAddControl, DoAddControl);
            StackLayoutControls = new List<View>();

            Title = "Click the Red Button to add a new control to the ListView";
            RedButtonText = "Click Me!";
        }

        bool CanAddControl(object _)
        {
            // Create an example limitation
            if (StackLayoutControls.Count >= 5)
            {
                return false;
            }
           
            return true;
        }
        void DoAddControl(object _)
        {
            // Create a label
            var newLabel = new Label()
            {
                BackgroundColor = Color.Black,
                Text = $"Control : {StackLayoutControls.Count.ToString()}"
            };

            // Add the label to the list
            StackLayoutControls.Add(newLabel);

            // Send the updated list to the view
            AddNewControl?.Invoke(this, new ControlChildrenEventArgs(StackLayoutControls));
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
