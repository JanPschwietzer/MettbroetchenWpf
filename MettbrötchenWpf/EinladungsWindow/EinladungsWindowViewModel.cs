using System;
using System.Windows.Input;
using MettbrötchenWpf.MVVM;

namespace MettbrötchenWpf
{
    public class EinladungsWindowViewModel : INotifyPropertyChangedBase
    {
        //Properties
        private string _datum;
        private string _datumString;
        private string _stunde;
        private string _minute;
        private string _statusText;

        public ICommand SendNotificationsButtonCommand { get; set; }
        
        //Getter & Setter
        public string Datum
        {
            get => _datum;
            set => Set(ref _datum, value);
        }
        public string DatumString
        {
            get => _datumString;
            set => Set(ref _datumString, value);
        }
        public string Stunde
        {
            get => _stunde;
            set => Set(ref _stunde, value.Length == 1 ? "0" + value : value);
        }
        public string Minute
        {
            get => _minute;
            set => Set(ref _minute, value.Length == 1 ? "0" + value : value);
        }
        public string Status
        {
            get => _statusText;
            set => Set(ref _statusText, value);
        }
        
        public EinladungsWindowViewModel()
        {
            Datum = DateTime.Today.ToShortDateString();
            DatumString = $"Einladung für den {Datum}";
            Stunde = DateTime.Now.AddHours(3).Hour.ToString();
            Minute = "00";
            Status = "Bereit";

            SendNotificationsButtonCommand = new RelayCommand(SendNotificationsButtonClick);
        }

        private void SendNotificationsButtonClick(object obj)
        {
            Status = "Senden...";
            var einladungsWindowModel = new EinladungsWindowModel();
            einladungsWindowModel.SendNotifications(Datum, Stunde, Minute);
            Status = "Fertig";
        }
    }
}