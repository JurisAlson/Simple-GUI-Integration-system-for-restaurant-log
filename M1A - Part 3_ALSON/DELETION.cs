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
    public partial class DELETION : Form
    {
        public DELETION()
        {
            InitializeComponent();
            CustomerDELETE.Click += customerDELETE_Click;
            orderIDDELETE.Click += orderIDDELETE_Click;
            productIDDELETE.Click += productIDDELETE_Click;
            orderitemIDDELETE.Click += orderitemIDDELETE_Click;
            paymentIDDELETE.Click += paymentIDDELETE_Click;

            READ.Click += READ_Click;
            INSERT.Click += INSERT_CLICK;
            UPDATE.Click += UPDATE_CLICK;
            EXIT.Click += EXIT_Click;

        }

        private static string connectionString = "User Id=System;Password=admin;Data Source=localhost:1521/XEPDB1";

        private void customerDELETE_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(CustomertextBox.Text))
            {
                MessageBox.Show("Please enter a Customer ID.");
                return;
            }

            if (!int.TryParse(CustomertextBox.Text, out int customerId))
            {
                MessageBox.Show("Customer ID must be a number.");
                return;
            }

            // Confirm deletion
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Customer ID {customerId} and all related data?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SQL.DeleteCustomer(customerId);
                    MessageBox.Show("Customer and related data deleted successfully.");
                    CustomertextBox.Clear(); // Optionally clear input
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void orderIDDELETE_Click(Object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(ORDERtextBox.Text))
            {
                MessageBox.Show("Please enter a Order ID.");
                return;
            }

            if (!int.TryParse(ORDERtextBox.Text, out int OrderId))
            {
                MessageBox.Show("Order ID must be a number.");
                return;
            }

            // Confirm deletion
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Order ID {OrderId} and all related data?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SQL.DeleteOrder(OrderId);
                    MessageBox.Show("Order and related data deleted successfully.");
                    ORDERtextBox.Clear();
                }
                catch (Exception ex)
                { 
             
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void productIDDELETE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductIDDELETEButton.Text))
            {
                MessageBox.Show("Please enter a Product ID.");
                return;
            }

            if (!int.TryParse(ProductIDDELETEButton.Text, out int ProductID))
            {
                MessageBox.Show("Product ID must be a number.");
                return;
            }

            //Confirm deletion
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Product ID {ProductID} and all related data?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SQL.DeleteProduct(ProductID);
                    MessageBox.Show("Product and related data deleted successfully.");
                    ProductIDDELETEButton.Clear(); // ✅ correct textbox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void orderitemIDDELETE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ORDERITEMIDtextBox.Text))
            {
                MessageBox.Show("Please enter a Order Item ID.");
                return;
            }

            if (!int.TryParse(ORDERITEMIDtextBox.Text, out int OrderItemID))
            {
                MessageBox.Show("Order Item ID must be a number.");
                return;
            }

            //Confirm deletion
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Order Item ID {OrderItemID} and all related data?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SQL.DeleteOrderItem(OrderItemID);
                    MessageBox.Show("OrderItemID and related data deleted successfully.");
                    ProductIDDELETEButton.Clear(); // ✅ correct textbox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void paymentIDDELETE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PAYMENTIDtextBox.Text))
            {
                MessageBox.Show("Please enter a Order Payment ID.");
                return;
            }

            if (!int.TryParse(PAYMENTIDtextBox.Text, out int PaymentID))
            {
                MessageBox.Show("Order Payment ID must be a number.");
                return;
            }

            //Confirm deletion
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Payment ID {PaymentID} and all related data?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SQL.DeletePayment(PaymentID);
                    MessageBox.Show("PaymentID and related data deleted successfully.");
                    PAYMENTIDtextBox.Clear(); // ✅ correct textbox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void INSERT_CLICK(object sender, EventArgs e)
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                var InsertForm = new MAIN();
                InsertForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message, "Error");
            }
        }
        private void UPDATE_CLICK(object sender, EventArgs e)
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                var RetriveForm = new UPDATE();
                RetriveForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message, "Error");
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
    }
        


    
    
}
