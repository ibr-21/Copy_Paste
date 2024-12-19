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
using TheArtOfDev.HtmlRenderer.Adapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Restaurant
{
    
    public partial class Sepetim : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;
        public Sepetim()
        {
            InitializeComponent();
        }
        void GetCustomers()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurant.accdb ");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Costumer ", conn);
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Yecekler y = new Yecekler();
            this.Hide();
            y.ShowDialog();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            İçecekler c = new İçecekler();
            this.Hide();
            c.ShowDialog();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Tatlılar t = new Tatlılar();
            this.Hide();
            t.ShowDialog();
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            this.Hide();
            a.ShowDialog();
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Sepetim s = new Sepetim();
            this.Hide();
            s.ShowDialog();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurant.accdb ");
            conn.Open();


            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT* FROM Masa (Masa,Tatlı, Yemek, İçecek, Yecek_Adet, İçecek_Adet, Tatlı_Adet, Ücret) " +
                              "VALUES (@Masa, @Tatlı, @Yecek, @İçecek, @Yecek_Adet, @İçecek_Adet, @Tatlı_Adet, @Ücret)";

            DataTable table = new DataTable();
            adapter.Fill(table);
            SepetView.DataSource = table;


            Masa.Text = SepetView.CurrentRow.Cells[1].Value.ToString();
            Tatlı.Text = SepetView.CurrentRow.Cells[2].Value.ToString();
            Yecek.Text = SepetView.CurrentRow.Cells[3].Value.ToString();
            İçecek.Text = SepetView.CurrentRow.Cells[4].Value.ToString();
            Yecek_Adet.Text = SepetView.CurrentRow.Cells[5].Value.ToString();
            İçecek_Adet.Text = SepetView.CurrentRow.Cells[6].Value.ToString();
            Tatlı_Adet.Text = SepetView.CurrentRow.Cells[7].Value.ToString();
            Ücret.Text = SepetView.CurrentRow.Cells[8].Value.ToString();
        }

        private void Sepetim_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton28_Click(object sender, EventArgs e)
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
        }

        private void bunifuButton27_Click(object sender, EventArgs e)
        {
            string delet = "DELETE FROM Masa WHERE Masa= @Masa";

            cmd = new OleDbCommand(delet, conn);
            cmd.Parameters.AddWithValue("@Masa", Masa.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("sipariş Silindi");
            GetCustomers();
        }

        private void bunifuButton29_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurant.accdb"))
                {
                    conn.Open();

                    string updateQuery = @"UPDATE Masa
                                  SET 
                                      Tatlı = @Tatlı,
                                      Yemek = @Yemek,
                                      İçecek = @İçecek,
                                      Yecek_Adet = @Yecek_Adet,
                                      İçecek_Adet = @İçecek_Adet,
                                      Tatlı_Adet = @Tatlı_Adet,
                                      Ücret = @Ücret
                                  WHERE Masa = @Masa";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Tatlı", Tatlı.Text);
                        cmd.Parameters.AddWithValue("@Yemek", Yecek.Text);
                        cmd.Parameters.AddWithValue("@İçecek", İçecek.Text);
                        cmd.Parameters.AddWithValue("@Yecek_Adet", Yecek_Adet.Text);
                        cmd.Parameters.AddWithValue("@İçecek_Adet", İçecek_Adet.Text);
                        cmd.Parameters.AddWithValue("@Tatlı_Adet", Tatlı_Adet.Text);
                        cmd.Parameters.AddWithValue("@Ücret", Ücret.Text);
                        cmd.Parameters.AddWithValue("@Masa", Masa.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sipariş düzenlendi");
                        }
                        else
                        {
                            MessageBox.Show("Bu Sipariş bulunmadı");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
            GetCustomers();
        }


        private void Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurant.accdb ");
                adapter = new OleDbDataAdapter("SELECT * FROM Masa", conn);

                dt = new DataTable();
                adapter.Fill(dt);
                SepetView.DataSource = dt;

                DataView dv = dt.DefaultView;
                int searchValue;
                if (int.TryParse(Search.Text, out searchValue))
                {
                    dv.RowFilter = $"Masa = {searchValue}";
                    SepetView.DataSource = dv;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Ücret_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton219_Click(object sender, EventArgs e)
        {

            Sipariş s = new Sipariş();
            this.Hide();
            s.ShowDialog();
        }
    }
}
