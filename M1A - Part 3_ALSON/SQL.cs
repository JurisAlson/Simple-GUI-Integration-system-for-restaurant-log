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

        // Payment
        public static void InsertPayment(int paymentId, int orderId, DateTime paymentDate, decimal paymentAmount, string paymentMethod, string paymentStatus)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "INSERT INTO Payment (PaymentID, OrderID, PaymentDate, PaymentAmount, PaymentMethod, PaymentStatus) " +
                    "VALUES (:paymentId, :orderId, :paymentDate, :paymentAmount, :paymentMethod, :paymentStatus)", conn))
                {
                    cmd.Parameters.Add(":paymentId", OracleDbType.Int32).Value = paymentId;
                    cmd.Parameters.Add(":orderId", OracleDbType.Int32).Value = orderId;
                    cmd.Parameters.Add(":paymentDate", OracleDbType.Date).Value = paymentDate;
                    cmd.Parameters.Add(":paymentAmount", OracleDbType.Decimal).Value = paymentAmount;
                    cmd.Parameters.Add(":paymentMethod", OracleDbType.Varchar2).Value = paymentMethod;
                    cmd.Parameters.Add(":paymentStatus", OracleDbType.Varchar2).Value = paymentStatus;

                    cmd.ExecuteNonQuery();
                }
            }
        }


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







    }
}
