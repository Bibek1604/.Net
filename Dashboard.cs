using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WeAreCarsRentalSystem
{
    public partial class Dashboard : Form
    {
        public static List<string> RentedCars = new List<string>(); // Static list for prototype

        public Dashboard()
        {
            InitializeComponent();
            UpdateRentedCarsList();
        }

        private void btnBookCar_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingForm booking = new BookingForm();
            booking.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        public void UpdateRentedCarsList()
        {
            lstRentedCars.Items.Clear();
            foreach (string car in RentedCars)
            {
                lstRentedCars.Items.Add(car);
            }
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to WeAreCars Rental System.\n\n" +
                            "1. Click 'Book Car' to start a new booking.\n" +
                            "2. Enter customer details and select options.\n" +
                            "3. Confirm the booking to add it to the rented cars list.\n" +
                            "4. Contact support at support@wearecars.com for assistance.",
                            "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}