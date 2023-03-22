using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MettbrötchenWpf.MVVM;

namespace MettbrötchenWpf
{
    public class MainWindowViewModel : INotifyPropertyChangedBase
    {
        //Properties
        private int _selectedBroetchen;
        private ObservableCollection<int> _broetchenList = new();
        private int _selectedMett;
        private MainWindowModel _model;
        private ObservableCollection<int> _mettList = new();
        private string _userEmail;
        private string _statusText;
        private bool _isAnmeldungMoeglich;
        private string _anmeldeschlussString;
        private DateTime _anmeldeschluss;
        public ICommand SendButtonCommand { get; set; }


        //Getter & Setter
        public DateTime Anmeldeschluss
        {
            get => _anmeldeschluss;
            set => Set(ref _anmeldeschluss, value);
        }
        public string AnmeldeschlussString
        {
            get => _anmeldeschlussString;
            set => Set(ref _anmeldeschlussString, value);
        }
        public string UserEmail
        {
            get => _userEmail;
            set => Set(ref _userEmail, value);
        }

        public bool IsAnmeldungMoeglich
        {
            get => _isAnmeldungMoeglich;
            set
            {
                bool oldValue = _isAnmeldungMoeglich;
                Set(ref _isAnmeldungMoeglich, value);
                if (oldValue == value) return;
                ToastWindow.Show(value);
            }
        }

        public int SelectedBroetchen
        {
            get => _selectedBroetchen;
            set => Set(ref _selectedBroetchen, value);
        }
        public string StatusText
        {
            get => _statusText;
            set => Set(ref _statusText, value);
        }

        public int SelectedMett
        {
            get => _selectedMett;
            set => Set(ref _selectedMett, value);
        }

        public ObservableCollection<int> BroetchenList
        {
            get => _broetchenList;
            set => Set(ref _broetchenList, value);
        }

        public ObservableCollection<int> MettList
        {
            get => _mettList;
            set => Set(ref _mettList, value);
        }

        //Constructor
        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
            
            IsAnmeldungMoeglich = _model.GetAnmeldeschluss() > DateTime.Now;
            UserEmail = "[IhrName]@genese.de";
            SelectedBroetchen = 2;
            SelectedMett = 150;
            StatusText = "Wartet...";
            BroetchenList.Add(0);
            BroetchenList.Add(2);
            BroetchenList.Add(3);
            MettList.Add(0);
            MettList.Add(150);
            MettList.Add(200);
            Anmeldeschluss = _model.GetAnmeldeschluss();
            AnmeldeschlussString  = IsAnmeldungMoeglich ? $"Anmeldeschluss: {Anmeldeschluss.ToShortDateString()} {Anmeldeschluss.ToShortTimeString()}" : "Anmeldung nicht mehr möglich!";

            SendButtonCommand = new RelayCommand( o => DatenSenden());
            
            UpdateData();
        }
        
        private async void UpdateData()
        {
            while (true)
            {
                Anmeldeschluss = _model.GetAnmeldeschluss();
                IsAnmeldungMoeglich = Anmeldeschluss > DateTime.Now;
                AnmeldeschlussString  = IsAnmeldungMoeglich ? $"Anmeldeschluss: {Anmeldeschluss.ToShortDateString()} {Anmeldeschluss.ToShortTimeString()}" : "Anmeldung nicht mehr möglich!";
                await Task.Delay(TimeSpan.FromSeconds(30));
            }
            // ReSharper disable once FunctionNeverReturns
        }

        //Commands
        private void DatenSenden()
        {
            StatusText = "sendet...";

            if (_model.AnfrageSenden(_userEmail, _selectedBroetchen, _selectedMett, _anmeldeschluss))
            {
                MessageBox.Show("Anfrage erfolgreich gesendet.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            StatusText = "Wartet...";
        }
    }
}