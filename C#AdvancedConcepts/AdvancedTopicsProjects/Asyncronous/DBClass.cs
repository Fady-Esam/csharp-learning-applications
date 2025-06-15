using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Asyncronous
{
    internal class DBClass
    {
        private static readonly SqlConnection sqlConn;
        private const string connString = "Server =DESKTOP-2CS7U6C\\SQLSERVERTEST; DataBase = HR_DB; User Id = sa; Password = 123; Timeout=30";
        private static DataTable dt1;
        private static SqlCommand cmd;
        private static SqlDataAdapter sda;
        private static SqlCommandBuilder cmdbl;
        private static string returnedCell;
        private static int returnedRowsCount;
        private static int returnedID = 0;
        private static object result;


        static DBClass()
        {
            try
            {
                sqlConn = new SqlConnection(connString);
            }
            catch
            {
                MessageBox.Show("Kindly check your connection");
            }
        }

        public DataTable dataget(string qry1, string state)
        {
            sda = new SqlDataAdapter(qry1, sqlConn);
            if (state == "get")
            {
                dt1 = new DataTable();
                try
                {
                    sda.Fill(dt1);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message, "Error of DataGet");
                }
                return dt1;
            }
            else
            {
                try
                {
                    cmdbl = new SqlCommandBuilder(sda);
                    sda.Update(dt1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
        }


        public async Task<DataTable> dataget2(string qry1, string state)
        {
            sda = new SqlDataAdapter(qry1, sqlConn);
            if (state == "get")
            {
                dt1 = new DataTable();
                try
                {
                    await Task.Run(() => sda.Fill(dt1))
                    ;
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message, "Error of DataGet");
                }
                return dt1;
            }

            else
            {
                try
                {
                    cmdbl = new SqlCommandBuilder(sda);
                    sda.Update(dt1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
        }


        public string dataget(string qry, int x)
        {

            dt1 = new DataTable();
            try
            {
                sda = new SqlDataAdapter(qry, sqlConn);
                sda.Fill(dt1);

                returnedCell = dt1.Rows[0][x].ToString();
                return returnedCell;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int saveway(string qry1)
        {
            cmd = new SqlCommand(qry1, sqlConn);

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }

                returnedRowsCount = cmd.ExecuteNonQuery();
                sqlConn.Close();
                return returnedRowsCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SaveWay Error");
                sqlConn.Close();
                return 0;
            }
        }
        public int SaveWithReturnIdentity(string qry)
        {
            cmd = new SqlCommand(qry, sqlConn);
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    returnedID = Convert.ToInt32(result);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SaveWithReturnIdentity Error");
            }
            finally
            {
                sqlConn.Close();
            }
            return returnedID;
        }


    }


}

