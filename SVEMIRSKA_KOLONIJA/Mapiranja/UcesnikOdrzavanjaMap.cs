using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    public class UcesnikOdrzavanjaMap : ClassMap<UcesnikOdrzavanja>
    {
        public UcesnikOdrzavanjaMap()
        {
            Table("UCESNIK_ODRZAVANJA");

            Id(x => x.Id, "UCESNIK_ODRZAVANJA_ID").GeneratedBy.Sequence("SEQ_UCESNIK_ODRZAVANJA");

            References(x => x.Ucesnik, "STANOVNIK_ID");
            References(x => x.Odrzavanje, "ZAPIS_ODRZAVANJA_ID");
        }
    }
}