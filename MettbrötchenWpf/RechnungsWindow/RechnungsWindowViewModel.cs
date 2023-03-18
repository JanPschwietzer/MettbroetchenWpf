using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mail;
using System.Windows;
using System.Xml.Linq;
using MettbrötchenWpf.MVVM;
using MettbrötchenWpf.NHibernate;
using ICommand = System.Windows.Input.ICommand;

namespace MettbrötchenWpf
{
    public class RechnungsWindowViewModel : INotifyPropertyChangedBase
    {
        //Properties
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
        public ICommand SendEmailsCommand { get; set; }


        //Getter & Setter
        public string HostName
        {
            get => _hostName;
            set => Set(ref _hostName, value);
        }
        public int Bestellungen
        {
            get => _bestellungen;
            set
            {
                _bestellungen = value;
                BestellungenAmTag = "Bestellungen am " + Rechnungsdatum.ToShortDateString() + ": " + _bestellungen;
            }
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
                Bestellungen = _model.GetNummerBestellungen(value);
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
            get => _broetchenPreis.ToString();
            set => Set(ref _broetchenPreis, value.Replace('.', ',') == "" ? 0 : double.Parse(value.Replace('.', ',')));
        }

        public string MettPreis
        {
            get => _mettPreis.ToString();
            set => Set(ref _mettPreis, value.Replace('.', ',') == "" ? 0 : double.Parse(value.Replace('.', ',')));
        }
        
        public string StatusText
        {
            get => _statusText;
            private set => Set(ref _statusText, value);
        }

        //Constructor
        public RechnungsWindowViewModel()
        {
            _model = new RechnungsWindowModel();
            PaypalEmail = "tstraube@gmx.de";
            BroetchenPreis = "0,00";
            MettPreis = "0,00";
            Rechnungsdatum = DateTime.Today;
            StatusText = "Wartet...";
            Bestellungen = _model.GetNummerBestellungen(Rechnungsdatum);
            HostName = "Tobias Straube";

            SendEmailsCommand = new RelayCommand(o => SendEmailsClick());
        }

        private void SendEmailsClick()
        {
            var bestellungen = _model.GetBestellungen(Rechnungsdatum);
            
            if (SendEmails(PrepareEmails(bestellungen)))
            {
                MessageBox.Show("Emails wurden erfolgreich versendet!", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Emails konnten nicht versendet werden!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        
        private bool SendEmails(IList<MailMessage> emails)
        {
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
                    System.Diagnostics.Process.Start(new ProcessStartInfo($"mailto:{email.To}&subject={email.Subject}&body={email.Body}") { UseShellExecute = true });
                    return false;
                }
            }
            return true;
        }

        private List<MailMessage> PrepareEmails(IList<Query> bestellungen)
        {
            GetAnzahlBroetchenMett(bestellungen);
            
            List<MailMessage> messages = new List<MailMessage>();

            foreach (var bestellung in bestellungen)
            {
                if (bestellung.Today.ToShortDateString() != Rechnungsdatum.ToShortDateString()) continue;

                MailMessage message = new MailMessage();
                
                double betrag = 0.0;
                betrag += bestellung.Broetchen * (_broetchenPreis / _anzahlBroetchen);
                betrag += bestellung.Mett * (_mettPreis / _grammMett);

                message.Subject = "Bezahlung Mettbrötchen vom " + Rechnungsdatum.ToShortDateString();
                message.Body = "Hallo,\n\n" +
                               $"bitte überweise den Betrag von {betrag.ToString("#,##")}€ auf folgendes Paypal Konto:\n" +
                               $"{PaypalEmail}\n" +
                               "Bitte nutze dafür die Freunde und Familie Option.\n" +
                               "Mit freundlichen Grüßen\n" +
                               $"{HostName}\n";
                message.From = new MailAddress("mettbroetchen@genese.de", "GMettbrötchen");
                message.To.Add(bestellung.Email);
                message.IsBodyHtml = false;

                messages.Add(message);
            }
            return messages;
        }

        private void GetAnzahlBroetchenMett(IList<Query> bestellungen)
        {
            _anzahlBroetchen = 0;
            _grammMett = 0;
            
            foreach (var bestellung in bestellungen)
            {
                if (bestellung.Today.ToShortDateString() != Rechnungsdatum.ToShortDateString()) continue;
                _anzahlBroetchen += bestellung.Broetchen;
                _grammMett += bestellung.Mett;
            }
        }
    }
}