using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
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

            //HasMany(x => x.PotrosnjaPoSektorima).KeyColumn("RESURS_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.PotrosnjaPoSektorima)
                .KeyColumn("RESURS_ID")
                .Cascade.AllDeleteOrphan() // Obavezno!
                .Inverse();

            // IZMENA: HasMany mapiranje ka prelaznom entitetu
            HasMany(x => x.UpravljaVeze)
                .KeyColumn("RESURS_ID")
                .Cascade.AllDeleteOrphan() // Briše vezu ako se ukloni iz liste
                .Inverse(); // Neophodno za HasMany
        }
    }
}