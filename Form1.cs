using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EmployeeManagementSystem
{
    public partial class Form1 : Form
    {
        //static string connectionString = "Data Source=PREDATOR2023\\SQLEXPRESS;Initial Catalog=ibrdb;Integrated Security=True;";
        SqlConnection connect = new SqlConnection("Data Source=PREDATOR2023\\SQLEXPRESS;Initial Catalog=ibrdb;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void login_btn_Click_1(object sender, EventArgs e)
        {
            // Get user input
            string username = login_username.Text.Trim();
            string password = login_password.Text.Trim();

            if ( username == ""
                || password == "")
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    string query = "SELECT COUNT(1) FROM users WHERE username = @username AND password = @password";
                    try
                    {
                        connect.Open();


                        using (SqlCommand cmd = new SqlCommand(query, connect))
                        {

                            // Add parameters to avoid SQL injection
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);


                            // Execute the query and check if the user exists
                            int userExists = Convert.ToInt32(cmd.ExecuteScalar());

                            if (userExists == 1)
                            {


                                MainForm mForm = new MainForm();
                                this.Hide();
                                mForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password"
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                        , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }

                }
            }
        }

        private void login_showPass_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '●';
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            // Get user input
            string username = login_username.Text.Trim();
            string password = login_password.Text.Trim();

            if (username == ""
                || password == "")
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkEmID = "SELECT COUNT(*) FROM users WHERE username = @username ";

                        using (SqlCommand checkUser = new SqlCommand(checkEmID, connect))
                        {
                            checkUser.Parameters.AddWithValue("@username", login_username.Text.Trim());
                            int count = (int)checkUser.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(login_username.Text.Trim() + " is already taken"
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                string insertData = "INSERT INTO users " +
                                    "(username,password) VALUES(@username,@password) ";


                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered successfully!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();

                    }
                }
            } 

        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        public void clearFields()
        {
            login_username.Text = "";
            login_password.Text = "";
    
        }

        private void reset_pass_Click(object sender, EventArgs e)
        {
            string username = login_username.Text.Trim();
            string password = login_password.Text.Trim();

            if (username == ""
                || password == "")
            {
                MessageBox.Show("Please fill all blank fields"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkEmID = "SELECT COUNT(*) FROM users WHERE username = @username ";

                        using (SqlCommand checkUser = new SqlCommand(checkEmID, connect))
                        {
                            checkUser.Parameters.AddWithValue("@username", login_username.Text.Trim());
                            int count = (int)checkUser.ExecuteScalar();

                            if (count == 0)
                            {
                                MessageBox.Show(login_username.Text.Trim() + " Username Not Found "
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                string updateData = "UPDATE users SET password = @password WHERE username = @username";


                                using (SqlCommand cmd = new SqlCommand(updateData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Password Updated Successfully!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();

                    }
                }
            }
        }
    }
}
