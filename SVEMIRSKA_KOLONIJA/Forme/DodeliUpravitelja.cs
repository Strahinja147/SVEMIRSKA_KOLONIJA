using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SVEMIRSKA_KOLONIJA.DTOs;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class OdabirStanovnikaForm : Form
    {
        public StanovnikPregled OdabraniStanovnik { get; private set; }

        /// <summary>
        /// Konstruktor sada prima listu stanovnika koji SU VEĆ upravitelji,
        /// kako bi ih forma sama izbacila iz prikaza.
        /// </summary>
        public OdabirStanovnikaForm(List<StanovnikPregled> postojeciUpravitelji)
        {
            InitializeComponent();
            this.OdabraniStanovnik = null;

            // --- Logika za filtriranje je SADA UNUTAR OVE FORME ---

            // 1. Učitavamo SVE stanovnike iz baze
            List<StanovnikPregled> sviStanovnici = DTOManager.VratiSveStanovnike();

            // 2. Pravimo set ID-jeva postojećih upravitelja radi brze pretrage
            HashSet<int> postojeciUpraviteljiId = new HashSet<int>(postojeciUpravitelji.Select(u => u.Id));

            // 3. Filtriramo listu - uzimamo samo one čiji ID nije u setu postojećih
            List<StanovnikPregled> dostupniStanovnici = sviStanovnici
                .Where(s => !postojeciUpraviteljiId.Contains(s.Id))
                .ToList();

            // 4. Prikazujemo filtriranu listu
            var prikazListe = dostupniStanovnici.Select(s => new
            {
                PraviStanovnik = s,
                PrikazTekst = $"{s.Ime} {s.Prezime} - {s.Zanimanje}"
            }).ToList();

            lbStanovnici.DataSource = prikazListe;
            lbStanovnici.DisplayMember = "PrikazTekst";
            lbStanovnici.ValueMember = "PraviStanovnik";
        }

        private void btnOdaberi_Click(object sender, EventArgs e)
        {
            if (lbStanovnici.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati stanovnika iz liste.", "Obaveštenje");
                return;
            }

            dynamic selektovaniItem = lbStanovnici.SelectedItem;
            this.OdabraniStanovnik = selektovaniItem.PraviStanovnik;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}