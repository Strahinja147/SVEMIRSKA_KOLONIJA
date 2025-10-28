using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    class SpecijalizacijaMap : ClassMap<Specijalizacija>
    {
        public SpecijalizacijaMap()
        {
            Table("SPECIJALIZACIJA");
            Id(x => x.Id, "SPECIJALIZACIJA_ID").GeneratedBy.Assigned();
            Map(x => x.Naziv, "NAZIV");

            HasMany(x => x.PosedujuStanovnici).KeyColumn("SPECIJALIZACIJA_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.PotrebnaZaZadatke).KeyColumn("SPECIJALIZACIJA_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}