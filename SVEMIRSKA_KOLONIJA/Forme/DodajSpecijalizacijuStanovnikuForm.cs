using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class DodajSpecijalizacijuStanovnikuForm : Form
    {
        public PosedujePregled NovaSpecijalizacija { get; private set; }

        public DodajSpecijalizacijuStanovnikuForm()
        {
            InitializeComponent();
        }

        private void DodajSpecijalizacijuStanovnikuForm_Load(object sender, EventArgs e)
        {
            PopuniSpecijalizacije();
        }

        private void PopuniSpecijalizacije()
        {
            var specijalizacije = DTOManager.VratiSveSpecijalizacije();
            cmbSpecijalizacija.DataSource = specijalizacije;
            cmbSpecijalizacija.DisplayMember = "Naziv";
            cmbSpecijalizacija.ValueMember = "Id";
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (cmbSpecijalizacija.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati specijalizaciju!");
                return;
            }

            var izabranaSpecijalizacija = (SpecijalizacijaPregled)cmbSpecijalizacija.SelectedItem;

            this.NovaSpecijalizacija = new PosedujePregled
            {
                Specijalizacija = izabranaSpecijalizacija,
                // ---- KLJUČNA ISPRAVKA ----
                NazivSpecijalizacije = izabranaSpecijalizacija.Naziv,
                NivoEkspertize = txtNivoEkspertize.Text,
                DatumSticanja = dtpDatumSticanja.Value,
                Institucija = txtInstitucija.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}