using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Management_System
{
    public partial class Ministatement : Form
    {
        public Ministatement()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Withdraw wd = new Withdraw();
            wd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deposit dp = new Deposit();
            dp.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePin cp = new ChangePin();
            cp.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fastcash fc = new Fastcash();
            fc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ministatement ms = new Ministatement();
            ms.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\C#\ATM\Database\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "Select * from TransactionTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MinistatementDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        public void getUserName()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Fullname from AccTbl where AccNum = '" + Login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Username.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            populate(); 
        }

        private void Ministatement_Load(object sender, EventArgs e)
        {
            getUserName();
        }

        private void SeeAccountInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccInfo accinfo = new AccInfo();
            accinfo.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Delete from AccTbl where AccNum = '" + Login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Con.Close();
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
