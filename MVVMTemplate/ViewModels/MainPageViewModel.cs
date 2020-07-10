using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using Phylogenetic_1_0.Annotations;
using Phylogenetic_1_0.Helpers;
using Phylogenetic_1_0.Helpers.EventArgsClasses;
using Phylogenetic_1_0.Views;
using Xamarin.Forms;

namespace Phylogenetic_1_0.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public string Test = "Test 1";

        public EventHandler<EventArgs> HelloEventHandler;

        private string _helloWorld;
        public string HelloWorld
        {
            get { return _helloWorld; }
            set
            {
                _helloWorld = value; 
                OnPropertyChanged();
            }
        }
        public EventHandler<PageEventArgs> AddNewPage;

        private readonly ForwardingCommand _helloCommand;
        public ICommand HelloCommand => _helloCommand;

        private readonly ForwardingCommand _addSpecies;
        public ICommand AddSpeciesCommand => _addSpecies;
        
        public MainPageViewModel()
        {
           

            _helloCommand = new ForwardingCommand(CanHelloWorld, DoHelloWorld);

            _addSpecies = new ForwardingCommand(CanAddSpecies, DoAddSpecies);
            HelloWorld = "hELLO wORL!!";
        }

        public bool CanHelloWorld(object _)
        {
            return true;
        }

        public void DoHelloWorld(object _)
        {
            HelloWorld = "NotSoHelloWorld!";

           // HelloEventHandler?.Invoke(this, EventArgs.Empty);
        }
        public bool CanAddSpecies(object _)
        {
            return true;
        }
       
        public  void DoAddSpecies(object _)
        {
            Page page = new TreeTraversalView();

            AddNewPage?.Invoke(this, new PageEventArgs(page));
        }

        // Get the appropriate 
        public ControlTemplate getNavigationPane()
        {

            return new ControlTemplate();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
