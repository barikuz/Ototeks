using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;
using Ototeks.Interfaces;

namespace Ototeks.UI
{
    public partial class FrmAddProductType : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // This is the signal that the form will send outward
        public event EventHandler OperationCompleted;

        private int _recordIdToUpdate = 0; // 0 = Add Mode, >0 = Update Mode

        public FrmAddProductType()
        {
            InitializeComponent();
        }

        public FrmAddProductType(int id)
        {
            InitializeComponent();
            _recordIdToUpdate = id; // Note which record we will edit.

            // Change the form title so the user understands
            this.Text = "Update Product Type";
            lblTitle.Text = "Update Product Type";
            btnSave.Text = "Update";

            LoadRecordData(); // Fill the fields
        }

        void LoadRecordData()
        {
            // Find the product type with this id from the database
            var repo = new GenericRepository<ProductType>();
            var manager = new ProductTypeManager(repo);
            var productType = manager.GetById(_recordIdToUpdate);

            if (productType != null)
            {
                // Fill the fields
                txtProductTypeName.Text = productType.TypeName;
                txtRequiredFabricAmount.Text = productType.RequiredFabricAmount.ToString("F2");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // STEP 1: Prepare connections
            var repo = new GenericRepository<ProductType>();
            var manager = new ProductTypeManager(repo);

            try
            {
                // Get the required fabric amount
                decimal requiredAmount = 0;
                decimal.TryParse(txtRequiredFabricAmount.Text, out requiredAmount);

                // SCENARIO 1: NEW RECORD (ID = 0)
                if (_recordIdToUpdate == 0)
                {
                    // Create the object
                    var newProductType = new ProductType
                    {
                        TypeName = txtProductTypeName.Text.Trim(),
                        RequiredFabricAmount = requiredAmount
                    };

                    // Send to Manager (let it check the rules there)
                    manager.Add(newProductType);

                    // Show success message
                    XtraMessageBox.Show("Product type has been successfully added to the system!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the fields so we can enter a new record
                    txtProductTypeName.Text = "";
                    txtRequiredFabricAmount.Text = "";
                    txtProductTypeName.Focus(); // Move cursor back to the first field
                }
                // SCENARIO 2: UPDATE (ID > 0)
                else
                {
                    // First fetch the original record from the database
                    var productTypeToUpdate = manager.GetById(_recordIdToUpdate);

                    // Overwrite with the new information from the screen
                    productTypeToUpdate.TypeName = txtProductTypeName.Text.Trim();
                    productTypeToUpdate.RequiredFabricAmount = requiredAmount;

                    // Tell the Manager to "update this"
                    manager.Update(productTypeToUpdate);

                    XtraMessageBox.Show("Product type has been updated!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
