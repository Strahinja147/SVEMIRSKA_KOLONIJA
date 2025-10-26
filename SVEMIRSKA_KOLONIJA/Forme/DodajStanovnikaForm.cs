using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class DodajStanovnikaForm : Form
    {
        private StanovnikDetalji Stanovnik;

        // Konstruktor za DODAVANJE
        public DodajStanovnikaForm()
        {
            InitializeComponent();
            this.Text = "DODAJ NOVOG STANOVNIKA";
            groupBoxPovezaniPodaci.Visible = false;
        }

        // Konstruktor za IZMENU
        public DodajStanovnikaForm(StanovnikDetalji stanovnik)
        {
            InitializeComponent();
            this.Stanovnik = stanovnik;
            this.Text = $"IZMENI STANOVNIKA: {stanovnik.Ime} {stanovnik.Prezime}";
            //PopuniPodacima();
        }

        private void DodajStanovnikaForm_Load(object sender, EventArgs e)
        {
            cmbPol.Items.Add('M');
            cmbPol.Items.Add('Z');

            // Ako je Stanovnik prosleđen (režim izmene), popunjavamo formu
            if (this.Stanovnik != null)
            {
                PopuniPodacima();
            }
        }

        private void PopuniPodacima()
        {
            // Popunjavanje osnovnih podataka
            txtIme.Text = this.Stanovnik.Ime;
            txtPrezime.Text = this.Stanovnik.Prezime;
            txtNacionalnost.Text = this.Stanovnik.Nacionalnost;
            txtZanimanje.Text = this.Stanovnik.Zanimanje;
            cmbPol.SelectedItem = this.Stanovnik.Pol;

            if (this.Stanovnik.DatumRodjenja.HasValue)
                dtpDatumRodjenja.Value = this.Stanovnik.DatumRodjenja.Value;
            if (this.Stanovnik.GodineUKoloniji.HasValue)
                numGodine.Value = this.Stanovnik.GodineUKoloniji.Value;

            // Popunjavanje ListView kontrola za povezane podatke
            PopuniPovezanePodatke();
        }

        private void PopuniPovezanePodatke()
        {
            // --- Kontakti na Zemlji ---
            listViewKontakti.Items.Clear();
            if (listViewKontakti.Columns.Count == 0) // Dodaj kolone samo ako ne postoje
            {
                listViewKontakti.Columns.Add("Ime", 120);
                listViewKontakti.Columns.Add("Odnos", 80);
            }
            foreach (var kontakt in this.Stanovnik.KontaktiNaZemlji)
            {
                listViewKontakti.Items.Add(new ListViewItem(new string[] { kontakt.Ime, kontakt.Odnos }));
            }
            listViewKontakti.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // --- Specijalizacije ---
            listViewSpecijalizacije.Items.Clear();
            if (listViewSpecijalizacije.Columns.Count == 0)
            {
                listViewSpecijalizacije.Columns.Add("Naziv", 150);
                listViewSpecijalizacije.Columns.Add("Nivo Ekspertize", 100);
            }
            foreach (var spec in this.Stanovnik.Specijalizacije)
            {
                listViewSpecijalizacije.Items.Add(new ListViewItem(new string[] { spec.NazivSpecijalizacije, spec.NivoEkspertize }));
            }
            listViewSpecijalizacije.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // ... i tako za ostale ListView kontrole
            // (Prilagodi nazive listViewSektoriKojeVodi, listViewOdgovoranZa itd. onima iz tvog dizajnera)
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIme.Text) || string.IsNullOrEmpty(txtPrezime.Text) || cmbPol.SelectedItem == null)
            {
                MessageBox.Show("Sva polja su obavezna!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.Stanovnik == null)
            {
                this.Stanovnik = new StanovnikDetalji();
            }

            this.Stanovnik.Ime = txtIme.Text;
            this.Stanovnik.Prezime = txtPrezime.Text;
            this.Stanovnik.Nacionalnost = txtNacionalnost.Text;
            this.Stanovnik.Zanimanje = txtZanimanje.Text;
            this.Stanovnik.Pol = cmbPol.SelectedItem.ToString()[0];
            this.Stanovnik.DatumRodjenja = dtpDatumRodjenja.Value;
            this.Stanovnik.GodineUKoloniji = (int)numGodine.Value;

            if (this.Stanovnik.Id == 0)
            {
                DTOManager.DodajStanovnika(this.Stanovnik);
            }
            else
            {
                DTOManager.AzurirajStanovnika(this.Stanovnik);
            }

            MessageBox.Show("Podaci su uspešno sačuvani!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}