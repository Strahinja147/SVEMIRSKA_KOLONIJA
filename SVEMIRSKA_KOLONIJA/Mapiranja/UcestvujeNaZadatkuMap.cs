using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class UcesnikZadatkaMap : ClassMap<UcesnikZadatka>
    {
        public UcesnikZadatkaMap()
        {
            Table("UCESNIK_ZADATKA");
            Id(x => x.Id, "UCESNIK_ZADATKA_ID").GeneratedBy.Sequence("SEQ_UCESNIK_ZADATKA");

            HasOne(x => x.PripadaStanovniku).PropertyRef(nameof(Stanovnik.UcesnikZadatka));
            HasOne(x => x.PripadaRobotu).PropertyRef(nameof(Robot.UcesnikZadatka));

            HasManyToMany(x => x.AngazovanNaZadacima)
                .Table("ANGAZOVAN_NA")
                .ParentKeyColumn("UCESNIK_ZADATKA_ID")
                .ChildKeyColumn("ZADATAK_ID")
                .Cascade.All()
                .Inverse();
        }
    }
}