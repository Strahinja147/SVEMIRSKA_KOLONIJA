using System.Collections.Generic;

namespace SVEMIRSKA_KOLONIJA.Entiteti
{
    public class Resurs
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual int? TrenutnaKolicina { get; set; }

        public virtual Sektor Sektor { get; set; }

        public virtual IList<Trosi> PotrosnjaPoSektorima { get; set; }
        public virtual IList<Stanovnik> Upravitelji { get; set; }

        public Resurs()
        {
            PotrosnjaPoSektorima = new List<Trosi>();
            Upravitelji = new List<Stanovnik>();
        }
    }
}