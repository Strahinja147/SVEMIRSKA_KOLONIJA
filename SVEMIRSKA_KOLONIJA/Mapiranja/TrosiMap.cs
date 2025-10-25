using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class TrosiMap : ClassMap<Trosi>
    {
        public TrosiMap()
        {
            Table("TROSI");
            // Napomena: Za ovo je potrebno dodati sekvencu u bazu
            Id(x => x.Id, "TROSI_ID").GeneratedBy.Sequence("SEQ_TROSI");

            Map(x => x.DnevniProsek, "DNEVNI_PROSEK");
            Map(x => x.KriticnaVrednost, "KRITICNA_VREDNOST");

            References(x => x.Sektor, "SEKTOR_ID");
            References(x => x.Resurs, "RESURS_ID");
        }
    }
}