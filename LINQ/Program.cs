using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Size { get; set; }
}

public class ProductRepository
{
    public static List<Product> GetAll()
    {
        return new List<Product>
        {
            new Product { ProductID = 1, Name = "Laptop", Color = "Black", StandardCost = 500.00m, ListPrice = 1000.00m, Size = "Medium" },
            new Product { ProductID = 2, Name = "Smartphone", Color = "Silver", StandardCost = 200.00m, ListPrice = 800.00m, Size = "Small" },
            new Product { ProductID = 3, Name = "Tablet", Color = "White", StandardCost = 150.00m, ListPrice = 400.00m, Size = "Large" },
            new Product { ProductID = 4, Name = "Sonitor", Color = "Gray", StandardCost = 300.00m, ListPrice = 600.00m, Size = "Large" },
            new Product { ProductID = 5, Name = "Keyboard", Color = "Black", StandardCost = 20.00m, ListPrice = 50.00m, Size = "Standard" }
        };
    }
}



public static class Helper
{
    public static IEnumerable<Product> ByColor(this IEnumerable<Product> query, string color)
    {
        return query.Where((p) => p.Color == color);
    }
}


internal class Program
{
    static void Main(string[] args)
    {
        List<Product> products = ProductRepository.GetAll();
        var list = (from prod in products select new
        {
            ID = prod.ProductID,
            NN = prod.Name,
        }).ToList();

        var list1 = (from prod in products orderby prod.ProductID descending, prod.Color select prod).ToList();
        var l = products.OrderByDescending((p) => p.ProductID);

        var list1V2 = (from prod in products orderby prod.ProductID descending select prod).ThenBy((p) => p.Color).ToList();


        var lis = (from prod in products
                   where prod.Name.StartsWith("S")
                   select prod).ToList();

        var lis2 = (from prod in products
                    orderby prod.ProductID descending
                    select prod).ByColor("Black").ToList();



        var lis3 = products.Select((p) => p.ListPrice).ToList();
        var item = products.FirstOrDefault((p) => p.Size == "khj");


        

        // var item2 = products.Single((p) => p.Name == "lk");

        var item4 = products.Take(3);
        var it = products.Select((p) => p.Name).Distinct().ToList();
        bool it2 = products.Any((p) => p.ListPrice > 800);




        var iit = l.SequenceEqual(list1);


        Console.WriteLine(it2);

        var prs = new List<Product>() 
        {
            new Product { ProductID = 6, Name = "Monitor", Color = "Black", StandardCost = 150.00m, ListPrice = 300.00m, Size = "Medium" },
            new Product { ProductID = 7, Name = "Printer", Color = "White", StandardCost = 100.00m, ListPrice = 250.00m, Size = "Standard" },
            new Product { ProductID = 8, Name = "Headphones", Color = "Red", StandardCost = 50.00m, ListPrice = 150.00m, Size = "Small" },
            new Product { ProductID = 9, Name = "Webcam", Color = "Black", StandardCost = 75.00m, ListPrice = 150.00m, Size = "Standard" },
            new Product { ProductID = 10, Name = "External Hard Drive", Color = "Silver", StandardCost = 80.00m, ListPrice = 200.00m, Size = "Large" }
        };



        // Console.WriteLine(item2.ListPrice);
        // lis3.ForEach((p) => Console.WriteLine(p));


        Console.ReadKey();
        
    }
}

