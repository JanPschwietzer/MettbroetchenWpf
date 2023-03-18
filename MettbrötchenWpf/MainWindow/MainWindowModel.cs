using System;
using System.Linq;
using System.Windows;
using MettbrötchenWpf.MVVM;
using MettbrötchenWpf.NHibernate;

namespace MettbrötchenWpf;

public class MainWindowModel
{
    public bool AnfrageSenden(string email, int broetchen, int mett, DateTime anmeldeschluss)
    {
        if (!AnfrageSendenMoeglich(email, broetchen, mett, anmeldeschluss)) return false;

        using (var sessionFactory = SessionFactory.CreateSessionFactory())
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        Bestellung bestellung = new Bestellung
                        {
                            Today = DateTime.Now,
                            Email = email,
                            Broetchen = broetchen,
                            Mett = mett
                        };

                        session.SaveOrUpdate(bestellung);
                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private static bool AnfrageSendenMoeglich(string email, int broetchen, int mett, DateTime anmeldeschluss)
    {
        if (email == "" || Helpers.EmailisValid(email) == false)
        {
            MessageBox.Show("Bitte gültige Email eingeben!", "Achtung", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }
        else if (anmeldeschluss < DateTime.Now)
        {
            MessageBox.Show("Anmeldeschluss ist bereits vorbei!", "Achtung", MessageBoxButton.OK,
                MessageBoxImage.Exclamation);
            return false;
        }
        else if (broetchen == 0 && mett == 0)
        {
            MessageBox.Show("Bitte mindestens eine der Bestelloptionen wählen!", "Achtung", MessageBoxButton.OK,
                MessageBoxImage.Exclamation);
            return false;
        }
        return true;
    }

    public DateTime GetAnmeldeschluss()
    {
        try
        {
            using (var sessionFactory = SessionFactory.CreateSessionFactory())
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var trans = session.CreateCriteria<Einladung>()
                        .List<Einladung>()
                        .FirstOrDefault();

                    if (trans == null) throw new Exception("Keine Einladung vorhanden");
                    return trans.Anmeldeschluss;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return DateTime.Now.AddMonths(-1);
        }
    }
}