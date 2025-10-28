using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    public class AngazovanNaMap : ClassMap<AngazovanNa>
    {
        public AngazovanNaMap()
        {
            Table("ANGAZOVAN_NA");

            Id(x => x.Id, "ANGAZOVAN_NA_ID").GeneratedBy.Sequence("SEQ_ANGAZOVAN_NA");

            References(x => x.Ucesnik, "UCESNIK_ZADATKA_ID");
            References(x => x.Zadatak, "ZADATAK_ID");
        }
    }
}