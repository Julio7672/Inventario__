using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;

namespace CafeManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Password.Text = "";
            Password.PasswordChar = '*';
        }
        SqlConnection con = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Teste99;Integrated Security=True");

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder guest = new GuestOrder();
            guest.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static string user;


        private void button1_Click(object sender, EventArgs e)
        {
            user = LgName.Text;

            if (LgName.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Insira o usuario e senha");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count (*) from UsersTbl where Uname = '" + LgName.Text + "'and Upassword = '" + Password.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    UserOrder uorder = new UserOrder();
                    uorder.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Senha ou usuario invalidos");
                }
                con.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}