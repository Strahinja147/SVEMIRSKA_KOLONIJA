using SVEMIRSKA_KOLONIJA;
using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class StanovniciForm : Form
    {
        public StanovniciForm()
        {
            InitializeComponent();
        }

        // Učitavanje forme
        private void StanovniciForm_Load(object sender, EventArgs e)
        {
            this.Text = "STANOVNICI";
            // Inicijalizacija kolona u ListView
            listViewStanovnici.Columns.Add("ID", 50);
            listViewStanovnici.Columns.Add("Ime", 150);
            listViewStanovnici.Columns.Add("Prezime", 150);
            listViewStanovnici.Columns.Add("Zanimanje", 200);

            // Popunjavanje podataka
            UcitajPodatke();
        }

        public void UcitajPodatke()
        {
            listViewStanovnici.Items.Clear();
            List<StanovnikPregled> podaci = DTOManager.VratiSveStanovnike();

            foreach (StanovnikPregled sp in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { sp.Id.ToString(), sp.Ime, sp.Prezime, sp.Zanimanje });
                listViewStanovnici.Items.Add(item);
            }
            listViewStanovnici.Refresh();
        }

        private void btnDodajStanovnika_Click(object sender, EventArgs e)
        {
            DodajStanovnikaForm forma = new DodajStanovnikaForm();
            forma.ShowDialog();
            this.UcitajPodatke(); // Osveži podatke nakon zatvaranja forme
        }

        private void btnIzmeniStanovnika_Click(object sender, EventArgs e)
        {
            if (listViewStanovnici.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite stanovnika koga želite da izmenite!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idStanovnika = Int32.Parse(listViewStanovnici.SelectedItems[0].SubItems[0].Text);
            StanovnikDetalji stanovnik = DTOManager.VratiStanovnikaDetalji(idStanovnika);

            DodajStanovnikaForm forma = new DodajStanovnikaForm(stanovnik);
            forma.ShowDialog();
            this.UcitajPodatke();
        }

        private void btnObrisiStanovnika_Click(object sender, EventArgs e)
        {
            // Proveravamo da li je tačno JEDAN stanovnik izabran.
            if (listViewStanovnici.SelectedItems.Count != 1)
            {
                MessageBox.Show("Molimo izaberite tačno jednog stanovnika koga želite da obrišete.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Sada smo sigurni da radimo sa jednim izabranim.
            ListViewItem selectedItem = listViewStanovnici.SelectedItems[0];
            int idStanovnika = Int32.Parse(selectedItem.SubItems[0].Text);

            string poruka = $"Da li ste sigurni da želite da obrišete stanovnika: {selectedItem.SubItems[1].Text} {selectedItem.SubItems[2].Text}?";
            string title = "Potvrda brisanja";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiStanovnika(idStanovnika);
                this.UcitajPodatke(); // Osveži prikaz
            }
        }
    }
}