


class Do
{
    public int Sum(int x, int y)
    {
        return x + y;
    }
}




class Program
{

    static void Main(string[] args)
    {
        Func<int, int, int> sum = (x, y) => x + y;
        Console.WriteLine(sum(10, 18));
        //Do d = new Do();
        //d.Sum()

        #region Custom Delegates
        Calc a, d, c;

        // a = new Calc(Add);
        // d = new Calc(Diff);
        // Add(4, 9);
        #endregion
    }




    delegate void Calc(int x, int y);
    static void Add(int x, int y)
    {
        Console.WriteLine(x + y);
    }
    static void Diff(int x, int y)
    {
        Console.WriteLine(x - y);
    }
}



