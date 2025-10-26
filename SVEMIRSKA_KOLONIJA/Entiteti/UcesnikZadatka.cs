using System.Collections.Generic;

namespace SVEMIRSKA_KOLONIJA.Entiteti
{
    public class UcesnikZadatka
    {
        public virtual int Id { get; protected set; }

        public virtual Stanovnik PripadaStanovniku { get; set; }
        public virtual Robot PripadaRobotu { get; set; }

        public virtual IList<Zadatak> AngazovanNaZadacima { get; set; }

        public UcesnikZadatka()
        {
            AngazovanNaZadacima = new List<Zadatak>();
        }
    }
}