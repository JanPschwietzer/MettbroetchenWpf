using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

using Framework.WPF.MVVM;

namespace MettbrötchenWpf
{

    //Todo: Add a ViewModelBase class to the Framework.WPF.MVVM namespace
    public class MainWindowViewModel : ViewModelBase
    {
        //Properties
        private int _selectedBroetchen;
        private ObservableCollection<int> _broetchenList = new();
        private int _selectedMett;
        private ObservableCollection<int> _mettList = new();
        private string _userEmail;
        private string _statusText;

        //Getter & Setter
        public string UserEmail
        {
            get => _userEmail;
            set => Set(ref _userEmail, value);
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
            UserEmail = "[IhrName]@genese.de";
            SelectedBroetchen = 2;
            SelectedMett = 150;
            StatusText = "Wartet...";
            BroetchenList.Add(2);
            BroetchenList.Add(3);
            MettList.Add(150);
            MettList.Add(200);
        }

        //Commands
        public bool DatenSenden()
        {

            return true;
        }
    }
}