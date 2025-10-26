namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class StanovniciForm
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
            this.listViewStanovnici = new System.Windows.Forms.ListView();
            this.btnObrisiStanovnika = new System.Windows.Forms.Button();
            this.btnIzmeniStanovnika = new System.Windows.Forms.Button();
            this.btnDodajStanovnika = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewStanovnici
            // 
            this.listViewStanovnici.FullRowSelect = true;
            this.listViewStanovnici.GridLines = true;
            this.listViewStanovnici.HideSelection = false;
            this.listViewStanovnici.Location = new System.Drawing.Point(36, 25);
            this.listViewStanovnici.MultiSelect = false;
            this.listViewStanovnici.Name = "listViewStanovnici";
            this.listViewStanovnici.Size = new System.Drawing.Size(545, 289);
            this.listViewStanovnici.TabIndex = 0;
            this.listViewStanovnici.UseCompatibleStateImageBehavior = false;
            this.listViewStanovnici.View = System.Windows.Forms.View.Details;
            // 
            // btnObrisiStanovnika
            // 
            this.btnObrisiStanovnika.Location = new System.Drawing.Point(446, 358);
            this.btnObrisiStanovnika.Name = "btnObrisiStanovnika";
            this.btnObrisiStanovnika.Size = new System.Drawing.Size(135, 23);
            this.btnObrisiStanovnika.TabIndex = 1;
            this.btnObrisiStanovnika.Text = "Obriši Stanovnika";
            this.btnObrisiStanovnika.UseVisualStyleBackColor = true;
            this.btnObrisiStanovnika.Click += new System.EventHandler(this.btnObrisiStanovnika_Click);
            // 
            // btnIzmeniStanovnika
            // 
            this.btnIzmeniStanovnika.Location = new System.Drawing.Point(236, 358);
            this.btnIzmeniStanovnika.Name = "btnIzmeniStanovnika";
            this.btnIzmeniStanovnika.Size = new System.Drawing.Size(136, 23);
            this.btnIzmeniStanovnika.TabIndex = 2;
            this.btnIzmeniStanovnika.Text = "Izmeni Stanovnika";
            this.btnIzmeniStanovnika.UseVisualStyleBackColor = true;
            this.btnIzmeniStanovnika.Click += new System.EventHandler(this.btnIzmeniStanovnika_Click);
            // 
            // btnDodajStanovnika
            // 
            this.btnDodajStanovnika.Location = new System.Drawing.Point(36, 358);
            this.btnDodajStanovnika.Name = "btnDodajStanovnika";
            this.btnDodajStanovnika.Size = new System.Drawing.Size(130, 23);
            this.btnDodajStanovnika.TabIndex = 3;
            this.btnDodajStanovnika.Text = "Dodaj Stanovnika";
            this.btnDodajStanovnika.UseVisualStyleBackColor = true;
            this.btnDodajStanovnika.Click += new System.EventHandler(this.btnDodajStanovnika_Click);
            // 
            // StanovniciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDodajStanovnika);
            this.Controls.Add(this.btnIzmeniStanovnika);
            this.Controls.Add(this.btnObrisiStanovnika);
            this.Controls.Add(this.listViewStanovnici);
            this.Name = "StanovniciForm";
            this.Text = "StanovniciForm";
            this.Load += new System.EventHandler(this.StanovniciForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewStanovnici;
        private System.Windows.Forms.Button btnObrisiStanovnika;
        private System.Windows.Forms.Button btnIzmeniStanovnika;
        private System.Windows.Forms.Button btnDodajStanovnika;
    }
}