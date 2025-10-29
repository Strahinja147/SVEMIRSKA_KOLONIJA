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
    public partial class ResursiForm : Form
    {
        public ResursiForm()
        {
            InitializeComponent();
        }

        private void ResursiForm_Load(object sender, EventArgs e)
        {
            this.PopuniPodacima();
        }

        private void PopuniPodacima()
        {
            this.lvResursi.Items.Clear();
            List<ResursPregled> resursi = DTOManager.VratiSveResurse().OrderBy(s=>s.Id).ToList();

            foreach (ResursPregled r in resursi)
            {
                ListViewItem item = new ListViewItem(new string[] { r.Id.ToString(), r.Naziv, r.TrenutnaKolicina.ToString() });
                this.lvResursi.Items.Add(item);
            }

            this.lvResursi.Refresh();
        }

        private void btnDodajResurs_Click(object sender, EventArgs e)
        {
            DodajIzmeniResursForm form = new DodajIzmeniResursForm();
            form.ShowDialog();
            this.PopuniPodacima();
        }

        private void btnIzmeniResurs_Click(object sender, EventArgs e)
        {
            if (lvResursi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite resurs koji želite da izmenite!", "Obaveštenje");
                return;
            }

            int idResursa = Int32.Parse(lvResursi.SelectedItems[0].SubItems[0].Text);
            DodajIzmeniResursForm form = new DodajIzmeniResursForm(idResursa);
            form.ShowDialog();
            this.PopuniPodacima();
        }

        private void btnObrisiResurs_Click(object sender, EventArgs e)
        {
            if (lvResursi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite resurs koji želite da obrišete!", "Obaveštenje");
                return;
            }

            int idResursa = Int32.Parse(lvResursi.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li ste sigurni da želite da obrišete izabrani resurs?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiResurs(idResursa);
                MessageBox.Show("Resurs je uspešno obrisan!", "Obaveštenje");
                this.PopuniPodacima();
            }
        }
    }
}