using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    public class IstrazivanjeMap : SubclassMap<Istrazivanje>
    {
        public IstrazivanjeMap()
        {
            DiscriminatorValue("ISTRAZIVANJE");
        }
    }
}