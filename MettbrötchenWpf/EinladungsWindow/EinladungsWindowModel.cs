using System;
using MettbrötchenWpf.NHibernate;

namespace MettbrötchenWpf;

public class EinladungsWindowModel
{
    public void SendNotifications(string datum, string stunde, string minute)
    {
        using (var session = SessionFactory.CreateSessionForRewriting())
        {
            using (var trans = session.OpenSession())
            {
                Einladung einladung = new Einladung
                {
                    Anmeldeschluss = DateTime.Parse($"{datum} {stunde}:{minute}")
                };

                trans.SaveOrUpdate(einladung);
                trans.Flush();
            }
        }
    }
}