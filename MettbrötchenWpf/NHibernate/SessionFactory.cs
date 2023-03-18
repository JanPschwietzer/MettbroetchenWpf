using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MettbrötchenWpf.NHibernate;

public static class SessionFactory
{

    private static readonly string Server = "WORK\\SQLEXPRESS";
    private static readonly string Database = "local";
    private static readonly string Username = "SA";
    private static readonly string Password = "g3n3s3";
    public static ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2012.ConnectionString(c => c
                    .Server(Server)
                    .Database(Database)
                    .Username(Username)
                    .Password(Password)))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Bestellung>())
            .ExposeConfiguration(cfg => { new SchemaUpdate(cfg).Execute(false, true); })
            .BuildSessionFactory();
    }
}