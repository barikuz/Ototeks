using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using Ototeks.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ototeks.UI
{
    public partial class FrmAddOrder : DevExpress.XtraEditors.XtraForm, IOperationForm
    {
        // This is the signal that the form will send to the outside
        public event EventHandler OperationCompleted;

        private BindingList<OrderItem> _orderItems;
        private int _recordIdToUpdate = 0; // 0 means Add Mode, >0 means Update Mode
        private OrderStatus _currentOrderStatus = OrderStatus.Pending; // Store the current order status

        public FrmAddOrder()
        {
            InitializeComponent();
            _orderItems = new BindingList<OrderItem>();
        }

        public FrmAddOrder(int id)
        {
            InitializeComponent();
            _orderItems = new BindingList<OrderItem>();
            _recordIdToUpdate = id; // Note which record we will edit.

            // Change the form title so the user understands
            this.Text = "Update Order";
            btnSave.Text = "Update";
        }

        private void FrmAddOrder_Load(object sender, EventArgs e)
        {
            // First load the dropdowns and basic settings
            LoadData();

            // Then load order data if in update mode
            if (_recordIdToUpdate > 0)
            {
                LoadOrderData();
            }
        }

        private void LoadOrderData()
        {
            try
            {
                // Find the order with that id from the database
                var repo = new GenericRepository<Order>();
                var manager = new OrderManager(repo);
                var order = manager.GetById(_recordIdToUpdate);

                if (order != null)
                {
                    // Store the current order status
                    _currentOrderStatus = order.OrderStatus;

                    // Fill the form fields
                    txtOrderNo.Text = order.OrderNumber;
                    dateOrderDate.DateTime = order.OrderDate ?? DateTime.Now;
                    lkpCustomer.EditValue = order.CustomerId;

                    // Clear and reload OrderItems
                    _orderItems.Clear();

                    // Load OrderItems as well
                    if (order.OrderItems != null && order.OrderItems.Any())
                    {
                        foreach (var item in order.OrderItems)
                        {
                            _orderItems.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occurred while loading order data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            // --- 1. Fill the Customers LookUpEdit ---
            var customerRepo = new GenericRepository<Customer>();
            var customerManager = new CustomerManager(customerRepo);

            // Fetch from database and assign to the control
            lkpCustomer.Properties.DataSource = customerManager.GetAll();

            // --- 2. Set the Date to Today ---
            if (_recordIdToUpdate == 0) // Only for new orders
            {
                dateOrderDate.DateTime = DateTime.Now;
            }

            // --- 3. Grid (Cart) Settings ---
            // Bind the grid to the BindingList we created.
            // Whatever we add to _orderItems will now appear on screen.
            gridOrderItems.DataSource = _orderItems;

            // --- C. PRODUCT TYPE DROPDOWN ---
            var productTypeRepo = new GenericRepository<ProductType>();
            var productTypeManager = new ProductTypeManager(productTypeRepo);

            // Repository created in the Designer
            repoProductType.DataSource = productTypeManager.GetAll();

            // --- D. FABRIC DROPDOWN ---
            var fabricRepo = new GenericRepository<Fabric>();
            var fabricManager = new FabricManager(fabricRepo);

            // Repository created in the Designer
            repoFabric.DataSource = fabricManager.GetAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // SCENARIO 1: NEW RECORD (ID = 0)
                if (_recordIdToUpdate == 0)
                {
                    // STEP 1: Prepare the object
                    Order newOrder = CreateOrderFromUI();

                    // STEP 2: Validate the order FIRST (before showing any modals)
                    var orderManager = new OrderManager(new GenericRepository<Order>());
                    orderManager.ValidateOrder(newOrder);

                    // STEP 3: Show stock information and ask for confirmation
                    ShowStockValidationResult(newOrder.OrderItems);

                    // STEP 4: Complete the operation
                    orderManager.Add(newOrder);

                    // STEP 5: Notify the user
                    XtraMessageBox.Show("Order has been successfully added and fabric stocks have been updated!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the form fields
                    ClearForm();
                }
                // SCENARIO 2: UPDATE (ID > 0)
                else
                {
                    // Create the order to update from the UI (set its ID)
                    Order orderToUpdate = CreateOrderFromUI();
                    orderToUpdate.OrderId = _recordIdToUpdate;

                    // Validate the order FIRST (before showing any modals)
                    var orderManager = new OrderManager(new GenericRepository<Order>());
                    orderManager.ValidateOrder(orderToUpdate, _recordIdToUpdate);

                    // Show stock information and ask for confirmation
                    ShowStockValidationResult(orderToUpdate.OrderItems);

                    // Tell the Manager to update this
                    orderManager.Update(orderToUpdate);

                    XtraMessageBox.Show("Order has been updated and fabric stocks have been recalculated!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // It makes more sense to close the form after updating.
                }

                // Send signal to the parent form (to refresh)
                OperationCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Catch and display errors
                ShowErrorMessage(ex);
            }
        }

        private Order CreateOrderFromUI()
        {
            Order order = new Order();

            // 1. Simple Assignments
            order.OrderNumber = txtOrderNo.Text;
            order.OrderDate = dateOrderDate.DateTime;

            // If in update mode, preserve the current status; for new records, set to Pending
            order.OrderStatus = _recordIdToUpdate > 0 ? _currentOrderStatus : OrderStatus.Pending;

            // "If no customer is selected assign 0, otherwise get the ID"
            order.CustomerId = lkpCustomer.EditValue != null ? (int)lkpCustomer.EditValue : 0;

            // 3. Related Data (Cart) - Preserve OrderItem IDs
            order.OrderItems = new List<OrderItem>();
            foreach (var item in _orderItems)
            {
                var orderItem = new OrderItem
                {
                    OrderItemId = item.OrderItemId, // Preserve existing ID (for updates)
                    OrderId = item.OrderId,
                    FabricId = item.FabricId,
                    TypeId = item.TypeId,
                    Quantity = item.Quantity,
                    CurrentStage = item.CurrentStage,
                    ProcessedByUserId = item.ProcessedByUserId
                };
                order.OrderItems.Add(orderItem);
            }

            return order;
        }

        private void ClearForm()
        {
            txtOrderNo.Text = "";
            dateOrderDate.DateTime = DateTime.Now;
            lkpCustomer.EditValue = null;
            _orderItems.Clear();
        }

        private void ShowErrorMessage(Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "An Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowStockValidationResult(ICollection<OrderItem> orderItems)
        {
            try
            {
                var orderManager = new OrderManager(new GenericRepository<Order>());

                // Calculate required fabric amounts
                var requiredFabrics = orderManager.CalculateRequiredFabrics(orderItems);

                if (requiredFabrics.Any())
                {
                    var message = new StringBuilder();
                    message.AppendLine("Required fabric amounts for this order:");
                    message.AppendLine();

                    foreach (var fabric in requiredFabrics)
                    {
                        message.AppendLine($"* {fabric.Key}: {fabric.Value:F2} meters");
                    }

                    message.AppendLine();
                    message.AppendLine("Do you want to continue?");

                    var result = XtraMessageBox.Show(message.ToString(), "Stock Information",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.No)
                    {
                        throw new Exception("Order operation was cancelled by the user.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch stock validation errors and rethrow so the main catch block handles them
                throw;
            }
        }

    }
}
