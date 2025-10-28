using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class DodajIzmeniSpecijalizacijuForm : Form
    {
        private SpecijalizacijaPregled specijalizacija;

        public DodajIzmeniSpecijalizacijuForm(SpecijalizacijaPregled spec = null)
        {
            InitializeComponent();
            this.specijalizacija = spec;
        }

        private void DodajIzmeniSpecijalizacijuForm_Load(object sender, EventArgs e)
        {
            if (this.specijalizacija != null)
            {
                this.Text = "Izmeni Specijalizaciju";
                txtNaziv.Text = this.specijalizacija.Naziv;
            }
            else
            {
                this.Text = "Dodaj Novu Specijalizaciju";
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Morate uneti naziv!");
                return;
            }

            if (this.specijalizacija == null)
            {
                var novaSpecijalizacija = new SpecijalizacijaPregled { Naziv = txtNaziv.Text };
                DTOManager.DodajSpecijalizaciju(novaSpecijalizacija);
            }
            else
            {
                this.specijalizacija.Naziv = txtNaziv.Text;
                DTOManager.AzurirajSpecijalizaciju(this.specijalizacija);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}