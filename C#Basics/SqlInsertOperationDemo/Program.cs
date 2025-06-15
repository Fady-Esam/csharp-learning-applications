using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Channels;

class Program
{
    static void Main()
    {
        string connectionString = "Server=DESKTOP-2CS7U6C;Database=SQLServerTest;Integrated Security=True;";
        Console.WriteLine(connectionString);
        InsertData(4, "John", "USA", "New York", 30);
    }
    
    public static void InsertData(int id, string name, string country, string city, int age)
    {
       string connectionString = "Server=DESKTOP-2CS7U6C;Database=SQLServerTest;Integrated Security=True;";

        using SqlConnection connection = new SqlConnection(connectionString);
        string query = "INSERT INTO Table (Id, Name, Country, City, Age) VALUES (@Id, @Name, @Country, @City, @Age)";

        using SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Country", country);
        command.Parameters.AddWithValue("@City", city);
        command.Parameters.AddWithValue("@Age", age);

        try
        {
            connection.Open();
            int result = command.ExecuteNonQuery();

            if (result < 0)
                Console.WriteLine("Error inserting data into Database!");
            else
                Console.WriteLine("Data inserted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
    
}
