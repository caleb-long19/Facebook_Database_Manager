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
        #region // Variables

        int IndexRow;

        string connectionString = "SERVER=" + DBConnect.SERVER + ";" +
                    "DATABASE=" + DBConnect.DATABASE_NAME + ";" + "UID=" +
                    DBConnect.USER_NAME + ";" + "PASSWORD=" +
                    DBConnect.PASSWORD + ";" + "SslMode=" +
                    DBConnect.SslMode + ";";

        public FacebookTestingForm()
        {
            InitializeComponent();
        }
        #endregion


        #region // Allow User to select what Data displays in the Datagrid
        private void mainFormComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Display Facebook Users in Datagrid
            if (mainFormComboBox.SelectedIndex == 0)
            {
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
                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_friendships";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable friendshipsDataTable = new DataTable();
                    sqlDA.Fill(friendshipsDataTable);

                    databaseGridView.DataSource = friendshipsDataTable;
                }
            }
            #endregion

            #region Display Facebook Friends List in Datagrid
            if (mainFormComboBox.SelectedIndex == 2)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_friends_list";
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable friendListDataTable = new DataTable();
                    sqlDA.Fill(friendListDataTable);

                    databaseGridView.DataSource = friendListDataTable;

                } // End of using (MySqlConnection connection = ...
            }
            #endregion

            #region Display Facebook Messages in Datagrid
            else if (mainFormComboBox.SelectedIndex == 3)
            {

                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_messages";
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
            else if (mainFormComboBox.SelectedIndex == 4)
            {
                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_universities";
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
            else if (mainFormComboBox.SelectedIndex == 5)
            {
                using (MySqlConnection connection =
                    new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_workplace";
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

        #region // Used to Display the Data from the Datagrid into the Text box
        private void databaseGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            IndexRow = e.RowIndex;
            if (mainFormComboBox.SelectedIndex == 0)
            {
                if (IndexRow >= 0)
                {
                    DataGridViewRow row = this.databaseGridView.Rows[IndexRow];

                    txtUserID.Text = row.Cells["UserID"].Value.ToString();
                    txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                    txtLastName.Text = row.Cells["LastName"].Value.ToString();
                    txtGender.Text = row.Cells["Gender"].Value.ToString();
                    txtHometown.Text = row.Cells["Hometown"].Value.ToString();
                    txtCity.Text = row.Cells["City"].Value.ToString();
                }
            }
        }
        #endregion


        #region // Button Functionality on the Main Form

        #region Used to Update data in the Database
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                string Query = "update isad157_clong.facebook_users set UserID='" + this.txtUserID.Text + "' ,FirstName = '" + this.txtFirstName.Text + 
                    "',LastName='" + this.txtLastName.Text + "',Gender='" + this.txtGender.Text + 
                    "',Hometown='" + this.txtHometown.Text + "',City='" + this.txtCity.Text + 
                    "' where UserID='" + this.txtUserID.Text + "';";

                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConnection = new MySqlConnection(connectionString);
                MySqlCommand sqlcmd = new MySqlCommand(Query, MyConnection);
                MySqlDataReader MyReader2;
                MyConnection.Open();
                MyReader2 = sqlcmd.ExecuteReader();
                MessageBox.Show("User Details have been Updated!");
                while (MyReader2.Read())
                {
                }
                MyConnection.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Delete User Function
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "delete from isad157_clong.facebook_users where UserID='" + this.txtUserID.Text + "';";

                MySqlConnection MyConnection = new MySqlConnection(connectionString);
                MySqlCommand sqlcmd = new MySqlCommand(Query, MyConnection);
                MySqlDataReader MyReader2;

                MyConnection.Open();
                MyReader2 = sqlcmd.ExecuteReader();
                MessageBox.Show("Record has been deleted from the Database");
                while (MyReader2.Read())
                {
                }
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Exit Application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    } 
}
