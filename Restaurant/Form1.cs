using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=PREDATOR2023\\SQLEXPRESS;Initial Catalog=ibrdb;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
        }
  
        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click_1(object sender, EventArgs e)
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


                                Home mForm = new Home();
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

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Create c = new Create() ;
            this.Hide();
            c.Show();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '●';
        }
    }
}
