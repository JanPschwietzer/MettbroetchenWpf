using FluentNHibernate.Cfg;
using NHibernate;

namespace MettbrötchenWpf.NHibernate;

public class SessionFactory
{
    private static ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure()
                //Configuration
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
            .BuildSessionFactory();
    }
}