using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Restaurant
{
    public partial class Sipariş : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;
        public Sipariş()
        {
            InitializeComponent();
        }
        void GetCustomers()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurant.accdb ");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Masa ", conn);
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
        }

        private void bunifuButton28_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton27_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton29_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton215_Click(object sender, EventArgs e)
        {
            try
            {

                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurant.accdb ");
                conn.Open();


                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO Masa (Masa,Tatlı, Yemek, İçecek, Yecek_Adet, İçecek_Adet, Tatlı_Adet, Ücret) " +
                                  "VALUES (@Masa, @Tatlı, @Yecek, @İçecek, @Yecek_Adet, @İçecek_Adet, @Tatlı_Adet, @Ücret)";


                cmd.Parameters.AddWithValue("@Masa", Masa.Text);
                cmd.Parameters.AddWithValue("@Tatlı", Tatlı.Text);
                cmd.Parameters.AddWithValue("@Yecek", Yecek.Text);
                cmd.Parameters.AddWithValue("@İçecek", İçecek.Text);
                cmd.Parameters.AddWithValue("@Yecek_Adet", Yecek_Adet.Text);
                cmd.Parameters.AddWithValue("@İçecek_Adet", İçecek_Adet.Text);
                cmd.Parameters.AddWithValue("@Tatlı_Adet", Tatlı_Adet.Text);
                cmd.Parameters.AddWithValue("@Ücret", Ücret.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Sipariş verildi");
                GetCustomers();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            /*
             conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurant.accdb ");
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Masa ( Tatlı, Yecek, İçecek, Yecek_Adet, İçecek_Adet, Tatlı_Adet, Ücret) " +
                              "VALUES ( @Tatlı, @Yecek, @İçecek, @Yecek_Adet, @İçecek_Adet, @Tatlı_Adet, @Ücret)";


            //cmd = new OleDbCommand(Sipar, conn);
           // cmd.Parameters.AddWithValue("@Id", Masa);
            cmd.Parameters.AddWithValue("@Tatlı", Tatlı.Text);
            cmd.Parameters.AddWithValue("@Yecek", Yecek.Text);
            cmd.Parameters.AddWithValue("@İçecek", İçecek.Text);
            cmd.Parameters.AddWithValue("@Yecek_Adet", Yecek_Adet.Text);
            cmd.Parameters.AddWithValue("@İçecek_Adet", İçecek_Adet.Text);
            cmd.Parameters.AddWithValue("@Ücret", Ücret.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sipariş verildi");
            GetCustomers();*/
        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuIconButton2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.ShowDialog();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tatlı_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void Sipariş_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Tatlı_Adet_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void İçecek_TextChanged(object sender, EventArgs e)
        {

        }

        private void İçecek_Adet_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Yecek_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Masa_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void Ücret_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
