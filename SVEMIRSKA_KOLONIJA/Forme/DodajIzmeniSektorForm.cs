using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class DodajIzmeniSektorForm : Form
    {
        private SektorDetalji sektorZaObradu;

        public DodajIzmeniSektorForm(int? sektorId)
        {
            InitializeComponent();

            if (sektorId.HasValue)
            {
                this.Text = "Izmena Sektora";
                sektorZaObradu = DTOManager.VratiSektorDetalji(sektorId.Value);
            }
            else
            {
                this.Text = "Dodavanje Novog Sektora";
                sektorZaObradu = new SektorDetalji();
                btnDodeliRadnika.Enabled = false;
            }
        }

        private void DodajIzmeniSektorForm_Load(object sender, EventArgs e)
        {
            if (sektorZaObradu.Id != 0)
            {
                PopuniPodatke();
            }
        }

        private void PopuniPodatke()
        {
            txtNaziv.Text = sektorZaObradu.Naziv;
            txtTipSektora.Text = sektorZaObradu.TipSektora;
            txtKapacitet.Text = sektorZaObradu.Kapacitet.ToString();
            txtPovrsina.Text = sektorZaObradu.Povrsina.ToString();

            if (sektorZaObradu.VodjaSektora != null)
            {
                txtVodjaSektora.Text = $"{sektorZaObradu.VodjaSektora.Ime} {sektorZaObradu.VodjaSektora.Prezime}";
            }

            PopuniListuRadnika();
        }

        private void PopuniListuRadnika()
        {
            lvRadnici.Items.Clear();

            if (sektorZaObradu.Radnici == null) return;

            foreach (var radnik in sektorZaObradu.Radnici)
            {
                ListViewItem item = new ListViewItem(new string[] { radnik.Id.ToString(), radnik.Ime, radnik.Prezime });
                item.Tag = radnik;
                lvRadnici.Items.Add(item);
            }
            lvRadnici.Refresh();
        }

        private void btnDodeliVodju_Click(object sender, EventArgs e)
        {
            IzaberiStanovnikaForm formaZaIzbor = new IzaberiStanovnikaForm();
            DialogResult rezultat = formaZaIzbor.ShowDialog();

            if (rezultat == DialogResult.OK)
            {
                sektorZaObradu.VodjaSektora = formaZaIzbor.IzabraniStanovnik;
                txtVodjaSektora.Text = $"{sektorZaObradu.VodjaSektora.Ime} {sektorZaObradu.VodjaSektora.Prezime}";
            }
        }

        private void btnDodeliRadnika_Click(object sender, EventArgs e)
        {
            IzaberiStanovnikaForm formaZaIzbor = new IzaberiStanovnikaForm();
            if (formaZaIzbor.ShowDialog() == DialogResult.OK)
            {
                var izabraniRadnik = formaZaIzbor.IzabraniStanovnik;

                // ---- KLJUČNA IZMENA: PROVERA ----
                // Proveri da li sektor uopšte ima dodeljenog vođu
                if (this.sektorZaObradu.VodjaSektora != null)
                {
                    // Ako ima, proveri da li je ID izabranog radnika isti kao ID vođe
                    if (izabraniRadnik.Id == this.sektorZaObradu.VodjaSektora.Id)
                    {
                        MessageBox.Show("Ne možete dodeliti vođu sektora kao radnika.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Prekini dalje izvršavanje
                    }
                }

                // Provera da li je radnik već dodat (ovo ostaje od ranije)
                if (sektorZaObradu.Radnici.Any(r => r.Id == izabraniRadnik.Id))
                {
                    MessageBox.Show("Ovaj radnik je već dodeljen sektoru.");
                    return;
                }

                // Ako provere prođu, nastavi sa postojećom logikom
                bool uspeh = DTOManager.DodeliRadnikaSektoru(izabraniRadnik.Id, this.sektorZaObradu.Id);

                if (uspeh)
                {
                    this.sektorZaObradu.Radnici.Add(izabraniRadnik);
                    PopuniListuRadnika();
                    MessageBox.Show("Radnik uspešno dodeljen.");
                }
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Morate uneti naziv sektora!");
                return;
            }

            sektorZaObradu.Naziv = txtNaziv.Text;
            sektorZaObradu.TipSektora = txtTipSektora.Text;

            int.TryParse(txtKapacitet.Text, out int kapacitet);
            sektorZaObradu.Kapacitet = kapacitet;

            double.TryParse(txtPovrsina.Text, out double povrsina);
            sektorZaObradu.Povrsina = povrsina;

            if (sektorZaObradu.Id == 0)
            {
                DTOManager.DodajSektor(this.sektorZaObradu);
                MessageBox.Show("Uspešno ste dodali novi sektor!");
            }
            else
            {
                DTOManager.AzurirajSektor(this.sektorZaObradu);
                MessageBox.Show("Uspešno ste ažurirali podatke o sektoru!");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUkloniRadnika_Click(object sender, EventArgs e)
        {
            if (lvRadnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati radnika kojeg želite da uklonite!");
                return;
            }

            var izabraniRadnik = (StanovnikPregled)lvRadnici.SelectedItems[0].Tag;

            string poruka = $"Da li ste sigurni da želite da uklonite radnika '{izabraniRadnik.Ime} {izabraniRadnik.Prezime}' iz ovog sektora?";
            if (MessageBox.Show(poruka, "Potvrda uklanjanja", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DTOManager.UkloniRadnikaIzSektora(izabraniRadnik.Id, this.sektorZaObradu.Id);

                // Ažuriraj lokalne podatke i UI bez ponovnog odlaska u bazu
                var radnikZaUklanjanje = this.sektorZaObradu.Radnici.FirstOrDefault(r => r.Id == izabraniRadnik.Id);
                if (radnikZaUklanjanje != null)
                {
                    this.sektorZaObradu.Radnici.Remove(radnikZaUklanjanje);
                }

                PopuniListuRadnika();
                MessageBox.Show("Radnik uspešno uklonjen iz sektora.");
            }
        }
    }
}