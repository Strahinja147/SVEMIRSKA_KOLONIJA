namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class DodajIzmeniResursForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.numKolicina = new System.Windows.Forms.NumericUpDown();
            this.cbxSkladiste = new System.Windows.Forms.ComboBox();
            this.lvUpravitelji = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnDodeliUpravitelja = new System.Windows.Forms.Button();
            this.lblUpravitelji = new System.Windows.Forms.Label();
            this.btnUkloniUpravitelja = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numKolicina)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trenutna količina:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sektor:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(188, 41);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(192, 22);
            this.txtNaziv.TabIndex = 3;
            // 
            // numKolicina
            // 
            this.numKolicina.Location = new System.Drawing.Point(188, 104);
            this.numKolicina.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numKolicina.Name = "numKolicina";
            this.numKolicina.Size = new System.Drawing.Size(192, 22);
            this.numKolicina.TabIndex = 4;
            // 
            // cbxSkladiste
            // 
            this.cbxSkladiste.FormattingEnabled = true;
            this.cbxSkladiste.Location = new System.Drawing.Point(188, 172);
            this.cbxSkladiste.Name = "cbxSkladiste";
            this.cbxSkladiste.Size = new System.Drawing.Size(192, 24);
            this.cbxSkladiste.TabIndex = 5;
            // 
            // lvUpravitelji
            // 
            this.lvUpravitelji.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Ime,
            this.Prezime});
            this.lvUpravitelji.FullRowSelect = true;
            this.lvUpravitelji.GridLines = true;
            this.lvUpravitelji.HideSelection = false;
            this.lvUpravitelji.Location = new System.Drawing.Point(15, 276);
            this.lvUpravitelji.MultiSelect = false;
            this.lvUpravitelji.Name = "lvUpravitelji";
            this.lvUpravitelji.Scrollable = false;
            this.lvUpravitelji.Size = new System.Drawing.Size(365, 245);
            this.lvUpravitelji.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvUpravitelji.TabIndex = 7;
            this.lvUpravitelji.UseCompatibleStateImageBehavior = false;
            this.lvUpravitelji.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Ime
            // 
            this.Ime.Text = "Ime";
            this.Ime.Width = 114;
            // 
            // Prezime
            // 
            this.Prezime.Text = "Prezime";
            this.Prezime.Width = 143;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(401, 451);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(150, 70);
            this.btnSacuvaj.TabIndex = 8;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnDodeliUpravitelja
            // 
            this.btnDodeliUpravitelja.Location = new System.Drawing.Point(401, 276);
            this.btnDodeliUpravitelja.Name = "btnDodeliUpravitelja";
            this.btnDodeliUpravitelja.Size = new System.Drawing.Size(150, 70);
            this.btnDodeliUpravitelja.TabIndex = 9;
            this.btnDodeliUpravitelja.Text = "Dodeli upravitelja";
            this.btnDodeliUpravitelja.UseVisualStyleBackColor = true;
            this.btnDodeliUpravitelja.Click += new System.EventHandler(this.btnDodeliUpravitelja_Click);
            // 
            // lblUpravitelji
            // 
            this.lblUpravitelji.AutoSize = true;
            this.lblUpravitelji.Location = new System.Drawing.Point(17, 236);
            this.lblUpravitelji.Name = "lblUpravitelji";
            this.lblUpravitelji.Size = new System.Drawing.Size(118, 16);
            this.lblUpravitelji.TabIndex = 10;
            this.lblUpravitelji.Text = "Upravitelji resursa:";
            // 
            // btnUkloniUpravitelja
            // 
            this.btnUkloniUpravitelja.Location = new System.Drawing.Point(401, 364);
            this.btnUkloniUpravitelja.Name = "btnUkloniUpravitelja";
            this.btnUkloniUpravitelja.Size = new System.Drawing.Size(150, 70);
            this.btnUkloniUpravitelja.TabIndex = 11;
            this.btnUkloniUpravitelja.Text = "Ukloni upravitelja";
            this.btnUkloniUpravitelja.UseVisualStyleBackColor = true;
            this.btnUkloniUpravitelja.Click += new System.EventHandler(this.btnUkloniUpravitelja_Click);
            // 
            // DodajIzmeniResursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 567);
            this.Controls.Add(this.btnUkloniUpravitelja);
            this.Controls.Add(this.lblUpravitelji);
            this.Controls.Add(this.lvUpravitelji);
            this.Controls.Add(this.btnDodeliUpravitelja);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cbxSkladiste);
            this.Controls.Add(this.numKolicina);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DodajIzmeniResursForm";
            this.Text = "DodajIzmeniResursForm";
            ((System.ComponentModel.ISupportInitialize)(this.numKolicina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.NumericUpDown numKolicina;
        private System.Windows.Forms.ComboBox cbxSkladiste;
        private System.Windows.Forms.ListView lvUpravitelji;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Ime;
        private System.Windows.Forms.ColumnHeader Prezime;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnDodeliUpravitelja;
        private System.Windows.Forms.Label lblUpravitelji;
        private System.Windows.Forms.Button btnUkloniUpravitelja;
    }
}