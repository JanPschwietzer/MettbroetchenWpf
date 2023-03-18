using System;
using System.Windows;
using MettbrötchenWpf.NHibernate;

namespace MettbrötchenWpf;

public class MainWindowModel
{
    public bool AnfrageSenden(string email, int broetchen, int mett)
    {
        var sessionFactory = SessionFactory.CreateSessionFactory();

        using (var session = sessionFactory.OpenSession())
        {
            using (var trans = session.BeginTransaction())
            {
                try
                {
                    Query query = new Query
                    {
                        Today = DateTime.Now,
                        Email = email,
                        Broetchen = broetchen,
                        Mett = mett
                    };

                    session.SaveOrUpdate(query);
                    trans.Commit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
            
        return true;
    }
}