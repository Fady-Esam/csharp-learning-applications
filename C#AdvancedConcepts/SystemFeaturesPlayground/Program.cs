using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;
internal class Program
{
    static void Main(string[] args)
    {

        StringBuilder sb = new StringBuilder();

        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        for (int i = 0; i < 200000; i++)
        {
            sb.Append('a');
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds.ToString());

        sw = Stopwatch.StartNew();

        sw.Start();
        string res = "";
        for (int i = 0; i < 200000; i++)
        {
            res += "a";
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds.ToString());

        #region App.Config


        //string ConString = ConfigurationManager.ConnectionStrings["ConSS"].ToString();
        //Console.WriteLine(ConString);





        #endregion
        #region Event Logs
        //string sourceName = "MyApp";
        //if (!EventLog.SourceExists(sourceName))
        //{
        //    EventLog.CreateEventSource(sourceName, "Application");
        //}
        //EventLog.WriteEntry(sourceName, "This Is a log Message", EventLogEntryType.Information);

        #endregion

        #region Registry
        //try
        //{
        //   string val = (string) Registry.GetValue($@"{Registry.LocalMachine}\SOFTWARE\MyLocMachineSoft", "TestKey", null);
        //    Console.WriteLine(val);
        //}
        //catch (Exception ex) 
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //string val = (string) Registry.GetValue($@"{Registry.CurrentUser}\SOFTWARE\MySoftware", "ValueName", null);
        //Console.WriteLine(val);
        //Console.ReadKey();
        #endregion

        Console.ReadKey();
    }
}

