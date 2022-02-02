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
    public partial class ManagerDeleteBook : Form
    {
        public ManagerDeleteBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            con.thisConnection.Open();
            OracleCommand thisCommand1 = con.thisConnection.CreateCommand();

            if (comboBox1.SelectedIndex == 0)
            {
                thisCommand1.CommandText =
                            "delete managerbookentry where bookname LIKE '%" + textBox1.Text + "%'";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                thisCommand1.CommandText =
                                            "delete managerbookentry where writername LIKE '%" + textBox1.Text + "%'";
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                thisCommand1.CommandText =
                                            "delete managerbookentry where categoryname LIKE '%" + textBox1.Text + "%'";
            }
            


            thisCommand1.Connection = con.thisConnection;
            thisCommand1.CommandType = CommandType.Text;
            try
            {
                thisCommand1.ExecuteNonQuery();
                MessageBox.Show("Book Deleted from Stock");
                this.Hide();
                ManagerHome ob = new ManagerHome();
                ob.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerHome ob = new ManagerHome();
            ob.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagerHome managerHome = new ManagerHome();
            managerHome.Show();
            this.Hide();
        }
    }
}
