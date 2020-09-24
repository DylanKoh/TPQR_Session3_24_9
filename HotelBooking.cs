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
    public partial class HotelBooking : Form
    {
        User _user;
        int _hotelID;
        public HotelBooking(User user, int hotelID)
        {
            InitializeComponent();
            _user = user;
            _hotelID = hotelID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
