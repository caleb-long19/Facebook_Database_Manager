using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FacebookDatabase
{
    public partial class FacebookTestingForm : Form
    {

        public static FacebookTestingForm frmkeepFacebookTestingForm = null;

        public FacebookTestingForm()
        {
            InitializeComponent();
            frmkeepFacebookTestingForm = this;
        }

        #region Allow User to select what Data displays in the Datagrid
        private void mainFormComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Display Facebook Users in Datagrid
            if (mainFormComboBox.SelectedIndex == 0)
            {
                string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_users";
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable userDataTable = new DataTable();
                    sqlDA.Fill(userDataTable);

                    databaseGridView.DataSource = userDataTable;

                } // End of using (MySqlConnection connection = ...
            }
            #endregion

            #region Display Facebook Friends in Datagrid
            else if (mainFormComboBox.SelectedIndex == 1)
            {
                string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";

                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_friendships_listed_id";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable friendsDataTable = new DataTable();
                    sqlDA.Fill(friendsDataTable);

                    databaseGridView.DataSource = friendsDataTable;
                }
            }
            #endregion

            #region Display Facebook Messages in Datagrid
            else if (mainFormComboBox.SelectedIndex == 2)
            {
                string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";

                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_messages_listed_id";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable messagesDataTable = new DataTable();
                    sqlDA.Fill(messagesDataTable);

                    databaseGridView.DataSource = messagesDataTable;
                }
            }
            #endregion

            #region Display Facebook Users Universities in Datagrid
            else if (mainFormComboBox.SelectedIndex == 3)
            {
                string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";

                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_universities_listed_id";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable universitiesDataTable = new DataTable();
                    sqlDA.Fill(universitiesDataTable);

                    databaseGridView.DataSource = universitiesDataTable;
                }
            }
            #endregion

            #region Display Facebook User Workplaces in Datagrid
            else
            {
                string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";

                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.workplace_listed_id";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable workplaceDataTable = new DataTable();
                    sqlDA.Fill(workplaceDataTable);

                    databaseGridView.DataSource = workplaceDataTable;
                }
            }
            #endregion
        }


        #endregion

        #region Button Functionality on the Main Form
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
