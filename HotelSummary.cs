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
    public partial class HotelSummary : Form
    {
        public HotelSummary()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new AdminMain()).ShowDialog();
            Close();
        }

        private void LoadData(int hotelID)
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session3Entities())
            {
                var getHotelBookings = (from x in context.Hotel_Booking
                                        where x.hotelIdFK == hotelID
                                        select x);
                foreach (var item in getHotelBookings)
                {
                    var newRow = new List<string>()
                    {
                        item.User.countryName, item.numSingleRoomsRequired.ToString(), item.numDoubleRoomsRequired.ToString()
                    };
                    dataGridView1.Rows.Add(newRow.ToArray());
                }
            }
        }

        private void btnQueens_Click(object sender, EventArgs e)
        {
            LoadData(6);
        }

        private void btnGrand_Click(object sender, EventArgs e)
        {
            LoadData(5);
        }

        private void btnInter_Click(object sender, EventArgs e)
        {
            LoadData(4);
        }

        private void btnCarlton_Click(object sender, EventArgs e)
        {
            LoadData(3);
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            LoadData(2);
        }

        private void btnRitz_Click(object sender, EventArgs e)
        {
            LoadData(1);
        }
    }
}
