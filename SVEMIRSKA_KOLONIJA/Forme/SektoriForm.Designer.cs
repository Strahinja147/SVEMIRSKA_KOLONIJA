namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class SektoriForm
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
            this.lvSektori = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Naziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tipSektora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDodajSektor = new System.Windows.Forms.Button();
            this.btnIzmeniSektor = new System.Windows.Forms.Button();
            this.btnObrisiSektor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvSektori
            // 
            this.lvSektori.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Naziv,
            this.tipSektora});
            this.lvSektori.FullRowSelect = true;
            this.lvSektori.GridLines = true;
            this.lvSektori.HideSelection = false;
            this.lvSektori.Location = new System.Drawing.Point(12, 12);
            this.lvSektori.Name = "lvSektori";
            this.lvSektori.Size = new System.Drawing.Size(356, 426);
            this.lvSektori.TabIndex = 0;
            this.lvSektori.UseCompatibleStateImageBehavior = false;
            this.lvSektori.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // Naziv
            // 
            this.Naziv.Text = "Naziv";
            this.Naziv.Width = 150;
            // 
            // tipSektora
            // 
            this.tipSektora.Text = "Tip Sektora";
            this.tipSektora.Width = 150;
            // 
            // btnDodajSektor
            // 
            this.btnDodajSektor.Location = new System.Drawing.Point(385, 212);
            this.btnDodajSektor.Name = "btnDodajSektor";
            this.btnDodajSektor.Size = new System.Drawing.Size(123, 66);
            this.btnDodajSektor.TabIndex = 1;
            this.btnDodajSektor.Text = "Dodaj sektor";
            this.btnDodajSektor.UseVisualStyleBackColor = true;
            this.btnDodajSektor.Click += new System.EventHandler(this.btnDodajSektor_Click);
            // 
            // btnIzmeniSektor
            // 
            this.btnIzmeniSektor.Location = new System.Drawing.Point(385, 294);
            this.btnIzmeniSektor.Name = "btnIzmeniSektor";
            this.btnIzmeniSektor.Size = new System.Drawing.Size(123, 66);
            this.btnIzmeniSektor.TabIndex = 2;
            this.btnIzmeniSektor.Text = "Izmeni sektor";
            this.btnIzmeniSektor.UseVisualStyleBackColor = true;
            this.btnIzmeniSektor.Click += new System.EventHandler(this.btnIzmeniSektor_Click);
            // 
            // btnObrisiSektor
            // 
            this.btnObrisiSektor.Location = new System.Drawing.Point(385, 372);
            this.btnObrisiSektor.Name = "btnObrisiSektor";
            this.btnObrisiSektor.Size = new System.Drawing.Size(123, 66);
            this.btnObrisiSektor.TabIndex = 3;
            this.btnObrisiSektor.Text = "Obriši sektor";
            this.btnObrisiSektor.UseVisualStyleBackColor = true;
            this.btnObrisiSektor.Click += new System.EventHandler(this.btnObrisiSektor_Click);
            // 
            // SektoriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 450);
            this.Controls.Add(this.btnObrisiSektor);
            this.Controls.Add(this.btnIzmeniSektor);
            this.Controls.Add(this.btnDodajSektor);
            this.Controls.Add(this.lvSektori);
            this.Name = "SektoriForm";
            this.Text = "SektoriForm";
            this.Load += new System.EventHandler(this.SektoriForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvSektori;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Naziv;
        private System.Windows.Forms.ColumnHeader tipSektora;
        private System.Windows.Forms.Button btnDodajSektor;
        private System.Windows.Forms.Button btnIzmeniSektor;
        private System.Windows.Forms.Button btnObrisiSektor;
    }
}