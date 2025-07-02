using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M1A___Part_3_ALSON
{
    public partial class UPDATE : Form
    {
        public UPDATE()
        {
            InitializeComponent();
            this.Load += UPDATE_Load;
            this.Load += UPDATE_LoadProduct;
            this.Load += UPDATE_LoadOrder;
            this.Load += UPDATE_LoadOOrderItem;
            this.Load += UPDATE_LoadPayment;

            dataGridViewCustomer.CellEndEdit += dataGridView1_CellEndEdit;
            DataGridViewProduct.CellEndEdit += ProductDataGridView_CellEndEdit;
            DataGridViewOrder1.CellEndEdit += OrderDataGridView_CellEndEdit;
            DataGridViewOrderitem.CellEndEdit += OrderItemDataGridView_CellEndEdit;
            DataGridViewPayment.CellEndEdit += PaymentDataGridView_CellEndEdit;

            READ.Click += READ_Click;
            INSERT.Click += INSERT_Click;
            DELETION.Click += DELETION_Click;
            EXIT.Click += EXIT_Click;
        }

        private void UPDATE_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllCustomers(); 
                dataGridViewCustomer.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }
        }

        private void UPDATE_LoadProduct(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllProducts();
                DataGridViewProduct.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

        }

        private void UPDATE_LoadOrder(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllOrders();
                DataGridViewOrder1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

        }

        private void UPDATE_LoadOOrderItem(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllOrderItem();
                DataGridViewOrderitem.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

        }

        private void UPDATE_LoadPayment(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllPayment();
                DataGridViewPayment.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

        }

        private void READ_Click(object sender, EventArgs e)
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                var RetriveForm = new Retrieve();
                RetriveForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message, "Error");
            }
        }
        private void INSERT_Click(object sender, EventArgs e)
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                var RetriveForm = new MAIN();
                RetriveForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message, "Error");
            }

        }
        private void DELETION_Click(object sender, EventArgs e) 
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                var RetriveForm = new DELETION();
                RetriveForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message, "Error");
            }

        }
        private void EXIT_Click(object sender, EventArgs e) 
        {
            Application.Exit();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var row = dataGridViewCustomer.Rows[e.RowIndex];

                int customerID = Convert.ToInt32(row.Cells["CustomerID"].Value);
                string firstName = row.Cells["FirstName"].Value.ToString();
                string lastName = row.Cells["LastName"].Value.ToString();
                string address = row.Cells["Address"].Value.ToString();
                string phone = row.Cells["PhoneNumber"].Value.ToString();
                string email = row.Cells["Email"].Value.ToString();

                SQL.UpdateCustomer(customerID, firstName, lastName, address, phone, email);
                MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message);
            }
        }
        private void ProductDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = DataGridViewProduct.Rows[e.RowIndex];

                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                string productName = row.Cells["ProductName"].Value.ToString();
                string description = row.Cells["Description"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                string category = row.Cells["Category"].Value.ToString();

                SQL.UpdateProduct(productId, productName, description, price, category);
                MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message);
            }
        }


        private void OrderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = DataGridViewOrder1.Rows[e.RowIndex];

                int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);
                int customerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
                DateTime orderDate = Convert.ToDateTime(row.Cells["OrderDate"].Value);
                decimal totalAmount = Convert.ToDecimal(row.Cells["TotalAmount"].Value);
                string orderStatus = row.Cells["OrderStatus"].Value.ToString();

                SQL.UpdateOrder(orderId, customerId, orderDate, totalAmount, orderStatus);
                MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message);
            }
        }


        private void OrderItemDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = DataGridViewOrderitem.Rows[e.RowIndex];

                int orderItemId = Convert.ToInt32(row.Cells["OrderItemID"].Value);
                int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);
                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal itemPrice = Convert.ToDecimal(row.Cells["ItemPrice"].Value);

                SQL.UpdateOrderItem(orderItemId, orderId, productId, quantity, itemPrice);
                MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message);
            }
        }

        private void PaymentDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = DataGridViewPayment.Rows[e.RowIndex];

                int paymentId = Convert.ToInt32(row.Cells["PaymentID"].Value);
                int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);
                DateTime paymentDate = Convert.ToDateTime(row.Cells["PaymentDate"].Value);
                string paymentMethod = row.Cells["PaymentMethod"].Value.ToString();
                string paymentStatus = row.Cells["PaymentStatus"].Value.ToString();

                SQL.UpdatePayment(paymentId, orderId, paymentDate, paymentMethod, paymentStatus);
                MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message);
            }
        }



    }
}
