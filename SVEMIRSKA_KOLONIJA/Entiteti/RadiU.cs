namespace SVEMIRSKA_KOLONIJA.Entiteti
{
    public class RadiU
    {
        public virtual int Id { get; protected set; }
        public virtual Sektor SektorGdeRadi { get; set; }
        public virtual Stanovnik Radnik { get; set; }
    }
}