namespace SvemirskaKolonija.Entiteti
{
    public class Evakuacija : Zadatak
    {
        public virtual string OblastEvakuacije { get; set; }
        public virtual int? BrojOsobaEvakuacije { get; set; }
    }
}