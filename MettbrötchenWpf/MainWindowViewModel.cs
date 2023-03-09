using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

using Framework.WPF.MVVM;

namespace MettbrötchenWpf
{
    
    //Todo: Add a ViewModelBase class to the Framework.WPF.MVVM namespace
    public class MainWindowViewModel : ViewModelBase
    {
        //Properties
        private int _selectedBroetchen;
        private ObservableCollection<int> _broetchenList = new ();
        private int _selectedMett;
        private ObservableCollection<int> _mettList = new ();

        //Getter & Setter
        public int SelectedBroetchen
        {
            get => _selectedBroetchen;
            set => Set(ref _selectedBroetchen, value);
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
        public MainWindowViewModel()
        {
            SelectedBroetchen = 1;
            for (int i = 0; i < 2; i++)
            {
                BroetchenList.Add(2);
                BroetchenList.Add(3);
            }
            
            SelectedMett = 1;
            for (int i = 0; i < 3; i++)
            {
                MettList.Add(150);
                MettList.Add(200);
            }
        }
    
    }
}