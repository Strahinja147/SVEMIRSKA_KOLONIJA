// Fajl: Mapiranja/PosedujeMap.cs
using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    class PosedujeMap : ClassMap<Poseduje>
    {
        public PosedujeMap()
        {
            // ISPRAVLJENO: Ime tabele sa velikim slovima
            Table("POSEDUJE");

            Id(x => x.Id, "POSEDuje_ID").GeneratedBy.Sequence("SEQ_POSEDUJE");

            Map(x => x.Institucija, "INSTITUCIJA");
            Map(x => x.DatumSticanja, "DATUM_STICANJA");
            Map(x => x.NivoEkspertize, "NIVO_EKSPERTIZE");

            References(x => x.Specijalizacija, "SPECIJALIZACIJA_ID");
            References(x => x.Stanovnik, "STANOVNIK_ID");
        }
    }
}