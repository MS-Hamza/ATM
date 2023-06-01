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
    public partial class AccInfo : Form
    {
        public AccInfo()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\C#\ATM\Database\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        public void get_acc()
        {
            Con.Open();
            string query = "Select AccNum from AccTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Acclbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        public void get_name()
        {
            Con.Open();
            string query = "Select Fullname from AccTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Namelbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        public void get_fname()
        {
            Con.Open();
            string query = "Select Fathername from AccTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            fnamelbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        public void get_add()
        {
            Con.Open();
            string query = "Select Address from AccTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            addlbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        public void get_occ()
        {
            Con.Open();
            string query = "Select Occupation from AccTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Occlbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        public void get_edu()
        {
            Con.Open();
            string query = "Select Education from AccTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Edulbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        public void get_phone()
        {
            Con.Open();
            string query = "Select Phone from AccTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Phonelbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        public void get_dob()
        {
            Con.Open();
            string query = "Select DOB from AccTbl where AccNum = '" + Login.AccNumber + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            doblbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void AccInfo_Load(object sender, EventArgs e)
        {
            get_acc();
            get_name();
            get_fname();
            get_add();
            get_edu();
            get_occ();
            get_phone();
            get_dob();
            getUserName();
        }

        private void SeeAccountInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AccInfo accInfo = new AccInfo();
                accInfo.Show();
                this.Hide();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Username_Click(object sender, EventArgs e)
        {

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

        private void button7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
