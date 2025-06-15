
// record used for immutable data, and comparison, no constructor, no methods, no properties
public record Person(string Name, int Age);

internal class Program
{
    static void AddTen(ref int num) // This method can modify
    {
        num += 10;
        // num = 0;
    }
    static void GetValues(out int x) // This method must Assign
    {
        x = 0;
    }
    static void display(in int y) // this method can not modify
    {
        Console.WriteLine(y);
    }


    static void Main()
    {
        int num = 5; // ref => must initialization before
        int x; // out => no need to initialize before
        int y = 96; // in => must initialization before
        AddTen(ref num);
        GetValues(out x);
        display(in y);


        string s = "41";
        
        int.TryParse(s, out int res);
        Console.WriteLine(res);


        //Console.WriteLine(num);

        #region record
        //var p = new Person("Fady", 19);
        //var p2 = new Person("Fady", 19);
        //bool isEqual = p == p2; // True
        //var newP2 = p2 with { Name = "Hamed" };

        //Console.WriteLine(newP2.Age);
        #endregion
        Console.ReadKey();
    }

}








