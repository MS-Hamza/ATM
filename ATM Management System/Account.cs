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
namespace ATM_Management_System
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Account_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\C#\ATM\Database\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            
            int bal = 0;
            if(AccNumtb.Text == "" || FullNametb.Text == "" || FatherNametb.Text == "" || Addresstb.Text == "" || Pintb.Text == "" || Occupationcb.Text == "" || Educationcb.Text == "" || Phonetb.Text == "" || DOBtb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AccTbl values('"+AccNumtb.Text+"','"+FullNametb.Text+"','"+FatherNametb.Text+"','"+Addresstb.Text+"','"+Pintb.Text+"','"+Occupationcb.SelectedItem.ToString()+"','"+Educationcb.SelectedItem.ToString()+"','"+Phonetb.Text+"','"+DOBtb.Text+"','"+bal+"')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully");
                    Con.Close();
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
