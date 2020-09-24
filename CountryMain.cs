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
    public partial class CountryMain : Form
    {
        User _user;
        public CountryMain(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new LoginForm()).ShowDialog();
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                var findArrival = (from x in context.Arrivals
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                if (findArrival == null)
                {
                    Hide();
                    (new ConfirmArrival(_user)).ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Arrival has been confirmed!");
                }
            }
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {

        }
    }
}
