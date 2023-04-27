using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInfoTask
{
 
    public partial class Form1 : Form
    {
        Customer model = new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();    

        }

        void Clear()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            button1.Text = "Запази";
            button2.Enabled = false;
            model.CustomerID = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
            PopulateDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.FirstName = textBox1.Text.Trim();
            model.LastName = textBox2.Text.Trim();
            model.City = textBox3.Text.Trim();
            model.Address = textBox4.Text.Trim();
            using (EF_DBEntities db = new EF_DBEntities())
            {
                if (model.CustomerID == 0)
                    db.Customer.Add(model);
                else
                    db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            Clear();
            PopulateDataGridView();
            MessageBox.Show("Данните са запазени!");
        }

        void PopulateDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            using(EF_DBEntities db = new EF_DBEntities())
            {
                dataGridView1.DataSource = db.Customer.ToList<Customer>();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                model.CustomerID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CustomerID"].Value);
                using(EF_DBEntities db = new EF_DBEntities())
                {
                    model = db.Customer.Where(x => x.CustomerID == model.CustomerID).FirstOrDefault();
                    textBox1.Text = model.FirstName;
                    textBox2.Text = model.LastName;
                    textBox3.Text = model.City;
                    textBox4.Text = model.Address;
                }
                button1.Text = "Update";
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Сигурен ли си, че искаш да изтриеш записа?", "EF CRUD Операция", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using(EF_DBEntities db = new EF_DBEntities())
                {
                    var entry = db.Entry(model);
                    if (entry.State == EntityState.Detached)
                        db.Customer.Attach(model);
                    db.Customer.Remove(model);
                    db.SaveChanges();
                    PopulateDataGridView();
                    Clear();
                    MessageBox.Show("Успешно изтрит запис!");
                }
            }
        }
    }
}
