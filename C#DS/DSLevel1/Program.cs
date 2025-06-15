using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



internal class Program
{

    static string BitArrayToString(BitArray biarr)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in biarr)
            sb.Append(Convert.ToBoolean(item) ? '1' : '0');
        return sb.ToString();
    }



    static (bool, string) testTuples()
    {
        return (true, "");
    }
    static void Main(string[] args)
    {
        #region Tuples
        // It is A dataSructure tha has fixed Elements with diffrent Data Types
        // one variable with more than one data type
        (int, string, bool) s = (3, "Fady", true);
        //Console.WriteLine(s.Item1);

        List<(int, string, bool)> dataList = new List<(int, string, bool)> 
        { 
            (19, "Fady", false), 
            (25, "Ahmed", true)  
        };

        dataList.ForEach((i) => { Console.WriteLine(i.Item2); });

        Console.WriteLine(testTuples().Item1);


        #endregion


        #region Jagged Array
        // Array in Array, It is Dynamic As every Row has its own columns
        int[][] jagArr = { new int[] { 3, 6 } , new int[] { 9 } };

        //jagArr[0] = new int[] {3, 6};
        //jagArr[1] = new int[] {9};
        //jagArr[2] = new int[] {1, 25, 71};


        for(int i = 0; i < jagArr.Length; i++)
        {
            for(int j = 0; j < jagArr[i].Length; j++)
            {
                //Console.WriteLine(jagArr[i][j]);
            }
        }



        #endregion

        #region BitArray


        bool[] boolArr = { true, false, false, true, true, false };
        BitArray biarr = new BitArray(boolArr);
        biarr.Set(2, true);
        //biarr.SetAll(true);
        BitArray biarr2 = new BitArray(new bool[] { false, false, true, false, true, false });

        biarr.And(biarr2);
        //Console.WriteLine(BitArrayToString(biarr));
        #endregion


        #region Arrays


        var employees = new[]
        {
            new { Id = 1, Name = "Alice", DepartmentId = 2 },
            new { Id = 2, Name = "Bob", DepartmentId = 1 }
        };


        // Array of departments
        var departments = new[]
        {
            new { Id = 1, Name = "Human Resources" },
            new { Id = 2, Name = "Development" }
        };




        var gd = employees.Join(departments, (o) => o.DepartmentId, (i) => i.Id, (o,i) => new {o.Name, Department = i.Name});
        foreach (var item in gd)
        {
            // Console.WriteLine(item);
        }




        //var people = new[]
        //{
        //    new { Name = "Alice", Age = 30 },
        //    new { Name = "Bob", Age = 25 },
        //    new { Name = "Charlie", Age = 35 },
        //    new { Name = "Diana", Age = 30 },
        //    new { Name = "Ethan", Age = 25 }
        //};





        int[,] nnn = { { 3, 6 }, { 9, 3 } };
        int[] da = {9, 1};
        int[] copy = new int[2];
        Array.Copy(da , copy, 2);
        var res = da.Where((i) => i % 2 == 1).Select((i) => i + 5);
        foreach (var item in res)
        {
            //Console.WriteLine(item);
        }


        for (int i = 0; i < nnn.GetLength(0); i++)
        {
            for(int j = 0; j < nnn.GetLength(1); j++)
            {
                //Console.WriteLine(nnn[i,j]);
            }
        }




        //nnn[0] = "a";
        //foreach (var item in nnn)
        //{
        //    Console.WriteLine(item);
        //}




        #endregion 

        #region LikedList
        // It consists of LinkedListNode
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddFirst("Amira");
        linkedList.AddAfter(linkedList.Find("Amira"),"Hady");
        
        foreach (var item in linkedList)
        {
            // Console.WriteLine(item);
        }

        #endregion

        #region Queue
        // First in Fist Out
        Queue<string> queue = new Queue<string>() ;
        queue.Enqueue("Fady");
        queue.Enqueue("Hamada");
        //queue.Dequeue();
        //Console.WriteLine(queue.Peek());


        #endregion 

        #region Stack
        // Last in First out
        Stack<int> sck = new Stack<int>();

        sck.Push(10);
        sck.Push(90);
        //Console.WriteLine(sck.Peek());
        

        while (sck.Count > 0)
        {
            //Console.WriteLine(sck.Pop());
        }



        #endregion

        #region ObservableCollection

        ObservableCollection<string> names = new ObservableCollection<string>();

        names.CollectionChanged += Notify;

        names.Add("Fady");
        names.Add("Ahmed");
        names.Add("Ramy");
        foreach (var item in names)
        {
            //Console.WriteLine(item);
        }
        names.Remove("Ahmed");
        names.Insert(0, "Kamel");
        names[0] = string.Empty;
        names.Move(0, 2);


        #endregion


        #region ArrayList
        ArrayList arrlist = new ArrayList();
        // Different Data Types
        arrlist.Add(10);
        arrlist.Add("Fady");
        arrlist.Add(true);
        ArrayList numsArrlist = new ArrayList() {3, 6, 1, 9};
        foreach (var item in arrlist)
        {
            //Console.WriteLine(item);
        }
        var numsArrListData = numsArrlist.Cast<int>().Where((i) => i % 2 == 1);

        foreach (var item in numsArrListData)
        {
            //Console.WriteLine(item);
        }




        #endregion
        Console.ReadKey();
    }
    static void Notify(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                //Console.WriteLine("Add ");
                break;
            case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                //Console.WriteLine("Move");
                break;
            case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                //Console.WriteLine("Remove");
                break;
            case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                //Console.WriteLine("Update");
                break;
        }
    }
}

