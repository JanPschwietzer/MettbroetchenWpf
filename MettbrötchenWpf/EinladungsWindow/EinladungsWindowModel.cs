using System;
using MettbrötchenWpf.NHibernate;
using NHibernate.Linq;

namespace MettbrötchenWpf;

public class EinladungsWindowModel
{
    public void SendNotifications(string datum, string stunde, string minute)
    {
        using (var session = SessionFactory.CreateSessionFactory())
        {
            using (var trans = session.OpenSession())
            {
                Einladung einladung = new Einladung
                {
                    Anmeldeschluss = DateTime.Parse($"{datum} {stunde}:{minute}")
                };
                trans.Query<Einladung>().Delete();
                trans.Save(einladung);
                trans.Flush();
            }
        }
    }
}