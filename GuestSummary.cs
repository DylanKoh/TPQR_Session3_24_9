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
    public partial class GuestSummary : Form
    {
        public GuestSummary()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new AdminMain()).ShowDialog();
            Close();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void LoadChart()
        {
            chart1.Series.Clear();
            chart1.Series.Add("Delegates");
            chart1.Series.Add("Competitors");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            using (var context = new Session3Entities())
            {
                var attendees = (from x in context.Arrivals
                                 select x);
                if (cbType.SelectedItem == null || cbType.SelectedItem.ToString() == "No Filter")
                {
                    foreach (var item in attendees)
                    {
                        var idx1 = chart1.Series[0].Points.AddXY(item.User.countryName, item.numberDelegate + item.numberHead);
                        var idx2 = chart1.Series[1].Points.AddXY(item.User.countryName, item.numberCompetitors);
                        chart1.Series[0].Points[idx1].Label = (item.numberDelegate + item.numberHead).ToString();
                        chart1.Series[1].Points[idx2].Label = item.numberCompetitors.ToString();
                    }
                }
                else if (cbType.SelectedItem.ToString() == "Delegates")
                {
                    foreach (var item in attendees)
                    {
                        var idx1 = chart1.Series[0].Points.AddXY(item.User.countryName, item.numberDelegate + item.numberHead);
                        chart1.Series[0].Points[idx1].Label = (item.numberDelegate + item.numberHead).ToString();
                    }
                }
                else
                {
                    foreach (var item in attendees)
                    {
                        var idx2 = chart1.Series[1].Points.AddXY(item.User.countryName, item.numberCompetitors);
                        chart1.Series[1].Points[idx2].Label = item.numberCompetitors.ToString();
                    }
                }
            }

        }

        private void GuestSummary_Load(object sender, EventArgs e)
        {
            LoadChart();
        }
    }
}
