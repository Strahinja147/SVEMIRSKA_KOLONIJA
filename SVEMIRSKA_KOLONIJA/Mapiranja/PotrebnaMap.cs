using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    class PotrebnaMap : ClassMap<Potrebna>
    {
        public PotrebnaMap()
        {
            Table("POTREBNA");
            Id(x => x.Id, "POTREBNA_ID").GeneratedBy.Sequence("SEQ_POTREBNA");

            Map(x => x.Nivo, "NIVO");

            References(x => x.Specijalizacija, "SPECIJALIZACIJA_ID");
            References(x => x.Zadatak, "ZADATAK_ID");
        }
    }
}