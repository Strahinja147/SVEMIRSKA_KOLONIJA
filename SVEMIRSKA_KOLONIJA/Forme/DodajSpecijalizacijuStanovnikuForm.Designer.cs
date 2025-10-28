namespace SVEMIRSKA_KOLONIJA.Forme
{
    partial class DodajSpecijalizacijuStanovnikuForm
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
            this.labelSpecijalizacija = new System.Windows.Forms.Label();
            this.labelNivo = new System.Windows.Forms.Label();
            this.labelDatum = new System.Windows.Forms.Label();
            this.labelInstitucija = new System.Windows.Forms.Label();
            this.cmbSpecijalizacija = new System.Windows.Forms.ComboBox();
            this.txtNivoEkspertize = new System.Windows.Forms.TextBox();
            this.dtpDatumSticanja = new System.Windows.Forms.DateTimePicker();
            this.txtInstitucija = new System.Windows.Forms.TextBox();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSpecijalizacija
            // 
            this.labelSpecijalizacija.AutoSize = true;
            this.labelSpecijalizacija.Location = new System.Drawing.Point(12, 31);
            this.labelSpecijalizacija.Name = "labelSpecijalizacija";
            this.labelSpecijalizacija.Size = new System.Drawing.Size(76, 13);
            this.labelSpecijalizacija.TabIndex = 0;
            this.labelSpecijalizacija.Text = "Specijalizacija:";
            // 
            // labelNivo
            // 
            this.labelNivo.AutoSize = true;
            this.labelNivo.Location = new System.Drawing.Point(12, 73);
            this.labelNivo.Name = "labelNivo";
            this.labelNivo.Size = new System.Drawing.Size(83, 13);
            this.labelNivo.TabIndex = 1;
            this.labelNivo.Text = "Nivo ekspertize:";
            // 
            // labelDatum
            // 
            this.labelDatum.AutoSize = true;
            this.labelDatum.Location = new System.Drawing.Point(12, 115);
            this.labelDatum.Name = "labelDatum";
            this.labelDatum.Size = new System.Drawing.Size(80, 13);
            this.labelDatum.TabIndex = 2;
            this.labelDatum.Text = "Datum sticanja:";
            // 
            // labelInstitucija
            // 
            this.labelInstitucija.AutoSize = true;
            this.labelInstitucija.Location = new System.Drawing.Point(12, 159);
            this.labelInstitucija.Name = "labelInstitucija";
            this.labelInstitucija.Size = new System.Drawing.Size(54, 13);
            this.labelInstitucija.TabIndex = 3;
            this.labelInstitucija.Text = "Institucija:";
            // 
            // cmbSpecijalizacija
            // 
            this.cmbSpecijalizacija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecijalizacija.FormattingEnabled = true;
            this.cmbSpecijalizacija.Location = new System.Drawing.Point(150, 28);
            this.cmbSpecijalizacija.Name = "cmbSpecijalizacija";
            this.cmbSpecijalizacija.Size = new System.Drawing.Size(179, 21);
            this.cmbSpecijalizacija.TabIndex = 4;
            this.cmbSpecijalizacija.TabStop = false;
            // 
            // txtNivoEkspertize
            // 
            this.txtNivoEkspertize.Location = new System.Drawing.Point(150, 70);
            this.txtNivoEkspertize.Name = "txtNivoEkspertize";
            this.txtNivoEkspertize.Size = new System.Drawing.Size(179, 20);
            this.txtNivoEkspertize.TabIndex = 5;
            // 
            // dtpDatumSticanja
            // 
            this.dtpDatumSticanja.Location = new System.Drawing.Point(150, 109);
            this.dtpDatumSticanja.Name = "dtpDatumSticanja";
            this.dtpDatumSticanja.Size = new System.Drawing.Size(179, 20);
            this.dtpDatumSticanja.TabIndex = 6;
            // 
            // txtInstitucija
            // 
            this.txtInstitucija.Location = new System.Drawing.Point(150, 156);
            this.txtInstitucija.Name = "txtInstitucija";
            this.txtInstitucija.Size = new System.Drawing.Size(179, 20);
            this.txtInstitucija.TabIndex = 7;
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(220, 224);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(109, 53);
            this.btnSnimi.TabIndex = 8;
            this.btnSnimi.Text = "Sačuvaj";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // DodajSpecijalizacijuStanovnikuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 298);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.txtInstitucija);
            this.Controls.Add(this.dtpDatumSticanja);
            this.Controls.Add(this.txtNivoEkspertize);
            this.Controls.Add(this.cmbSpecijalizacija);
            this.Controls.Add(this.labelInstitucija);
            this.Controls.Add(this.labelDatum);
            this.Controls.Add(this.labelNivo);
            this.Controls.Add(this.labelSpecijalizacija);
            this.Name = "DodajSpecijalizacijuStanovnikuForm";
            this.Text = "DodajSpecijalizacijuStanovnikuForm";
            this.Load += new System.EventHandler(this.DodajSpecijalizacijuStanovnikuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSpecijalizacija;
        private System.Windows.Forms.Label labelNivo;
        private System.Windows.Forms.Label labelDatum;
        private System.Windows.Forms.Label labelInstitucija;
        private System.Windows.Forms.ComboBox cmbSpecijalizacija;
        private System.Windows.Forms.TextBox txtNivoEkspertize;
        private System.Windows.Forms.DateTimePicker dtpDatumSticanja;
        private System.Windows.Forms.TextBox txtInstitucija;
        private System.Windows.Forms.Button btnSnimi;
    }
}