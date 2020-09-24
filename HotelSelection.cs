using System;
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
    public partial class HotelSelection : Form
    {
        User _user;
        public HotelSelection(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new CountryMain(_user)).ShowDialog();
            Close();
        }

        private void btnQueens_Click(object sender, EventArgs e)
        {
            (new HotelBooking(_user, 6)).ShowDialog();
            using (var context = new Session3Entities())
            {
                var findBooking = (from x in context.Hotel_Booking
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                if (findBooking != null)
                {
                    Hide();
                    (new CountryMain(_user)).ShowDialog();
                    Close();
                }
            }
        }

        private void btnGrand_Click(object sender, EventArgs e)
        {
            (new HotelBooking(_user, 5)).ShowDialog();
            using (var context = new Session3Entities())
            {
                var findBooking = (from x in context.Hotel_Booking
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                if (findBooking != null)
                {
                    Hide();
                    (new CountryMain(_user)).ShowDialog();
                    Close();
                }
            }
        }

        private void btnInter_Click(object sender, EventArgs e)
        {
            (new HotelBooking(_user, 4)).ShowDialog();
            using (var context = new Session3Entities())
            {
                var findBooking = (from x in context.Hotel_Booking
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                if (findBooking != null)
                {
                    Hide();
                    (new CountryMain(_user)).ShowDialog();
                    Close();
                }
            }
        }

        private void btnCarlton_Click(object sender, EventArgs e)
        {
            (new HotelBooking(_user, 3)).ShowDialog();
            using (var context = new Session3Entities())
            {
                var findBooking = (from x in context.Hotel_Booking
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                if (findBooking != null)
                {
                    Hide();
                    (new CountryMain(_user)).ShowDialog();
                    Close();
                }
            }
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            (new HotelBooking(_user, 2)).ShowDialog();
            using (var context = new Session3Entities())
            {
                var findBooking = (from x in context.Hotel_Booking
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                if (findBooking != null)
                {
                    Hide();
                    (new CountryMain(_user)).ShowDialog();
                    Close();
                }
            }
        }

        private void btnRitz_Click(object sender, EventArgs e)
        {
            (new HotelBooking(_user, 1)).ShowDialog();
            using (var context = new Session3Entities())
            {
                var findBooking = (from x in context.Hotel_Booking
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                if (findBooking != null)
                {
                    Hide();
                    (new CountryMain(_user)).ShowDialog();
                    Close();
                }
            }
        }
    }
}
