using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;







class MyCustomCollection<T> : IEnumerable<T>
{
    private List<T> list = new List<T>();
    public IEnumerator<T> GetEnumerator()
    {
        for(int i = 0; i < list.Count; i++)
        {
            // yeild to save the location and move next then return to the last location
            yield return list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Add(T item)
    {
        list.Add(item);
    }
}



public class MyColCollection<T> : ICollection<T>
{
    private List<T> list = new List<T>();
    int ICollection<T>.Count => list.Count;

    bool ICollection<T>.IsReadOnly => true;

    void ICollection<T>.Add(T item)
    {
        list.Add((T)item);
    }

    void ICollection<T>.Clear()
    {
        list.Clear();
    }

    bool ICollection<T>.Contains(T item)
    {
        return list.Contains(item);
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }
    bool ICollection<T>.Remove(T item)
    {
        return list.Remove(item);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        for(int i = 0; i < list.Count; i++)
        {
            yield return list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

}



public class MySimpleCollection<T> : IList<T>
{
    private List<T> list = new List<T>();

    public T this[int index] { get => list[index]; set => list[index] = value; }

    public int Count => list.Count;

    public bool IsReadOnly => true;

    public void Add(T item)
    {
        list.Add(item);
    }

    public void Clear()
    {
        list.Clear();
    }

    public bool Contains(T item)
    {
        return list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < list.Count; i++)
        {
            yield return list[i];
        }
    }

    public int IndexOf(T item)
    {
        return list.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        list.Insert(index, item);
    }

    public bool Remove(T item)
    {
        return list.Remove(item);
    }

    public void RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}






public class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public int CompareTo(Person obj)
    {
        if (obj == null) return 1;

        return (this.Age.CompareTo(obj.Age));
    }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}


internal class Program
{

    static void Main(string[] args)
    {
        #region IComparable

        List<Person> people = new List<Person>
        {
            new Person("John", 30),
            new Person("Jane", 25),
            new Person("Doe", 28),
        };


        // Sorting the list using IComparable implementation
        people.Sort();

        // Printing the sorted list
        Console.WriteLine("People sorted by age:");
        foreach (Person person in people)
        {
            Console.WriteLine(person.Name);
        }



        #endregion


        #region ISet
        // extends ICollection, It makes Iterations, Linq, More Features and Methods Like Add, Remove
        // and Make elements Unique


        #endregion

        #region IDictionary
        // extends ICollection,  It makes Iterations, Linq, More Features and Methods Like Add, Remove
        // and Make keys and values, and Methods assiocated with them



        #endregion

        #region IList
        // More Features, Methods and Indexing, extends ICollection




        #endregion

        #region ICollection
        // It is high level more than IEnumerable, extends IEnumerable It makes Iterations, Linq, More Features and Methods Like Add, Remove

        MyColCollection<int> ColCol = new MyColCollection<int> ();
        foreach (var item in ColCol)
        {
            //Console.WriteLine(item);
        }
        #endregion

        #region IEnumerable
        // It is an Iterfacte, It makes Iterations, Linq

        MyCustomCollection<int> CustColl = new MyCustomCollection<int> { 1, 2, 3, 4 };

        foreach (var item in CustColl)
        {
            //Console.WriteLine(item);
        }


        #endregion




        Console.ReadKey();
    }
}

