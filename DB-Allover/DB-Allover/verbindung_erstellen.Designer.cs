namespace DB_Allover
{
    partial class verbindung_erstellen
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tb_ipadresse = new System.Windows.Forms.TextBox();
            this.tb_benutzername = new System.Windows.Forms.TextBox();
            this.tb_passwort = new System.Windows.Forms.TextBox();
            this.tb_datenbankname = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP Adresse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Benutzername";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Passwort";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Datenbank Name";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 119);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "SSL Verbindung";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tb_ipadresse
            // 
            this.tb_ipadresse.Location = new System.Drawing.Point(104, 12);
            this.tb_ipadresse.Name = "tb_ipadresse";
            this.tb_ipadresse.Size = new System.Drawing.Size(213, 20);
            this.tb_ipadresse.TabIndex = 7;
            // 
            // tb_benutzername
            // 
            this.tb_benutzername.Location = new System.Drawing.Point(104, 39);
            this.tb_benutzername.Name = "tb_benutzername";
            this.tb_benutzername.Size = new System.Drawing.Size(213, 20);
            this.tb_benutzername.TabIndex = 8;
            // 
            // tb_passwort
            // 
            this.tb_passwort.Location = new System.Drawing.Point(104, 66);
            this.tb_passwort.Name = "tb_passwort";
            this.tb_passwort.Size = new System.Drawing.Size(213, 20);
            this.tb_passwort.TabIndex = 9;
            // 
            // tb_datenbankname
            // 
            this.tb_datenbankname.Location = new System.Drawing.Point(104, 93);
            this.tb_datenbankname.Name = "tb_datenbankname";
            this.tb_datenbankname.Size = new System.Drawing.Size(213, 20);
            this.tb_datenbankname.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "speichern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "bearbeiten";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // verbindung_erstellen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 171);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_datenbankname);
            this.Controls.Add(this.tb_passwort);
            this.Controls.Add(this.tb_benutzername);
            this.Controls.Add(this.tb_ipadresse);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "verbindung_erstellen";
            this.Text = "verbindung erstellen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tb_ipadresse;
        private System.Windows.Forms.TextBox tb_benutzername;
        private System.Windows.Forms.TextBox tb_passwort;
        private System.Windows.Forms.TextBox tb_datenbankname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}