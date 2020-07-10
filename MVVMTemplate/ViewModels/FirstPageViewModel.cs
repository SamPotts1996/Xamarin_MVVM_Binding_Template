using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Phylogenetic_1_0.Helpers;
using Phylogenetic_1_0.Helpers.EventArgsClasses;
using Xamarin.Forms;

namespace MVVMTemplate.ViewModels
{
    public class FirstPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly ForwardingCommand _addControlChildrenCommand;
        public ICommand AddControlChildrenCommand => _addControlChildrenCommand;
        public EventHandler<PageEventArgs> AddNewPage;
        public FirstPageViewModel()
        {

            _addControlChildrenCommand = new ForwardingCommand(CanControlChildren, DoControlChildren);

           
        }
        public bool CanControlChildren(object _)
        {
            return true;
        }

        public void DoControlChildren(object _)
        {
            Page page = new ControlChildrenTemplate();
            AddNewPage?.Invoke(this, new PageEventArgs(page));
        }
    }
}
