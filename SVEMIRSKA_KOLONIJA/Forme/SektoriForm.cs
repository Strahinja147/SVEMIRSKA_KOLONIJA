using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class SektoriForm : Form
    {
        public SektoriForm()
        {
            InitializeComponent();
        }

        private void SektoriForm_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            lvSektori.Items.Clear();
            var sektori = DTOManager.VratiSveSektore().OrderBy(s=>s.Id).ToList();

            foreach (var sektor in sektori)
            {
                ListViewItem item = new ListViewItem(new string[] { sektor.Id.ToString(), sektor.Naziv, sektor.TipSektora });
                item.Tag = sektor;
                lvSektori.Items.Add(item);
            }
            lvSektori.Refresh();
        }

        private void btnDodajSektor_Click(object sender, EventArgs e)
        {
            DodajIzmeniSektorForm form = new DodajIzmeniSektorForm(null);
            form.ShowDialog();
            this.PopuniPodacima();
        }

        private void btnIzmeniSektor_Click(object sender, EventArgs e)
        {
            if (lvSektori.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sektor koji želite da izmenite!");
                return;
            }

            var izabraniSektor = (SektorPregled)lvSektori.SelectedItems[0].Tag;
            DodajIzmeniSektorForm form = new DodajIzmeniSektorForm(izabraniSektor.Id);
            form.ShowDialog();
            this.PopuniPodacima();
        }

        private void btnObrisiSektor_Click(object sender, EventArgs e)
        {
            if (lvSektori.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sektor koji želite da obrišete!");
                return;
            }

            var izabraniSektor = (SektorPregled)lvSektori.SelectedItems[0].Tag;
            string poruka = $"Da li ste sigurni da želite da obrišete sektor '{izabraniSektor.Naziv}'?";
            DialogResult dr = MessageBox.Show(poruka, "Potvrda brisanja", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                
                bool validnoObrisan = DTOManager.ObrisiSektor(izabraniSektor.Id);
                if (validnoObrisan)
                {
                    MessageBox.Show("Sektor uspešno obrisan!");
                    this.PopuniPodacima();
                }
            }
        }
    }
}