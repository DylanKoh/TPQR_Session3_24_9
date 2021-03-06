﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_24_9
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill up all fields!");
            }
            else
            {
                using (var context = new Session3Entities())
                {
                    var findUser = (from x in context.Users
                                    where x.userId == txtUserID.Text
                                    select x).FirstOrDefault();
                    if (findUser == null)
                    {
                        MessageBox.Show("User does not exist!");
                    }
                    else if (findUser.passwd != txtPassword.Text)
                    {
                        MessageBox.Show("Password incorrect!");
                    }
                    else
                    {
                        MessageBox.Show($"Welcome {findUser.countryName}!");
                        if (findUser.userTypeIdFK == 1)
                        {
                            Hide();
                            (new AdminMain()).ShowDialog();
                            Close();
                        }
                        else
                        {
                            Hide();
                            (new CountryMain(findUser)).ShowDialog();
                            Close();
                        }
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Hide();
            (new CreateAccount()).ShowDialog();
            Close();
        }
    }
}
