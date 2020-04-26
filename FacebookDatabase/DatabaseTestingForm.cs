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
using System.IO;

namespace FacebookDatabase
{
    public partial class FacebookTestingForm : Form
    {
        #region // Variables

        int IndexRow;

        // store our SQL Log in details from the DBConnect class in the connectionString variable
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
                // Create an open connection to a MySQL Server database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_users"; // Creates a query to display all data stored in facebook_users table in our data grid view
                    connection.Open(); // Open a Database Connection

                    // Submit the SQL statement to be executed against the MySQL database.
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // The MySqlDataAdapter represents a set of data commands and a database connection that are used to fill a dataset and update a MySQL database.
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable userDataTable = new DataTable();
                    sqlDA.Fill(userDataTable);

                    // Bind the Facebook_User table to the Data Grid View.
                    databaseGridView.DataSource = userDataTable;

                } // End of using (MySqlConnection connection = ...
            }
            #endregion

            #region Display Facebook Friends in Datagrid
            if (mainFormComboBox.SelectedIndex == 1)
            {
                // Create an open connection to a MySQL Server database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_friendships"; // Creates a query to display all data stored in facebook_friendships table in our data grid view
                    connection.Open(); // Open a Database Connection

                    // Submit the SQL statement to be executed against the MySQL database.
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // The MySqlDataAdapter represents a set of data commands and a database connection that are used to fill a dataset and update a MySQL database.
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable friendshipsDataTable = new DataTable();
                    sqlDA.Fill(friendshipsDataTable);

                    // Bind the Facebook_friendships table to the Data Grid View.
                    databaseGridView.DataSource = friendshipsDataTable;
                }
            }
            #endregion

            #region Display Facebook Friends List in Datagrid
            if (mainFormComboBox.SelectedIndex == 2)
            {
                // Create an open connection to a MySQL Server database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_friends_list"; // Creates a query to display all data stored in facebook_friends_list table in our data grid view
                    connection.Open(); // Open a Database Connection

                    // Submit the SQL statement to be executed against the MySQL database.
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // The MySqlDataAdapter represents a set of data commands and a database connection that are used to fill a dataset and update a MySQL database.
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable friendListDataTable = new DataTable();
                    sqlDA.Fill(friendListDataTable);

                    // Bind the Facebook_Friend_List table to the Data Grid View.
                    databaseGridView.DataSource = friendListDataTable;

                } // End of using (MySqlConnection connection = ...
            }
            #endregion

            #region Display Facebook Messages in Datagrid
            if (mainFormComboBox.SelectedIndex == 3)
            {
                // Create an open connection to a MySQL Server database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_messages"; // Creates a query to display all data stored in facebook_messages table in our data grid view
                    connection.Open(); // Open a Database Connection

                    // Submit the SQL statement to be executed against the MySQL database.
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // The MySqlDataAdapter represents a set of data commands and a database connection that are used to fill a dataset and update a MySQL database.
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable messagesDataTable = new DataTable();
                    sqlDA.Fill(messagesDataTable);

                    // Bind the Facebook_Messages table to the Data Grid View.
                    databaseGridView.DataSource = messagesDataTable;
                }
            }
            #endregion

            #region Display Facebook Users Universities in Datagrid
            if (mainFormComboBox.SelectedIndex == 4)
            {
                // Create an open connection to a MySQL Server database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_universities"; // Creates a query to display all data stored in facebook_universities table in our data grid view
                    connection.Open(); // Open a Database Connection

                    // Submit the SQL statement to be executed against the MySQL database.
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // The MySqlDataAdapter represents a set of data commands and a database connection that are used to fill a dataset and update a MySQL database.
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable universitiesDataTable = new DataTable();
                    sqlDA.Fill(universitiesDataTable);

                    // Bind the Facebook_Universities table to the Data Grid View.
                    databaseGridView.DataSource = universitiesDataTable;
                }
            }
            #endregion

            #region Display Facebook User Workplaces in Datagrid
            if (mainFormComboBox.SelectedIndex == 5)
            {
                // Create an open connection to a MySQL Server database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT * FROM isad157_clong.facebook_workplace"; // Creates a query to display all data stored in facebook_workplace table in our data grid view
                    connection.Open(); // Open a Database Connection

                    // Submit the SQL statement to be executed against the MySQL database.
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // The MySqlDataAdapter represents a set of data commands and a database connection that are used to fill a dataset and update a MySQL database.
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable workplaceDataTable = new DataTable();
                    sqlDA.Fill(workplaceDataTable);

                    // Bind the Facebook_Workplace table to the Data Grid View.
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

            //If our selected index is equal to 0 (Facebook_users table), display selected rows in our text boxes
            if (mainFormComboBox.SelectedIndex == 0)
            {
                if (IndexRow >= 0)
                {
                    //Stores our selected row
                    DataGridViewRow row = this.databaseGridView.Rows[IndexRow];

                    //The stored selected row is displayed properly in our text boxes and are all converted to Strings
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


        #region // Update User Method
        private void UpdateUserDetails()
        {
            bool allUserDataIsOk = false; // Create a bool to set whether input is null or not
            allUserDataIsOk = notNullTextBox(txtFirstName, txtLastName, txtGender, txtHometown, txtCity, "User Details");  // Checks to see if our text boxes are null

            if (allUserDataIsOk)
            {
                try
                {
                    //An Update Query which links our Windows Form to our Database and replaces the record that has been selected with the data in the Text Boxes 
                    string UpdateQuery = "update isad157_clong.facebook_users set UserID='" + this.txtUserID.Text + "' ,FirstName = '" + this.txtFirstName.Text +
                        "',LastName='" + this.txtLastName.Text + "',Gender='" + this.txtGender.Text +
                        "',Hometown='" + this.txtHometown.Text + "',City='" + this.txtCity.Text +
                        "' where UserID='" + this.txtUserID.Text + "';";

                    //Creates a connection between our Windows form and our Database
                    MySqlConnection MyConnection = new MySqlConnection(connectionString);
                    MySqlCommand sqlcmd = new MySqlCommand(UpdateQuery, MyConnection);
                    MySqlDataReader QueryReader;

                    //Opens the connection to our database
                    MyConnection.Open();
                    QueryReader = sqlcmd.ExecuteReader();

                    //Displays a message informing the User that the details were successfully changed
                    MessageBox.Show("User Details have been Updated!");
                    while (QueryReader.Read())
                    {
                    }
                    //Close Database Connection
                    MyConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region // Delete User Method
        private void DeleteUserFunction()
        {
            try
            {
                // Creates a Query which deletes a record located in the facebook_users table that is being display in the USER ID Text Box on the windows form
                string DeleteQuery = "delete from isad157_clong.facebook_users where UserID='" + this.txtUserID.Text + "';";

                // Creates a connection between Visual Studio and My SQL Workbench
                MySqlConnection MyConnection = new MySqlConnection(connectionString);
                MySqlCommand sqlcmd = new MySqlCommand(DeleteQuery, MyConnection);
                MySqlDataReader QueryReader;

                //Opens the Connection
                MyConnection.Open();
                QueryReader = sqlcmd.ExecuteReader();

                //Displays the message if a record has been removed from the database
                MessageBox.Show("Record has been deleted from the Database");
                while (QueryReader.Read())
                {
                }
                //Close Database Connection
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region // Button Functionality on the Main Form

        #region Used to Update data in the Database
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateUserDetails();
        }
        #endregion

        #region Delete User Function
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteUserFunction();
        }
        #endregion

        #region Exit Application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Closes the Windows Form Application
        }
        #endregion

        #endregion


        #region // Exception Handling
        private bool notNullTextBox(TextBox txtFirstName, TextBox txtLastName, TextBox txtGender, TextBox txtHometown, TextBox txtCity, String userFeedback)
        {
            if (txtFirstName.Text  == "" || txtLastName.Text == "" || txtGender.Text == "" || txtHometown.Text == "" || txtCity.Text == "")
            {
                // Generate error message if input box is empty!
                MessageBox.Show("ERROR - Text Box is missing " + userFeedback + " and they can't be empty!. Please fill in the missing Text Box/s");
                return false;
            }
            else
                return true;
        }
        #endregion
    }
}
