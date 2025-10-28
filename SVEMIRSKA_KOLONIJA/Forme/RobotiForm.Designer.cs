namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class RobotiForm
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
            this.lvRoboti = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sifra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDodajRobota = new System.Windows.Forms.Button();
            this.btnIzmeniRobota = new System.Windows.Forms.Button();
            this.btnObrisiRobota = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvRoboti
            // 
            this.lvRoboti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Sifra,
            this.Tip});
            this.lvRoboti.FullRowSelect = true;
            this.lvRoboti.GridLines = true;
            this.lvRoboti.HideSelection = false;
            this.lvRoboti.Location = new System.Drawing.Point(12, 12);
            this.lvRoboti.Name = "lvRoboti";
            this.lvRoboti.Size = new System.Drawing.Size(355, 426);
            this.lvRoboti.TabIndex = 0;
            this.lvRoboti.UseCompatibleStateImageBehavior = false;
            this.lvRoboti.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // Sifra
            // 
            this.Sifra.Text = "Šifra";
            this.Sifra.Width = 150;
            // 
            // Tip
            // 
            this.Tip.Text = "Tip";
            this.Tip.Width = 150;
            // 
            // btnDodajRobota
            // 
            this.btnDodajRobota.Location = new System.Drawing.Point(397, 192);
            this.btnDodajRobota.Name = "btnDodajRobota";
            this.btnDodajRobota.Size = new System.Drawing.Size(113, 71);
            this.btnDodajRobota.TabIndex = 1;
            this.btnDodajRobota.Text = "Dodaj robota";
            this.btnDodajRobota.UseVisualStyleBackColor = true;
            this.btnDodajRobota.Click += new System.EventHandler(this.btnDodajRobota_Click);
            // 
            // btnIzmeniRobota
            // 
            this.btnIzmeniRobota.Location = new System.Drawing.Point(397, 278);
            this.btnIzmeniRobota.Name = "btnIzmeniRobota";
            this.btnIzmeniRobota.Size = new System.Drawing.Size(113, 71);
            this.btnIzmeniRobota.TabIndex = 2;
            this.btnIzmeniRobota.Text = "Izmeni robota";
            this.btnIzmeniRobota.UseVisualStyleBackColor = true;
            this.btnIzmeniRobota.Click += new System.EventHandler(this.btnIzmeniRobota_Click);
            // 
            // btnObrisiRobota
            // 
            this.btnObrisiRobota.Location = new System.Drawing.Point(397, 367);
            this.btnObrisiRobota.Name = "btnObrisiRobota";
            this.btnObrisiRobota.Size = new System.Drawing.Size(113, 71);
            this.btnObrisiRobota.TabIndex = 3;
            this.btnObrisiRobota.Text = "Obriši robota";
            this.btnObrisiRobota.UseVisualStyleBackColor = true;
            this.btnObrisiRobota.Click += new System.EventHandler(this.btnObrisiRobota_Click);
            // 
            // RobotiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 450);
            this.Controls.Add(this.btnObrisiRobota);
            this.Controls.Add(this.btnIzmeniRobota);
            this.Controls.Add(this.btnDodajRobota);
            this.Controls.Add(this.lvRoboti);
            this.Name = "RobotiForm";
            this.Text = "RobotiForm";
            this.Load += new System.EventHandler(this.RobotiForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRoboti;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Sifra;
        private System.Windows.Forms.ColumnHeader Tip;
        private System.Windows.Forms.Button btnDodajRobota;
        private System.Windows.Forms.Button btnIzmeniRobota;
        private System.Windows.Forms.Button btnObrisiRobota;
    }
}