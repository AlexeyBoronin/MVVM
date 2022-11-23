using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;

namespace MVVM
{
    public class ApplicationViewModel:INotifyPropertyChanged
    {
        private Phone selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        public Phone SelectedPhone 
        {
            get { return selectedPhone;}
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone"); 
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone{ Title="IPhone 14", Company="Apple", Price=125000 },
                new Phone{ Title="Galaxy S22 Ultra", Company="Samsung", Price=90000},
                new Phone{ Title="12 Lite", Company="Xiaomi", Price=35000}
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
