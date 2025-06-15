using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {

        
        // clone => only structure (no data)
        // copy => both structure and data


        // DataTable
        #region DataTable


        DataTable EmployeesDataTable = new DataTable();
        EmployeesDataTable.Columns.Add("ID", typeof(int));
        EmployeesDataTable.Columns.Add("Name", typeof(string));
        EmployeesDataTable.Columns.Add("Country", typeof(string));
        EmployeesDataTable.Columns.Add("Department", typeof(string));
        EmployeesDataTable.Columns.Add("Salary", typeof(decimal));
        EmployeesDataTable.Columns.Add("Date", typeof(DateTime));




        //DataColumn dtColumn;
        //dtColumn = new DataColumn();
        //dtColumn.DataType = typeof(int);
        //dtColumn.ColumnName = "ID";
        //dtColumn.ReadOnly = true;
        //dtColumn.Unique = true;
        //dtColumn.AutoIncrement = true;
        //dtColumn.AutoIncrementSeed = 1;
        //dtColumn.AutoIncrementStep = 1;

        //EmployeesDataTable.Columns.Add(dtColumn);

        //DataColumn[] dcp = new DataColumn[1];
        //dcp[0] = EmployeesDataTable.Columns["ID"];
        //EmployeesDataTable.PrimaryKey = dcp;


        //DataRow dtr;
        //dtr = EmployeesDataTable.NewRow();
        //dtr["ID"] = 4;


        //Add rows 
        EmployeesDataTable.Rows.Add(1, "Mina Ramy", "Jordan", "HR" , 5000, DateTime.Now);
        EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA", "IT",525.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(3, "Lina Kamal", "Jordan","HR" ,730.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(4, "Fadi JAmeel", "Egypt","IT" , 800, DateTime.Now);
        EmployeesDataTable.Rows.Add(5, "Omar Mahmoud", "Lebanon","HR" ,7000, DateTime.Now);

        foreach (DataRow RecordRow in EmployeesDataTable.Rows)
        {
            //Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
            //    RecordRow["ID"], RecordRow["Name"], RecordRow["Country"], RecordRow["Salary"],
            //    RecordRow["Date"]);
        }

        var s = from row in EmployeesDataTable.AsEnumerable()
                orderby row.Field<int>("Salary") descending
                select row;


        var NewData = from row in EmployeesDataTable.AsEnumerable()
                        group row by row.Field<string>("Department") into newGroupedData
                        select new 
                        { 
                            
                        };


        DataRow[] rows = EmployeesDataTable.Select("Salary >= 5000");
        foreach (var RecordRow in rows)
        {
            // Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
            // RecordRow["ID"], RecordRow["Name"], RecordRow["Country"], RecordRow["Salary"],
            // RecordRow["Date"]);
        }
        decimal filterSalary = EmployeesDataTable.AsEnumerable().Min((dr) => dr.Field<decimal>("Salary"));


        filterSalary = Convert.ToDecimal(EmployeesDataTable.Compute("SUM(Salary)", "Salary >= 5000"));

        //EmployeesDataTable.AsEnumerable().Where((dt) => dt.Field<>())


        EmployeesDataTable.DefaultView.Sort = "ID DESC";
        EmployeesDataTable = EmployeesDataTable.DefaultView.ToTable();

        foreach (DataRow RecordRow in EmployeesDataTable.Rows)
        {
            //Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
            //    RecordRow["ID"], RecordRow["Name"], RecordRow["Country"], RecordRow["Salary"],
            //    RecordRow["Date"]);

        }


        //Console.WriteLine(filterSalary);


        //EmployeesDataTable.Select("ID = 4")[0].Delete();
        EmployeesDataTable.Select("ID = 4")[0]["Salary"] = 50000;

        foreach (DataRow RecordRow in EmployeesDataTable.Rows)
        {
            //Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
            //    RecordRow["ID"], RecordRow["Name"], RecordRow["Country"], RecordRow["Salary"],
            //    RecordRow["Date"]);
        }
        #endregion

        // DataView
        #region DataView


        DataView dtv = new DataView(EmployeesDataTable); // dataview is considered two dimentional array
        dtv.Sort = "ID DESC";
        dtv.RowFilter = "Salary >= 5000";
        for (int i = 0; i < dtv.Count; i++)
        {
            for(int j = 0; j < EmployeesDataTable.Columns.Count; j++)
            {
                Console.WriteLine(dtv[i][j]);
            }
        }





        #endregion
        Console.ReadKey();
    }
}

