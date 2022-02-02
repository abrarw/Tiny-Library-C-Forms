using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace TinyLibraryManagementSystem
{
    public partial class ManagerEditBookInfo : Form
    {
        public ManagerEditBookInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = CN.thisConnection.CreateCommand();
            if (comboBox1.SelectedIndex == 0)
            {
                thisCommand.CommandText = "SELECT * FROM managerbookentry where bookname LIKE '%" + textBox1.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                thisCommand.CommandText = "SELECT * FROM managerbookentry where writername LIKE '%" + textBox1.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                thisCommand.CommandText = "SELECT * FROM managerbookentry where categoryname LIKE '%" + textBox1.Text + "%'";
            }
            listView1.Clear();
            listView2.Clear();
            listView3.Clear();
            listView4.Clear();
            listView5.Clear();
            listView6.Clear();

            try
            {
                OracleDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    ListViewItem lsvItem2 = new ListViewItem();
                    ListViewItem lsvItem3 = new ListViewItem();
                    ListViewItem lsvItem4 = new ListViewItem();
                    ListViewItem lsvItem5 = new ListViewItem();
                    ListViewItem lsvItem6 = new ListViewItem();
                    lsvItem.Text = thisReader["quantityofbook"].ToString();
                    lsvItem2.Text = thisReader["bookname"].ToString();
                    lsvItem3.Text = thisReader["bookpublishyear"].ToString();
                    lsvItem4.Text = thisReader["writername"].ToString();
                    lsvItem5.Text = thisReader["categoryname"].ToString();
                    lsvItem6.Text = thisReader["entrydate"].ToString();
                    listView1.Items.Add(lsvItem);
                    listView2.Items.Add(lsvItem2);
                    listView3.Items.Add(lsvItem3);
                    listView4.Items.Add(lsvItem4);
                    listView5.Items.Add(lsvItem5);
                    listView6.Items.Add(lsvItem6);
                    

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please enter a category for search");
                ManagerEditBookInfo managerEditBookInfo = new ManagerEditBookInfo();
                managerEditBookInfo.Show();
                this.Hide();
            }

            CN.thisConnection.Close();


        }

        private void ManagerEditBookInfo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            OracleCommand thisCommand = sv.thisConnection.CreateCommand();

            if (comboBox1.SelectedIndex == 0)
            {
                thisCommand.CommandText = "UPDATE managerbookentry SET quantityofbook = '" + textBox2.Text + "'where bookname LIKE '%" + textBox1.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                thisCommand.CommandText = "UPDATE managerbookentry SET quantityofbook = '" + textBox2.Text + "'where writername LIKE '%" + textBox1.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                thisCommand.CommandText = "UPDATE managerbookentry SET quantityofbook = '" + textBox2.Text + "'where categoryname LIKE '%" + textBox1.Text + "%'";
            }
           

            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;
            try
            {
                thisCommand.ExecuteNonQuery();
                MessageBox.Show("Updated Quantity in stock");
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sv.thisConnection.Close();
            this.Close();

            ManagerHome ob = new ManagerHome();
            ob.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagerHome ob = new ManagerHome();
            ob.Show();
            this.Hide();

        }
    }
}
