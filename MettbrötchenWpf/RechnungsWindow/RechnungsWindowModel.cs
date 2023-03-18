using System;
using System.Collections.Generic;
using MettbrötchenWpf.NHibernate;
using NHibernate;

namespace MettbrötchenWpf;

public class RechnungsWindowModel
{
    public int GetNummerBestellungen(DateTime date)
    {
        int bestellungen = 0;
        try
        {
            ISessionFactory sessionFactory = SessionFactory.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                var trans = session.CreateCriteria<Bestellung>()
                    .List<Bestellung>();

                foreach (var entry in trans)
                {
                    if (entry.Today.Date.ToShortDateString() == date.Date.ToShortDateString())
                    {
                        bestellungen += 1;
                    }
                }

                return bestellungen;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }

    public IList<Bestellung> GetBestellungen(DateTime date)
    {
        
        IList<Bestellung> bestellungen = new List<Bestellung>();
        try
        {
            ISessionFactory sessionFactory = SessionFactory.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                var trans = session.CreateCriteria<Bestellung>()
                    .List<Bestellung>();

                foreach (var entry in trans)
                {
                    if (entry.Today.Date.ToShortDateString() == date.Date.ToShortDateString())
                    {
                        bestellungen.Add(entry);
                    }
                }
                return bestellungen;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}