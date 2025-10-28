using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class DodajIzmeniRobotaForm : Form
    {
        private RobotDetalji robotZaObradu;

        public DodajIzmeniRobotaForm(int? robotId)
        {
            InitializeComponent();

            if (robotId.HasValue)
            {
                this.Text = "Izmena Robota";
                robotZaObradu = DTOManager.VratiRobotaDetalji(robotId.Value);
            }
            else
            {
                this.Text = "Dodavanje Novog Robota";
                robotZaObradu = new RobotDetalji();
            }
        }

        private void DodajIzmeniRobotForm_Load(object sender, EventArgs e)
        {
            PopuniComboBoxSektorima();

            if (robotZaObradu.Id != 0)
            {
                PopuniPodatke();
            }
        }

        private void PopuniComboBoxSektorima()
        {
            var sektori = DTOManager.VratiSveSektore();
            cmbSektor.DataSource = sektori;
            cmbSektor.DisplayMember = "Naziv";
            cmbSektor.ValueMember = "Id";
        }

        private void PopuniPodatke()
        {
            txtSifra.Text = robotZaObradu.Sifra;
            cmbTipRobota.Text = robotZaObradu.Tip;

            if (robotZaObradu.OdgovorniStanovnik != null)
            {
                txtOdgovorni.Text = $"{robotZaObradu.OdgovorniStanovnik.Ime} {robotZaObradu.OdgovorniStanovnik.Prezime}";
            }

            if (robotZaObradu.Programer != null)
            {
                txtProgramer.Text = $"{robotZaObradu.Programer.Ime} {robotZaObradu.Programer.Prezime}";
            }

            if (robotZaObradu.Sektor != null)
            {
                cmbSektor.SelectedValue = robotZaObradu.Sektor.Id;
            }
        }

        private void btnIzaberiOdgovornog_Click(object sender, EventArgs e)
        {
            IzaberiStanovnikaForm forma = new IzaberiStanovnikaForm();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                robotZaObradu.OdgovorniStanovnik = forma.IzabraniStanovnik;
                txtOdgovorni.Text = $"{forma.IzabraniStanovnik.Ime} {forma.IzabraniStanovnik.Prezime}";
            }
        }

        private void btnIzaberiProgramera_Click(object sender, EventArgs e)
        {
            IzaberiStanovnikaForm forma = new IzaberiStanovnikaForm();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                robotZaObradu.Programer = forma.IzabraniStanovnik;
                txtProgramer.Text = $"{forma.IzabraniStanovnik.Ime} {forma.IzabraniStanovnik.Prezime}";
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifra.Text))
            {
                MessageBox.Show("Morate uneti šifru robota!");
                return;
            }

            robotZaObradu.Sifra = txtSifra.Text;
            robotZaObradu.Tip = cmbTipRobota.Text;

            if (cmbSektor.SelectedItem != null)
            {
                robotZaObradu.Sektor = (SektorPregled)cmbSektor.SelectedItem;
            }
            else
            {
                robotZaObradu.Sektor = null;
            }

            if (robotZaObradu.Id == 0)
            {
                DTOManager.DodajRobota(robotZaObradu);
                MessageBox.Show("Uspešno ste dodali novog robota!");
            }
            else
            {
                DTOManager.AzurirajRobota(robotZaObradu);
                MessageBox.Show("Uspešno ste ažurirali podatke o robotu!");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}