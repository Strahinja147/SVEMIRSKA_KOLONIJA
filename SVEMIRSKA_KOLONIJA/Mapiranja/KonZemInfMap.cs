using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class KonZemInfMap : ClassMap<KonZemInf>
    {
        public KonZemInfMap()
        {
            Table("KON_ZEM_INF");

            // Napomena: Za ovo je potrebno dodati sekvencu u bazu
            Id(x => x.Id, "KON_ZEM_INF_ID").GeneratedBy.Sequence("SEQ_KON_ZEM_INF");

            Map(x => x.KontaktInformacija, "KONTAKT_INFORMACIJE");
            References(x => x.PripadaKontaktu, "KONTAKT_ID");
        }
    }
}