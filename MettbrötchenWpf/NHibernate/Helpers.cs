using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MettbrötchenWpf.NHibernate;

public static class SessionFactory
{
    public static ISessionFactory CreateSessionFactory()
    {
        return Fluently.Configure().Database(
                MsSqlConfiguration.MsSql2012.ConnectionString(c => c
                    .Server("WORK\\SQLEXPRESS")
                    .Database("local")
                    .Username("SA")
                    .Password("g3n3s3")))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Query>())
            .ExposeConfiguration(cfg => { new SchemaUpdate(cfg).Execute(false, true); })
            .BuildSessionFactory();
    }
}