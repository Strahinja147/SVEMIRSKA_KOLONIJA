namespace SVEMIRSKA_KOLONIJA.Entiteti
{
    public class MedicinskaIntervencija : Zadatak
    {
        public virtual int? BrojPovredjenih { get; set; }
        public virtual int? StepenKriticnosti { get; set; }
    }
}