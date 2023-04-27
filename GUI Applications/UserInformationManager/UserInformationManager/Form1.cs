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

namespace UserInformationManager
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=desktop-aapmf08;Initial Catalog=UserInfoDB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        string sex;
        int ID = 0;

        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from UserInfo", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
            {
                cmd = new SqlCommand("insert into UserInfo(FirstName,LastName,Department,Sex)values(@firstname,@lastname, @department, @sex)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                cmd.Parameters.AddWithValue("@department", textBox4.Text);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Потребителят е запазен успешно!");
                DisplayData();
            }
            else
            {
                MessageBox.Show("Моля, попълнете всичките полета!");
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete UserInfo where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Записът е изтрит!");
                DisplayData();
            }
            else
            {
                MessageBox.Show("Трябва да избереш запис от таблицата!");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            sex = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void GetSexRadioButton(object sender, EventArgs e)
        {
            sex = ((RadioButton)sender).Text;
        }

    }


}
