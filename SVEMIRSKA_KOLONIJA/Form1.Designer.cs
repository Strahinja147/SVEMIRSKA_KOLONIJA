namespace SVEMIRSKA_KOLONIJA
{
    partial class Form1
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
            this.btnPrikaziStanovnike = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Zanimanje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnPrikaziStanovnike
            // 
            this.btnPrikaziStanovnike.Location = new System.Drawing.Point(289, 321);
            this.btnPrikaziStanovnike.Name = "btnPrikaziStanovnike";
            this.btnPrikaziStanovnike.Size = new System.Drawing.Size(179, 23);
            this.btnPrikaziStanovnike.TabIndex = 0;
            this.btnPrikaziStanovnike.Text = "Prikaži Stanovnike";
            this.btnPrikaziStanovnike.UseVisualStyleBackColor = true;
            this.btnPrikaziStanovnike.Click += new System.EventHandler(this.btnPrikaziStanovnike_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Ime,
            this.Prezime,
            this.Zanimanje});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(41, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(718, 249);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 160;
            // 
            // Ime
            // 
            this.Ime.Text = "Ime";
            this.Ime.Width = 160;
            // 
            // Prezime
            // 
            this.Prezime.Text = "Prezime";
            this.Prezime.Width = 160;
            // 
            // Zanimanje
            // 
            this.Zanimanje.Text = "Zanimanje";
            this.Zanimanje.Width = 160;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnPrikaziStanovnike);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrikaziStanovnike;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Ime;
        private System.Windows.Forms.ColumnHeader Prezime;
        private System.Windows.Forms.ColumnHeader Zanimanje;
    }
}

