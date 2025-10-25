using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class PosedujeMap : ClassMap<Poseduje>
    {
        public PosedujeMap()
        {
            Table("POSEDuje");
            // Napomena: Za ovo je potrebno dodati sekvencu u bazu
            Id(x => x.Id, "POSEDuje_ID").GeneratedBy.Sequence("SEQ_POSEDuje");

            Map(x => x.Institucija, "INSTITUCIJA");
            Map(x => x.DatumSticanja, "DATUM_STICANJA");
            Map(x => x.NivoEkspertize, "NIVO_EKSPERTIZE");

            References(x => x.Specijalizacija, "SPECIJALIZACIJA_ID");
            References(x => x.Stanovnik, "STANOVNIK_ID");
        }
    }
}