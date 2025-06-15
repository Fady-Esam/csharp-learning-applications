using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




class Logger
{
    public delegate void LogAction(string message);

    LogAction loA;

    public Logger(LogAction loA)
    {
        this.loA = loA;
    }

    public void log(string message)
    {
        loA(message);
    }


}

internal class Program
{
    static void LogScreen(string s)
    {
        Console.WriteLine(s);
    }
    static void LogConsole(string s)
    {
        Console.WriteLine(s);

    }

    delegate int SquaryValues(int x);


    static int multy(int x)
    {
        return x * x;
    }

    static void TestDel(string s)
    {
        Console.WriteLine(s);
    }
    static bool IsEven(int x)
    {
        return (x % 2 == 0);
    }


    public delegate void dels(string g);
    static void Testing(dels t)
    {
        //ac();
    }



    public delegate int operation(int x, int y); 


    public static  void ExecuteOperation(int x, int y, operation op)
    {
        Console.WriteLine(op(x, y));
    }

    static void Main(string[] args)
    {

        ExecuteOperation(6, 7, ( (x,y) => x + y));


        #region Delegates
        // Testing((s) => { Console.WriteLine(); });
        // Func Is a delegate that points to a function with a return value and up to 16 parameters
        // Action Is a delegate that points to a function without a return value and up to 16 parameters
        // Predicate Is a delegate that points to a bool function with one Parameter

        //SquaryValues s = new SquaryValues(multy);

        //Predicate<int> predicate = IsEven; 

        //Action<string> dele = TestDel;

        //dele("Hello");
        //Func<int, int> d = multy;

        //Console.WriteLine(d(5));


        //Console.WriteLine(s(5));


        //Logger l = new Logger(LogScreen);
        //Logger l2 = new Logger(LogConsole);
        //l.log("I am in logScreen");
        //l2.log("I am in LogConsole");
        #endregion

        #region Lamda Expression

        Func<int, int> sq = x => x * x;
        Predicate<int> per = v => v == 50;
        Action<string> act = (s) => { Console.WriteLine("So Good"); };
        #endregion

        operation op = (x, y) => x * y;

        //Console.WriteLine(op(5, 4)); 



        Console.ReadKey();
    }
}

