namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class IzaberiStanovnikaForm
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
            this.lvStanovnici = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnIzaberi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvStanovnici
            // 
            this.lvStanovnici.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Ime,
            this.Prezime});
            this.lvStanovnici.FullRowSelect = true;
            this.lvStanovnici.GridLines = true;
            this.lvStanovnici.HideSelection = false;
            this.lvStanovnici.Location = new System.Drawing.Point(12, 12);
            this.lvStanovnici.Name = "lvStanovnici";
            this.lvStanovnici.Size = new System.Drawing.Size(296, 327);
            this.lvStanovnici.TabIndex = 0;
            this.lvStanovnici.UseCompatibleStateImageBehavior = false;
            this.lvStanovnici.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // Ime
            // 
            this.Ime.Text = "Ime";
            this.Ime.Width = 120;
            // 
            // Prezime
            // 
            this.Prezime.Text = "Prezime";
            this.Prezime.Width = 120;
            // 
            // btnIzaberi
            // 
            this.btnIzaberi.Location = new System.Drawing.Point(392, 12);
            this.btnIzaberi.Name = "btnIzaberi";
            this.btnIzaberi.Size = new System.Drawing.Size(107, 59);
            this.btnIzaberi.TabIndex = 1;
            this.btnIzaberi.Text = "Izaberi";
            this.btnIzaberi.UseVisualStyleBackColor = true;
            this.btnIzaberi.Click += new System.EventHandler(this.btnIzaberi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(392, 91);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(107, 59);
            this.btnOdustani.TabIndex = 2;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // IzaberiStanovnikaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 450);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnIzaberi);
            this.Controls.Add(this.lvStanovnici);
            this.Name = "IzaberiStanovnikaForm";
            this.Text = "IzaberiStanovnikaForm";
            this.Load += new System.EventHandler(this.IzaberiStanovnikaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvStanovnici;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Ime;
        private System.Windows.Forms.ColumnHeader Prezime;
        private System.Windows.Forms.Button btnIzaberi;
        private System.Windows.Forms.Button btnOdustani;
    }
}