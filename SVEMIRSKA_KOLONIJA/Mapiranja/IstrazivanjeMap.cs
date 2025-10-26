using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    public class IstrazivanjeMap : SubclassMap<Istrazivanje>
    {
        public IstrazivanjeMap()
        {
            DiscriminatorValue("ISTRAZIVANJE");
        }
    }
}