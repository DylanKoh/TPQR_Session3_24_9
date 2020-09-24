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
    public partial class ConfirmArrival : Form
    {
        User _user;
        public ConfirmArrival(User user)
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

        private void rb22_CheckedChanged(object sender, EventArgs e)
        {
            LoadTime();
        }

        private void rb23_CheckedChanged(object sender, EventArgs e)
        {
            LoadTime();
        }

        private void LoadTime()
        {
            dataGridView1.Rows.Clear();
            var newRow = new List<string>()
            {
                "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm"
            };
            var listAllowed22 = new List<string>()
            {
                "9am", "11am", "12pm", "3pm", "4pm"
            };
            var listAllowed23 = new List<string>()
            {
                "10am", "11am", "1pm", "2pm", "3pm"
            };
            dataGridView1.Rows.Add(newRow.ToArray());
            if (rb22.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn cell in dataGridView1.Columns)
                    {
                        if (!listAllowed22.Contains(dataGridView1[cell.Index, row.Index].Value.ToString()))
                        {
                            dataGridView1[cell.Index, row.Index].Style.BackColor = Color.Black;
                        }
                    }
                }
            }
            else if (rb23.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn cell in dataGridView1.Columns)
                    {
                        if (!listAllowed23.Contains(dataGridView1[cell.Index, row.Index].Value.ToString()))
                        {
                            dataGridView1[cell.Index, row.Index].Style.BackColor = Color.Black;
                        }
                    }
                }
            }
            
        }

        private void nudHead_ValueChanged(object sender, EventArgs e)
        {
            CalculateVeh();
        }

        private void nudDelegates_ValueChanged(object sender, EventArgs e)
        {
            CalculateVeh();
        }

        private void nudCompetitors_ValueChanged(object sender, EventArgs e)
        {
            CalculateVeh();
        }

        private void CalculateVeh()
        {
            lblCar.Text = 0.ToString();
            lbl19.Text = 0.ToString();
            lbl42.Text = 0.ToString();
            if (nudHead.Value == 0)
            {
                lblCar.Text = 0.ToString();
            }
            else
            {
                lblCar.Text = 1.ToString();
            }
            var totalP = (int)(nudCompetitors.Value + nudDelegates.Value);
            if (totalP % 42 == 0)
            {
                lbl42.Text = (totalP / 42).ToString();
            }
            else
            {
                if (totalP % 42 <= 38 && totalP % 42 > 0)
                {
                    if (totalP % 42 <= 19)
                    {
                        lbl42.Text = (totalP / 42).ToString();
                        lbl19.Text = 1.ToString();
                    }
                    else
                    {
                        lbl42.Text = (totalP / 42).ToString();
                        lbl19.Text = 2.ToString();
                    }
                }
                else
                {
                    lbl42.Text = ((totalP / 42) + 1).ToString();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!rb22.Checked && !rb23.Checked)
            {
                MessageBox.Show("Please select a date!");
            }
            else if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Please select a time!");
            }
            else if (dataGridView1.CurrentCell.Style.BackColor == Color.Black)
            {
                MessageBox.Show("Please select another timing that is not blacked out!");
            }
            else
            {
                var newArrival = new Arrival()
                {
                    arrivalTime = dataGridView1.CurrentCell.Value.ToString(),
                    number19seat = int.Parse(lbl19.Text),
                    number42seat = int.Parse(lbl42.Text),
                    numberCars = int.Parse(lblCar.Text),
                    numberHead = (int)nudHead.Value,
                    numberDelegate = (int)nudDelegates.Value,
                    numberCompetitors = (int)nudCompetitors.Value,
                    userIdFK = _user.userId
                };
                if (rb22.Checked)
                {
                    newArrival.arrivalDate = DateTime.Parse("22 July 2020");
                }
                else if (rb23.Checked)
                {
                    newArrival.arrivalDate = DateTime.Parse("23 July 2020");
                }
                using (var context  = new Session3Entities())
                {
                    context.Arrivals.Add(newArrival);
                    context.SaveChanges();
                    MessageBox.Show("Successfully confirmed arrival!");
                }
                Hide();
                (new CountryMain(_user)).ShowDialog();
                Close();
            }
        }
    }
}
