using Asyncronous;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


public class CustomEventArgument : EventArgs
{
    public int Parameter1 { get;}
    public int Parameter2 { get; }
    public CustomEventArgument(int Parameter1, int Parameter2)
    {
        this.Parameter1 = Parameter1;
        this.Parameter2 = Parameter2;   
    }
}




internal class Program
{
    private static readonly DBClass DB = new DBClass();
    public delegate void CallBackEventHandler(object sender, CustomEventArgument e);
    public static event CallBackEventHandler CallBack;
    
    
    static void Func() { }
    static void Func2(string url) { }
    static void OnCallBackReceived(object sender, CustomEventArgument e)
    {

    }
    static async Task Main(string[] args)
    {
        CallBack += OnCallBackReceived; //  Subscribe

        List<string> list = new List<string>() {"", "", ""};
        #region Parallel

        #region Parallel For

        Parallel.For(0, 10, i => 
        {// make this 10 (Threads) Function Executed In Parllel (Multi Threading)
            Console.WriteLine("I am in Parllel For Loop");
            Task.Delay(1000).Wait();
        
        });





        //for(int i = 0; i < 10; i++)
        //{
        //    Thread t = new Thread(Func);
        //    t.Start();
        //    Thread.Sleep(1000);
        //}

        #endregion


        #region Parallel ForEach


        Parallel.ForEach(list, url => 
        {
            Func2(url);


        });


        #endregion




        #region Parallel Invoke
        // It takes List Of Call back and Execute them In Parallel (MultThreading)

        Parallel.Invoke(Func);


        #endregion





        #endregion

        #region Task Factory
        //CancellationTokenSource cts = new CancellationTokenSource();
        //CancellationToken token = cts.Token;
        //TaskFactory tsF = new TaskFactory(
        //    token,
        //    TaskCreationOptions.AttachedToParent,
        //    TaskContinuationOptions.ExecuteSynchronously,
        //    TaskScheduler.Default
        //);
        //Task task1 = tsF.StartNew(() =>
        //{
        //    Console.WriteLine("Task 1 Running");
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Task 1 Finished");
        //});

        //Task task2 = tsF.StartNew(() =>
        //{
        //    Console.WriteLine("Task 2 Running");
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Task 2 Finished");
        //});
        //Task task3 = tsF.StartNew(() =>
        //{
        //    Console.WriteLine("Task 3 Running");
        //    Thread.Sleep(3000);
        //    Console.WriteLine("Task 3 Finished");
        //});


        //Task.WaitAll(task1, task2, task3);

        //cts.Dispose();
        #endregion


        #region Tasks
        //Task t = PerformAsyncOp2();
        //for(int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine(i);
        //}
        //await t;
        //Console.WriteLine("After");
        //Task<int> result = PerformAsyncOperation();
        //Console.WriteLine("Doing SomeThing");
        //int res = await result;
        //Console.WriteLine(res);
        #endregion
        Console.ReadKey();
    }




    static async Task PerformAsyncOp2()
    {
        // Fetching Data From Data Base Code
        await Task.Run(() => DB.dataget("Select * from HREmployeesTbl", "get"));

        Console.WriteLine("Fetched SuccessFully");

        //return Task.CompletedTask;
        // return Task.Run(() => );
    }


    static async Task PerformTask(CustomEventArgument e)
    {

    }





}

