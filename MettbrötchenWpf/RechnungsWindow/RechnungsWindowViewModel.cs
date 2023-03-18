using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Mail;
using System.Windows;
using MettbrötchenWpf.MVVM;
using MettbrötchenWpf.NHibernate;
using ICommand = System.Windows.Input.ICommand;

namespace MettbrötchenWpf
{
    public class RechnungsWindowViewModel : INotifyPropertyChangedBase
    {
        #region Properties
        private string _hostName;
        private string _paypalEmail;
        private double _broetchenPreis;
        private double _mettPreis;
        private string _statusText;
        private DateTime _rechnungsdatum;
        private string _bestellungenAmTag;
        private int _bestellungen;
        private RechnungsWindowModel _model;
        private int _anzahlBroetchen;
        private int _grammMett;
        private IList<Bestellung> _bestellungenList;
        private int _anzahl150g;
        private int _anzahl200g;
        public ICommand SendEmailsCommand { get; set; }
        #endregion

        #region Getter & Setter
        public int AnzahlBroetchen
        {
            get => _anzahlBroetchen;
            set => Set(ref _anzahlBroetchen, value);
        }
        public int GrammMett
        {
            get => _grammMett;
            set => Set(ref _grammMett, value);
        }
        public int Anzahl150g
        {
            get => _anzahl150g;
            set => Set(ref _anzahl150g, value);
        }
        public int Anzahl200g
        {
            get => _anzahl200g;
            set => Set(ref _anzahl200g, value);
        }
        public IList<Bestellung> BestellungenList
        {
            get => _bestellungenList;
            set => Set(ref _bestellungenList, value);
        }
        public string HostName
        {
            get => _hostName;
            set => Set(ref _hostName, value);
        }
        public int Bestellungen
        {
            get => _bestellungen;
            set => _bestellungen = value;
        }
        public string BestellungenAmTag
        {
            get => _bestellungenAmTag;
            set => Set(ref _bestellungenAmTag, value);
        }
        public DateTime Rechnungsdatum
        {
            get => _rechnungsdatum;
            set
            {
                _rechnungsdatum= value;
                BestellungenList = _model.GetBestellungen(value);
                Bestellungen = _model.GetNummerBestellungen(value);
                ReloadBestelldaten();
            }
        }
        public string PaypalEmail
        {
            get => _paypalEmail;
            set
            {
                _paypalEmail = value;
            }
        }

        public string BroetchenPreis
        {
            get => _broetchenPreis.ToString(CultureInfo.CurrentCulture);
            set => Set(ref _broetchenPreis, value.Replace('.', ',') == "" ? 0 : double.Parse(value.Replace('.', ',')));
        }

        public string MettPreis
        {
            get => _mettPreis.ToString(CultureInfo.CurrentCulture);
            set => Set(ref _mettPreis, value.Replace('.', ',') == "" ? 0 : double.Parse(value.Replace('.', ',')));
        }
        
        public string StatusText
        {
            get => _statusText;
            private set => Set(ref _statusText, value);
        }
        
        #endregion

        #region Constructor
        public RechnungsWindowViewModel()
        {
            _model = new RechnungsWindowModel();
            
            PaypalEmail = "[name]@gmx.de";
            BroetchenPreis = "0,00";
            MettPreis = "0,00";
            StatusText = "Wartet...";
            HostName = "Ihr Mettbrötchen-Team";
            Bestellungen = _model.GetNummerBestellungen(Rechnungsdatum);
            Rechnungsdatum = DateTime.Today;
            
            SendEmailsCommand = new RelayCommand(o => SendEmailsClick());
            
        }
        #endregion
        
        #region Methods
        private void SendEmailsClick()
        {
            if (!AnfrageSendenMoeglich()) return;

            if (SendEmails(PrepareEmails()))
            {
                MessageBox.Show("Emails wurden erfolgreich versendet!", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Emails konnten nicht versendet werden!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool AnfrageSendenMoeglich()
        {
            if (PaypalEmail == "" || Helpers.EmailisValid(PaypalEmail) == false)
            {
                MessageBox.Show("Bitte geben Sie eine gültige Email-Adresse ein!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (BroetchenPreis == "" || MettPreis == "")
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Preis ein!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (Bestellungen == 0)
            {
                MessageBox.Show("Es gibt keine Bestellungen für diesen Tag!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (HostName == "")
            {
                MessageBox.Show("Bitte geben Sie einen Namen ein!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool SendEmails(IList<MailMessage> emails)
        {
            StatusText = "Emails werden versendet...";
            foreach (var email in emails)
            {

                try
                {
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp-relay.sendinblue.com";
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential("schwietzer.jan@gmail.com", "47AxUqSMH8tfjFcI");
                    client.Send(email);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Process.Start(new ProcessStartInfo($"mailto:{email.To}&subject={email.Subject}&body={email.Body}") { UseShellExecute = true });
                    StatusText = "Wartet...";
                    return false;
                }
            }
            StatusText = "Wartet...";
            return true;
        }

        private List<MailMessage> PrepareEmails()
        {
            ReloadBestelldaten();
            
            List<MailMessage> messages = new List<MailMessage>();

            foreach (var bestellung in BestellungenList)
            {
                if (bestellung.Today.ToShortDateString() != Rechnungsdatum.ToShortDateString()) continue;

                MailMessage message = new MailMessage();
                
                double betrag = 0.0;
                betrag += bestellung.Broetchen * (_broetchenPreis / _anzahlBroetchen);
                betrag += bestellung.Mett * (_mettPreis / _grammMett);

                string format = "0.00";

                message.Subject = "Bezahlung Mettbrötchen vom " + Rechnungsdatum.ToShortDateString();
                message.Body = "Hallo Lieber Mettbrötchenfreund,\n\n" +
                               $"bitte überweise den Betrag von {betrag.ToString(format)}€ auf folgendes Paypal Konto:\n" +
                               $"{PaypalEmail}\n\n" +
                               "Kostenaufstellung: \n" +
                               $"Brötchen: {bestellung.Broetchen} Stück à {(_broetchenPreis / _anzahlBroetchen).ToString(format)}€ = {(bestellung.Broetchen * (_broetchenPreis / _anzahlBroetchen)).ToString(format)}€\n" +
                               $"Mett: {bestellung.Mett}g à {((_mettPreis / _grammMett) * 100).ToString(format)}€ = {(bestellung.Mett * (_mettPreis / _grammMett)).ToString(format)}€\n\n" +
                               "Mit freundlichen Grüßen\n" +
                               $"{HostName}\n";
                message.From = new MailAddress("mettbroetchen@genese.de", "GMettbrötchen");
                message.To.Add(bestellung.Email);
                message.IsBodyHtml = false;

                messages.Add(message);
            }
            return messages;
        }

        private void ReloadBestelldaten()
        {
            AnzahlBroetchen = 0;
            GrammMett = 0;
            Anzahl200g = 0;
            Anzahl150g = 0;

            foreach (var bestellung in BestellungenList)
            {
                if (bestellung.Today.ToShortDateString() != Rechnungsdatum.ToShortDateString()) continue;
                AnzahlBroetchen += bestellung.Broetchen;
                GrammMett += bestellung.Mett;
                if (bestellung.Mett == 150) Anzahl150g++;
                if (bestellung.Mett == 200) Anzahl200g++;

            }
        }
        #endregion
    }
}