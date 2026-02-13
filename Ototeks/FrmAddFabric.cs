using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;
using Ototeks.Interfaces;
using System.Linq;

namespace Ototeks.UI
{
    public partial class FrmAddFabric : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // This is the signal that the form will send outward
        public event EventHandler OperationCompleted;

        private int _recordIdToUpdate = 0; // 0 = Add Mode, >0 = Update Mode

        public FrmAddFabric()
        {
            InitializeComponent();
            LoadColors(); // Load colors
        }

        public FrmAddFabric(int id)
        {
            InitializeComponent();
            LoadColors(); // Load colors
            _recordIdToUpdate = id; // Note which record we will edit.

            // Change the form title so the user understands
            this.Text = "Update Fabric";
            lblTitle.Text = "Update Fabric";
            btnSave.Text = "Update";

            LoadRecordData(); // Fill the fields
        }

        void LoadColors()
        {
            try
            {
                // Fetch colors from the database
                var colorRepo = new GenericRepository<Color>();
                var colorManager = new ColorManager(colorRepo);
                var colors = colorManager.GetAll();

                cmbColor.Properties.Items.Clear();

                // Add placeholder
                cmbColor.Properties.Items.Add("Select a color...");

                // Add colors to the ComboBox (text only)
                foreach (var color in colors)
                {
                    cmbColor.Properties.Items.Add(color.ColorName);
                }

                // Set the placeholder as selected
                cmbColor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading colors: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadRecordData()
        {
            // Find the fabric with this id from the database
            var repo = new GenericRepository<Fabric>();
            var manager = new FabricManager(repo);
            var fabric = manager.GetById(_recordIdToUpdate);

            if (fabric != null)
            {
                // Fill the fields
                txtFabricCode.Text = fabric.FabricCode;
                txtFabricName.Text = fabric.FabricName;
                txtStock.Text = fabric.StockQuantity?.ToString("F2") ?? "0.00";

                // Set the color selection
                if (fabric.ColorId.HasValue)
                {
                    // Find and select ColorName from ColorId
                    var colorRepo = new GenericRepository<Color>();
                    var colorManager = new ColorManager(colorRepo);
                    var selectedColor = colorManager.GetById(fabric.ColorId.Value);
                    if (selectedColor != null)
                    {
                        cmbColor.SelectedItem = selectedColor.ColorName;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // STEP 1: Prepare connections
            // (Call the database access and business logic classes)
            var repo = new GenericRepository<Fabric>();
            var manager = new FabricManager(repo);

            try
            {
                // Get the stock amount
                decimal stockAmount = 0;
                decimal.TryParse(txtStock.Text, out stockAmount);

                // Find the selected color's ID
                var colorRepo = new GenericRepository<Color>();
                var colorManager = new ColorManager(colorRepo);
                var colors = colorManager.GetAll();
                var selectedColorName = cmbColor.SelectedItem.ToString();
                var selectedColor = colors.FirstOrDefault(c => c.ColorName == selectedColorName);

                // If placeholder is selected, set ColorId to null so the validator catches it
                int? colorId = null;
                if (selectedColorName != "Select a color..." && selectedColor != null)
                {
                    colorId = selectedColor.ColorId;
                }

                // SCENARIO 1: NEW RECORD (ID = 0)
                if (_recordIdToUpdate == 0)
                {
                    // Create the object
                    var newFabric = new Fabric
                    {
                        FabricCode = txtFabricCode.Text.Trim(),
                        FabricName = txtFabricName.Text.Trim(),
                        StockQuantity = stockAmount,
                        ColorId = colorId
                    };

                    // Send to Manager (let it check the rules there)
                    manager.Add(newFabric);

                    // Show success message
                    XtraMessageBox.Show("Fabric has been successfully added to the system!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the fields so we can enter a new record
                    txtFabricCode.Text = "";
                    txtFabricName.Text = "";
                    txtStock.Text = ""; // Leave empty, don't fill with 0.00
                    cmbColor.SelectedIndex = 0; // Reset to placeholder
                    txtFabricCode.Focus(); // Move cursor back to the first field
                }
                // SCENARIO 2: UPDATE (ID > 0)
                else
                {
                    // First fetch the original record from the database
                    var fabricToUpdate = manager.GetById(_recordIdToUpdate);

                    // Overwrite with the new information from the screen
                    fabricToUpdate.FabricCode = txtFabricCode.Text.Trim();
                    fabricToUpdate.FabricName = txtFabricName.Text.Trim();
                    fabricToUpdate.StockQuantity = stockAmount;
                    fabricToUpdate.ColorId = colorId;

                    // Tell the Manager to "update this"
                    manager.Update(fabricToUpdate);

                    XtraMessageBox.Show("Fabric has been updated!", "Success",
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
