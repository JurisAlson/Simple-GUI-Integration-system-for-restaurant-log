using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Net;

namespace M1A___Part_3_ALSON
{
    internal static class SQL
    {
        private static string connectionString = "User Id=System;Password=admin;Data Source=localhost:1521/XEPDB1";

        public static bool TestConnection(out string message)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    message = "Connected to Oracle successfully.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = "Connection failed: " + ex.Message;
                return false;
            }
        }

        public static void InsertCustomer(int customerID, string firstName, string lastName, string address, string phoneNumber, string email)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "INSERT INTO Customer (CustomerID, FirstName, LastName, Address, PhoneNumber, Email) " +
                    "VALUES (:customerID, :firstName, :lastName, :address, :phoneNumber, :email)", conn))
                {
                    cmd.Parameters.Add(":customerID", OracleDbType.Int32).Value = customerID;
                    cmd.Parameters.Add(":firstName", OracleDbType.Varchar2).Value = firstName;
                    cmd.Parameters.Add(":lastName", OracleDbType.Varchar2).Value = lastName;
                    cmd.Parameters.Add(":address", OracleDbType.Varchar2).Value = address;
                    cmd.Parameters.Add(":phoneNumber", OracleDbType.Varchar2).Value = phoneNumber;
                    cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = email;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Order
        public static void InsertOrder(int orderID2, int customerID, DateTime orderDate, decimal totalAmount, string orderStatus)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "INSERT INTO Orders2 (OrderID, CustomerID, OrderDate, TotalAmount, OrderStatus) " +
                    "VALUES (:orderID, :customerID, :orderDate, :totalAmount, :orderStatus)", conn))
                {
                    cmd.Parameters.Add(":orderID", OracleDbType.Int32).Value = orderID2;
                    cmd.Parameters.Add(":customerID", OracleDbType.Int32).Value = customerID;
                    cmd.Parameters.Add(":orderDate", OracleDbType.Date).Value = orderDate;
                    cmd.Parameters.Add(":totalAmount", OracleDbType.Decimal).Value = totalAmount;
                    cmd.Parameters.Add(":orderStatus", OracleDbType.Varchar2).Value = orderStatus;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertProduct(int productId, string productName, string description, decimal price, string category)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "INSERT INTO Product (ProductID, ProductName, Description, Price, Category) " +
                    "VALUES (:productId, :productName, :description, :price, :category)", conn))
                {
                    cmd.Parameters.Add(":productId", OracleDbType.Int32).Value = productId;
                    cmd.Parameters.Add(":productName", OracleDbType.Varchar2).Value = productName;
                    cmd.Parameters.Add(":description", OracleDbType.Varchar2).Value = description;
                    cmd.Parameters.Add(":price", OracleDbType.Decimal).Value = price;
                    cmd.Parameters.Add(":category", OracleDbType.Varchar2).Value = category;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void InsertPayment(int paymentID, int orderID, DateTime paymentDate, string paymentMethods, string status)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "INSERT INTO Payment (PaymentID, OrderID, PaymentDate, PaymentMethod, PaymentStatus) " +
                    "VALUES (:paymentID, :orderID, :paymentDate, :method, :status)", conn))
                {
                    cmd.Parameters.Add(":paymentID", OracleDbType.Int32).Value = paymentID;
                    cmd.Parameters.Add(":orderID", OracleDbType.Int32).Value = orderID;
                    cmd.Parameters.Add(":paymentDate", OracleDbType.Date).Value = paymentDate;
                    cmd.Parameters.Add(":method", OracleDbType.Varchar2).Value = paymentMethods;
                    cmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = status;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void InsertOrderItem(int orderItemID, int orderID, int productID, int quantity, decimal itemPrice)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "INSERT INTO OrderItem (OrderItemID, OrderID, ProductID, Quantity, ItemPrice) " +
                    "VALUES (:orderItemID, :orderID, :productID, :quantity, :itemPrice)", conn))
                {
                    cmd.Parameters.Add(":orderItemID", OracleDbType.Int32).Value = orderItemID;
                    cmd.Parameters.Add(":orderID", OracleDbType.Int32).Value = orderID;
                    cmd.Parameters.Add(":productID", OracleDbType.Int32).Value = productID;
                    cmd.Parameters.Add(":quantity", OracleDbType.Int32).Value = quantity;
                    cmd.Parameters.Add(":itemPrice", OracleDbType.Decimal).Value = itemPrice;

                    cmd.ExecuteNonQuery();
                }
            }
        }



        //DELETION
        public static void DeleteCustomer(int customerId)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "DELETE FROM Customer WHERE CustomerID = :customerID", conn))
                {
                    cmd.Parameters.Add(":customerID", OracleDbType.Int32).Value = customerId;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteOrder(int orderId)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "DELETE FROM Orders2 WHERE OrderID = :OrderID", conn)) 
                {
                    cmd.Parameters.Add(":OrderID", OracleDbType.Int32).Value = orderId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteProduct(int orderId)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "DELETE FROM Product WHERE ProductID = :ProductID", conn))
                {
                    cmd.Parameters.Add(":ProductID", OracleDbType.Int32).Value = orderId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteOrderItem(int OrderItemID)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "DELETE FROM OrderItem WHERE OrderItemID = :OrderItemID", conn))
                {
                    cmd.Parameters.Add(":OrderItemID", OracleDbType.Int32).Value = OrderItemID;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeletePayment(int OrderItemID)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "DELETE FROM Payment WHERE PaymentID = :PaymentID", conn))
                {
                    cmd.Parameters.Add(":PaymentID", OracleDbType.Int32).Value = OrderItemID;
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public static DataTable RetrieveAllCustomers()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("SELECT * FROM Customer", conn))
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public static DataTable RetrieveAllProducts()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("SELECT * FROM Product", conn))
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public static DataTable RetrieveAllOrders()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("SELECT * FROM Orders2", conn))
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public static DataTable RetrieveAllOrderItem()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("SELECT * FROM OrderItem", conn))
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public static DataTable RetrieveAllPayment()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("SELECT * FROM Payment", conn))
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }   


    }
}

