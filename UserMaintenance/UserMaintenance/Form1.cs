using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<Entities.User> users = new BindingList<Entities.User>();

        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource.LastName; // label1
            lblFirstName.Text = Resource.FirstName; // label2
            btnAdd.Text = Resource.Add; // button1
            btnAdd.Click += BtnAdd_Click;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var u = new Entities.User()
            {
                LastName = textBox1.Text,
                FirstName = textBox2.Text
            };
            users.Add(u);
        }
    }
}
