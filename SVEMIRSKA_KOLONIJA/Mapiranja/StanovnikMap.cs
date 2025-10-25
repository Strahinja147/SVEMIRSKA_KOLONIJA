using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class StanovnikMap : ClassMap<Stanovnik>
    {
        public StanovnikMap()
        {
            Table("STANOVNIK");

            Id(x => x.Id, "STANOVNIK_ID").GeneratedBy.Sequence("SEQ_STANOVNIK");

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pol, "POL");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.Nacionalnost, "NACIONALNOST");
            Map(x => x.Zanimanje, "ZANIMANJE");
            Map(x => x.GodineUKoloniji, "GODINE_U_KOLONIJI");

            References(x => x.UcesnikZadatka, "UCESNIK_ZADATKA_ID").Unique();

            HasMany(x => x.KontaktiNaZemlji).KeyColumn("STANOVNIK_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.SektoriKojeVodi).KeyColumn("STANOVNIK_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.OdgovoranZaRobote).KeyColumn("ODGOVORNI_STANOVNIK_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.ProgramiraniRoboti).KeyColumn("PROGRAMER_STANOVNIK_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Specijalizacije).KeyColumn("STANOVNIK_ID").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.RadiUSektorima)
                .Table("RADI_U")
                .ParentKeyColumn("STANOVNIK_ID")
                .ChildKeyColumn("SEKTOR_ID")
                .Cascade.All();

            HasManyToMany(x => x.UpravljaResursima)
                .Table("UPRAVLJA_RESURSOM")
                .ParentKeyColumn("STANOVNIK_ID")
                .ChildKeyColumn("RESURS_ID")
                .Cascade.All();

            HasManyToMany(x => x.UcestvovaoUOdrzavanjima)
                .Table("UCESNIK_ODRZAVANJA")
                .ParentKeyColumn("STANOVNIK_ID")
                .ChildKeyColumn("ZAPIS_ODRZAVANJA_ID")
                .Cascade.All();
        }
    }
}