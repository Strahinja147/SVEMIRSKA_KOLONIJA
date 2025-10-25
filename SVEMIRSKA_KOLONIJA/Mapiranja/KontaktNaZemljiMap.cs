using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class KontaktNaZemljiMap : ClassMap<KontaktNaZemlji>
    {
        public KontaktNaZemljiMap()
        {
            Table("KONTAKT_NA_ZEMLJI");
            Id(x => x.Id, "KONTAKT_ID").GeneratedBy.Sequence("SEQ_KONTAKT_NA_ZEMLJI");
            Map(x => x.Odnos, "ODNOS");
            Map(x => x.Ime, "IME");

            References(x => x.Stanovnik, "STANOVNIK_ID");

            HasMany(x => x.KontaktInformacije).KeyColumn("KONTAKT_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}