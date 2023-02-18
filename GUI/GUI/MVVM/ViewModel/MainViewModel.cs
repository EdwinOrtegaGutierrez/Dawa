using GUI.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public FileViewModel FileVM { get; set; }
        // Logic for change view
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            FileVM = new FileViewModel();
            CurrentView = FileVM;

            
        }
    }
}
