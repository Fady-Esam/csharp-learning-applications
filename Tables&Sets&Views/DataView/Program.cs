using System;
using System.Data;

class Program
{
    static void Main()
    {
        // Step 1: Create a DataSet
        DataSet companyDataSet = new DataSet();

        // Step 2: Create Departments DataTable
        DataTable departmentsTable = new DataTable("Departments");
        departmentsTable.Columns.Add("DepartmentID", typeof(int));
        departmentsTable.Columns.Add("DepartmentName", typeof(string));

        departmentsTable.PrimaryKey = new DataColumn[1] { departmentsTable.Columns["DepartmentID"] };


        // Add rows to Departments DataTable
        departmentsTable.Rows.Add(1, "HR");
        departmentsTable.Rows.Add(2, "IT");
        departmentsTable.Rows.Add(3, "Finance");

        // Step 3: Create Employees DataTable
        DataTable employeesTable = new DataTable("Employees");
        employeesTable.Columns.Add("EmployeeID", typeof(int));
        employeesTable.Columns.Add("EmployeeName", typeof(string));
        employeesTable.Columns.Add("DepartmentID", typeof(int)); // Foreign key


        employeesTable.PrimaryKey = new DataColumn[1] { employeesTable.Columns["EmployeeID"] };

        // Add rows to Employees DataTable
        employeesTable.Rows.Add(1, "John Doe", 1); // HR
        employeesTable.Rows.Add(2, "Jane Smith", 2); // IT
        employeesTable.Rows.Add(3, "Sam Brown", 2); // IT
        employeesTable.Rows.Add(4, "Lisa White", 3); // Finance

        // Step 4: Add tables to the DataSet
        companyDataSet.Tables.Add(departmentsTable);
        companyDataSet.Tables.Add(employeesTable);

        // Step 5: Create a DataRelation between Employees and Departments
        DataRelation relation = new DataRelation("DeptEmpRelation",
            departmentsTable.Columns["DepartmentID"],
            employeesTable.Columns["DepartmentID"]);
        
        companyDataSet.Relations.Add(relation);

        // Step 6: Display the data
        Console.WriteLine("Departments and their Employees:");
        foreach (DataRow departmentRow in departmentsTable.Rows)
        {
            Console.WriteLine($"Department: {departmentRow["DepartmentName"]}");
            // Get the employees in this department
            foreach (DataRow employeeRow in departmentRow.GetChildRows(relation))
            {
                Console.WriteLine($"  Employee: {employeeRow["EmployeeName"]}");
            }
        }

        Console.ReadKey();
    }
}
