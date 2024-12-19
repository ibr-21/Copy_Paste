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
using System.Windows.Forms.DataVisualization.Charting;

namespace Restaurant
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {

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

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Sepetim s = new Sepetim();
            this.Hide();
            s.ShowDialog();
        }

  

        private void bunifuButton218_Click(object sender, EventArgs e)
        {
            Yecekler y = new Yecekler();
            this.Hide();
            y.ShowDialog();

        }

        private void bunifuButton219_Click(object sender, EventArgs e)
        {
            Sipariş s = new Sipariş();
            this.Hide();
            s.ShowDialog();
        }

        private void bunifuButton27_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton28_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton211_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton210_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton29_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton212_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton213_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton214_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurant.accdb");
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Yecek_Adet, Tatlı_Adet, İçecek_Adet FROM Masa", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                chart1.DataSource = dt;
                chart1.Series.Clear();
                chart1.Series.Add("Yemek");
                chart1.Series.Add("Tatlı");
                chart1.Series.Add("İçecek");

                int rowIndex = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int yemekAdet = Convert.ToInt32(row["Yecek_Adet"]);
                    int tatliAdet = Convert.ToInt32(row["Tatlı_Adet"]);
                    int icecekAdet = Convert.ToInt32(row["İçecek_Adet"]);

                    chart1.Series["Yemek"].Points.AddXY(rowIndex, yemekAdet);
                    chart1.Series["Tatlı"].Points.AddXY(rowIndex, tatliAdet);
                    chart1.Series["İçecek"].Points.AddXY(rowIndex, icecekAdet);

                    rowIndex++;
                }

                chart1.Series["Yemek"].ChartType = SeriesChartType.Column;
                chart1.Series["Tatlı"].ChartType = SeriesChartType.Column;
                chart1.Series["İçecek"].ChartType = SeriesChartType.Column;
                chart1.ChartAreas[0].AxisX.Title = "Siparişler";
                chart1.ChartAreas[0].AxisY.Title = "Adet";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
