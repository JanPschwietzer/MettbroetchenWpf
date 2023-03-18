using System;
using System.Collections;
using System.Collections.Generic;
using MettbrötchenWpf.NHibernate;
using NHibernate;
using NHibernate.Criterion;

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
                var trans = session.CreateCriteria<Query>()
                    .List<Query>();

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

    public IList<Query> GetBestellungen(DateTime date)
    {
        try
        {
            ISessionFactory sessionFactory = SessionFactory.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                var trans = session.CreateCriteria<Query>()
                    .List<Query>();

                return trans;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}