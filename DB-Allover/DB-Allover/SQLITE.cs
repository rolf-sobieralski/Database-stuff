using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace DB_Allover
{
    class SQLITE
    {
        SQLiteConnection connection = new SQLiteConnection();
        SQLiteDataAdapter dataAdapter;

        public void OpenConnection(string database)
        {
            try
            {
                connection.ConnectionString = "Data Source=" + database;
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void close()
        {
            try { 
            connection.Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
}

        public void update_data(BindingSource bind)
        {
    try { 
            dataAdapter.Update((DataTable)bind.DataSource);
}
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }

        public void get_search_result(BindingSource bind, DataGridView dataGrid, string tablename, string firstfield, string secondfield)
        {
    try { 
            string CommandText = "SELECT * FROM " + tablename + " WHERE " + secondfield + "='" + firstfield + "'";
            dataAdapter = new SQLiteDataAdapter(CommandText, connection);
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(dataAdapter);
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


        public void sqlite_get_tables(BindingSource bind, DataGridView dataGrid)
        {
    try { 
            string CommandText = "SELECT name FROM sqlite_master WHERE type='table';";
            dataAdapter = new SQLiteDataAdapter(CommandText,connection);
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(dataAdapter);
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

        public void sqlite_get_table_data(BindingSource bind, DataGridView dataGrid,ComboBox cbox, string tablename)
        {
    try { 
            string CommandText = "SELECT * FROM " + tablename + ";";
            dataAdapter = new SQLiteDataAdapter(CommandText, connection);
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            bind.DataSource = table;
            dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            CommandText = "PRAGMA table_info(" + tablename + ");";
            
            dataAdapter = new SQLiteDataAdapter(CommandText, connection);
            commandBuilder = new SQLiteCommandBuilder(dataAdapter);
            DataTable cTable = new DataTable();
            dataAdapter.Fill(cTable);
            cbox.Items.Clear();
            foreach (DataRow res in cTable.Rows)
            {
                cbox.Items.Add(res.ItemArray.GetValue(1));
            }
}
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
