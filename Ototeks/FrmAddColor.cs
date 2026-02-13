using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Windows.Forms;
using Ototeks.Interfaces;

namespace Ototeks.UI
{
    public partial class FrmAddColor : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // This is the signal that the form will send outward
        public event EventHandler OperationCompleted;

        private int _recordIdToUpdate = 0; // 0 = Add Mode, >0 = Update Mode

        public FrmAddColor()
        {
            InitializeComponent();
        }

        public FrmAddColor(int id)
        {
            InitializeComponent();
            _recordIdToUpdate = id; // Note which record we will edit.

            // Change the form title so the user understands
            this.Text = "Update Color";
            lblTitle.Text = "Update Color";
            btnSave.Text = "Update";

            LoadRecordData(); // Fill the fields
        }

        void LoadRecordData()
        {
            // Find the color with this id from the database
            var repo = new GenericRepository<Color>();
            var manager = new ColorManager(repo);
            var color = manager.GetById(_recordIdToUpdate);

            if (color != null)
            {
                // Fill the fields
                txtColorName.Text = color.ColorName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // STEP 1: Prepare connections
            var repo = new GenericRepository<Color>();
            var manager = new ColorManager(repo);

            try
            {
                // SCENARIO 1: NEW RECORD (ID = 0)
                if (_recordIdToUpdate == 0)
                {
                    // Create the object
                    var newColor = new Color
                    {
                        ColorName = txtColorName.Text.Trim()
                    };

                    // Send to Manager (let it check the rules there)
                    manager.Add(newColor);

                    // Show success message
                    XtraMessageBox.Show("Color has been successfully added to the system!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the fields so we can enter a new record
                    txtColorName.Text = "";
                    txtColorName.Focus(); // Move cursor back to the first field
                }
                // SCENARIO 2: UPDATE (ID > 0)
                else
                {
                    // First fetch the original record from the database
                    var colorToUpdate = manager.GetById(_recordIdToUpdate);

                    // Overwrite with the new information from the screen
                    colorToUpdate.ColorName = txtColorName.Text.Trim();

                    // Tell the Manager to "update this"
                    manager.Update(colorToUpdate);

                    XtraMessageBox.Show("Color has been updated!", "Success",
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
