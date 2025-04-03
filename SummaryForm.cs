using System;
using System.Windows.Forms;

namespace WeAreCarsRentalSystem
{
    public partial class SummaryForm : Form
    {
        private string bookingDetails;

        public SummaryForm(string details)
        {
            InitializeComponent();
            bookingDetails = details;
            txtSummary.Text = details;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Dashboard.RentedCars.Add(bookingDetails.Split('\n')[0]); // Add booking name to list
            MessageBox.Show("Booking confirmed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingForm booking = new BookingForm();
            booking.Show();
        }
    }
}