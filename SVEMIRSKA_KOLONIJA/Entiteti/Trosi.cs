namespace SvemirskaKolonija.Entiteti
{
    public class Trosi
    {
        public virtual int Id { get; protected set; } // Dodat je surogat ključ
        public virtual double? DnevniProsek { get; set; }
        public virtual int? KriticnaVrednost { get; set; }

        public virtual Sektor Sektor { get; set; }
        public virtual Resurs Resurs { get; set; }
    }
}