using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinForm
{
    public partial class EFModelInsert : Form
    {
        public EFModelInsert()
        {
            InitializeComponent();
        }

        private void EFModelInsert_Load(object sender, EventArgs e)
        {
            Text = @"Starting...";
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            using (var context = new sakilaEntities())
            {
                var friend = new friend
                {
                    FriendlyName = textBox3.Text
                };

                var anotherFriend = new friend
                    {
                    FriendlyName = textBox3.Text + " Jr."
                };

                var contact = new contact
                {
                    FirstName = textBox1.Text,
                    LastName = textBox2.Text,
                    friends = new List<friend>
                        {
                            friend,
                            anotherFriend
                        }
                };
                context.contacts.Add(contact);
                context.SaveChanges();
            }

            Text = @"Success";
        }
    }
}