using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadCustomers();
            //CreateCustomer();
            //ReadCustomers();

            UsingDataSet();

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

        }

        static void ReadCustomers()
        {
            Console.WriteLine();
            Console.WriteLine("Reading Customers...");
            //string connStr = @"Data Source=ASINGALA-LPT01\SQLEXPRESS;Initial Catalog=FirstDb;Integrated Security=true;"
            string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=FirstDb;Integrated Security=true;";
            //string connStr = @"Data Source=ASINGALA-LPT01\SQLEXPRESS;Initial Catalog=FirstDb;user id=abc;password=1234;";

            SqlConnection conn = new SqlConnection(connStr);
            string qry = "SELECT * FROM Customers";
            SqlCommand cmd = new SqlCommand(qry, conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}: {rdr[1]} {rdr[2]}");
                //Console.WriteLine("{ {0}: {1} {2}", rdr["Id"], rdr["Firstname"], rdr["Lastname"]);
            }
            conn.Close();
        }

        static void CreateCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("Creating Customer...");

            //string connStr = @"Data Source=ASINGALA-LPT01\SQLEXPRESS;Initial Catalog=FirstDb;Integrated Security=true;"
            string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=FirstDb;Integrated Security=true;";
            //string connStr = @"Data Source=ASINGALA-LPT01\SQLEXPRESS;Initial Catalog=FirstDb;user id=abc;password=1234;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //string qry = "INSERT INTO Customers";
                //qry += " (Firstname, Lastname, City)";
                //qry += " VALUES ('Greg', 'Norman', 'Los Angeles')";

                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO Customers");
                sb.Append(" (Firstname, Lastname, City)");
                sb.Append(" VALUES ('George', 'Norman', 'Los Angeles');");
                sb.Append(" SELECT @@IDENTITY;");

                using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
                {
                    conn.Open();
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine($"Id of inserted record is {newId}");
                }
                conn.Close();
            }
        }

        // Disconnected Architecture.
        static void UsingDataSet()
        {
            Console.WriteLine();
            Console.WriteLine("Reading Customers using DataSet...");
            string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=FirstDb;Integrated Security=true;";

            SqlConnection conn = new SqlConnection(connStr);
            string qry = "SELECT * FROM Customers";

            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Customers");

            DataTable dt = ds.Tables["Customers"];
            Console.WriteLine("Customers...");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row[0]}: {row[1]} {row[2]}");
            }

            string qry2 = "SELECT * FROM Orders";

            SqlDataAdapter da2 = new SqlDataAdapter(qry2, conn);
            da2.Fill(ds, "Orders");
            DataTable dt2 = ds.Tables["Orders"];
            Console.WriteLine("Orders...");
            foreach (DataRow row in dt2.Rows)
            {
                Console.WriteLine($"{row[0]}: {row[1]} {row[2]}");
            }
        }
    }
}
