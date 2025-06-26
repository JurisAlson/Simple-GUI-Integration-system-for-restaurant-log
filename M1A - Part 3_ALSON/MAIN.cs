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
    public partial class MAIN : Form
    {
        public MAIN()
        {
            InitializeComponent();
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
            button6.Click += button6_Click;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string customer = textboxCustomerID.Text.Trim();
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            string phoneNumber = textBoxPhone.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            if (string.IsNullOrEmpty(customer) ||
                string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all customer fields.");
                return;
            }

            // Try to parse CustomerID to int
            if (!int.TryParse(customer, out int customerId))
            {
                MessageBox.Show("Customer ID must be a valid number.");
                return;
            }

            try
            {
                SQL.InsertCustomer(customerId, firstName, lastName, address, phoneNumber, email);
                MessageBox.Show("Customer added successfully!");

                textboxCustomerID.Clear();
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxAddress.Clear();
                textBoxPhone.Clear();
                textBoxEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //Order Insertion
        private void button3_Click(object sender, EventArgs e)
        {
            // Get order details
            string orderIdText = textBoxOrderID.Text.Trim();
            string customerIdText = textBoxOrderCustomerID.Text.Trim();
            string orderDateText = textBoxOrderDate.Text.Trim();
            string totalAmountText = textBoxTotalAmount.Text.Trim();
            string orderStatus = textBoxOrderStatus.Text.Trim();

            // Validate
            if (string.IsNullOrEmpty(orderIdText) ||
                string.IsNullOrEmpty(customerIdText) ||
                string.IsNullOrEmpty(orderDateText) ||
                string.IsNullOrEmpty(totalAmountText) ||
                string.IsNullOrEmpty(orderStatus))
            {
                MessageBox.Show("Please fill in all order fields.");
                return;
            }

            // Convert and validate types
            if (!int.TryParse(orderIdText, out int orderId))
            {
                MessageBox.Show("Order ID must be a number.");
                return;
            }

            if (!int.TryParse(customerIdText, out int customerId))
            {
                MessageBox.Show("Customer ID must be a number.");
                return;
            }

            if (!DateTime.TryParse(orderDateText, out DateTime orderDate))
            {
                MessageBox.Show("Invalid Order Date (format: yyyy-MM-dd).");
                return;
            }

            if (!decimal.TryParse(totalAmountText, out decimal totalAmount))
            {
                MessageBox.Show("Invalid Total Amount.");
                return;
            }

            // Validate OrderStatus
            var validStatuses = new[] { "preparing", "order out", "receive" };
            if (!validStatuses.Contains(orderStatus.ToLower()))
            {
                MessageBox.Show("Order status must be: preparing, order out, or receive.");
                return;
            }

            try
            {
                SQL.InsertOrder(orderId, customerId, orderDate, totalAmount, orderStatus);
                MessageBox.Show("Order inserted successfully!");

                textBoxOrderID.Clear();
                textBoxOrderCustomerID.Clear();
                textBoxOrderDate.Clear();
                textBoxTotalAmount.Clear();
                textBoxOrderStatus.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Product
        private void button4_Click(object sender, EventArgs e)
        {
            string productIdText = textBoxProductID.Text.Trim();
            string productName = textBoxProductName.Text.Trim();
            string description = textBoxDescription.Text.Trim();
            string priceText = textBoxPrice.Text.Trim();
            string category = comboBoxCategory.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(productIdText) ||
                string.IsNullOrEmpty(productName) ||
                string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(priceText) ||
                string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please fill in all product fields.");
                return;
            }

            if (!int.TryParse(productIdText, out int productId))
            {
                MessageBox.Show("Product ID must be a valid number.");
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Price must be a valid decimal number.");
                return;
            }

            string[] validCategories = { "BreakFast", "Lunch", "Dinner" };
            if (!validCategories.Contains(category))
            {
                MessageBox.Show("Category must be one of: BreakFast, Lunch, Dinner.");
                return;
            }

            try
            {
                SQL.InsertProduct(productId, productName, description, price, category);
                MessageBox.Show("Product added successfully!");

                // Clear fields
                textBoxProductID.Clear();
                textBoxProductName.Clear();
                textBoxDescription.Clear();
                textBoxPrice.Clear();
                comboBoxCategory.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //Payment
        private void button6_Click(object sender, EventArgs e)
        {
            string paymentIDText = PaymentID.Text.Trim();
            string orderIDText = textorderID.Text.Trim();
            string paymentDateText = textpaymentdate.Text.Trim();
            string paymentMethod = textstatus.Text.Trim(); // Should only be used for method
            string paymentStatus = paymenttext.Text.Trim();
            //string amountText = textAmount.Text.Trim();  // This should hold the amount

            // Validate required fields
            if (string.IsNullOrEmpty(paymentIDText) ||
                string.IsNullOrEmpty(orderIDText) ||
                string.IsNullOrEmpty(paymentDateText) ||
                string.IsNullOrEmpty(paymentStatus) ||
                string.IsNullOrEmpty(paymentMethod)) 
                //string.IsNullOrEmpty(amountText))
            {
                MessageBox.Show("Please fill in all payment fields.");
                return;
            }

            // Convert numeric fields
            if (!int.TryParse(paymentIDText, out int paymentID))
            {
                MessageBox.Show("Payment ID must be a valid number.");
                return;
            }

            if (!int.TryParse(orderIDText, out int orderID))
            {
                MessageBox.Show("Order ID must be a valid number.");
                return;
            }

            //if (!decimal.TryParse(amountText, out decimal paymentAmount))
            //{
            //    MessageBox.Show("Payment amount must be a valid decimal number.");
            //    return;
            //}

            if (!DateTime.TryParse(paymentDateText, out DateTime paymentDate))
            {
                MessageBox.Show("Payment date must be a valid date.");
                return;
            }

            // Validate method and status
            string[] validMethods = { "Cash on Delivery", "Card" };
            if (!validMethods.Contains(paymentMethod))
            {
                MessageBox.Show("Payment method must be either 'Cash on Delivery' or 'Card'.");
                return;
            }

            string[] validStatuses = { "Processing", "Completed", "Cancelled" };
            if (!validStatuses.Contains(paymentStatus))
            {
                MessageBox.Show("Payment status must be one of: Processing, Completed, Cancelled.");
                return;
            }

            // Perform insertion
            try
            {
                SQL.InsertPayment(paymentID, orderID, paymentDate, paymentMethod, paymentStatus);
                MessageBox.Show("Payment added successfully!");

                // Clear fields
                PaymentID.Clear();
                textorderID.Clear();
                textpaymentdate.Clear();
                //textAmount.Clear();
                textstatus.Clear();
                //paymenttext.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }








        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxOrderDate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxOrderStatus = new System.Windows.Forms.TextBox();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.textBoxOrderCustomerID = new System.Windows.Forms.TextBox();
            this.textBoxOrderID = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.textBoxProductID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textboxCustomerID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.PaymentID = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.paymenttext = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.textstatus = new System.Windows.Forms.TextBox();
            this.textorderID = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.textpaymentdate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(223, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Insert";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(147, 98);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(151, 20);
            this.textBoxFirstName.TabIndex = 1;
            this.textBoxFirstName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(147, 154);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(151, 20);
            this.textBoxLastName.TabIndex = 2;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(147, 299);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(151, 20);
            this.textBoxEmail.TabIndex = 6;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(147, 243);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(151, 20);
            this.textBoxPhone.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "First Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 9;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Last Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(147, 203);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(151, 20);
            this.textBoxAddress.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Address";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Phone Nmber";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Email";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Order Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Total Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Order Date";
            // 
            // textBoxOrderDate
            // 
            this.textBoxOrderDate.Location = new System.Drawing.Point(405, 148);
            this.textBoxOrderDate.Name = "textBoxOrderDate";
            this.textBoxOrderDate.Size = new System.Drawing.Size(151, 20);
            this.textBoxOrderDate.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(322, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Customer ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(327, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Order ID";
            // 
            // textBoxOrderStatus
            // 
            this.textBoxOrderStatus.Location = new System.Drawing.Point(405, 243);
            this.textBoxOrderStatus.Name = "textBoxOrderStatus";
            this.textBoxOrderStatus.Size = new System.Drawing.Size(151, 20);
            this.textBoxOrderStatus.TabIndex = 19;
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Location = new System.Drawing.Point(405, 203);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.Size = new System.Drawing.Size(151, 20);
            this.textBoxTotalAmount.TabIndex = 18;
            // 
            // textBoxOrderCustomerID
            // 
            this.textBoxOrderCustomerID.Location = new System.Drawing.Point(405, 105);
            this.textBoxOrderCustomerID.Name = "textBoxOrderCustomerID";
            this.textBoxOrderCustomerID.Size = new System.Drawing.Size(151, 20);
            this.textBoxOrderCustomerID.TabIndex = 17;
            // 
            // textBoxOrderID
            // 
            this.textBoxOrderID.Location = new System.Drawing.Point(410, 67);
            this.textBoxOrderID.Name = "textBoxOrderID";
            this.textBoxOrderID.Size = new System.Drawing.Size(151, 20);
            this.textBoxOrderID.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(481, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Insert";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(601, 264);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Category";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(601, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Price";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(601, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Description";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(684, 165);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(151, 20);
            this.textBoxDescription.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(601, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Product Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(601, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Product ID";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Location = new System.Drawing.Point(684, 261);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(151, 20);
            this.comboBoxCategory.TabIndex = 31;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(684, 205);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(151, 20);
            this.textBoxPrice.TabIndex = 30;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(684, 116);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(151, 20);
            this.textBoxProductName.TabIndex = 29;
            // 
            // textBoxProductID
            // 
            this.textBoxProductID.Location = new System.Drawing.Point(684, 60);
            this.textBoxProductID.Name = "textBoxProductID";
            this.textBoxProductID.Size = new System.Drawing.Size(151, 20);
            this.textBoxProductID.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(693, 185);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 26;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(65, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Customer ID";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // textboxCustomerID
            // 
            this.textboxCustomerID.Location = new System.Drawing.Point(148, 61);
            this.textboxCustomerID.Name = "textboxCustomerID";
            this.textboxCustomerID.Size = new System.Drawing.Size(151, 20);
            this.textboxCustomerID.TabIndex = 38;
            this.textboxCustomerID.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(65, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 40;
            this.label19.Text = "Customer";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(327, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 41;
            this.label20.Text = "Orders";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(65, 361);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 55;
            this.label21.Text = "Order Item";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(65, 393);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 13);
            this.label22.TabIndex = 54;
            this.label22.Text = "Order Item ID";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(148, 392);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(151, 20);
            this.textBox12.TabIndex = 53;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(64, 581);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 51;
            this.label24.Text = "Item ID";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(64, 541);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 50;
            this.label25.Text = "Quantity";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(147, 534);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(151, 20);
            this.textBox13.TabIndex = 49;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(64, 486);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(58, 13);
            this.label26.TabIndex = 48;
            this.label26.Text = "Product ID";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(64, 430);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 13);
            this.label27.TabIndex = 47;
            this.label27.Text = "Order ID";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(147, 574);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(151, 20);
            this.textBox15.TabIndex = 45;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(147, 485);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(151, 20);
            this.textBox16.TabIndex = 44;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(147, 429);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(151, 20);
            this.textBox17.TabIndex = 43;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(224, 609);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 42;
            this.button5.Text = "Insert";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(327, 362);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 13);
            this.label28.TabIndex = 69;
            this.label28.Text = "Payment";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(327, 394);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(62, 13);
            this.label29.TabIndex = 68;
            this.label29.Text = "Payment ID";
            // 
            // PaymentID
            // 
            this.PaymentID.Location = new System.Drawing.Point(410, 393);
            this.PaymentID.Name = "PaymentID";
            this.PaymentID.Size = new System.Drawing.Size(151, 20);
            this.PaymentID.TabIndex = 67;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(326, 523);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(81, 13);
            this.label32.TabIndex = 64;
            this.label32.Text = "Payment Status";
            // 
            // paymenttext
            // 
            this.paymenttext.Location = new System.Drawing.Point(409, 516);
            this.paymenttext.Name = "paymenttext";
            this.paymenttext.Size = new System.Drawing.Size(151, 20);
            this.paymenttext.TabIndex = 63;
            this.paymenttext.TextChanged += new System.EventHandler(this.textBox19_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(326, 487);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(87, 13);
            this.label33.TabIndex = 62;
            this.label33.Text = "Payment Method";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(326, 431);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(47, 13);
            this.label34.TabIndex = 61;
            this.label34.Text = "Order ID";
            // 
            // textstatus
            // 
            this.textstatus.Location = new System.Drawing.Point(409, 486);
            this.textstatus.Name = "textstatus";
            this.textstatus.Size = new System.Drawing.Size(151, 20);
            this.textstatus.TabIndex = 58;
            // 
            // textorderID
            // 
            this.textorderID.Location = new System.Drawing.Point(409, 430);
            this.textorderID.Name = "textorderID";
            this.textorderID.Size = new System.Drawing.Size(151, 20);
            this.textorderID.TabIndex = 57;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(485, 576);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 56;
            this.button6.Text = "Insert";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(620, 30);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(49, 13);
            this.label35.TabIndex = 70;
            this.label35.Text = "Products";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(760, 296);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 71;
            this.button4.Text = "Insert";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button7_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(327, 457);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 73;
            this.label23.Text = "Payment Date";
            // 
            // textpaymentdate
            // 
            this.textpaymentdate.Location = new System.Drawing.Point(410, 456);
            this.textpaymentdate.Name = "textpaymentdate";
            this.textpaymentdate.Size = new System.Drawing.Size(151, 20);
            this.textpaymentdate.TabIndex = 72;
            // 
            // MAIN
            // 
            this.ClientSize = new System.Drawing.Size(904, 703);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textpaymentdate);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.PaymentID);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.paymenttext);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.textstatus);
            this.Controls.Add(this.textorderID);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textboxCustomerID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.textBoxProductID);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxOrderDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxOrderStatus);
            this.Controls.Add(this.textBoxTotalAmount);
            this.Controls.Add(this.textBoxOrderCustomerID);
            this.Controls.Add(this.textBoxOrderID);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.button2);
            this.Name = "MAIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
