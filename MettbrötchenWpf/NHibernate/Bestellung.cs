using System;
using FluentNHibernate.Mapping;

namespace MettbrötchenWpf.NHibernate;

public class Bestellung
{ 
    public virtual string Email { get; set; }
    public virtual DateTime Today { get; set; }
    public virtual int Broetchen { get; set; }
    public virtual int Mett { get; set; }
}

public class BestellungMap : ClassMap<Bestellung>
{
    public BestellungMap()
    {
        Id(x => x.Email).Column("email");
        Map(x => x.Today).Column("datetime");
        Map(x => x.Broetchen).Column("broetchen");
        Map(x => x.Mett).Column("mett");
    }
}