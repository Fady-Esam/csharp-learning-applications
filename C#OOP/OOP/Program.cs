using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMathClassLibrary;

namespace C_OOPFirstProj
{
    class Person
    {
        public int ID {  get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public Person(int ID, string FirstName, string LastName)
        {
            this.ID = ID;
            this.FirsName = FirstName;
            this.LastName = LastName;
        }
        public virtual void Print1()
        {
            Console.WriteLine("Hello I am From Base");
        }
        public virtual void Print2() 
        {
            Console.WriteLine("Hello I am From Base But Will Not Overriding");
        }
    }
    class Employee : Person
    {
        public double Salary {  get; set; }
        public string Title { get; set; }

        public Employee(int ID, string FirstName, string LastName, double Salary, string Title) : base(ID, FirstName, LastName)
        {
            this.Salary = Salary;
            this.Title = Title;
        }

        public override void Print1()
        {
            Console.WriteLine("Hello I am From Derived And Overrided");
        }
        public new void Print2() // Shadowing(Method Hiding)
        {
            Console.WriteLine("Hello I am From Derived But New");
        }

    }



    internal abstract class clsPerson
    {
        public string FirstName { get; set; }
        public string LastNmae { get; set; }

        public abstract void Introduce();

        public void SayHello()
        {
            Console.WriteLine("Hello From Abstract Class");
        }
        public clsPerson()
        {

        }
    }
    class clsEmployee : clsPerson
    {
        public override void Introduce()
        {
           
        }
    }


    interface IPerson
    {
        string FirstName { get; set; }
        string LastNmae { get; set; }
        void Introduce();
        string to_string();

    }


    interface ICommunicate
    {
        void Call();
        
    }


    class Emp : IPerson, ICommunicate
    {
        public string FirstName { get ; set; }
        public string LastNmae { get; set; }

        public void Introduce()
        {
            Console.WriteLine("Hello I am Fady");
        }

        public string to_string()
        {
            return "";
        }

        void ICommunicate.Call()
        {
            throw new NotImplementedException();
        }
    }
     class OuterClass {
        public string Name;
        public OuterClass(string Name)
        {
            this.Name = Name;
        }
        public class InnerClass 
        {
            //InnerClass() { }
            public void PrintOutData(OuterClass ouCls)
            {
                Console.WriteLine($"Data => {ouCls.Name} ");
            }
        }
    }
    // Composition is to make and use an instance of a class in another class
    // Sealed is linked with inheritance






    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.X == p2.X && p1.Y == p2.Y);    
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1.X == p2.X && p1.Y == p2.Y);
        }


    }

    // Generic Class
    class GenBox<T>
    {
        public T X { get; set; }
        public GenBox(T X)
        {
            this.X = X;
        }




        
    }
     


    internal class Program
    {
        //class A
        //{
        //    private int x = 10;
        //    public int y;
        //    protected int z;
        //    protected void Print()
        //    {
        //        Console.WriteLine($"x = {x}");
        //    }
        //    public int GetX()
        //    {
        //        return 200;
        //    }
        //}
        //class B :  A
        //{
        //    public new void Print()
        //    {
        //        base.Print();
        //        Console.WriteLine("Hello");
        //    }
        //}
        //class Employee
        //{
        //    private string _Name = string.Empty;

        //    public string Name
        //    {

        //        set
        //        {
        //            _Name = value;
        //        }
        //        get
        //        {
        //            return _Name;
        //        }

        //    }
        //}
        //class Test
        //{
        //    public int X { set; get; }
        //    private int _Y;
        //    public int Days
        //    {
        //        get { return DateTime.Now.Day; }
        //    }
        //    public int Y
        //    {
        //        set
        //        {
        //            _Y = value;
        //        }
        //        get
        //        {
        //            return _Y;
        //        }
        //    }

        //}

        //class Settings
        //{
        //    static int x;
        //    public static int DayNumber
        //    {
        //        get
        //        {
        //            return DateTime.Today.Day;
        //        }
        //    }

        //    public static string DayName
        //    {
        //        get
        //        {
        //            return DateTime.Today.Day.ToString();
        //        }
        //    }

        //    static Settings() // It is called only one time along the life of the program, it can not be parametrized
        //    {

        //    }

        //    ~Settings()
        //    {
        //        Console.WriteLine("I am Destructed");
        //    }
        //    //private Settings()
        //    //{

        //    //}
        //}

        static void Main(string[] args)
        {
            GenBox<int> ob = new GenBox<int>(5);
            Console.WriteLine(ob.X);
            //string x = "";
            //var d = 5;
            //Console.WriteLine(x.Length.ToString()) ;
            //dynamic dyn = 10;
            //dyn = "Hello";  // You can change the type at runtime
            //Console.WriteLine(dyn.Length.ToString());
            // No error at compile time, but will throw at runtime if it doesn't exist

            //Point p1 = new Point(2, 5);
            //Point p2 = new Point(9, 12);
            //Point p3 = p1 + p2;
            //Console.WriteLine(p3.X);
            //clsMath c = new clsMath();
            //Console.WriteLine(c.Sum(5, 3));
            //PersonClass PC = new PersonClass();
            //PC.Age = 12;
            //PC.BirthDary();
            //OuterClass outer = new OuterClass("Fady");

            // Create an instance of InnerClass
            //OuterClass.InnerClass inner = new OuterClass.InnerClass();
            //inner.PrintOutData(outer);
            //Emp e = new Emp();
            //e.Introduce();


            //clsEmployee emp = new clsEmployee();

            //emp.SayHello();

            // UpCating
            //Employee emp = new Employee(1,"Fady", "Esam", 5465.96, "Software Developer");
            //Person person = emp;
            //person.Print1();
            //person.Print2();

            //// DownCasting
            //Person person2 = new Employee(2, "Ahmed", "Osama", 7987654, "Newtwork Engineer");
            //Employee emp2 =(Employee) person2;
            ////Console.WriteLine(emp2.Title);
            //Console.WriteLine(person.FirsName);

            //Person person = new Person(1, "Fady", "Esam");



            //B b = new B();
            //Test t = new Test();
            //t.X = 10;
            //t.Y = 85;
            //Console.WriteLine(t.Y);
            ////Console.WriteLine(t.X);
            //A a = new A();
            //B b = new B();


            //Console.WriteLine(a.GetX()); 
            Console.ReadKey();

        }
    }
}
