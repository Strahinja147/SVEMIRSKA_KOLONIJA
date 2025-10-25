using SvemirskaKolonija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVEMIRSKA_KOLONIJA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrikaziStanovnike_Click(object sender, EventArgs e)
        {
            // 1. Obriši prethodne stavke iz liste (ako ih ima)
            this.listView1.Items.Clear();

            // 2. Pozovi metodu iz DTOManager-a
            List<SvemirskaKolonija.DTOs.StanovnikPregled> stanovnici = DTOManager.VratiSveStanovnike();

            // 3. Prođi kroz dobijenu listu i dodaj svaki DTO kao red u ListView
            foreach (var st in stanovnici)
            {
                ListViewItem item = new ListViewItem(new string[] { st.Id.ToString(), st.Ime, st.Prezime, st.Zanimanje });
                this.listView1.Items.Add(item);
            }

            // 4. (Opciono) Automatski podesi širinu kolona
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            MessageBox.Show("Podaci o stanovnicima su uspešno učitani!");
        }
    }
}
