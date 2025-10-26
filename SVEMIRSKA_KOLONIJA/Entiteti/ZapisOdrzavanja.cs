using System;
using System.Collections.Generic;

namespace SVEMIRSKA_KOLONIJA.Entiteti
{
    public class ZapisOdrzavanja
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime? VremeOdrzavanja { get; set; }

        public virtual Sektor Sektor { get; set; }

        public virtual IList<Stanovnik> UcesniciOdrzavanja { get; set; }

        public ZapisOdrzavanja()
        {
            UcesniciOdrzavanja = new List<Stanovnik>();
        }
    }
}