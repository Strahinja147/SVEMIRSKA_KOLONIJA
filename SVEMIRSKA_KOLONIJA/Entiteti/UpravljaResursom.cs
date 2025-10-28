namespace SVEMIRSKA_KOLONIJA.Entiteti
{
    public class UpravljaResursom
    {
        public virtual int Id { get; protected set; }
        public virtual Stanovnik Stanovnik { get; set; }
        public virtual Resurs Resurs { get; set; }
    }
}