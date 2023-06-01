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
    public partial class Fastcash : Form
    {
        public Fastcash()
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

        private void Fastcash_Load(object sender, EventArgs e)
        {
            get_balance();
            getUserName();
        }

        private void Balancelbl_Click(object sender, EventArgs e)
        {

        }
        public int bal;
        public void get_balance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Balance from AccTbl where AccNum = '" + Login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Balancelbl.Text = "Balance: Rs. " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void add_transaction(int amt)
        {
            string trtype = "WithDraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + trtype + "','" + amt.ToString() + "','" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void fcash(int amount)
        {
            if (bal < amount)
            {
                MessageBox.Show("Insufficient balance");
            }
            else
            {
                try
                {
                    int newBalance = bal - amount;
                    string Acc = Login.AccNumber;
                    Con.Open();
                    string query = "update AccTbl set Balance = '"+newBalance+"' where AccNum = '" + Acc + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdrawn successfully");
                    Con.Close();
                    add_transaction(amount);
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
            fcash(100);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            fcash(500);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fcash(1000);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            fcash(2000);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fcash(5000);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            fcash(10000);
        }

        private void Username_Click(object sender, EventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
