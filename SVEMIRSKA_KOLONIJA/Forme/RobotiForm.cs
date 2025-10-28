using SVEMIRSKA_KOLONIJA.DTOs;
using System;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA.Forme
{
    public partial class RobotiForm : Form
    {
        public RobotiForm()
        {
            InitializeComponent();
        }

        private void RobotiForm_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            lvRoboti.Items.Clear();
            var roboti = DTOManager.VratiSveRobote();

            foreach (var robot in roboti)
            {
                ListViewItem item = new ListViewItem(new string[] { robot.Id.ToString(), robot.Sifra, robot.Tip });
                item.Tag = robot;
                lvRoboti.Items.Add(item);
            }
            lvRoboti.Refresh();
        }

        private void btnDodajRobota_Click(object sender, EventArgs e)
        {
            DodajIzmeniRobotaForm form = new DodajIzmeniRobotaForm(null);
            form.ShowDialog();
            this.PopuniPodacima();
        }

        private void btnIzmeniRobota_Click(object sender, EventArgs e)
        {
            if (lvRoboti.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite robota kojeg želite da izmenite!");
                return;
            }

            var izabraniRobot = (RobotPregled)lvRoboti.SelectedItems[0].Tag;
            DodajIzmeniRobotaForm form = new DodajIzmeniRobotaForm(izabraniRobot.Id);
            form.ShowDialog();
            this.PopuniPodacima();
        }

        private void btnObrisiRobota_Click(object sender, EventArgs e)
        {
            if (lvRoboti.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite robota kojeg želite da obrišete!");
                return;
            }

            var izabraniRobot = (RobotPregled)lvRoboti.SelectedItems[0].Tag;
            string poruka = $"Da li ste sigurni da želite da obrišete robota sa šifrom '{izabraniRobot.Sifra}'?";
            DialogResult dr = MessageBox.Show(poruka, "Potvrda brisanja", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                DTOManager.ObrisiRobota(izabraniRobot.Id);
                MessageBox.Show("Robot uspešno obrisan!");
                this.PopuniPodacima();
            }
        }
    }
}