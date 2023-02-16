namespace MG_94_2018
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nazivSlike = new System.Windows.Forms.Label();
            this.brojacPoteza = new System.Windows.Forms.Label();
            this.vremeOdPocetka = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(984, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(81, 73);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimenzije";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "3x4x2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "3x3x2";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(991, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Ucitaj sliku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(991, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 55);
            this.button2.TabIndex = 26;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nazivSlike
            // 
            this.nazivSlike.AutoSize = true;
            this.nazivSlike.Location = new System.Drawing.Point(995, 91);
            this.nazivSlike.Name = "nazivSlike";
            this.nazivSlike.Size = new System.Drawing.Size(0, 13);
            this.nazivSlike.TabIndex = 27;
            // 
            // brojacPoteza
            // 
            this.brojacPoteza.AutoSize = true;
            this.brojacPoteza.Location = new System.Drawing.Point(989, 229);
            this.brojacPoteza.Name = "brojacPoteza";
            this.brojacPoteza.Size = new System.Drawing.Size(72, 13);
            this.brojacPoteza.TabIndex = 28;
            this.brojacPoteza.Text = "Broj poteza: 0";
            // 
            // vremeOdPocetka
            // 
            this.vremeOdPocetka.AutoSize = true;
            this.vremeOdPocetka.Location = new System.Drawing.Point(862, -1);
            this.vremeOdPocetka.Name = "vremeOdPocetka";
            this.vremeOdPocetka.Size = new System.Drawing.Size(148, 13);
            this.vremeOdPocetka.TabIndex = 29;
            this.vremeOdPocetka.Text = "Broj sekundi od pocetka igre: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.vremeOdPocetka);
            this.Controls.Add(this.brojacPoteza);
            this.Controls.Add(this.nazivSlike);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label nazivSlike;
        private System.Windows.Forms.Label brojacPoteza;
        private System.Windows.Forms.Label vremeOdPocetka;
    }
}

