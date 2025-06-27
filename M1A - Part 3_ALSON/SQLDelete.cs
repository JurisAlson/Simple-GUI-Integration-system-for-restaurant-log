using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1A___Part_3_ALSON
{
    internal class SQLDelete
    {
        private static string connectionString = "User Id=System;Password=admin;Data Source=localhost:1521/XEPDB1";

        // Deletion Customer
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
