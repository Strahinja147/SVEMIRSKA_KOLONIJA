namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class OdabirStanovnikaForm
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
            this.lbStanovnici = new System.Windows.Forms.ListBox();
            this.btnOdaberi = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbStanovnici
            // 
            this.lbStanovnici.FormattingEnabled = true;
            this.lbStanovnici.ItemHeight = 16;
            this.lbStanovnici.Location = new System.Drawing.Point(12, 12);
            this.lbStanovnici.Name = "lbStanovnici";
            this.lbStanovnici.Size = new System.Drawing.Size(357, 324);
            this.lbStanovnici.Sorted = true;
            this.lbStanovnici.TabIndex = 0;
            // 
            // btnOdaberi
            // 
            this.btnOdaberi.Location = new System.Drawing.Point(430, 25);
            this.btnOdaberi.Name = "btnOdaberi";
            this.btnOdaberi.Size = new System.Drawing.Size(123, 108);
            this.btnOdaberi.TabIndex = 1;
            this.btnOdaberi.Text = "Odaberi";
            this.btnOdaberi.UseVisualStyleBackColor = true;
            this.btnOdaberi.Click += new System.EventHandler(this.btnOdaberi_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(430, 199);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(123, 108);
            this.btnOdustani.TabIndex = 2;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // DodeliUpravitelja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 352);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnOdaberi);
            this.Controls.Add(this.lbStanovnici);
            this.Name = "DodeliUpravitelja";
            this.Text = "DodeliUpravitelja";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbStanovnici;
        private System.Windows.Forms.Button btnOdaberi;
        private System.Windows.Forms.Button btnOdustani;
    }
}