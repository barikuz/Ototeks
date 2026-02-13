using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;
using Ototeks.Interfaces;

namespace Ototeks.UI
{
    public partial class FrmAddCustomer : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // This is the signal that the form will send outward
        public event EventHandler OperationCompleted;

        private int _recordIdToUpdate = 0; // 0 = Add Mode, >0 = Update Mode

        public FrmAddCustomer()
        {
            InitializeComponent();
        }

        public FrmAddCustomer(int id)
        {
            InitializeComponent();
            _recordIdToUpdate = id; // Note which record we will edit.

            // Change the form title so the user understands
            this.Text = "Update Customer";
            lblTitle.Text = "Update Customer";
            btnSave.Text = "Update";

            LoadRecordData(); // Fill the fields
        }

        void LoadRecordData()
        {
            // Find the customer with this id from the database
            var repo = new GenericRepository<Customer>();
            var manager = new CustomerManager(repo);
            var customer = manager.GetById(_recordIdToUpdate);

            if (customer != null)
            {
                // Fill the fields
                txtCustomerName.Text = customer.CustomerName;
                txtPhone.Text = customer.Phone;
                txtEmail.Text = customer.Email;
                txtAddress.Text = customer.Address;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // STEP 1: Prepare connections
            var repo = new GenericRepository<Customer>();
            var manager = new CustomerManager(repo);

            try
            {
                // SCENARIO 1: NEW RECORD (ID = 0)
                if (_recordIdToUpdate == 0)
                {
                    // Create the object
                    var newCustomer = new Customer
                    {
                        CustomerName = txtCustomerName.Text,
                        Phone = txtPhone.Text,
                        Email = txtEmail.Text,
                        Address = txtAddress.Text
                    };

                    // Send to Manager
                    manager.Add(newCustomer);

                    // Show success message
                    XtraMessageBox.Show("Customer has been successfully added to the system!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the fields so we can enter a new record
                    txtCustomerName.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    txtCustomerName.Focus(); // Move cursor back to the first field
                }
                // SCENARIO 2: UPDATE (ID > 0)
                else
                {
                    // First fetch the original record from the database
                    var customerToUpdate = manager.GetById(_recordIdToUpdate);

                    // Overwrite with the new information from the screen
                    customerToUpdate.CustomerName = txtCustomerName.Text;
                    customerToUpdate.Phone = txtPhone.Text;
                    customerToUpdate.Email = txtEmail.Text;
                    customerToUpdate.Address = txtAddress.Text;

                    // Tell the Manager to "update this"
                    manager.Update(customerToUpdate);

                    XtraMessageBox.Show("Customer has been updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // It makes more sense to close the form after updating.
                }

                // Send signal to the parent form (to refresh)
                OperationCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Catch the error here and show it to the user.
                XtraMessageBox.Show(ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
