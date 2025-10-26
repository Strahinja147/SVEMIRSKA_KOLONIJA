using FluentNHibernate.Mapping;
using SVEMIRSKA_KOLONIJA.Entiteti;

namespace SVEMIRSKA_KOLONIJA.Mapiranja
{
    public class ZadatakMap : ClassMap<Zadatak>
    {
        public ZadatakMap()
        {
            Table("ZADATAK");

            Id(x => x.Id, "ZADATAK_ID").GeneratedBy.Sequence("SEQ_ZADATAK");

            // Definiše kolonu koja određuje tip podklase
            DiscriminateSubClassesOnColumn("TIP_ZADATKA");

            Map(x => x.OcekivanoTrajanjeDani, "OCEKIVANO_TRAJANJE_DANI");
            Map(x => x.DatumZavrsetka, "DATUM_ZAVRSETKA");
            Map(x => x.DatumPocetka, "DATUM_POCETKA");
            Map(x => x.OcenaUspesnosti, "OCENA_USPESNOSTI");
            Map(x => x.BrojPotrebnihUcesnika, "BROJ_POTREBNIH_UCESNika");
            Map(x => x.Rezultat, "REZULTAT");
            Map(x => x.OpisCilja, "OPIS_CILJA");
            Map(x => x.Lokacija, "LOKACIJA");

            References(x => x.Nadzadatak, "PODZADATAK_ID");

            HasMany(x => x.Podzadaci).KeyColumn("PODZADATAK_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.PotrebneSpecijalizacije).KeyColumn("ZADATAK_ID").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.AngazovaniUcesnici)
                .Table("ANGAZOVAN_NA")
                .ParentKeyColumn("ZADATAK_ID")
                .ChildKeyColumn("UCESNIK_ZADATKA_ID")
                .Cascade.All();
        }
    }
}