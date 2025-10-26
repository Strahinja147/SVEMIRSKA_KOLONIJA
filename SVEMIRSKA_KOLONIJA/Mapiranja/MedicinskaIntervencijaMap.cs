namespace SVEMIRSKA_KOLONIJA.Mapiranja 
{ 
    using FluentNHibernate.Mapping;
    using SVEMIRSKA_KOLONIJA.Entiteti;

    public class MedicinskaIntervencijaMap : SubclassMap<MedicinskaIntervencija>
    {
        public MedicinskaIntervencijaMap()
        {
            DiscriminatorValue("MEDICINSKA_INTERVENCIJA");
            Map(x => x.BrojPovredjenih, "BROJ_POVREDJENIH");
            Map(x => x.StepenKriticnosti, "STEPEN_KRITICNOSTI");
        }
    }
}
