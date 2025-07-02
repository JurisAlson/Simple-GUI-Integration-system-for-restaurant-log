using System;
using System.Data;
using System.Windows.Forms;

namespace M1A___Part_3_ALSON
{
    public partial class Retrieve : Form
    {
        public Retrieve()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Retrieve_Load);
            this.Load += new System.EventHandler(this.Retrieve_LoadProduct);
            this.Load += new System.EventHandler(this.Retrieve_LoadOrder);
            this.Load += new System.EventHandler(this.Retrieve_LoadOOrderItem);
            this.Load += new System.EventHandler(this.Retrieve_LoadPayment);

            INSERT.Click += INSERT_Click;
            UPDATE.Click += UPDATE_Click;
            DELETE.Click += DELETION_Click;
            EXIT.Click += EXIT_Click;
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

        private void UPDATE_Click(object sender, EventArgs e)
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

        private void Retrieve_Load(object sender, EventArgs e)
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

        private void Retrieve_LoadProduct(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllProducts();
                ProductDataGridView.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

        }

        private void Retrieve_LoadOrder(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllOrders();
                OrderDataGridView.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

        }

        private void Retrieve_LoadOOrderItem(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllOrderItem();
                OrderItemDataGridView.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

        }

        private void Retrieve_LoadPayment(object sender, EventArgs e)
        {
            try
            {
                DataTable data = SQL.RetrieveAllPayment();
                PaymentDataGridView.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }

        }
    }
}
