

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AdventureWorks.Library.Models;

namespace AdventureWorks.Data 
{
    public class AdoData
    {
        // To connect to database we need connection string
        // needs to have name of server, name of database, credentials
        private string dbconnect = "data source=adventureworksdb.cxkf3wzoieaw.us-east-2.rds.amazonaws.com; initial catalog=adventureworksdb;user id=sqladmin; password=password123";

        public string ReadConnected()
        {
            //DataSet ds;
            SqlDataReader dr; // like iterator, keeps reading information
            string q = "select firstname, lastname from person.person;";
            SqlCommand sc = new SqlCommand(q);
            var sb = new StringBuilder();

            using(SqlConnection c = new SqlConnection(dbconnect)) // use using so connection closes itself
            {
                c.Open();
                sc.Connection = c;

                dr = sc.ExecuteReader();
            
                var count = 0;
                while(dr.Read() && count < 5) // read one row, then read next row
                {
                    sb.AppendLine(string.Format("{0} {1}", dr[0], dr[1]));
                    // System.Console.WriteLine("{0} {1}", dr[0], dr[1]); // indexing of row is columns, these are POCO objects, an object of type object
                    count += 1;
                }
            }
            return sb.ToString();
        }

        public string ReadDisconnected()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string q = "select firstname, lastname from person.person;";
            var sb = new StringBuilder();
            var count = 0;

            using (var c = new SqlConnection(dbconnect))
            {
                var sc = new SqlCommand(q);
                sc.Connection = c;
                da.SelectCommand = sc;
                da.Fill(ds);
            } // here is the difference from read connected, you just saved everything to a dataset

            foreach (DataRow row in ds.Tables[0].Rows) // we cannot loop on dataset itself, Tables because select could return more than one table
            {
                if(count > 9)
                    break;
                // What you are actually getting back is a dictionary
                // You get positions and names from query, these will be case sensitive
                sb.AppendLine(string.Format("{0} {1}", row["firstname"], row["lastname"]));
                count += 1;
            }

            return sb.ToString();
        }
        
        //Create a way to deal with these strings as C# objects
        public List<Person> ReadPeopleDisconnected()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string q = "select firstname, lastname from person.person;";
            var sb = new StringBuilder();
            var count = 0;

            using (var c = new SqlConnection(dbconnect))
            {
                var sc = new SqlCommand(q);
                sc.Connection = c;
                da.SelectCommand = sc;
                da.Fill(ds);
            } // here is the difference from read connected, you just saved everything to a dataset

            var people = new List<Person>();

            foreach (DataRow row in ds.Tables[0].Rows) // we cannot loop on dataset itself, Tables because select could return more than one table
            {
                if(count > 9)
                    break;
                // What you are actually getting back is a dictionary
                // You get positions and names from query, these will be case sensitive
                sb.AppendLine(string.Format("{0} {1}", row["firstname"], row["lastname"]));
                var firstname = string.Format("{0}", row["firstname"]);
                var lastname = string.Format("{0}", row["lastname"]);
                var p = new Person(firstname, lastname);
                people.Add(p);
                count += 1;
            }

            return people;
        }


        public string ReadConnected3(string query) // checking for sql injection
        {
            //DataSet ds;
            SqlDataReader dr; // like iterator, keeps reading information
            var sp = new SqlParameter("id", query); // helps prevent sql injection, will make it one value
            string q = "select firstname, lastname from person.person where businessentityid= @id;"; // we created a variable in sql rather than passing plain text
            SqlCommand sc = new SqlCommand(q);
            var sb = new StringBuilder();

            using(SqlConnection c = new SqlConnection(dbconnect)) // use using so connection closes itself
            {
                c.Open();
                sc.Parameters(sp);
                sc.Connection = c;

                dr = sc.ExecuteReader();
            
                var count = 0;
                while(dr.Read() && count < 5) // read one row, then read next row
                {
                    sb.AppendLine(string.Format("{0} {1}", dr[0], dr[1]));
                    // System.Console.WriteLine("{0} {1}", dr[0], dr[1]); // indexing of row is columns, these are POCO objects, an object of type object
                    count += 1;
                }
            }
            return sb.ToString();
        }

        public bool Insert() // always disconnected because you can only use sqladapter
        {
            using(var c = new SqlConnection());
            {
                var sc = new SqlCommand("INSERT INTO Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, rowguid, SpatialLocation) Values('TampLa', NULL, '334 EEEtball St', 79, 22222, '2018-03-20', '0B6B739D-8EB6-4378-8D55-FE196BF34C2F', 0xE6100000010C61C64D8ABBD94740C460EA3FD8855FC0);");
                sc.Connection = c;
                return sc.ExecuteNonQuery() == 1; // It is ok to return inside using

                // // This is another way to do it
                // sc.CommandText = "INSERT INTO Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, rowguid, SpatialLocation) Values('TampLa', NULL, '334 EEEtball St', 79, 22222, '2018-03-20', '0B6B739D-8EB6-4378-8D55-FE196BF34C2F', 0xE6100000010C61C64D8ABBD94740C460EA3FD8855FC0);";
                // sc.CommandType = CommandType.StoredProcedure;
                // return sc.ExecuteNonQuery() == 1; // It is ok to return inside using, ExecuteNonQuery makes SqlDataAdapter behind scenes

                // // Another way to do it using a DataSet
                // var ds = new DataSet()
                // var da = new SqlDataAdapter();
                // da.InsertCommand = sc;
                // da.Fill(ds);            
            }
        }

        // You can do same thing for delete and same thing for update
    }
}