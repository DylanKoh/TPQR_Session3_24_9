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
    public partial class ArrivalSummary : Form
    {
        public ArrivalSummary()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new AdminMain()).ShowDialog();
            Close();
        }

        private void ArrivalSummary_Load(object sender, EventArgs e)
        {
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
            dataGridView2.Rows.Add(newRow.ToArray());
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
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (DataGridViewColumn cell in dataGridView2.Columns)
                {
                    if (!listAllowed23.Contains(dataGridView2[cell.Index, row.Index].Value.ToString()))
                    {
                        dataGridView2[cell.Index, row.Index].Style.BackColor = Color.Black;
                    }
                }
            }
            
            var july22 = DateTime.Parse("22 July 2020");
            var july23 = DateTime.Parse("23 July 2020");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewColumn cell in dataGridView1.Columns)
                {
                    var timing = dataGridView1[cell.Index, row.Index].Value.ToString();
                    using (var context = new Session3Entities())
                    {
                        var get22Arrival = (from x in context.Arrivals
                                            where x.arrivalDate == july22 && x.arrivalTime == timing
                                            select x);
                        var sb = new StringBuilder(dataGridView1[cell.Index, row.Index].Value.ToString());
                        foreach (var item in get22Arrival)
                        {
                            sb.Append($"\n\n{item.User.countryName}\n({item.numberCars + item.number42seat + item.number19seat} Veh)");
                        }
                        dataGridView1[cell.Index, row.Index].Value = sb.ToString();
                    }
                }
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (DataGridViewColumn cell in dataGridView2.Columns)
                {
                    var timing = dataGridView2[cell.Index, row.Index].Value.ToString();
                    using (var context = new Session3Entities())
                    {
                        var get23Arrival = (from x in context.Arrivals
                                            where x.arrivalDate == july23 && x.arrivalTime == timing
                                            select x);
                        var sb = new StringBuilder(dataGridView2[cell.Index, row.Index].Value.ToString());
                        foreach (var item in get23Arrival)
                        {
                            sb.Append($"\n\n{item.User.countryName}\n({item.numberCars + item.number42seat + item.number19seat} Veh)");
                        }
                        dataGridView2[cell.Index, row.Index].Value = sb.ToString();
                    }
                }
            }
        }
    }
}
