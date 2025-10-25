using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    public class OdrzavanjeMap : SubclassMap<Odrzavanje>
    {
        public OdrzavanjeMap()
        {
            DiscriminatorValue("ODRZAVANJE");
        }
    }
}