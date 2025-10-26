using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    public class OdrzavanjeMap : SubclassMap<Odrzavanje>
    {
        public OdrzavanjeMap()
        {
            DiscriminatorValue("ODRZAVANJE");
        }
    }
}