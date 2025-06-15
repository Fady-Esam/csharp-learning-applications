using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

internal class Program
{
    static void Main(string[] args)
    {
        string conString = "";

        DataTable dataTable;

        using(SqlConnection con = new SqlConnection(conString))
        {
            SqlCommand cmd = new SqlCommand("select * from ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dataTable = new DataTable();
            sda.Fill(dataTable); // it is a bridge between DataTable or DataSet and database
        }
    }
}

