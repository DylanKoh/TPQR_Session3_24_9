using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session3_24_9
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new LoginForm()).ShowDialog();
            Close();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            cbCountry.Items.Clear();
            var countries = new List<string>()
            {
                "Brunei", "Cambodia", "Indonesia", "Laos", "Malaysia", "Myanmar", "Philippines", "Singapore", "Thailand", "Vietnam"
            };
            using (var context = new Session3Entities())
            {
                var getRegistered = (from x in context.Users
                                     where x.userTypeIdFK == 2
                                     select x.countryName);
                foreach (var item in getRegistered)
                {
                    countries.Remove(item);
                }
            }
            cbCountry.Items.AddRange(countries.ToArray());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cbCountry.SelectedItem == null || string.IsNullOrWhiteSpace(txtUserID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtRePassword.Text))
            {
                MessageBox.Show("Please ensure all fields are filled!");
            }
            else if (txtPassword.Text != txtRePassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
            }
            else if (txtUserID.TextLength < 8)
            {
                MessageBox.Show("Ensure there are at least 8 characters for User ID!");
            }
            else if (!Regex.IsMatch(txtUserID.Text, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Ensure only letters and numeric characters in User ID!");
            }
            else
            {
                using (var context = new Session3Entities())
                {
                    var findUser = (from x in context.Users
                                    where x.userId == txtUserID.Text
                                    select x).FirstOrDefault();
                    if (findUser != null)
                    {
                        MessageBox.Show("User ID used!");
                    }
                    else
                    {
                        var newUser = new User()
                        {
                            countryName = cbCountry.SelectedItem.ToString(),
                            userId = txtUserID.Text,
                            userTypeIdFK = 2,
                            passwd = txtPassword.Text
                        };
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        MessageBox.Show("Successfully added user!");
                        Hide();
                        (new LoginForm()).ShowDialog();
                        Close();
                    }
                }
            }
        }
    }
}
