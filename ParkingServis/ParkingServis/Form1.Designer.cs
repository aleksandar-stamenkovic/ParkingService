namespace ParkingServis
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
            this.cmdUcitavanjeParkinga = new System.Windows.Forms.Button();
            this.cmdDodavanjeParkinga = new System.Windows.Forms.Button();
            this.cmdVezaManyToOne = new System.Windows.Forms.Button();
            this.cmdUcitavanjePravnogLica = new System.Windows.Forms.Button();
            this.cmdUcitavanjeFizickog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdUcitavanjeParkinga
            // 
            this.cmdUcitavanjeParkinga.Location = new System.Drawing.Point(13, 13);
            this.cmdUcitavanjeParkinga.Name = "cmdUcitavanjeParkinga";
            this.cmdUcitavanjeParkinga.Size = new System.Drawing.Size(132, 23);
            this.cmdUcitavanjeParkinga.TabIndex = 0;
            this.cmdUcitavanjeParkinga.Text = "Ucitavanje parkinga";
            this.cmdUcitavanjeParkinga.UseVisualStyleBackColor = true;
            this.cmdUcitavanjeParkinga.Click += new System.EventHandler(this.cmdUcitavanjeParkinga_Click);
            // 
            // cmdDodavanjeParkinga
            // 
            this.cmdDodavanjeParkinga.Location = new System.Drawing.Point(13, 43);
            this.cmdDodavanjeParkinga.Name = "cmdDodavanjeParkinga";
            this.cmdDodavanjeParkinga.Size = new System.Drawing.Size(132, 23);
            this.cmdDodavanjeParkinga.TabIndex = 1;
            this.cmdDodavanjeParkinga.Text = "Dodavanje parkinga";
            this.cmdDodavanjeParkinga.UseVisualStyleBackColor = true;
            this.cmdDodavanjeParkinga.Click += new System.EventHandler(this.cmdDodavanjeParkinga_Click);
            // 
            // cmdVezaManyToOne
            // 
            this.cmdVezaManyToOne.Location = new System.Drawing.Point(13, 72);
            this.cmdVezaManyToOne.Name = "cmdVezaManyToOne";
            this.cmdVezaManyToOne.Size = new System.Drawing.Size(132, 23);
            this.cmdVezaManyToOne.TabIndex = 1;
            this.cmdVezaManyToOne.Text = "Veza many-to-one";
            this.cmdVezaManyToOne.UseVisualStyleBackColor = true;
            this.cmdVezaManyToOne.Click += new System.EventHandler(this.cmdVezaManyToOne_Click);
            // 
            // cmdUcitavanjePravnogLica
            // 
            this.cmdUcitavanjePravnogLica.Location = new System.Drawing.Point(166, 13);
            this.cmdUcitavanjePravnogLica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdUcitavanjePravnogLica.Name = "cmdUcitavanjePravnogLica";
            this.cmdUcitavanjePravnogLica.Size = new System.Drawing.Size(122, 23);
            this.cmdUcitavanjePravnogLica.TabIndex = 2;
            this.cmdUcitavanjePravnogLica.Text = "Ucitavanje pravnog lica";
            this.cmdUcitavanjePravnogLica.UseVisualStyleBackColor = true;
            this.cmdUcitavanjePravnogLica.Click += new System.EventHandler(this.cmdUcitavanjePravnogLica_Click);
            // 
            // cmdUcitavanjeFizickog
            // 
            this.cmdUcitavanjeFizickog.Location = new System.Drawing.Point(166, 42);
            this.cmdUcitavanjeFizickog.Name = "cmdUcitavanjeFizickog";
            this.cmdUcitavanjeFizickog.Size = new System.Drawing.Size(122, 23);
            this.cmdUcitavanjeFizickog.TabIndex = 3;
            this.cmdUcitavanjeFizickog.Text = "Ucitavanje fizickog";
            this.cmdUcitavanjeFizickog.UseVisualStyleBackColor = true;
            this.cmdUcitavanjeFizickog.Click += new System.EventHandler(this.cmdUcitavanjeFizickog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdUcitavanjeFizickog);
            this.Controls.Add(this.cmdUcitavanjePravnogLica);
            this.Controls.Add(this.cmdVezaManyToOne);
            this.Controls.Add(this.cmdDodavanjeParkinga);
            this.Controls.Add(this.cmdUcitavanjeParkinga);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdUcitavanjeParkinga;
        private System.Windows.Forms.Button cmdDodavanjeParkinga;
        private System.Windows.Forms.Button cmdVezaManyToOne;
        private System.Windows.Forms.Button cmdUcitavanjePravnogLica;
        private System.Windows.Forms.Button cmdUcitavanjeFizickog;
    }
}

