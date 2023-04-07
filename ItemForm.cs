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


namespace CafeManagement
{
    public partial class ItemForm : Form
    {
        public ItemForm()
        {
            InitializeComponent();
            date.Text = DateTime.Today.ToShortDateString();

        }
        SqlConnection con = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Teste99;Integrated Security=True");
        void populate()
        {
            con.Open();
            string query = "select * from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UsersGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder order = new UserOrder();
            order.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (itemNumTb.Text == "" || itemNameTb.Text == "" || itemPriceTb.Text == "")
            {
                MessageBox.Show(" Complete todos os campos");

            }
            else
            {
                con.Open();
                string query = "update ItemTbl set ItemNum= '" + itemNumTb.Text + "',ItemPrice= '" + itemPriceTb.Text + "',ItemCat= '" + ItemCat.SelectedItem.ToString() + "' Where ItemName = '" + itemNameTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario atualizado com sucesso");
                con.Close();
                populate();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (itemNameTb.Text == "" || itemNumTb.Text == "" || itemPriceTb.Text == "")
            {
                MessageBox.Show("Preencha todos os dados");
            }
            else
            {
                con.Open();
                string query = "insert into ItemTbl values('" + (itemNumTb.Text + "','" + itemNameTb.Text + "','" + ItemCat.SelectedItem.ToString() + "','" + itemPriceTb.Text + "')");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario Criado com Sucesso");
                con.Close();
                populate();

            }


        }

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemNumTb.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
            itemNameTb.Text = UsersGV.SelectedRows[0].Cells[1].Value.ToString();
            ItemCat.Text = UsersGV.SelectedRows[0].Cells[2].Value.ToString();
            itemPriceTb.Text = UsersGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            populate();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (itemNumTb.Text == "")
            {
                MessageBox.Show("Escolha o Usuario a ser deletado");

            }
            else
            {
                con.Open();
                string query = "delete from ItemTbl where ItemNum = '" + itemNumTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Item deletado com sucesso");
                con.Close();
                populate();

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserFormcs user = new UserFormcs();
            user.Show();
        }

        private void date_Click(object sender, EventArgs e)
        {

        }


    }
}





