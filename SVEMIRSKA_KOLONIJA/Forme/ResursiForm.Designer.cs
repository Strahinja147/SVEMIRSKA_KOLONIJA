namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class ResursiForm
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
            this.lvResursi = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Naziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrenutnaKolicina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDodajResurs = new System.Windows.Forms.Button();
            this.btnIzmeniResurs = new System.Windows.Forms.Button();
            this.btnObrisiResurs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvResursi
            // 
            this.lvResursi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Naziv,
            this.TrenutnaKolicina});
            this.lvResursi.FullRowSelect = true;
            this.lvResursi.GridLines = true;
            this.lvResursi.HideSelection = false;
            this.lvResursi.Location = new System.Drawing.Point(12, 12);
            this.lvResursi.MultiSelect = false;
            this.lvResursi.Name = "lvResursi";
            this.lvResursi.Scrollable = false;
            this.lvResursi.Size = new System.Drawing.Size(373, 369);
            this.lvResursi.TabIndex = 0;
            this.lvResursi.UseCompatibleStateImageBehavior = false;
            this.lvResursi.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Naziv
            // 
            this.Naziv.Text = "Naziv";
            this.Naziv.Width = 100;
            // 
            // TrenutnaKolicina
            // 
            this.TrenutnaKolicina.Text = "Trenutna kolicina";
            this.TrenutnaKolicina.Width = 120;
            // 
            // btnDodajResurs
            // 
            this.btnDodajResurs.Location = new System.Drawing.Point(412, 12);
            this.btnDodajResurs.Name = "btnDodajResurs";
            this.btnDodajResurs.Size = new System.Drawing.Size(170, 106);
            this.btnDodajResurs.TabIndex = 1;
            this.btnDodajResurs.Text = "Dodaj resurs";
            this.btnDodajResurs.UseVisualStyleBackColor = true;
            this.btnDodajResurs.Click += new System.EventHandler(this.btnDodajResurs_Click);
            // 
            // btnIzmeniResurs
            // 
            this.btnIzmeniResurs.Location = new System.Drawing.Point(412, 144);
            this.btnIzmeniResurs.Name = "btnIzmeniResurs";
            this.btnIzmeniResurs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnIzmeniResurs.Size = new System.Drawing.Size(170, 106);
            this.btnIzmeniResurs.TabIndex = 2;
            this.btnIzmeniResurs.Text = "Izmeni resurs";
            this.btnIzmeniResurs.UseVisualStyleBackColor = true;
            this.btnIzmeniResurs.Click += new System.EventHandler(this.btnIzmeniResurs_Click);
            // 
            // btnObrisiResurs
            // 
            this.btnObrisiResurs.Location = new System.Drawing.Point(412, 275);
            this.btnObrisiResurs.Name = "btnObrisiResurs";
            this.btnObrisiResurs.Size = new System.Drawing.Size(170, 106);
            this.btnObrisiResurs.TabIndex = 3;
            this.btnObrisiResurs.Text = "Obrisi resurs";
            this.btnObrisiResurs.UseVisualStyleBackColor = true;
            this.btnObrisiResurs.Click += new System.EventHandler(this.btnObrisiResurs_Click);
            // 
            // ResursiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 399);
            this.Controls.Add(this.btnObrisiResurs);
            this.Controls.Add(this.btnIzmeniResurs);
            this.Controls.Add(this.btnDodajResurs);
            this.Controls.Add(this.lvResursi);
            this.Name = "ResursiForm";
            this.Text = "ResursiForm";
            this.Load += new System.EventHandler(this.ResursiForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvResursi;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Naziv;
        private System.Windows.Forms.ColumnHeader TrenutnaKolicina;
        private System.Windows.Forms.Button btnDodajResurs;
        private System.Windows.Forms.Button btnIzmeniResurs;
        private System.Windows.Forms.Button btnObrisiResurs;
    }
}