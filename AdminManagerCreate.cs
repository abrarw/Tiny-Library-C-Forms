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
    public partial class AdminManagerCreate : Form
    {
        public AdminManagerCreate()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM logintable", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "logintable");

            DataRow thisRow = thisDataSet.Tables["logintable"].NewRow();
            try
            {

                thisRow["username"] = textBox1.Text;
                thisRow["password"] = textBox2.Text;
                thisDataSet.Tables["logintable"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "logintable");
                MessageBox.Show("Data Submitted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
            AdminManagerCreate ob = new AdminManagerCreate();
            ob.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            con.thisConnection.Open();
            OracleCommand thisCommand1 = con.thisConnection.CreateCommand();
            thisCommand1.CommandText =
                "delete logintable where username= '" + textBox3.Text + "'";

            thisCommand1.Connection = con.thisConnection;
            thisCommand1.CommandType = CommandType.Text;
            try
            {
                thisCommand1.ExecuteNonQuery();
                MessageBox.Show("User Deleted");
                this.Hide();
                AdminManagerCreate ob = new AdminManagerCreate();
                ob.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagerList managerList = new ManagerList();
            managerList.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
            this.Hide();
        }
    }
}
