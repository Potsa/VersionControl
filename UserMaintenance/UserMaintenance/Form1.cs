using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            lblFullName.Text = Resource.FullName; // label1
            btnAdd.Text = Resource.Add; // button1
            btnMentes.Text = Resource.Save_to_file;
            btnDelete.Text = Resource.Delete;
            btnAdd.Click += BtnAdd_Click;
            btnMentes.Click += BtnMentes_Click;
            btnDelete.Click += BtnDelete_Click;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var o = listUsers.SelectedItem;
            users.Remove(o);
        }

        private void BtnMentes_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt file (*.txt)|*.txt";
            sfd.Title = "Mentés";
            sfd.ShowDialog();
            sfd.ShowDialog();

            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                sw.WriteLine(string.Format("ID:", listUsers.ValueMember));
                sw.WriteLine(string.Format("Full Name:", listUsers.DisplayMember));
                
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var u = new Entities.User()
            {
                FullName = textBox1.Text
            };
            users.Add(u);
        }
    }
}
