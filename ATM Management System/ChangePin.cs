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
    public partial class ChangePin : Form
    {
        public ChangePin()
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
       
        private void ChangePin_Load(object sender, EventArgs e)
        {
            getUserName();
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
        private void button8_Click(object sender, EventArgs e)
        {
            if (Pin1tb.Text == "" || Pin2tb.Text == "")
            {
                MessageBox.Show("Complete the fields");
            }
            if(Pin1tb.Text != Pin2tb.Text)
            {
                MessageBox.Show("Enter and Confirm new Password correctly");
            }
            else{
                try
                {
                    string Acc = Login.AccNumber;
                    Con.Open();
                    string query = "update AccTbl set Pin = " + Pin1tb.Text + " where AccNum = '" + Acc + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pin Changed successfully");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
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

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
