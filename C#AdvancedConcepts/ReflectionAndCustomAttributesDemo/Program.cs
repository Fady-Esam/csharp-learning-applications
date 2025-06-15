using System;

using System.Reflection;
using System.Linq;


public class MyClass
{
    public int Property1 { get; set; }
    public void Method1()
    {
        Console.WriteLine("I am Method One");
    }
    public void Method2(int value1, int value2)
    {
        Console.WriteLine($"I am Method {value1} {value2}");

    }
}


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
class MyCustomAttribute : Attribute
{
    public string Description { get; set; }
    public MyCustomAttribute(string description)
    {
        Description = description;
    }
}


[MyCustom("This is Class Test")]



class clsTest
{
    [MyCustom("This is A Method For Test")]
    public void Method()
    {

    }

}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]

class RangeAttribute : Attribute
{ 
    public int Min { get; set; }
    public int Max { get; set; }
    public string ErrMessage { get; set; }

    public RangeAttribute(int min, int max)
    {
        Min = min; 
        Max = max;
    }

}


public class clsPerson
{
    [Range(18, 99, ErrMessage = "Range must be between 5 and 42")]
    public int Age { get; set; }


    public clsPerson(int age)
    {
        Age = age;
    }   
}





// Build in Attributes => Serializer, NoSerializer,  Obselete, Conditional


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public class AnotherCustAttribute : Attribute
{
    public string Description;
    public AnotherCustAttribute(string DES)
    {
        Description = DES;
    }
}




public class Program
{

    static void Validate(clsPerson person)
    {
        Type type = typeof(clsPerson);

        foreach (var prop in type.GetProperties())
        {
            if(Attribute.IsDefined(prop, typeof(RangeAttribute))){
                var RangeAttr = (RangeAttribute) Attribute.GetCustomAttribute(prop, typeof(RangeAttribute));
                int val = (int) prop.GetValue(person);
                if(val < RangeAttr.Min || val > RangeAttr.Max)
                    Console.WriteLine("Invalid");
                else
                    Console.WriteLine("Valid");
            }
        }

    }





    static void Main(string[] args)
    {
        clsPerson p = new clsPerson(115);
        Validate(p);
        #region Reflection on Custom Attributes

        //Type AttType = typeof(clsTest);
        //object[] clsCustomAttr = AttType.GetCustomAttributes(typeof(MyCustomAttribute), false);
        //foreach (MyCustomAttribute i in clsCustomAttr)
        //{
        //    Console.WriteLine(i.Description);
        //}

        //MethodInfo methodInfo = AttType.GetMethod("Method");

        //object[] MethodCustomAttr = methodInfo.GetCustomAttributes(typeof(MyCustomAttribute), false);
        //foreach (MyCustomAttribute i in MethodCustomAttr)
        //{
        //    Console.WriteLine(i.Description);
        //}

        #endregion

        #region Reflections on MyClass


        //Type type = typeof(MyClass);

        //foreach(var item in type.GetMethods())
        //{
        //    Console.WriteLine(item.Name);
        //}



        //object obj = Activator.CreateInstance(type);
        //type.GetProperty("Property1").SetValue(obj, 15);
        //int PropertyValue = (int)type.GetProperty("Property1").GetValue(obj);

        //Console.WriteLine(PropertyValue);

        //type.GetMethod("Method1").Invoke(obj, null);
        //type.GetMethod("Method2").Invoke(obj, new object [] { 3, 5});

        #endregion

        #region Reflection String Assembly
        //Assembly assembly = typeof(string).Assembly;

        //Type type = assembly.GetType("System.String");


        //if(type != null )
        //{
        //    var stringMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
        //        .OrderBy(method => method.Name);
        //    foreach( var stringMethod in stringMethods )
        //    {
        //        Console.WriteLine(stringMethod);
        //    }
        //}
        #endregion

        Console.ReadKey();

        //var strData = type.GetMethod(BindingFlags.Public | BindingFlags.Instance)
        //    .



    }
}

