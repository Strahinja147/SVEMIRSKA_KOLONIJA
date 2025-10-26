using System.Collections.Generic;

namespace SVEMIRSKA_KOLONIJA.Entiteti
{
    public class Specijalizacija
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }

        public virtual IList<Poseduje> PosedujuStanovnici { get; set; }
        public virtual IList<Potrebna> PotrebnaZaZadatke { get; set; }

        public Specijalizacija()
        {
            PosedujuStanovnici = new List<Poseduje>();
            PotrebnaZaZadatke = new List<Potrebna>();
        }
    }
}