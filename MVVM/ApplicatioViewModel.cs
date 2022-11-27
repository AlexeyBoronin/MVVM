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
    internal class ApplicationViewModel:INotifyPropertyChanged
    {
        private Phone selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        //command Add
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Phone phone = new Phone();
                        Phones.Insert(0, phone);
                        SelectedPhone = phone;
                    }));
            }
        }
        //command Relay
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Phone phone = obj as Phone;
                        if (phone != null)
                        {
                            Phones.Remove(phone);
                        }
                    },
                    (obj) => Phones.Count > 0));
            }
        }
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
