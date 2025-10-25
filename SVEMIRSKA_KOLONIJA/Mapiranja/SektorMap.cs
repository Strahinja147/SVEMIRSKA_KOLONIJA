using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class SektorMap : ClassMap<Sektor>
    {
        public SektorMap()
        {
            Table("SEKTOR");

            Id(x => x.Id, "SEKTOR_ID").GeneratedBy.Sequence("SEQ_SEKTOR");

            Map(x => x.TipSektora, "TIP_SEKTORA");
            Map(x => x.Kapacitet, "KAPACITET");
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Povrsina, "POVRSINA");

            References(x => x.VodjaSektora, "STANOVNIK_ID");

            HasMany(x => x.ResursiUSektoru).KeyColumn("SEKTOR_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.RobotiUSektoru).KeyColumn("SEKTOR_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.ZapisiOdrzavanja).KeyColumn("SEKTOR_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.PotrosnjaResursa).KeyColumn("SEKTOR_ID").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.Radnici)
                .Table("RADI_U")
                .ParentKeyColumn("SEKTOR_ID")
                .ChildKeyColumn("STANOVNIK_ID")
                .Cascade.All()
                .Inverse();
        }
    }
}