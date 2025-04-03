using System;
using System.Windows.Forms;

namespace WeAreCarsRentalSystem
{
    public partial class BookingForm : Form
    {
        private ToolTip toolTip;

        public BookingForm()
        {
            InitializeComponent();
            cmbCarType.Items.AddRange(new string[] { "City", "Family", "Sports", "SUV" });
            cmbFuelType.Items.AddRange(new string[] { "Petrol", "Diesel", "Hybrid", "Electric" });

            // Initialize ToolTip
            toolTip = new ToolTip();
            toolTip.SetToolTip(txtFirstName, "Enter customer's first name");
            toolTip.SetToolTip(txtSurname, "Enter customer's surname");
            toolTip.SetToolTip(txtAddress, "Enter customer's full address");
            toolTip.SetToolTip(numDays, "Enter number of rental days (1-28)");
            toolTip.SetToolTip(chkDrivingLicense, "Check if customer has a valid driving license");
            toolTip.SetToolTip(cmbCarType, "Select the type of car");
            toolTip.SetToolTip(cmbFuelType, "Select the fuel type");
            toolTip.SetToolTip(chkUnlimitedMileage, "Add unlimited mileage (£10/day)");
            toolTip.SetToolTip(chkBreakdownCover, "Add breakdown cover (£2/day)");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtSurname.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) || !chkDrivingLicense.Checked ||
                cmbCarType.SelectedIndex == -1 || cmbFuelType.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all mandatory fields and confirm a valid driving license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int days = (int)numDays.Value;
            if (days < 1 || days > 28)
            {
                MessageBox.Show("Number of days must be between 1 and 28.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cost calculation
            decimal total = days * 25;
            switch (cmbCarType.SelectedItem.ToString())
            {
                case "Family": total += 50; break;
                case "Sports": total += 75; break;
                case "SUV": total += 65; break;
            }
            switch (cmbFuelType.SelectedItem.ToString())
            {
                case "Hybrid": total += 30; break;
                case "Electric": total += 50; break;
            }
            if (chkUnlimitedMileage.Checked) total += days * 10;
            if (chkBreakdownCover.Checked) total += days * 2;

            // Prepare summary
            string summary = $"Name: {txtFirstName.Text} {txtSurname.Text}\n" +
                             $"Address: {txtAddress.Text}\n" +
                             $"Days: {days}\n" +
                             $"Car: {cmbCarType.SelectedItem} ({cmbFuelType.SelectedItem})\n" +
                             $"Extras: {(chkUnlimitedMileage.Checked ? "Unlimited Mileage" : "")} " +
                             $"{(chkBreakdownCover.Checked ? "Breakdown Cover" : "")}\n" +
                             $"Total: £{total}";
            SummaryForm summaryForm = new SummaryForm(summary);
            summaryForm.Show();
            this.Hide();
        }
    }
}