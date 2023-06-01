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
    public partial class Withdraw : Form
    {
        public Withdraw()
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
        private void add_transaction()
        {
            string trtype = "Withraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + trtype + "','" + WithdrawAmttb.Text + "','" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (WithdrawAmttb.Text == "")
            {
                MessageBox.Show("Enter amount to deposit");
            }else if(Convert.ToInt32(WithdrawAmttb.Text) <= 0)
            {
                MessageBox.Show("Enter a valid amount");
            }else if(Convert.ToInt32(WithdrawAmttb.Text) > bal)
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                try
                {
                    string Acc = Login.AccNumber;
                    Con.Open();
                    string query = "update AccTbl set Balance = Balance - " + WithdrawAmttb.Text + " where AccNum = '" + Acc + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdrawn successfully");
                    Con.Close();
                    add_transaction();
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

        private void Withdraw_Load(object sender, EventArgs e)
        {
            get_balance();
            getUserName();
        }
        public int bal;
        public void get_balance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Balance from AccTbl where AccNum = '" + Login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label5.Text = "Rs. " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
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
