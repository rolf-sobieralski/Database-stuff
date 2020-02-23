using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DB_Allover
{
    public partial class MainForm : Form
    {
        SQLITE sq = new SQLITE();
        MYSQL msq = new MYSQL();
        bool myflag = false;
        bool loaded = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename;
            filename = "fehlerdialog";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                open_database(filename);
            }
            
        }

        private void open_database(string filename)
        {
            string fExtension;
            fExtension = System.IO.Path.GetExtension(filename);
            if(fExtension == ".dba")
            {
                myflag = true;
                string dbname = msq.OpenConnection(filename);
                msq.mysql_get_tables(bindingSource1, dataGridView1, dbname);
            }
            else
            {
                sq.OpenConnection(filename);
                sq.sqlite_get_tables(bindingSource1, dataGridView1);
            }
            loaded = true;

        }

        private void neueVerbindungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verbindung_erstellen verbindung = new verbindung_erstellen();
            verbindung.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loaded = false;
            if (myflag == true)
            {
                msq.close();
            }
            else
            {
                sq.close();
            }
            bindingSource1.DataSource = null;
            bindingSource2.DataSource = null;
            myflag = false;
            
        }

        private void aktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myflag == true)
            {
                msq.update_data(bindingSource2);
            }
            else
            {
                sq.update_data(bindingSource2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string colname = comboBox1.Text;
            if (colname == "")
            {
                MessageBox.Show("bitte suchspalte auswählen");
            }
            else
            {
                if (myflag == true)
                {
                    msq.get_search_result(bindingSource2, dataGridView2, dataGridView1.SelectedCells[0].Value.ToString(), textBox1.Text, comboBox1.Text);
                }
                else
                {
                    sq.get_search_result(bindingSource2, dataGridView2, dataGridView1.SelectedCells[0].Value.ToString(), textBox1.Text, comboBox1.Text);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string cContent;
            if (loaded == true)
            {
                cContent = dataGridView1.SelectedCells[0].Value.ToString();
                if (myflag == true)
                {
                    msq.mysql_get_table_data(bindingSource2, dataGridView2, comboBox1, cContent);
                }
                else
                {
                    sq.sqlite_get_table_data(bindingSource2, dataGridView2, comboBox1, cContent);
                }
            }
        }
    }
}
