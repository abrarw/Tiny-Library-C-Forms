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
    public partial class ManagerBookSearch : Form
    {
        public ManagerBookSearch()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ManagerBookSearch_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerHome managerHome = new ManagerHome();
            managerHome.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            connection CN = new connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            listView1.Items.Clear();

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
          

            try
            {

                OracleDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader["bookname"].ToString();
                    lsvItem.SubItems.Add(thisReader["writername"].ToString());
                    lsvItem.SubItems.Add(thisReader["entrydate"].ToString());
                    lsvItem.SubItems.Add(thisReader["quantityofbook"].ToString());
                    lsvItem.SubItems.Add(thisReader["categoryname"].ToString());

                    listView1.Items.Add(lsvItem);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a category for search");
                ManagerBookSearch managerBookSearch = new ManagerBookSearch();
                managerBookSearch.Show();
                this.Hide();
            }
                
            
            CN.thisConnection.Close();
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM managerbookentry order by bookname";



            OracleDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["bookname"].ToString();
                lsvItem.SubItems.Add(thisReader["writername"].ToString());
                lsvItem.SubItems.Add(thisReader["entrydate"].ToString());
                lsvItem.SubItems.Add(thisReader["quantityofbook"].ToString());
                lsvItem.SubItems.Add(thisReader["categoryname"].ToString());
                listView1.Items.Add(lsvItem);

            }

            CN.thisConnection.Close();
        }

        

        private void button4_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}
