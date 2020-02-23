using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Allover
{
    public partial class verbindung_erstellen : Form
    {
        public verbindung_erstellen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ipadresse = tb_ipadresse.Text;
            string benutzer = tb_benutzername.Text;
            string passwort = tb_passwort.Text;
            string dbname = tb_datenbankname.Text;
            bool ssl = checkBox1.Checked;
            string verbindungsname;
            string tempname;
            tempname = "";
            int i = 1;
            verbindungsname = "NeueVerbindung";
            SaveFileDialog savefile = new SaveFileDialog();
            if(savefile.ShowDialog() == DialogResult.OK)
            {
                verbindungsname = savefile.FileName;
            }
            tempname = verbindungsname + ".dba";
            while(System.IO.File.Exists(tempname) == true)
            {
                tempname = verbindungsname + i + ".dba";
                i++;
            }
            
            WriteXML(ipadresse, benutzer, passwort, dbname,ssl,tempname);
            this.Close();
        }

        public class MySQLConn
        {
            public String IP;
            public String benutzer;
            public String passwort;
            public String Datenbankname;
            public bool ssl;
        }


        public static void WriteXML(string ip, string benutzer, string passwort, string datenbankname, bool checkstate, string dateiname)
        {
            MySQLConn verbindungsdatei = new MySQLConn();
            verbindungsdatei.IP = ip;
            verbindungsdatei.benutzer = benutzer;
            verbindungsdatei.passwort = passwort;
            verbindungsdatei.Datenbankname = datenbankname;
            verbindungsdatei.ssl = checkstate;
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(MySQLConn));


            System.IO.FileStream file = System.IO.File.Create(dateiname);

            writer.Serialize(file, verbindungsdatei);
            file.Close();
        }
    }
}
