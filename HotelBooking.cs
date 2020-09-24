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
        int originalSingle;
        int originalDouble;
        DateTime endDate = DateTime.Parse("30 July 2020");
        DateTime arrivalDate;
        int daysToSpend;
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

        private void HotelBooking_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session3Entities())
            {
                var findArrival = (from x in context.Arrivals
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                arrivalDate = findArrival.arrivalDate;
                daysToSpend = (endDate - arrivalDate).Days;
                lblCompetitors.Text = findArrival.numberCompetitors.ToString();
                lblDelegates.Text = findArrival.numberDelegate.ToString();
                var getHotel = (from x in context.Hotels
                                where x.hotelId == _hotelID
                                select x).FirstOrDefault();
                lblHotelName.Text = getHotel.hotelName;
                if (findArrival.numberCompetitors % 2 != 0)
                {
                    originalDouble = findArrival.numberCompetitors / 2;
                    originalSingle = findArrival.numberDelegate + 1;
                }
                else
                {
                    originalDouble = findArrival.numberCompetitors / 2;
                    originalSingle = findArrival.numberDelegate;
                }
                var singleRow = new List<string>()
                {
                    "Single", getHotel.singleRate.ToString(),
                    (getHotel.numSingleRoomsTotal - getHotel.numSingleRoomsBooked).ToString(),
                    originalSingle.ToString(),
                    (getHotel.singleRate * originalSingle * daysToSpend).ToString()
                };
                var doubleRow = new List<string>()
                {
                    "Double", getHotel.doubleRate.ToString(),
                    (getHotel.numDoubleRoomsTotal - getHotel.numDoubleRoomsBooked).ToString(),
                    originalDouble.ToString(),
                    (getHotel.doubleRate * originalDouble * daysToSpend).ToString()
                };
                dataGridView1.Rows.Add(singleRow.ToArray());
                dataGridView1.Rows.Add(doubleRow.ToArray());
                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            lblTotal.Text = 0.ToString();
            var total = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                total += Convert.ToInt32(dataGridView1[4, item.Index].Value);
            }
            lblTotal.Text = total.ToString();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (!int.TryParse(dataGridView1[3, e.RowIndex].Value.ToString(), out _))
                {
                    MessageBox.Show("Please input a valid positive integer!");
                    if (e.RowIndex == 0)
                        dataGridView1[3, e.RowIndex].Value = originalSingle;
                    else if (e.RowIndex == 1)
                        dataGridView1[3, e.RowIndex].Value = originalDouble;
                }
                else
                {
                    if (e.RowIndex == 0)
                        originalSingle = Convert.ToInt32(dataGridView1[3, e.RowIndex].Value);
                    else
                        originalDouble = Convert.ToInt32(dataGridView1[3, e.RowIndex].Value);
                    dataGridView1[4, e.RowIndex].Value = Convert.ToInt32(dataGridView1[1, e.RowIndex].Value) * Convert.ToInt32(dataGridView1[3, e.RowIndex].Value) * daysToSpend;
                    CalculateTotal();
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            var getTotalCap = int.Parse(lblDelegates.Text) + int.Parse(lblCompetitors.Text);
            var bookedCap = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (dataGridView1[0, item.Index].Value.ToString() == "Double")
                {
                    bookedCap += Convert.ToInt32(dataGridView1[3, item.Index].Value) * 2;
                }
                else
                {
                    bookedCap += Convert.ToInt32(dataGridView1[3, item.Index].Value);
                }
            }
            if (bookedCap < getTotalCap)
            {
                MessageBox.Show("Please ensure number of rooms booked are enough for all visitors!");
            }
            else
            {
                var boolCheck = true;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                { 
                    if (Convert.ToInt32(dataGridView1[2, item.Index].Value) < Convert.ToInt32(dataGridView1[3, item.Index].Value))
                    {
                        boolCheck = false;
                    }
                }
                if (boolCheck == false)
                {
                    MessageBox.Show("Hotel will not have enough rooms for desired amount!");
                }
                else
                {
                    using (var context = new Session3Entities())
                    {
                        var newBooking = new Hotel_Booking()
                        {
                            hotelIdFK = _hotelID,
                            numSingleRoomsRequired = originalSingle,
                            numDoubleRoomsRequired = originalDouble,
                            userIdFK = _user.userId
                        };
                        context.Hotel_Booking.Add(newBooking);
                        context.SaveChanges();
                        MessageBox.Show("Hotel booking successful!");
                        Close();
                    }
                }
            }
        }
    }
}
