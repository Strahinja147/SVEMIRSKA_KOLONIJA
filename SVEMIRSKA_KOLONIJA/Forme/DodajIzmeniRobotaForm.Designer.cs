namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class DodajIzmeniRobotaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSifra = new System.Windows.Forms.Label();
            this.labelTip = new System.Windows.Forms.Label();
            this.labelOdgovorni = new System.Windows.Forms.Label();
            this.labelProgramer = new System.Windows.Forms.Label();
            this.labelSektor = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.txtOdgovorni = new System.Windows.Forms.TextBox();
            this.txtProgramer = new System.Windows.Forms.TextBox();
            this.cmbSektor = new System.Windows.Forms.ComboBox();
            this.btnIzaberiOdgovornog = new System.Windows.Forms.Button();
            this.btnIzaberiProgramera = new System.Windows.Forms.Button();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.cmbTipRobota = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelSifra
            // 
            this.labelSifra.AutoSize = true;
            this.labelSifra.Location = new System.Drawing.Point(12, 50);
            this.labelSifra.Name = "labelSifra";
            this.labelSifra.Size = new System.Drawing.Size(31, 13);
            this.labelSifra.TabIndex = 0;
            this.labelSifra.Text = "Šifra:";
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Location = new System.Drawing.Point(12, 83);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(25, 13);
            this.labelTip.TabIndex = 1;
            this.labelTip.Text = "Tip:";
            // 
            // labelOdgovorni
            // 
            this.labelOdgovorni.AutoSize = true;
            this.labelOdgovorni.Location = new System.Drawing.Point(12, 115);
            this.labelOdgovorni.Name = "labelOdgovorni";
            this.labelOdgovorni.Size = new System.Drawing.Size(108, 13);
            this.labelOdgovorni.TabIndex = 2;
            this.labelOdgovorni.Text = "Odgovorni stanovnik:";
            // 
            // labelProgramer
            // 
            this.labelProgramer.AutoSize = true;
            this.labelProgramer.Location = new System.Drawing.Point(12, 145);
            this.labelProgramer.Name = "labelProgramer";
            this.labelProgramer.Size = new System.Drawing.Size(58, 13);
            this.labelProgramer.TabIndex = 3;
            this.labelProgramer.Text = "Programer:";
            // 
            // labelSektor
            // 
            this.labelSektor.AutoSize = true;
            this.labelSektor.Location = new System.Drawing.Point(12, 177);
            this.labelSektor.Name = "labelSektor";
            this.labelSektor.Size = new System.Drawing.Size(41, 13);
            this.labelSektor.TabIndex = 4;
            this.labelSektor.Text = "Sektor:";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(146, 47);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(170, 20);
            this.txtSifra.TabIndex = 5;
            // 
            // txtOdgovorni
            // 
            this.txtOdgovorni.Location = new System.Drawing.Point(146, 112);
            this.txtOdgovorni.Name = "txtOdgovorni";
            this.txtOdgovorni.Size = new System.Drawing.Size(170, 20);
            this.txtOdgovorni.TabIndex = 7;
            // 
            // txtProgramer
            // 
            this.txtProgramer.Location = new System.Drawing.Point(146, 142);
            this.txtProgramer.Name = "txtProgramer";
            this.txtProgramer.Size = new System.Drawing.Size(170, 20);
            this.txtProgramer.TabIndex = 8;
            // 
            // cmbSektor
            // 
            this.cmbSektor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSektor.FormattingEnabled = true;
            this.cmbSektor.Location = new System.Drawing.Point(146, 174);
            this.cmbSektor.Name = "cmbSektor";
            this.cmbSektor.Size = new System.Drawing.Size(170, 21);
            this.cmbSektor.TabIndex = 9;
            // 
            // btnIzaberiOdgovornog
            // 
            this.btnIzaberiOdgovornog.Location = new System.Drawing.Point(338, 109);
            this.btnIzaberiOdgovornog.Name = "btnIzaberiOdgovornog";
            this.btnIzaberiOdgovornog.Size = new System.Drawing.Size(130, 24);
            this.btnIzaberiOdgovornog.TabIndex = 11;
            this.btnIzaberiOdgovornog.Text = "Izaberi odgovornog...";
            this.btnIzaberiOdgovornog.UseVisualStyleBackColor = true;
            this.btnIzaberiOdgovornog.Click += new System.EventHandler(this.btnIzaberiOdgovornog_Click);
            // 
            // btnIzaberiProgramera
            // 
            this.btnIzaberiProgramera.Location = new System.Drawing.Point(338, 139);
            this.btnIzaberiProgramera.Name = "btnIzaberiProgramera";
            this.btnIzaberiProgramera.Size = new System.Drawing.Size(130, 24);
            this.btnIzaberiProgramera.TabIndex = 12;
            this.btnIzaberiProgramera.Text = "Izaberi programera...";
            this.btnIzaberiProgramera.UseVisualStyleBackColor = true;
            this.btnIzaberiProgramera.Click += new System.EventHandler(this.btnIzaberiProgramera_Click);
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(169, 214);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(111, 49);
            this.btnSnimi.TabIndex = 13;
            this.btnSnimi.Text = "Sačuvaj";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // cmbTipRobota
            // 
            this.cmbTipRobota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipRobota.FormattingEnabled = true;
            this.cmbTipRobota.Items.AddRange(new object[] {
            "Transportni",
            "Inženjerski",
            "Medicinski",
            "Nadzorni"});
            this.cmbTipRobota.Location = new System.Drawing.Point(146, 80);
            this.cmbTipRobota.Name = "cmbTipRobota";
            this.cmbTipRobota.Size = new System.Drawing.Size(170, 21);
            this.cmbTipRobota.TabIndex = 14;
            // 
            // DodajIzmeniRobotaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 284);
            this.Controls.Add(this.cmbTipRobota);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.btnIzaberiProgramera);
            this.Controls.Add(this.btnIzaberiOdgovornog);
            this.Controls.Add(this.cmbSektor);
            this.Controls.Add(this.txtProgramer);
            this.Controls.Add(this.txtOdgovorni);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.labelSektor);
            this.Controls.Add(this.labelProgramer);
            this.Controls.Add(this.labelOdgovorni);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.labelSifra);
            this.Name = "DodajIzmeniRobotaForm";
            this.Text = "DodajIzmeniRobotaForm";
            this.Load += new System.EventHandler(this.DodajIzmeniRobotForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSifra;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.Label labelOdgovorni;
        private System.Windows.Forms.Label labelProgramer;
        private System.Windows.Forms.Label labelSektor;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.TextBox txtOdgovorni;
        private System.Windows.Forms.TextBox txtProgramer;
        private System.Windows.Forms.ComboBox cmbSektor;
        private System.Windows.Forms.Button btnIzaberiOdgovornog;
        private System.Windows.Forms.Button btnIzaberiProgramera;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.ComboBox cmbTipRobota;
    }
}