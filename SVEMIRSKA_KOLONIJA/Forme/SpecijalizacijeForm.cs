using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class SpecijalizacijeForm : Form
    {
        public SpecijalizacijeForm()
        {
            InitializeComponent();
        }

        private void SpecijalizacijeForm_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        private void PopuniPodacima()
        {
            lvSpecijalizacije.Items.Clear();
            var specijalizacije = DTOManager.VratiSveSpecijalizacije().OrderBy(s => s.Id).ToList();

            foreach (var s in specijalizacije)
            {
                ListViewItem item = new ListViewItem(new string[] { s.Id.ToString(), s.Naziv });
                item.Tag = s;
                lvSpecijalizacije.Items.Add(item);
            }
            lvSpecijalizacije.Refresh();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            DodajIzmeniSpecijalizacijuForm form = new DodajIzmeniSpecijalizacijuForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                PopuniPodacima();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (lvSpecijalizacije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati specijalizaciju za izmenu!");
                return;
            }

            var izabrana = (SpecijalizacijaPregled)lvSpecijalizacije.SelectedItems[0].Tag;
            DodajIzmeniSpecijalizacijuForm form = new DodajIzmeniSpecijalizacijuForm(izabrana);
            if (form.ShowDialog() == DialogResult.OK)
            {
                PopuniPodacima();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (lvSpecijalizacije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati specijalizaciju za brisanje!");
                return;
            }

            var izabrana = (SpecijalizacijaPregled)lvSpecijalizacije.SelectedItems[0].Tag;
            string poruka = $"Da li ste sigurni da želite da obrišete specijalizaciju '{izabrana.Naziv}'?";

            if (MessageBox.Show(poruka, "Potvrda brisanja", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DTOManager.ObrisiSpecijalizaciju(izabrana.Id);
                PopuniPodacima();
            }
        }
    }
}