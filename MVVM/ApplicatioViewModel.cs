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
        Phone? selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        //command Add
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Phone? phone = new Phone("","",0);
                        Phones.Insert(0, phone);
                        SelectedPhone = phone;
                    }));
            }
        }
        //command Relay
        private RelayCommand? removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Phone? phone = obj as Phone;
                        if (phone != null)
                        {
                            Phones.Remove(phone);
                        }
                    },
                    (obj) => Phones.Count > 0));
            }
        }
        private RelayCommand? doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                    (doubleCommand = new RelayCommand(obj =>
                    {
                        Phone? phone = obj as Phone;
                        if (phone != null)
                        {
                            Phone phoneCopy = new Phone(phone.Company, phone.Title, phone.Price);
                            Phones.Insert(0,phoneCopy);
                        }
                    }));
            }
        }


        public Phone? SelectedPhone 
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
                new Phone("IPhone 14", "Apple", 125000 ),
                new Phone("Galaxy S22 Ultra", "Samsung", 90000),
                new Phone("12 Lite", "Xiaomi", 35000)
            };
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
   
}
