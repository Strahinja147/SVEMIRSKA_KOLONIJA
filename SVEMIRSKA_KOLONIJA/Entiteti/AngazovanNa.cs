namespace SVEMIRSKA_KOLONIJA.Entiteti
{
    public class AngazovanNa
    {
        public virtual int Id { get; protected set; }
        public virtual UcesnikZadatka Ucesnik { get; set; }
        public virtual Zadatak Zadatak { get; set; }
    }
}