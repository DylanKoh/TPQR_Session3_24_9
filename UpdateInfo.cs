using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_24_9
{
    public partial class UpdateInfo : Form
    {
        User _user;
        DateTime endDate = DateTime.Parse("30 July 2020");
        DateTime arrivalDate;
        int daysToSpend;
        int originalSingle;
        int originalDouble;
        public UpdateInfo(User user)
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

        private void UpdateInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session3Entities())
            {
                var findArrival = (from x in context.Arrivals
                                   where x.userIdFK == _user.userId
                                   select x).FirstOrDefault();
                arrivalDate = findArrival.arrivalDate;
                daysToSpend = (endDate - arrivalDate).Days;
                nudCompetitors.Value = findArrival.numberCompetitors;
                nudDelegates.Value = findArrival.numberDelegate;
                nudHead.Value = findArrival.numberHead;
                var getBooking = (from x in context.Hotel_Booking
                                where x.userIdFK == _user.userId
                                select x).FirstOrDefault();
                originalSingle = getBooking.numSingleRoomsRequired;
                originalDouble = getBooking.numDoubleRoomsRequired;
                var singleRow = new List<string>()
                {
                    "Single", getBooking.Hotel.singleRate.ToString(),
                    (getBooking.Hotel.numSingleRoomsTotal - getBooking.Hotel.numSingleRoomsBooked).ToString(),
                    getBooking.numSingleRoomsRequired.ToString(), "",
                    (getBooking.Hotel.singleRate * getBooking.numSingleRoomsRequired * daysToSpend).ToString()
                };
                var doubleRow = new List<string>()
                {
                    "Double", getBooking.Hotel.doubleRate.ToString(),
                    (getBooking.Hotel.numDoubleRoomsTotal - getBooking.Hotel.numDoubleRoomsBooked).ToString(),
                    getBooking.numDoubleRoomsRequired.ToString(), "",
                    (getBooking.Hotel.doubleRate * getBooking.numDoubleRoomsRequired * daysToSpend).ToString()
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
                total += Convert.ToInt32(dataGridView1[5, item.Index].Value);
            }
            lblTotal.Text = total.ToString();
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (!int.TryParse(dataGridView1[4, e.RowIndex].Value.ToString(), out _))
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
                        originalSingle = Convert.ToInt32(dataGridView1[4, e.RowIndex].Value);
                    else
                        originalDouble = Convert.ToInt32(dataGridView1[4, e.RowIndex].Value);
                    dataGridView1[5, e.RowIndex].Value = Convert.ToInt32(dataGridView1[1, e.RowIndex].Value) * Convert.ToInt32(dataGridView1[4, e.RowIndex].Value) * daysToSpend;
                    CalculateTotal();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var getTotalCap = (int)nudCompetitors.Value + (int)nudDelegates.Value;
            var bookedCap = originalSingle + (originalDouble * 2);

            if (bookedCap < getTotalCap)
            {
                MessageBox.Show("Please ensure number of rooms booked are enough for all visitors!");
            }
            else
            {
                var boolCheck = true;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (dataGridView1[4, item.Index].Value.ToString() != "")
                    {
                        if (Convert.ToInt32(dataGridView1[2, item.Index].Value) < Convert.ToInt32(dataGridView1[4, item.Index].Value))
                        {
                            boolCheck = false;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(dataGridView1[2, item.Index].Value) < Convert.ToInt32(dataGridView1[3, item.Index].Value))
                        {
                            boolCheck = false;
                        }
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
                        var findArrival = (from x in context.Arrivals
                                           where x.userIdFK == _user.userId
                                           select x).FirstOrDefault();
                        findArrival.numberHead = (int)nudHead.Value;
                        findArrival.numberCompetitors = (int)nudCompetitors.Value;
                        findArrival.numberDelegate = (int)nudDelegates.Value;
                        context.SaveChanges();
                        var findBooking = (from x in context.Hotel_Booking
                                           where x.userIdFK == _user.userId
                                           select x).FirstOrDefault();
                        findBooking.numSingleRoomsRequired = originalSingle;
                        findBooking.numDoubleRoomsRequired = originalDouble;
                        context.SaveChanges();
                        var findHotel = (from x in context.Hotels
                                         where x.hotelId == findBooking.hotelIdFK
                                         select x).FirstOrDefault();
                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            if (dataGridView1[0, item.Index].Value.ToString() == "Single")
                            {
                                if (dataGridView1[4, item.Index].Value.ToString() != "")
                                {
                                    if (findHotel.numSingleRoomsBooked == Convert.ToInt32(dataGridView1[4, item.Index].Value))
                                    {
                                        findHotel.numSingleRoomsBooked = Convert.ToInt32(dataGridView1[4, item.Index].Value);
                                    }
                                    else
                                    {
                                        findHotel.numSingleRoomsBooked = findHotel.numSingleRoomsBooked - Convert.ToInt32(dataGridView1[3, item.Index].Value) + Convert.ToInt32(dataGridView1[4, item.Index].Value);
                                    }
                                }
                            }
                            else
                            {
                                if (dataGridView1[4, item.Index].Value.ToString() != "")
                                {
                                    if (findHotel.numDoubleRoomsBooked == Convert.ToInt32(dataGridView1[4, item.Index].Value))
                                    {
                                        findHotel.numDoubleRoomsBooked = Convert.ToInt32(dataGridView1[4, item.Index].Value);
                                    }
                                    else
                                    {
                                        findHotel.numDoubleRoomsBooked = findHotel.numDoubleRoomsBooked - Convert.ToInt32(dataGridView1[3, item.Index].Value) + Convert.ToInt32(dataGridView1[4, item.Index].Value);
                                    }
                                }
                            }
                        }
                        context.SaveChanges();
                        MessageBox.Show("Update Info and Booking successful!");
                        Hide();
                        (new CountryMain(_user)).ShowDialog();
                        Close();
                    }
                }
            }
        }
    }
}
