//#define Trace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Alias
// using koko = System.Console;
using static System.Math;
using System.Data.SqlClient;
using System.Data;

using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

[Serializable] // this is an Attribute
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}



internal class MyClass
{
    [Conditional("DEBUG")]
    public void DebugModeMethod()
    {
        Console.WriteLine("Debug Method");

    }

    [Obsolete("This Method will be depecated")]
    public void TestObsoleteMethod()
    {
        Console.WriteLine("Hello");
    }


    [Conditional("koko")]
    public void NormalMethod()
    {
        Console.WriteLine("Normal Method");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        MyClass mycls = new MyClass();
        mycls.DebugModeMethod();
        mycls.NormalMethod();
        mycls.TestObsoleteMethod();





        #region Serialization
        // Json Serialization

        #region Binary Serialization
        //Person person = new Person { Name = "Fady", Age = 19 };

        //BinaryFormatter bf = new BinaryFormatter(); 
        //using(var fStream = new FileStream("person.bin", FileMode.Create))
        //{
        //    bf.Serialize(fStream, person);
        //}


        //using(var fStream = new FileStream("person.bin", FileMode.Open))
        //{
        //    Person p = (Person)bf.Deserialize(fStream);
        //    Console.WriteLine(p.Name);
        //}


        #endregion





        #region Json Serialization
        //Person person = new Person { Name = "Fady", Age = 19 };

        //DataContractJsonSerializer jsonserializer = new DataContractJsonSerializer(typeof(Person));

        //using(var stream = new MemoryStream())
        //{
        //    jsonserializer.WriteObject(stream, person);
        //    string jsonString = System.Text.Encoding.UTF8.GetString(stream.ToArray());
        //    File.WriteAllText("person.json", jsonString);
        //}



        //using(var stream = new FileStream("person.json", FileMode.Open))
        //{
        //    Person DeSirializedObject = (Person) jsonserializer.ReadObject(stream);
        //    Console.WriteLine(DeSirializedObject.Name);
        //}

        #endregion

        #region XML Serialization

        //Person person = new Person { Name = "Fady", Age = 19 };

        //var xmlSerializer = new XmlSerializer(typeof(Person));
        //using(var writer = new StreamWriter("person.xml"))
        //{
        //    xmlSerializer.Serialize(writer, person);
        //}


        //using(var reader = new StreamReader("person.xml"))
        //{
        //    Person DeSerializedPerson = (Person) xmlSerializer.Deserialize(reader);
        //    Console.WriteLine(DeSerializedPerson.Name);
        //}

        #endregion





        #endregion
        #region using
        //DataTable tbl;
        //using (var SqlCon = new SqlConnection("Server =DESKTOP-2CS7U6C\\SQLSERVERTEST; DataBase = HR_DB; User Id = sa; Password = 123; Timeout=30"))
        //{
        //    SqlCommand cmd = new SqlCommand("select * from HRDeductionsTbl", SqlCon);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    tbl = new DataTable();
        //    adapter.Fill(tbl);
        //}
        //foreach(DataRow row in tbl.Rows)
        //{
        //    //Console.WriteLine(row["Details"].ToString());
        //}
        #endregion EndUsin

        #region Casts
        // Implicit
        int x = 10;
        long y = x;

        // Explicit

        double z = 5.2d;
        int i = (int)z;


        // boxing
        int s = 18;
        object obs = s;
        int sk = (int)obs;  // unBoxing

        // as
        object TestAs = "Hello";
        string str = TestAs as string; // If obj is not a string, str will be null

        // is
        object oob = "Hello";
        if(oob is int myStr)
        {
            //Console.WriteLine("Good");
        }


        // Convert Class


        #endregion
        Console.ReadKey();
    }
}

