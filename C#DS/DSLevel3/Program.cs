using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;





class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public Employee(string Name, string Department, double Salary) 
    { 
        this.Name = Name;
        this.Department = Department;
        this.Salary = Salary;
    }

}



internal class Program
{
    
    static void Main(string[] args)
    {

        #region SortedDictionary 
        // Faster in Retrieving, Adding, Removing, It depends on Tree DS (Binary Search Tree) o(log n) , more Memory
        SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
        sortedDictionary.Add(2, "orange");
        sortedDictionary.Add(1, "Bana");
        sortedDictionary.Add(3, "Apple");
        foreach (var item in sortedDictionary)
        {
            Console.WriteLine(item.Value);
        }



        #endregion

        #region Sorted Set

        SortedSet<int> sortedSet = new SortedSet<int>();
        sortedSet.Add(5);
        sortedSet.Add(91);
        sortedSet.Add(63);
        sortedSet.Add(63);
        sortedSet.Add(12);


        foreach (var item in sortedSet)
        {
            //Console.WriteLine(item);
        }




        #endregion

        #region SortedList
        // it has indexing, Faster in Retrieving as it uses binary search o(log n), Slower in Adding, Removing o(n), It depends on Array DS, Less memory
        SortedList<string, int> sl = new SortedList<string, int>();
        sl.Add("Orange", 1);
        sl.Add("Banana", 6);
        sl.Add("Apple", 8);


        foreach (var item in sl)
        {
            //Console.WriteLine(item.Key);
        }
        var data = from i in sl 
                   where i.Value > 1 
                   select i;

        var data2 = sl.Where((kv) => kv.Value > 1);


        foreach (var item in data)
        {
            //Console.WriteLine(item);
        }
        foreach (var item in data2)
        {
            //Console.WriteLine(item);
        }


        SortedList<int, string> sl2 = new SortedList<int, string>()
        {
            {1, "Apple"},
            {2, "orang"},
            {3, "ch"},
            {4, "St"},
            {5, "kiw"},
            {6, "Ban"},
        };






        var res = sl2.GroupBy((kv) => kv.Value.Length);

        foreach (var item in res)
        {
            //Console.WriteLine($"{item.Key} : {string.Join(", ", item.Select((kv) => kv.Value))}");
        }
        SortedList<int, Employee> empList = new SortedList<int, Employee>()
        {
            { 1, new Employee("Alice", "HR", 50000) },
            { 2, new Employee("Bob", "IT", 70000) },
            { 3, new Employee("Charlie", "HR", 52000) },
            { 4, new Employee("Daisy", "IT", 80000) },
            { 5, new Employee("Ethan", "Marketing", 45000) }
        };



        var result = empList.Where((kv) => kv.Value.Department == "IT").OrderByDescending((kv) => kv.Value.Salary).Select((kv) => kv.Value.Name);

        foreach (var item in result)
        {
            //Console.WriteLine(item);
        }



        #endregion

        #region HashSet

        HashSet<int> set = new HashSet<int>() { 3, 5, 9 };

        HashSet<int> set2 = new HashSet<int>() { 64, 2, 5 };

        //set.UnionWith(set2); // 3 5 9 64 2
        //set.IntersectWith(set2); // 5
        //set.ExceptWith(set2); // 3 9
        set.SymmetricExceptWith(set2); // 3 9 64 2
        foreach (var item in set)
        {
            // Console.WriteLine(item);
        }
        set.SetEquals(set2); // returns a bool, it checks if set is equal to set2
        set.IsSubsetOf(set2); // returns a bool, it checks if set is a part of set2
        set.IsSupersetOf(set2); // returns a bool, it checks if set is super / parent of set2
        set.Overlaps(set2); // returns a bool, it checks if set is Intersected with set2 at any value / values

        //HashSet<string> set = new HashSet<string>() 
        //{ 
        //    "Apple",
        //    "Banana",
        //};

        //set.Add("Banana");
        //int[] arr = new int[]{ 1, 2, 1, 5, 9, 1, 7, 1 };

        //arr = arr.ToHashSet().ToArray();
        //arr = arr.Append(845).ToArray();
        //List<int> list = new List<int>();
        //foreach (var item in arr)
        //{
        //    Console.WriteLine(item);
        //}





        //foreach (var item in set)
        //{
        //    Console.WriteLine(item);
        //}








        #endregion

        #region Dictionary

        Dictionary<int, string> dic = new Dictionary<int, string>() 
        {
            {1, "Fady"},
            {2, "Ahmed"},
            {3, "Ramy"},
            {4, "Adel"},
        };

        Dictionary<int, string> DicData = new Dictionary<int, string>()
        {
            {2, "Fady"},
            {3, "Ahmed"},
            {4, "Ramy"},
            {5, "Adel"},
            {7, "Ahmed"},

        };
        var g = DicData.GroupBy((kv) => kv.Value);
        foreach(var item in g)
        {
            //Console.WriteLine(item.Key);
            foreach (var item1 in item)
            {
                //Console.WriteLine(item1.Key);
            }
        }





        //dic.Select(kv => kv.Value).ToList().ForEach((v) => Console.WriteLine(v));
        
        if(dic.TryGetValue(1, out string  val))
        {
            // Console.WriteLine(val);
        }
        

        foreach (var item in dic)
        {
            
        }
        #endregion


        #region HashTable

        Hashtable ht = new Hashtable() // Non-Generic Type big O(1)
        {
            {1, "Fady"},
            {2, "Ahmed"},
            {3, "Ramy"},
            {4, "Adel"},
        };
        
        //Console.WriteLine(ht[4]);
        foreach (var item in ht)
        {
            //Console.WriteLine(item.Value);
        }

        #endregion


        #region List
        //List<int> numbers = new List<int>() {5, 2, 6, 92, 62, 69, 95};
        //Console.WriteLine(numbers.Sum());
        //Console.WriteLine(numbers.Count());
        //Console.WriteLine(numbers.Max());
        //Console.WriteLine(numbers.Min());

        //numbers.Where((x) => x > 10).ToList().ForEach((x) => Console.WriteLine(x));

        //numbers.Sort();

        //numbers.OrderBy((x) => x).ToList().ForEach((x) => Console.WriteLine(x));

        //int[] nums = new int[] { 1, 2, 3, 4, 5, 6 };
        //nums.ToList();

        //numbers.Contains(92);
        //Console.WriteLine(numbers.Find((x) => x > 5));
        //numbers.OrderByDescending((x) => x);
        //numbers.Exists((x) => x > 10);
        //numbers.Any((x) => x > 5);
        //numbers.RemoveAll((x) => x > 90);
        //Console.WriteLine(string.Join(", ", numbers));
        //numbers.ForEach((x) => {});
        //Console.ReadKey();
        #endregion
    
    
        Console.ReadKey();
    }
}

