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
    public partial class ManagerNewBookEntry : Form
    {
        public ManagerNewBookEntry()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM managerbookentry", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "managerbookentry");

            DataRow thisRow = thisDataSet.Tables["managerbookentry"].NewRow();
            try
            {

                thisRow["bookname"] = textBox1.Text;
                thisRow["bookpublishyear"] = textBox2.Text;
                thisRow["writername"] = textBox3.Text;
                thisRow["quantityofbook"] = textBox4.Text;
                thisRow["categoryname"] = textBox5.Text;
                thisRow["entrydate"] = dateTimePicker1.Value;




                thisDataSet.Tables["managerbookentry"].Rows.Add(thisRow);



                thisAdapter.Update(thisDataSet, "managerbookentry");
                MessageBox.Show("Book added in inventory.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

            ManagerNewBookEntry ob = new ManagerNewBookEntry();
            ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerHome obj = new ManagerHome();
            obj.Show();
            this.Hide();
        }

        private void ManagerNewBookEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
