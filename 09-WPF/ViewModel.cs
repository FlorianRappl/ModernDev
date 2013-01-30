using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace ModernDev
{
    //Dieses Interface (INotifyPropertyChanged) ist wohl das mit Abstand
    //wichtigste in WPF  /  MVVM
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region MVVM Zeugs

        public event PropertyChangedEventHandler PropertyChanged;

        //Dieser Wrapper sorgt dafür, dass wir uns einige Zeilen sparen können
        //Durch die Verwendung von CallerMemberName brauchen wir meistens keinen
        //String manuell eingeben (fehlerfreier!) und können auf Reflection (Performance-Fresser)
        //verzichten -- d.h.wir haben nur Vorteile!
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    /// <summary>
    /// Hauptmodel - hier wollen wir die Kollektion ablegen etc. - soll als ViewModel
    /// für unseren View dienen
    /// </summary>
    class MyViewModel : BaseViewModel
    {
        bool isloading;

        public MyViewModel()
        {
            Customers = new ObservableCollection<CustomerViewModel>();
            Customers.CollectionChanged += (s, e) => { RaisePropertyChanged("Count"); };
            Load();
        }

        void Load()
        {
            foreach (var customer in DB.Customers)
                Customers.Add(new CustomerViewModel(customer));
        }

        public ObservableCollection<CustomerViewModel> Customers { get; set; }

        public int Count
        {
            get { return Customers.Count; }
        }

        public ICommand Reload
        {
            get
            {
                return new RelayCommand(async x =>
                {
                    if (isloading)
                        return;

                    isloading = true;
                    Customers.Clear();
                    //Verzögert damit wir das RELOADEN sehen
                    await Task.Delay(2000);
                    Load();
                    isloading = false;
                });
            }
        }

        public ICommand Add
        {
            get
            {
                return new RelayCommand(x =>
                {
                    //Folge Zeile auskommentieren um max. 1 NEUE Zeile drin zu haben
                    //welche noch nicht hinzugefügt wurde

                    //if(!HaveUnsavedCustomers)
                    Customers.Add(new CustomerViewModel());
                });
            }
        }

        public bool HaveUnsavedCustomers
        {
            get
            {
                foreach (var customer in Customers)
                    if (customer.ShowSave)
                        return true;

                return false;
            }
        }
    }

    /// <summary>
    /// UnterViewModel, d.h. dieses VM soll als VM für jeden EINZELNEN
    /// Kunden dienen. Im Prinzip ist dies ein (UI) Wrapper für unser
    /// Model Customer.
    /// </summary>
    class CustomerViewModel : BaseViewModel
    {
        #region Members

        Customer model;
        bool saveVisible;
        bool saveEnabled;

        #endregion

        #region ctor

        public CustomerViewModel(Customer customer)
        {
            model = customer;
        }

        public CustomerViewModel()
        {
            model = new Customer();
            ShowSave = true;
        }

        #endregion

        #region Eigenschaften

        //Keine Notwendigkeit ALLE Eigenschaften des Models preis zu geben
        //Nur die, die später von (einem beliebigen) View benötigt werden (könnten)

        public string Name
        {
            get { return model.Name; }
            set
            {
                if (IsValidName(value))
                    model.Name = value;

                EnableSave = true;
                RaisePropertyChanged();
            }
        }

        public int Age
        {
            get { return model.Age; }
            set
            {
                if(IsValidAge(value))
                    model.Age = value;

                EnableSave = true;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region UI Helpers

        public ICommand Save
        {
            get
            {
                return new RelayCommand(x =>
                {
                    //Lieber Regeln ÖFTERS checken - nicht auf UI verlassen
                    //das ViewModel sollte über (automatische) Tests geprüft
                    //werden, d.h. im Regelfall muss alles OHNE UI funktionieren.
                    if (EnableSave)
                    {
                        ShowSave = false;
                        DB.AddCustomer(model);
                    }
                });
            }
        }

        public bool EnableSave
        {
            get { return saveEnabled; }
            set
            {
                saveEnabled = IsValidAge(Age) && IsValidName(Name);
                RaisePropertyChanged();
            }
        }

        public bool ShowSave
        {
            get { return saveVisible; }
            set
            {
                saveVisible = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Regeln

        bool IsValidName(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        bool IsValidAge(int value)
        {
            return value > 17 && value < 99;
        }

        #endregion
    }

    //Die Klasse ist sehr nützlich zur Verwendung mit Commands
    class RelayCommand : ICommand
    {
        #region Members

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion

        #region ctor

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Implementierung

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }
}
