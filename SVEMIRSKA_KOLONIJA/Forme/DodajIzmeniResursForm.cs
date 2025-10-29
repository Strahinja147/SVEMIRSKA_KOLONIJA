using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SVEMIRSKA_KOLONIJA.DTOs;


namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class DodajIzmeniResursForm : Form
    {
        private int? resursId;
        private ResursDetalji resurs;
        // NOVA LISTA:
        private List<StanovnikPregled> privremeniUpravitelji = new List<StanovnikPregled>();

        public DodajIzmeniResursForm(int? id = null)
        {
            InitializeComponent();
            this.resursId = id;
            this.resurs = null;

            this.PopuniSektore();

            // IZMENA: Sekcija za upravitelje je SADA UVEK VIDLJIVA
            lblUpravitelji.Visible = true;
            lvUpravitelji.Visible = true;
            btnDodeliUpravitelja.Visible = true;
            btnUkloniUpravitelja.Visible = true; // Prikazujemo i novo dugme

            if (this.resursId.HasValue)
            {
                this.Text = "Izmena Resursa";
                this.UcitajPodatkeResursa();
            }
            else
            {
                this.Text = "Dodavanje Novog Resursa";
                // Za novi resurs, privremena lista je inicijalno prazna, što je u redu.
            }
        }

        private void PopuniSektore()
        {
            cbxSkladiste.Items.Clear();
            List<SektorPregled> sektori = DTOManager.VratiSveSektore();
            foreach (var s in sektori)
            {
                cbxSkladiste.Items.Add(s);
            }
            cbxSkladiste.DisplayMember = "Naziv";
        }


        private void UcitajPodatkeResursa()
        {
            if (!this.resursId.HasValue) return;

            this.resurs = DTOManager.VratiResursDetalji(this.resursId.Value);
            if (this.resurs == null)
            {
                MessageBox.Show("Nije moguće učitati podatke o resursu.", "Greška");
                this.Close();
                return;
            }

            txtNaziv.Text = resurs.Naziv;
            numKolicina.Value = resurs.TrenutnaKolicina ?? 0;

            // Postavi selektovani sektor
            if (resurs.Skladiste != null)
            {
                foreach (SektorPregled item in cbxSkladiste.Items)
                {
                    if (item.Id == resurs.Skladiste.Id)
                    {
                        cbxSkladiste.SelectedItem = item;
                        break;
                    }
                }
            }

            // IZMENA: Popunjavamo privremenu listu i osvežavamo prikaz
            this.privremeniUpravitelji = new List<StanovnikPregled>(resurs.Upravitelji);
            this.OsveziPrikazUpravitelja();

        }


        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Naziv resursa je obavezno polje.", "Upozorenje");
                return;
            }

            if (cbxSkladiste.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati skladište (sektor) za resurs.", "Upozorenje");
                return; 
            }

           if ((int)numKolicina.Value <= 0)
           {
                MessageBox.Show("Nevalidna vrednost za kolicinu resursa.", "Upozorenje");
                return;
           }

            ResursDetalji noviResurs = new ResursDetalji
            {
                Naziv = txtNaziv.Text,
                TrenutnaKolicina = (int)numKolicina.Value,
                Skladiste = cbxSkladiste.SelectedItem as SektorPregled,
                // KLJUČNA IZMENA: Dodeljujemo listu upravitelja DTO objektu
                Upravitelji = this.privremeniUpravitelji

            };

            if (this.resursId.HasValue)
            {
                noviResurs.Id = this.resursId.Value;
                DTOManager.AzurirajResurs(noviResurs); // Poslaćemo AzurirajResurs na doradu
                MessageBox.Show("Podaci o resursu su uspešno ažurirani.", "Informacija");
            }
            else
            {
                DTOManager.DodajResurs(noviResurs); // Poslaćemo DodajResurs na doradu
                MessageBox.Show("Novi resurs je uspešno dodat.", "Informacija");
            }

            this.Close();
        }

        private void btnDodeliUpravitelja_Click(object sender, EventArgs e)
        {
            // Provera da li ima smisla otvarati formu.
            // Ovo radimo tako što uporedimo broj trenutnih upravitelja sa ukupnim brojem stanovnika.
            int ukupanBrojStanovnika = DTOManager.VratiSveStanovnike().Count;
            if (this.privremeniUpravitelji.Count >= ukupanBrojStanovnika)
            {
                MessageBox.Show("Svi postojeći stanovnici su već dodeljeni kao upravitelji.", "Obaveštenje");
                return;
            }

            // 1. Kreiramo instancu naše nove forme.
            //    Prosleđujemo joj našu PRIVREMENU listu postojećih upravitelja.
            //    Forma će sama odraditi logiku filtriranja.
            OdabirStanovnikaForm form = new OdabirStanovnikaForm(this.privremeniUpravitelji);

            // 2. Prikazujemo formu i čekamo ishod
            if (form.ShowDialog() == DialogResult.OK)
            {
                // 3. Ako je korisnik kliknuo "Odaberi", preuzimamo rezultat
                StanovnikPregled odabraniStanovnik = form.OdabraniStanovnik;

                // 4. Dodajemo ga u lokalnu listu i osvežavamo prikaz
                this.privremeniUpravitelji.Add(odabraniStanovnik);
                this.OsveziPrikazUpravitelja();
            }
        }

        private void btnUkloniUpravitelja_Click(object sender, EventArgs e)
        {
            if (lvUpravitelji.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite upravitelja kojeg želite da uklonite iz liste.", "Obaveštenje");
                return;
            }

            int idZaUklanjanje = Int32.Parse(lvUpravitelji.SelectedItems[0].SubItems[0].Text);

            StanovnikPregled stanovnikZaUklanjanje = this.privremeniUpravitelji
                                                        .FirstOrDefault(s => s.Id == idZaUklanjanje);

            if (stanovnikZaUklanjanje != null)
            {
                this.privremeniUpravitelji.Remove(stanovnikZaUklanjanje);
                this.OsveziPrikazUpravitelja();
            }
        }

        private void OsveziPrikazUpravitelja()
        {
            lvUpravitelji.Items.Clear();
            foreach (var upravitelj in this.privremeniUpravitelji)
            {
                ListViewItem item = new ListViewItem(new string[] { upravitelj.Id.ToString(), upravitelj.Ime, upravitelj.Prezime });
                lvUpravitelji.Items.Add(item);
            }
            
            lvUpravitelji.Refresh();
        }
    }
}