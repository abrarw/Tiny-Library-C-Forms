using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyLibraryManagementSystem
{
    public partial class ManagerHome : Form
    {
        public ManagerHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerNewBookEntry managerNewBookEntry = new ManagerNewBookEntry();
            managerNewBookEntry.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerEditBookInfo obj = new ManagerEditBookInfo();
            obj.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManagerDeleteBook managerDeleteBook = new ManagerDeleteBook();
            managerDeleteBook.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagerBookSearch managerBookSearch = new ManagerBookSearch();
            managerBookSearch.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ManagerEditBookInfo managerEditBookInfo = new ManagerEditBookInfo();
            managerEditBookInfo.Show();
            this.Hide();
        }
    }
}
