using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Apr28
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection Connector = new SqlConnection())
            {
                Connector.ConnectionString =
                    ConfigurationManager.ConnectionStrings["c"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Connector;
                    cmd.CommandText = "Select ProductName from products";

                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        DataSet d = new DataSet();
                        ad.SelectCommand = cmd;
                        ad.Fill(d);
                        foreach(DataRow row in d.Tables[0].Rows)
                        {
                            Console.WriteLine(row.Field<string>("ProductName"));
                        }
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
