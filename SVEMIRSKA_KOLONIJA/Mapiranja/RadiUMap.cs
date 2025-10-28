using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    public class RadiUMap : ClassMap<RadiU>
    {
        public RadiUMap()
        {
            Table("RADI_U");

            Id(x => x.Id, "RADI_U_ID").GeneratedBy.Sequence("SEQ_RADI_U");

            References(x => x.SektorGdeRadi, "SEKTOR_ID");
            References(x => x.Radnik, "STANOVNIK_ID");
        }
    }
}