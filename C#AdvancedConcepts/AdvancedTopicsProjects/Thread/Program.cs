using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


internal class Program
{


    static int Counter = 0;
    static object lockObject = new object();

    static void Main(string[] args)
    {



        #region Thread Syncronyzation
        Thread th1 = new Thread(() => IncrementCounter());
        Thread th2 = new Thread(() => IncrementCounter());

        th1.Start();
        th2.Start();
        #endregion


        #region Thread 
        // It causes Race Codition
        //Thread t = new Thread(() => MethodOne("FirstThread"));
        //Thread t2 = new Thread(() => MethodTwo("SecondThread"));

        //t.Start();
        //t2.Start();
        //t.Join();
        //t2.Join();
        //for(int i = 0; i < 20; i++)
        //{
        //    Console.WriteLine(i);
        //    Thread.Sleep(500);
        //}
        #endregion
        Console.ReadKey();
    }
    
    static void IncrementCounter()
    {
        for(int i = 0; i < 100; i++)
        {
            lock (lockObject) 
            {
                Counter++;
            }
        }
    }


    static void MethodOne(string s)
    {
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Method {s} : {i}");
            Thread.Sleep(500);

        }
    }
    static void MethodTwo(string s)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Method {s} : {i}");
            Thread.Sleep(500);

        }
    }
}

