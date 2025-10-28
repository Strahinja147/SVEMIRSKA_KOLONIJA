using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms; // Potrebno za MessageBox
using NHibernate;
using NHibernate.Linq;
using SVEMIRSKA_KOLONIJA.Entiteti;
using SVEMIRSKA_KOLONIJA.DTOs;
using SVEMIRSKA_KOLONIJA; // Obavezno dodati using za namespace gde se nalazi DataLayer

namespace SVEMIRSKA_KOLONIJA
{
    public static class DTOManager
    {
        #region Stanovnik

        /// <summary>
        /// Vraća listu svih stanovnika sa osnovnim podacima. U slučaju greške, prikazuje poruku i vraća praznu listu.
        /// </summary>
        public static List<StanovnikPregled> VratiSveStanovnike()
        {
            var stanovnici = new List<StanovnikPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Stanovnik> sviStanovnici = from o in s.Query<Stanovnik>() select o;

                foreach (Stanovnik st in sviStanovnici)
                {
                    stanovnici.Add(new StanovnikPregled
                    {
                        Id = st.Id,
                        Ime = st.Ime,
                        Prezime = st.Prezime,
                        Zanimanje = st.Zanimanje
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja podataka o stanovnicima.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return stanovnici;
        }

        /// <summary>
        /// Vraća sve detaljne informacije o jednom stanovniku. U slučaju greške, prikazuje poruku i vraća null.
        /// </summary>
        public static StanovnikDetalji VratiStanovnikaDetalji(int id)
        {
            StanovnikDetalji stanovnik = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Stanovnik st = s.Load<Stanovnik>(id);

                stanovnik = new StanovnikDetalji
                {
                    Id = st.Id,
                    Ime = st.Ime,
                    Prezime = st.Prezime,
                    Pol = st.Pol,
                    DatumRodjenja = st.DatumRodjenja,
                    Nacionalnost = st.Nacionalnost,
                    Zanimanje = st.Zanimanje,
                    GodineUKoloniji = st.GodineUKoloniji,

                    KontaktiNaZemlji = st.KontaktiNaZemlji.Select(k => new KontaktNaZemljiPregled
                    {
                        Id = k.Id,
                        Ime = k.Ime,
                        Odnos = k.Odnos,
                        KontaktInformacije = k.KontaktInformacije.Select(info => info.KontaktInformacija).ToList()
                    }).ToList(),

                    Specijalizacije = st.Specijalizacije.Select(p => new PosedujePregled
                    {
                        Id = p.Id,
                        NazivSpecijalizacije = p.Specijalizacija.Naziv,
                        NivoEkspertize = p.NivoEkspertize,
                        DatumSticanja = p.DatumSticanja,
                        Institucija = p.Institucija,
                        Specijalizacija = new SpecijalizacijaPregled { Id = p.Specijalizacija.Id, Naziv = p.Specijalizacija.Naziv }
                    }).ToList(),

                    SektoriKojeVodi = st.SektoriKojeVodi.Select(sek => new SektorPregled
                    {
                        Id = sek.Id,
                        Naziv = sek.Naziv,
                        TipSektora = sek.TipSektora
                    }).ToList(),

                    OdgovoranZaRobote = st.OdgovoranZaRobote.Select(r => new RobotPregled
                    {
                        Id = r.Id,
                        Sifra = r.Sifra,
                        Tip = r.Tip
                    }).ToList(),

                    ProgramiraniRoboti = st.ProgramiraniRoboti.Select(r => new RobotPregled
                    {
                        Id = r.Id,
                        Sifra = r.Sifra,
                        Tip = r.Tip
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja detalja o stanovniku.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return stanovnik;
        }

        /// <summary>
        /// Dodaje novog stanovnika u bazu unutar transakcije.
        /// </summary>
        public static Stanovnik DodajStanovnika(StanovnikDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var stanovnik = new Stanovnik
                {
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Pol = p.Pol,
                    DatumRodjenja = p.DatumRodjenja,
                    Nacionalnost = p.Nacionalnost,
                    Zanimanje = p.Zanimanje,
                    GodineUKoloniji = p.GodineUKoloniji
                };

                s.Save(stanovnik);
                t.Commit();
                return stanovnik; // VRAĆAMO SAČUVANI ENTITET SA NOVIM ID-JEM
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodavanja stanovnika.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Ažurira postojećeg stanovnika u bazi unutar transakcije.
        /// </summary>
        public static void AzurirajStanovnika(StanovnikDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var stanovnik = s.Load<Stanovnik>(p.Id);

                stanovnik.Ime = p.Ime;
                stanovnik.Prezime = p.Prezime;
                stanovnik.Pol = p.Pol;
                stanovnik.DatumRodjenja = p.DatumRodjenja;
                stanovnik.Nacionalnost = p.Nacionalnost;
                stanovnik.Zanimanje = p.Zanimanje;
                stanovnik.GodineUKoloniji = p.GodineUKoloniji;

                s.Update(stanovnik);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom ažuriranja stanovnika.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Briše stanovnika iz baze unutar transakcije.
        /// </summary>
        public static void ObrisiStanovnika(int id)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                Stanovnik st = s.Load<Stanovnik>(id);
                s.Delete(st); // Pusti bazu da javi grešku ako je stanovnik i dalje negde vođa ili odgovoran

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                // Poruka će sada biti mnogo jasnija, npr. "ORA-02292: integrity constraint violated..."
                MessageBox.Show($"Došlo je do greške prilikom brisanja stanovnika. Proverite da li je i dalje vođa nekog sektora ili odgovoran za nekog robota.\n\nOriginalna greška:\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        #endregion

        // ... Ostali regioni (Sektor, Robot, itd.) bi sledili isti obrazac ...
        #region Sektor

        /// <summary>
        /// Vraća listu svih sektora sa osnovnim podacima.
        /// </summary>
        public static List<SektorPregled> VratiSveSektore()
        {
            var sektori = new List<SektorPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var sviSektori = s.Query<Sektor>().ToList();

                foreach (var sekt in sviSektori)
                {
                    sektori.Add(new SektorPregled
                    {
                        Id = sekt.Id,
                        Naziv = sekt.Naziv,
                        TipSektora = sekt.TipSektora
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja podataka o sektorima.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return sektori;
        }

        /// <summary>
        /// Vraća sve detaljne informacije o jednom sektoru.
        /// </summary>
        public static SektorDetalji VratiSektorDetalji(int id)
        {
            SektorDetalji sektor = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var sekt = s.Load<Sektor>(id);

                sektor = new SektorDetalji
                {
                    Id = sekt.Id,
                    Naziv = sekt.Naziv,
                    TipSektora = sekt.TipSektora,
                    Kapacitet = sekt.Kapacitet,
                    Povrsina = sekt.Povrsina,
                    VodjaSektora = sekt.VodjaSektora != null ? new StanovnikPregled
                    {
                        Id = sekt.VodjaSektora.Id,
                        Ime = sekt.VodjaSektora.Ime,
                        Prezime = sekt.VodjaSektora.Prezime,
                        Zanimanje = sekt.VodjaSektora.Zanimanje
                    } : null,

                    Radnici = sekt.Radnici.Select(veza => new StanovnikPregled
                    {
                        Id = veza.Id,
                        Ime = veza.Ime,
                        Prezime = veza.Prezime,
                        Zanimanje = veza.Zanimanje
                    }).ToList(),

                    ResursiUSektoru = sekt.ResursiUSektoru.Select(r => new ResursPregled
                    {
                        Id = r.Id,
                        Naziv = r.Naziv,
                        TrenutnaKolicina = r.TrenutnaKolicina
                    }).ToList(),

                    IstorijaOdrzavanja = sekt.ZapisiOdrzavanja.Select(zo => new ZapisOdrzavanjaPregled
                    {
                        Id = zo.Id,
                        VremeOdrzavanja = zo.VremeOdrzavanja,
                        NazivSektora = zo.Sektor.Naziv
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja detalja o sektoru.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return sektor;
        }

        /// <summary>
        /// Dodaje novi sektor u bazu unutar transakcije.
        /// </summary>
        public static Sektor DodajSektor(SektorDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var sektor = new Sektor
                {
                    Naziv = p.Naziv,
                    TipSektora = p.TipSektora,
                    Kapacitet = p.Kapacitet,
                    Povrsina = p.Povrsina,
                };

                // Postavljanje reference na vođu sektora
                if (p.VodjaSektora != null)
                {
                    var vodja = s.Load<Stanovnik>(p.VodjaSektora.Id);
                    sektor.VodjaSektora = vodja;
                }

                s.Save(sektor);
                t.Commit();
                return sektor;
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodavanja sektora.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Ažurira postojeći sektor u bazi unutar transakcije.
        /// </summary>
        public static void AzurirajSektor(SektorDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var sektor = s.Load<Sektor>(p.Id);

                sektor.Naziv = p.Naziv;
                sektor.TipSektora = p.TipSektora;
                sektor.Kapacitet = p.Kapacitet;
                sektor.Povrsina = p.Povrsina;

                // Ažuriranje reference na vođu sektora
                if (p.VodjaSektora != null)
                {
                    var vodja = s.Load<Stanovnik>(p.VodjaSektora.Id);
                    sektor.VodjaSektora = vodja;
                }
                else
                {
                    sektor.VodjaSektora = null;
                }

                s.Update(sektor);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom ažuriranja sektora.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Briše sektor iz baze unutar transakcije.
        /// </summary>
        public static bool ObrisiSektor(int id)
        {
            ISession s = null;
            ITransaction t = null;
            bool validnoObrisan = false;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var sektor = s.Load<Sektor>(id);
                s.Delete(sektor);

                t.Commit();
                validnoObrisan = true;
                return validnoObrisan;
            }
            catch (Exception ex)
            {
                t?.Rollback();
                // Najčešća greška ovde je foreign key constraint - ako resursi, roboti ili radnici i dalje postoje u ovom sektoru.
                MessageBox.Show($"Došlo je do greške prilikom brisanja sektora. Proverite da li postoje resursi ili roboti koji su i dalje vezani za ovaj sektor.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validnoObrisan;
            }
            finally
            {
                s?.Close();
            }
        }

        public static bool DodeliRadnikaSektoru(int radnikId, int sektorId)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var radnik = s.Load<Stanovnik>(radnikId);
                var sektor = s.Load<Sektor>(sektorId);

                // Provera da li veza već postoji
                bool vezaPostoji = s.Query<RadiU>().Any(r => r.Radnik.Id == radnikId && r.SektorGdeRadi.Id == sektorId);
                if (vezaPostoji)
                {
                    t.Commit(); // Commit prazne transakcije
                    return true; // Smatramo uspehom ako veza već postoji
                }

                var novaVeza = new RadiU
                {
                    Radnik = radnik,
                    SektorGdeRadi = sektor
                };

                s.Save(novaVeza);
                t.Commit();
                return true;
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodele radnika sektoru.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Uklanja radnika iz sektora (raskida M:N vezu).
        /// </summary>
        public static void UkloniRadnikaIzSektora(int radnikId, int sektorId)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var vezaZaBrisanje = s.Query<RadiU>()
                                     .FirstOrDefault(r => r.Radnik.Id == radnikId && r.SektorGdeRadi.Id == sektorId);

                if (vezaZaBrisanje != null)
                {
                    s.Delete(vezaZaBrisanje);
                }

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom uklanjanja radnika iz sektora.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        #endregion

        #region Zadatak

        /// <summary>
        /// Pomoćna privatna funkcija koja konvertuje Zadatak entitet u odgovarajući konkretni ZadatakPregled DTO.
        /// </summary>
        private static ZadatakPregled KreirajZadatakPregled(Zadatak zadatak)
        {
            if (zadatak == null)
                return null;

            ZadatakPregled pregled;

            if (zadatak is Istrazivanje)
                pregled = new IstrazivanjePregled { TipZadatka = "Istrazivanje" };
            else if (zadatak is Odrzavanje)
                pregled = new OdrzavanjePregled { TipZadatka = "Odrzavanje" };
            else if (zadatak is Evakuacija)
                pregled = new EvakuacijaPregled { TipZadatka = "Evakuacija" };
            else if (zadatak is Eksperiment)
                pregled = new EksperimentPregled { TipZadatka = "Eksperiment" };
            else if (zadatak is MedicinskaIntervencija)
                pregled = new MedicinskaIntervencijaPregled { TipZadatka = "Medicinska Intervencija" };
            else
                return null; // Nepoznat tip zadatka

            pregled.Id = zadatak.Id;
            pregled.OpisCilja = zadatak.OpisCilja;
            pregled.DatumPocetka = zadatak.DatumPocetka;

            return pregled;
        }

        public static List<ZadatakPregled> VratiSveZadatke()
        {
            var zadaciPregled = new List<ZadatakPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var sviZadaci = s.Query<Zadatak>().ToList();

                foreach (var zadatak in sviZadaci)
                {
                    // Koristimo pomoćnu funkciju da dobijemo ispravan DTO
                    var pregled = KreirajZadatakPregled(zadatak);
                    if (pregled != null)
                    {
                        zadaciPregled.Add(pregled);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja podataka o zadacima.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return zadaciPregled;
        }

        public static ZadatakDetalji VratiZadatakDetalji(int id)
        {
            ZadatakDetalji detalji = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var zadatak = s.Load<Zadatak>(id);

                if (zadatak is Evakuacija z_evak)
                {
                    detalji = new EvakuacijaDetalji
                    {
                        OblastEvakuacije = z_evak.OblastEvakuacije,
                        BrojOsobaEvakuacije = z_evak.BrojOsobaEvakuacije
                    };
                }
                else if (zadatak is Eksperiment z_exp)
                {
                    detalji = new EksperimentDetalji { NivoOpasnosti = z_exp.NivoOpasnosti };
                }
                else if (zadatak is MedicinskaIntervencija z_med)
                {
                    detalji = new MedicinskaIntervencijaDetalji
                    {
                        BrojPovredjenih = z_med.BrojPovredjenih,
                        StepenKriticnosti = z_med.StepenKriticnosti
                    };
                }
                else if (zadatak is Odrzavanje)
                {
                    detalji = new OdrzavanjeDetalji();
                }
                else if (zadatak is Istrazivanje)
                {
                    detalji = new IstrazivanjeDetalji();
                }

                if (detalji != null)
                {
                    // Popunjavanje zajedničkih podataka
                    detalji.Id = zadatak.Id;
                    detalji.OpisCilja = zadatak.OpisCilja;
                    detalji.Lokacija = zadatak.Lokacija;
                    detalji.OcekivanoTrajanjeDani = zadatak.OcekivanoTrajanjeDani;
                    detalji.DatumPocetka = zadatak.DatumPocetka;
                    detalji.DatumZavrsetka = zadatak.DatumZavrsetka;
                    detalji.OcenaUspesnosti = zadatak.OcenaUspesnosti;
                    detalji.Rezultat = zadatak.Rezultat;
                    detalji.BrojPotrebnihUcesnika = zadatak.BrojPotrebnihUcesnika;

                    // ISPRAVLJENO: Koristimo pomoćnu funkciju umesto 'new ZadatakPregled()'
                    detalji.Nadzadatak = KreirajZadatakPregled(zadatak.Nadzadatak);
                    detalji.Podzadaci = zadatak.Podzadaci.Select(p => KreirajZadatakPregled(p)).ToList();

                    detalji.PotrebneSpecijalizacije = zadatak.PotrebneSpecijalizacije.Select(p => new PotrebnaPregled { Id = p.Id, NazivSpecijalizacije = p.Specijalizacija.Naziv, Nivo = p.Nivo }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja detalja o zadatku.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return detalji;
        }

        // Metode DodajZadatak, AzurirajZadatak i ObrisiZadatak ostaju iste kao u prethodnom odgovoru
        // ... (da ih ne bih ponavljao bez potrebe) ...
        public static void DodajZadatak(ZadatakDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                Zadatak noviZadatak = null;

                if (p is EvakuacijaDetalji evak)
                    noviZadatak = new Evakuacija { OblastEvakuacije = evak.OblastEvakuacije, BrojOsobaEvakuacije = evak.BrojOsobaEvakuacije };
                else if (p is EksperimentDetalji exp)
                    noviZadatak = new Eksperiment { NivoOpasnosti = exp.NivoOpasnosti };
                else if (p is MedicinskaIntervencijaDetalji med)
                    noviZadatak = new MedicinskaIntervencija { BrojPovredjenih = med.BrojPovredjenih, StepenKriticnosti = med.StepenKriticnosti };
                else if (p is OdrzavanjeDetalji)
                    noviZadatak = new Odrzavanje();
                else if (p is IstrazivanjeDetalji)
                    noviZadatak = new Istrazivanje();

                if (noviZadatak != null)
                {
                    noviZadatak.OpisCilja = p.OpisCilja;
                    noviZadatak.Lokacija = p.Lokacija;
                    noviZadatak.OcekivanoTrajanjeDani = p.OcekivanoTrajanjeDani;
                    noviZadatak.DatumPocetka = p.DatumPocetka;
                    noviZadatak.DatumZavrsetka = p.DatumZavrsetka;

                    s.Save(noviZadatak);
                    t.Commit();
                }
                else
                {
                    throw new InvalidOperationException("Tip zadatka nije prepoznat i ne može biti sačuvan.");
                }
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodavanja zadatka.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        public static void AzurirajZadatak(ZadatakDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                Zadatak zadatak = s.Load<Zadatak>(p.Id);

                zadatak.OpisCilja = p.OpisCilja;
                zadatak.Lokacija = p.Lokacija;
                zadatak.OcekivanoTrajanjeDani = p.OcekivanoTrajanjeDani;
                zadatak.DatumPocetka = p.DatumPocetka;
                zadatak.DatumZavrsetka = p.DatumZavrsetka;
                zadatak.Rezultat = p.Rezultat;
                zadatak.OcenaUspesnosti = p.OcenaUspesnosti;

                if (zadatak is Evakuacija z_evak && p is EvakuacijaDetalji evak)
                {
                    z_evak.OblastEvakuacije = evak.OblastEvakuacije;
                    z_evak.BrojOsobaEvakuacije = evak.BrojOsobaEvakuacije;
                }
                else if (zadatak is Eksperiment z_exp && p is EksperimentDetalji exp)
                {
                    z_exp.NivoOpasnosti = exp.NivoOpasnosti;
                }
                else if (zadatak is MedicinskaIntervencija z_med && p is MedicinskaIntervencijaDetalji med)
                {
                    z_med.BrojPovredjenih = med.BrojPovredjenih;
                    z_med.StepenKriticnosti = med.StepenKriticnosti;
                }

                s.Update(zadatak);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom ažuriranja zadatka.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        public static void ObrisiZadatak(int id)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var zadatak = s.Load<Zadatak>(id);
                s.Delete(zadatak);

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom brisanja zadatka.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        public static void AngazujUcesnikaNaZadatku(int ucesnikZadatkaId, int zadatakId)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var ucesnik = s.Load<UcesnikZadatka>(ucesnikZadatkaId);
                var zadatak = s.Load<Zadatak>(zadatakId);

                if (!zadatak.AngazovaniUcesnici.Any(u => u.Id == ucesnikZadatkaId))
                {
                    zadatak.AngazovaniUcesnici.Add(ucesnik);
                    s.Update(zadatak);
                }

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom angažovanja učesnika na zadatku.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        #endregion

        #region Robot

        /// <summary>
        /// Vraća listu svih robota sa osnovnim podacima.
        /// </summary>
        public static List<RobotPregled> VratiSveRobote()
        {
            var roboti = new List<RobotPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var sviRoboti = s.Query<Robot>().ToList();

                foreach (var r in sviRoboti)
                {
                    roboti.Add(new RobotPregled
                    {
                        Id = r.Id,
                        Sifra = r.Sifra,
                        Tip = r.Tip
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja podataka o robotima.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return roboti;
        }

        /// <summary>
        /// Vraća sve detaljne informacije o jednom robotu.
        /// </summary>
        public static RobotDetalji VratiRobotaDetalji(int id)
        {
            RobotDetalji robot = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var r = s.Load<Robot>(id);

                robot = new RobotDetalji
                {
                    Id = r.Id,
                    Tip = r.Tip,
                    Sifra = r.Sifra,
                    OdgovorniStanovnik = r.OdgovorniStanovnik != null ? new StanovnikPregled
                    {
                        Id = r.OdgovorniStanovnik.Id,
                        Ime = r.OdgovorniStanovnik.Ime,
                        Prezime = r.OdgovorniStanovnik.Prezime,
                        Zanimanje = r.OdgovorniStanovnik.Zanimanje
                    } : null,
                    Programer = r.Programer != null ? new StanovnikPregled
                    {
                        Id = r.Programer.Id,
                        Ime = r.Programer.Ime,
                        Prezime = r.Programer.Prezime,
                        Zanimanje = r.Programer.Zanimanje
                    } : null,
                    Sektor = r.Sektor != null ? new SektorPregled
                    {
                        Id = r.Sektor.Id,
                        Naziv = r.Sektor.Naziv,
                        TipSektora = r.Sektor.TipSektora
                    } : null
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja detalja o robotu.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return robot;
        }

        /// <summary>
        /// Dodaje novog robota u bazu unutar transakcije.
        /// </summary>
        public static void DodajRobota(RobotDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var robot = new Robot
                {
                    Sifra = p.Sifra,
                    Tip = p.Tip
                    // UcesnikZadatka se namerno ostavlja kao null
                };

                if (p.OdgovorniStanovnik != null)
                {
                    var odgovorni = s.Load<Stanovnik>(p.OdgovorniStanovnik.Id);
                    robot.OdgovorniStanovnik = odgovorni;
                }
                if (p.Programer != null)
                {
                    var programer = s.Load<Stanovnik>(p.Programer.Id);
                    robot.Programer = programer;
                }
                if (p.Sektor != null)
                {
                    var sektor = s.Load<Sektor>(p.Sektor.Id);
                    robot.Sektor = sektor;
                }

                s.Save(robot);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodavanja robota.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Ažurira postojećeg robota u bazi unutar transakcije.
        /// </summary>
        public static void AzurirajRobota(RobotDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var robot = s.Load<Robot>(p.Id);

                robot.Sifra = p.Sifra;
                robot.Tip = p.Tip;

                if (p.OdgovorniStanovnik != null)
                {
                    var odgovorni = s.Load<Stanovnik>(p.OdgovorniStanovnik.Id);
                    robot.OdgovorniStanovnik = odgovorni;
                }
                else { robot.OdgovorniStanovnik = null; }

                if (p.Programer != null)
                {
                    var programer = s.Load<Stanovnik>(p.Programer.Id);
                    robot.Programer = programer;
                }
                else { robot.Programer = null; }

                if (p.Sektor != null)
                {
                    var sektor = s.Load<Sektor>(p.Sektor.Id);
                    robot.Sektor = sektor;
                }
                else { robot.Sektor = null; }

                s.Update(robot);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom ažuriranja robota.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Briše robota iz baze unutar transakcije.
        /// </summary>
        public static void ObrisiRobota(int id)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var robot = s.Load<Robot>(id);
                s.Delete(robot);

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom brisanja robota.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        #endregion

        #region Resurs

        /// <summary>
        /// Vraća listu svih resursa sa osnovnim podacima.
        /// </summary>
        public static List<ResursPregled> VratiSveResurse()
        {
            var resursi = new List<ResursPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var sviResursi = s.Query<Resurs>().ToList();
                foreach (var r in sviResursi)
                {
                    resursi.Add(new ResursPregled
                    {
                        Id = r.Id,
                        Naziv = r.Naziv,
                        TrenutnaKolicina = r.TrenutnaKolicina
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja podataka o resursima.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return resursi;
        }

        /// <summary>
        /// Vraća sve detaljne informacije o jednom resursu.
        /// </summary>
        public static ResursDetalji VratiResursDetalji(int id)
        {
            ResursDetalji detalji = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var r = s.Load<Resurs>(id);

                detalji = new ResursDetalji
                {
                    Id = r.Id,
                    Naziv = r.Naziv,
                    TrenutnaKolicina = r.TrenutnaKolicina,
                    Skladiste = r.Sektor != null ? new SektorPregled
                    {
                        Id = r.Sektor.Id,
                        Naziv = r.Sektor.Naziv,
                        TipSektora = r.Sektor.TipSektora
                    } : null,

                    Upravitelji = r.Upravitelji.Select(u => new StanovnikPregled
                    {
                        Id = u.Id,
                        Ime = u.Ime,
                        Prezime = u.Prezime,
                        Zanimanje = u.Zanimanje
                    }).ToList(),

                    PotrosnjaPoSektorima = r.PotrosnjaPoSektorima.Select(p => new TrosiPregled
                    {
                        Id = p.Id,
                        NazivSektora = p.Sektor.Naziv,
                        NazivResursa = p.Resurs.Naziv,
                        DnevniProsek = p.DnevniProsek,
                        KriticnaVrednost = p.KriticnaVrednost
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja detalja o resursu.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return detalji;
        }

        /// <summary>
        /// Dodaje novi resurs u bazu unutar transakcije.
        /// </summary>
        public static void DodajResurs(ResursDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var resurs = new Resurs
                {
                    Naziv = p.Naziv,
                    TrenutnaKolicina = p.TrenutnaKolicina
                };

                if (p.Skladiste != null)
                {
                    var skladiste = s.Load<Sektor>(p.Skladiste.Id);
                    resurs.Sektor = skladiste;
                }

                // Veza M-N (Upravitelji) se obično dodaje naknadno
                // kroz posebnu funkciju, npr. DodajUpraviteljaResursu(resursId, stanovnikId)
                // Ovde je izostavljeno radi jednostavnosti DTO-a.

                s.Save(resurs);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodavanja resursa.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Ažurira postojeći resurs u bazi unutar transakcije.
        /// </summary>
        public static void AzurirajResurs(ResursDetalji p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var resurs = s.Load<Resurs>(p.Id);

                resurs.Naziv = p.Naziv;
                resurs.TrenutnaKolicina = p.TrenutnaKolicina;

                if (p.Skladiste != null)
                {
                    var skladiste = s.Load<Sektor>(p.Skladiste.Id);
                    resurs.Sektor = skladiste;
                }
                else
                {
                    resurs.Sektor = null;
                }

                s.Update(resurs);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom ažuriranja resursa.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Briše resurs iz baze unutar transakcije.
        /// </summary>
        public static void ObrisiResurs(int id)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var resurs = s.Load<Resurs>(id);
                s.Delete(resurs);

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom brisanja resursa. Proverite da li se ovaj resurs i dalje troši u nekom sektoru.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        public static void DodeliUpraviteljaResursu(int stanovnikId, int resursId)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var stanovnik = s.Load<Stanovnik>(stanovnikId);
                var resurs = s.Load<Resurs>(resursId);

                if (!resurs.Upravitelji.Any(u => u.Id == stanovnikId))
                {
                    resurs.Upravitelji.Add(stanovnik);
                    s.Update(resurs);
                }

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodeljivanja upravitelja resursu.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        #endregion

        #region Specijalizacija

        /// <summary>
        /// Vraća listu svih dostupnih specijalizacija.
        /// </summary>
        public static List<SpecijalizacijaPregled> VratiSveSpecijalizacije()
        {
            var specijalizacije = new List<SpecijalizacijaPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var sveSpecijalizacije = s.Query<Specijalizacija>().ToList();
                foreach (var spec in sveSpecijalizacije)
                {
                    specijalizacije.Add(new SpecijalizacijaPregled
                    {
                        Id = spec.Id,
                        Naziv = spec.Naziv
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja podataka o specijalizacijama.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return specijalizacije;
        }

        public static void DodajSpecijalizaciju(SpecijalizacijaPregled p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var specijalizacija = new Specijalizacija
                {
                    Naziv = p.Naziv
                };
                var noviId = s.CreateSQLQuery("SELECT SEQ_SPECIJALIZACIJA.NEXTVAL FROM DUAL").UniqueResult<decimal>();
                specijalizacija.Id = Convert.ToInt32(noviId);

                s.Save(specijalizacija);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodavanja specijalizacije.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        public static void AzurirajSpecijalizaciju(SpecijalizacijaPregled p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var specijalizacija = s.Load<Specijalizacija>(p.Id);
                specijalizacija.Naziv = p.Naziv;

                s.Update(specijalizacija);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom ažuriranja specijalizacije.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        public static void ObrisiSpecijalizaciju(int id)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var specijalizacija = s.Load<Specijalizacija>(id);
                s.Delete(specijalizacija);

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom brisanja specijalizacije. Proverite da li je neki stanovnik i dalje poseduje.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        #endregion

        #region ZapisOdrzavanja

        /// <summary>
        /// Vraća listu svih zapisa o održavanjima.
        /// </summary>
        public static List<ZapisOdrzavanjaPregled> VratiSveZapiseOdrzavanja()
        {
            var zapisi = new List<ZapisOdrzavanjaPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var sviZapisi = s.Query<ZapisOdrzavanja>().ToList();
                foreach (var z in sviZapisi)
                {
                    zapisi.Add(new ZapisOdrzavanjaPregled
                    {
                        Id = z.Id,
                        VremeOdrzavanja = z.VremeOdrzavanja,
                        NazivSektora = z.Sektor?.Naziv // Dodajemo ? za slučaj da je sektor null
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja zapisa o održavanjima.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return zapisi;
        }

        /// <summary>
        /// Vraća detaljne informacije o jednom zapisu održavanja.
        /// </summary>
        public static ZapisOdrzavanjaDetalji VratiZapisOdrzavanjaDetalji(int id)
        {
            ZapisOdrzavanjaDetalji detalji = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var z = s.Load<ZapisOdrzavanja>(id);

                detalji = new ZapisOdrzavanjaDetalji
                {
                    Id = z.Id,
                    VremeOdrzavanja = z.VremeOdrzavanja,
                    Sektor = new SektorPregled
                    {
                        Id = z.Sektor.Id,
                        Naziv = z.Sektor.Naziv,
                        TipSektora = z.Sektor.TipSektora
                    },
                    UcesniciOdrzavanja = z.UcesniciOdrzavanja.Select(u => new StanovnikPregled
                    {
                        Id = u.Id,
                        Ime = u.Ime,
                        Prezime = u.Prezime,
                        Zanimanje = u.Zanimanje
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom preuzimanja detalja o zapisu održavanja.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
            return detalji;
        }


        #endregion

        #region Upravljanje Vezama (Poseduje, Trosi, Potrebna, Kontakt)

        /// <summary>
        /// Dodaje specijalizaciju (posedovanje) određenom stanovniku.
        /// </summary>
        public static void DodajSpecijalizacijuStanovniku(int stanovnikId, int specijalizacijaId, PosedujePregled p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var stanovnik = s.Load<Stanovnik>(stanovnikId);
                var specijalizacija = s.Load<Specijalizacija>(specijalizacijaId);

                var poseduje = new Poseduje
                {
                    Stanovnik = stanovnik,
                    Specijalizacija = specijalizacija,
                    NivoEkspertize = p.NivoEkspertize,
                    DatumSticanja = p.DatumSticanja,
                    Institucija = p.Institucija
                };

                s.Save(poseduje);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodavanja specijalizacije stanovniku.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Briše vezu 'Poseduje' (uklanja specijalizaciju stanovniku).
        /// </summary>
        public static void ObrisiPosedujeVezu(int posedujeId)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var poseduje = s.Load<Poseduje>(posedujeId);
                s.Delete(poseduje);

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom brisanja specijalizacije.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Dodaje kontakt na Zemlji za određenog stanovnika.
        /// </summary>
        public static void DodajKontaktZaStanovnika(int stanovnikId, KontaktNaZemljiPregled p)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var stanovnik = s.Load<Stanovnik>(stanovnikId);

                var kontakt = new KontaktNaZemlji
                {
                    Stanovnik = stanovnik,
                    Ime = p.Ime,
                    Odnos = p.Odnos
                };
                var noviId = s.CreateSQLQuery("SELECT SEQ_KONTAKT_NA_ZEMLJI.NEXTVAL FROM DUAL").UniqueResult<decimal>();
                kontakt.Id = Convert.ToInt32(noviId);

                foreach (var info in p.KontaktInformacije)
                {
                    var konInfo = new KonZemInf
                    {
                        PripadaKontaktu = kontakt,
                        KontaktInformacija = info
                    };
                    kontakt.KontaktInformacije.Add(konInfo);
                }

                s.Save(kontakt);
                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom dodavanja kontakta.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }

        /// <summary>
        /// Briše kontakt na Zemlji.
        /// </summary>
        public static void ObrisiKontakt(int kontaktId)
        {
            ISession s = null;
            ITransaction t = null;
            try
            {
                s = DataLayer.GetSession();
                t = s.BeginTransaction();

                var kontakt = s.Load<KontaktNaZemlji>(kontaktId);
                s.Delete(kontakt); // Cascade će obrisati i KonZemInf

                t.Commit();
            }
            catch (Exception ex)
            {
                t?.Rollback();
                MessageBox.Show($"Došlo je do greške prilikom brisanja kontakta.\n\n{ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                s?.Close();
            }
        }


        #endregion
    }
}