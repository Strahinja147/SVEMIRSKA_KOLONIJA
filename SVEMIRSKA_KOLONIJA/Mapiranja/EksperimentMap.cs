using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
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