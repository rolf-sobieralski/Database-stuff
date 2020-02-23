using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace DB_Allover
{
    class MYSQL
    {
        MySqlConnection connection = new MySqlConnection();
        MySqlDataAdapter dataAdapter;
        String datenbankname = "";


        public String OpenConnection(string dateiname)
        {
            try
            {
                MySQLConn conparameters = ReadXML(dateiname);
                string connstring = "";
                if (conparameters.ssl == true)
                {
                    connstring = string.Format("Server={0}; database={1}; UID={2}; password={3};", conparameters.IP, conparameters.Datenbankname, conparameters.benutzer, conparameters.passwort);

                }
                else
                {
                    connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}; SslMode=None;", conparameters.IP, conparameters.Datenbankname, conparameters.benutzer, conparameters.passwort);

                }
                connection = new MySqlConnection();
                connection.ConnectionString = connstring;
                connection.Open();
                return conparameters.Datenbankname;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return "";
            }
        }

        public void get_search_result(BindingSource bind, DataGridView dataGrid, string tablename, string firstfield, string secondfield)
        {
            try
            {
                string CommandText = "SELECT * FROM " + tablename + " WHERE " + secondfield + "='" + firstfield + "'";
                dataAdapter = new MySqlDataAdapter(CommandText, connection);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bind.DataSource = table;
                dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void mysql_get_tables(BindingSource bind, DataGridView dataGrid, string databaseName)
        {
            try
            {

                string CommandText = "SHOW TABLES FROM " + databaseName;
                dataAdapter = new MySqlDataAdapter(CommandText, connection);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bind.DataSource = table;
                dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void mysql_get_table_data(BindingSource bind, DataGridView dataGrid, ComboBox cbox,string tablename)
        {
            try
            {
                string CommandText = "SELECT * FROM " + tablename;
                dataAdapter = new MySqlDataAdapter(CommandText, connection);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bind.DataSource = table;
                dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + datenbankname + "' AND TABLE_NAME = '" + tablename + "'";
                dataAdapter = new MySqlDataAdapter(CommandText, connection);
                commandBuilder = new MySqlCommandBuilder(dataAdapter);
                DataTable cTable = new DataTable();
                dataAdapter.Fill(cTable);
                cbox.Items.Clear();
                foreach (DataRow res in cTable.Rows)
                {
                    cbox.Items.Add(res.ItemArray.GetValue(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void close()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public MySQLConn ReadXML(string dateiname)
        {
            try
            {
                MySQLConn verbindungsdatei = new MySQLConn();
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(MySQLConn));

                System.IO.FileStream file = System.IO.File.OpenRead(dateiname);


                verbindungsdatei = (MySQLConn)reader.Deserialize(file);
                file.Close();

                datenbankname = verbindungsdatei.Datenbankname;
                return verbindungsdatei;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public void update_data(BindingSource bind)
        {
            try
            {
                dataAdapter.Update((DataTable)bind.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    public class MySQLConn
    {
        public String IP;
        public String benutzer;
        public String passwort;
        public String Datenbankname;
        public bool ssl;
    }
}
