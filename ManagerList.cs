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
    public partial class ManagerList : Form
    {
        public ManagerList()
        {
            InitializeComponent();
        }

        private void ManagerList_Load(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM logintable order by username";

            OracleDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["username"].ToString();
                lsvItem.SubItems.Add(thisReader["password"].ToString());
                lsvItem.SubItems.Add(thisReader["password"].ToString());
                listView1.Items.Add(lsvItem);

            }

            CN.thisConnection.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminManagerCreate adminManagerCreate = new AdminManagerCreate();
            adminManagerCreate.Show();
            this.Hide();
        }
    }
}
