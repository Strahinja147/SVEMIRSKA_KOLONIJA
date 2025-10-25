using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class ResursMap : ClassMap<Resurs>
    {
        public ResursMap()
        {
            Table("RESURS");
            Id(x => x.Id, "RESURS_ID").GeneratedBy.Sequence("SEQ_RESURS");

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.TrenutnaKolicina, "TRENUTNA_KOLICINA");

            References(x => x.Sektor, "SEKTOR_ID");

            HasMany(x => x.PotrosnjaPoSektorima).KeyColumn("RESURS_ID").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.Upravitelji)
                .Table("UPRAVLJA_RESURSOM")
                .ParentKeyColumn("RESURS_ID")
                .ChildKeyColumn("STANOVNIK_ID")
                .Cascade.All()
                .Inverse();
        }
    }
}