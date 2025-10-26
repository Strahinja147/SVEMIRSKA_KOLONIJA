using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
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

            // --- ISPRAVLJENA LINIJA ---
            // Zamenjeno .Cascade.All() sa .Cascade.AllDeleteOrphan()
            // da bi se osiguralo brisanje zavisnih informacija.
            HasMany(x => x.KontaktInformacije)
                .KeyColumn("KONTAKT_ID")
                .LazyLoad()
                .Cascade.AllDeleteOrphan() // Ovo je ključna izmena
                .Inverse();
        }
    }
}