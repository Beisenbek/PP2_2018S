using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);

        }


        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        private void button1_Click(object sender, EventArgs e)
        {

      
            bool connectionIsOpen = true;

            server = "localhost";
            database = "fitdb";
            uid = "bsnbk";
            password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);


            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                connectionIsOpen = false;
                MessageBox.Show(ex.Message);
            }

            string query = "SELECT CustomerID, CustomerName FROM  Customers2";

            List<string>[] list = new List<string>[2];
            list[0] = new List<string>();
            list[1] = new List<string>();

            //Open connection
            if (connectionIsOpen)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["CustomerID"] + "");
                    list[1].Add(dataReader["CustomerName"] + "");

                    MessageBox.Show(dataReader["CustomerID"] + " " + dataReader["CustomerName"]);
                }

                //close Data Reader
                dataReader.Close();

                try
                {
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool connectionIsOpen = true;

            server = "localhost";
            database = "fitdb";
            uid = "bsnbk";
            password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);


            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                connectionIsOpen = false;
                MessageBox.Show(ex.Message);
            }

            string query = "INSERT INTO Customers2 (CustomerName, ContactName, Address, City, PostalCode, Country) VALUES('Cardinal2', 'Tom B. Erichsen 2', 'Skagen 212', 'Stavanger2', '14006', 'KZ'); ";

            List<string>[] list = new List<string>[2];
            list[0] = new List<string>();
            list[1] = new List<string>();

            //Open connection
            if (connectionIsOpen)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                int n = cmd.ExecuteNonQuery();

                MessageBox.Show(n.ToString());

                try
                {
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
