using FluentNHibernate.Mapping;
using SvemirskaKolonija.Entiteti;

namespace SvemirskaKolonija.Mapiranja
{
    public class EksperimentMap : SubclassMap<Eksperiment>
    {
        public EksperimentMap()
        {
            DiscriminatorValue("EKSPERIMENT");
            Map(x => x.NivoOpasnosti, "NIVO_OPASNOSTI");
        }
    }
}