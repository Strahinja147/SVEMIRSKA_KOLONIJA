using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    public class EvakuacijaMap : SubclassMap<Evakuacija>
    {
        public EvakuacijaMap()
        {
            DiscriminatorValue("EVAKUACIJA");
            Map(x => x.OblastEvakuacije, "OBLAST_EVAKUACIJE");
            Map(x => x.BrojOsobaEvakuacije, "BROJ_OSOBA_EVAKUACIJE");
        }
    }
}