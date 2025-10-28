using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class DodajKontaktForm : Form
    {
        public KontaktNaZemljiPregled NoviKontakt { get; private set; }

        public DodajKontaktForm()
        {
            InitializeComponent();
        }

        private void btnDodajInfo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtKontaktInfo.Text))
            {
                lbKontaktInformacije.Items.Add(txtKontaktInfo.Text);
                txtKontaktInfo.Clear();
                txtKontaktInfo.Focus();
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text) || string.IsNullOrWhiteSpace(txtOdnos.Text))
            {
                MessageBox.Show("Morate uneti ime i odnos kontakta!");
                return;
            }

            this.NoviKontakt = new KontaktNaZemljiPregled
            {
                Ime = txtIme.Text,
                Odnos = txtOdnos.Text,
                KontaktInformacije = new List<string>()
            };

            foreach (var item in lbKontaktInformacije.Items)
            {
                this.NoviKontakt.KontaktInformacije.Add(item.ToString());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}