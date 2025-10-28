using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class DodajIzmeniSektorForm : Form
    {
        private SektorDetalji sektorZaObradu;
        private List<StanovnikPregled> privremeniRadnici;
        public DodajIzmeniSektorForm(int? sektorId)
        {
            InitializeComponent();

            if (sektorId.HasValue)
            {
                this.Text = "Izmena Sektora";
                sektorZaObradu = DTOManager.VratiSektorDetalji(sektorId.Value);
                privremeniRadnici = new List<StanovnikPregled>(sektorZaObradu.Radnici ?? new List<StanovnikPregled>());
            }
            else
            {
                this.Text = "Dodavanje Novog Sektora";
                privremeniRadnici = new List<StanovnikPregled>();
                sektorZaObradu = new SektorDetalji();
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
            cmbTipSektora.Text = sektorZaObradu.TipSektora;
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

            foreach (var radnik in privremeniRadnici)
            {
                ListViewItem item = new ListViewItem(new string[] { radnik.Id.ToString(), radnik.Ime, radnik.Prezime });
                item.Tag = radnik;
                lvRadnici.Items.Add(item);
            }
            lvRadnici.Sort();
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
            List<int> postojeciId = privremeniRadnici.Select(r => r.Id).ToList();
            if (sektorZaObradu.VodjaSektora != null)
                postojeciId.Add(sektorZaObradu.VodjaSektora.Id);

            IzaberiStanovnikaForm formaZaIzbor = new IzaberiStanovnikaForm(postojeciId);

            if (formaZaIzbor.ShowDialog() == DialogResult.OK)
            {
                var izabraniRadnik = formaZaIzbor.IzabraniStanovnik;

                if (sektorZaObradu.Id != 0)
                {
                    DTOManager.DodeliRadnikaSektoru(izabraniRadnik.Id, this.sektorZaObradu.Id);
                }

                privremeniRadnici.Add(izabraniRadnik);
                PopuniListuRadnika();
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
            sektorZaObradu.TipSektora = cmbTipSektora.Text;
            bool vrednostKap = int.TryParse(txtKapacitet.Text, out int kapacitet);
            if (vrednostKap == false || kapacitet < 0)
            {
                MessageBox.Show("Uneli ste losu vrednost za kapacitet!");
                return;
            }
            sektorZaObradu.Kapacitet = kapacitet;

            bool vrednostPov = double.TryParse(txtPovrsina.Text, out double povrsina);
            if (vrednostPov == false || povrsina < 0)
            {
                MessageBox.Show("Uneli ste losu vrednost za povrsinu!");
                return;
            }
            sektorZaObradu.Povrsina = povrsina;

            if (sektorZaObradu.Id == 0)
            {
                var sacuvaniSektor = DTOManager.DodajSektor(sektorZaObradu);

                if (sacuvaniSektor != null)
                {
                    foreach (var radnik in privremeniRadnici)
                    {
                        DTOManager.DodeliRadnikaSektoru(radnik.Id, sacuvaniSektor.Id);
                    }
                }
            }
            else
            {
                DTOManager.AzurirajSektor(sektorZaObradu);
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
                privremeniRadnici.Remove(izabraniRadnik);
                PopuniListuRadnika();
                MessageBox.Show("Radnik uspešno uklonjen iz sektora.");
            }
        }
    }
}