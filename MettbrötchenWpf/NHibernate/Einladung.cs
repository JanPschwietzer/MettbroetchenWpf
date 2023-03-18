using System;
using FluentNHibernate.Mapping;

namespace MettbrötchenWpf.NHibernate;

public class Einladung
{
    public virtual DateTime Anmeldeschluss { get; set; }
}

public class EinladungMap : ClassMap<Einladung>
{
    public EinladungMap()
    {
        Id(x => x.Anmeldeschluss).Column("anmeldeschluss");
    }
}