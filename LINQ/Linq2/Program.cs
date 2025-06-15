using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } // this temporary property
    public int CategoryID { get; set; }

}

public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
}


internal class Program
{
    static void Main(string[] args)
    {

        #region Intersect
        //List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };

        //List<int> list2 = new List<int> { 4, 5, 6, 7, 8 };

        //var commonElements = list1.Intersect(list2);

        //foreach (var item in commonElements)
        //{
        //    Console.WriteLine(item);
        //}
        #endregion

        #region Union

        //List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };

        //List<int> list2 = new List<int> { 4, 5, 6, 7, 8 };

        //// Combine the two lists using Union (only unique elements will be kept) No Dupliaction
        //var unionResult = list1.Union(list2);
        //foreach (int element in unionResult)
        //{
        //    Console.WriteLine(element);
        //}
        #endregion

        #region Concat
        //List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };

        //// Second list of integers
        //List<int> list2 = new List<int> { 4, 5, 6, 7, 8 };

        //// Combine the two lists using Concat (all elements will be included, duplicates are allowed)
        //var combinedList = list1.Concat(list2);

        //// Display the combined list with all elements
        //foreach (int element in combinedList)
        //{
        //    Console.WriteLine(element);
        //}
        #endregion

        #region Join
        //List<Product> products = new List<Product>
        //{
        //    new Product { ProductID = 1, Name = "Laptop", CategoryID = 1 },
        //    new Product { ProductID = 2, Name = "Smartphone", CategoryID = 1 },
        //    new Product { ProductID = 3, Name = "Tablet", CategoryID = 2 }
        //};

        //// List of categories
        //List<Category> categories = new List<Category>
        //{
        //    new Category { CategoryID = 1, CategoryName = "Electronics" },
        //    new Category { CategoryID = 2, CategoryName = "Gadgets" }
        //};


        //var prodCatJoin = from prod in products
        //                  join c in categories on
        //                  prod.CategoryID equals c.CategoryID
        //                  select new
        //                  {
        //                      pro = prod.Name,
        //                      cat = c.CategoryName,
        //                  };



        //var j = products.Join(categories, (p) => p.CategoryID, (c) => c.CategoryID, (p, c) => new { n = p.Name, cn = c.CategoryName });

        //foreach (var item in prodCatJoin)
        //{
        //    Console.WriteLine($"{item.pro} {item.cat}");
        //}



        #endregion

        #region Group

        List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Category = "Electronics" },
            new Product { Name = "Smartphone", Category = "Electronics" },
            new Product { Name = "Shirt", Category = "Clothing" },
            new Product { Name = "Tablet", Category = "Electronics" },
            new Product { Name = "Jeans", Category = "Clothing" }
        };

        // Group products by their Category
        var groupedProducts = from product in products
                              group product by product.Category into productGroup
                              select new { Category = productGroup.Key, Products = productGroup };



        // List of categories
        List<Category> categories = new List<Category>
        {
            new Category { CategoryID = 1, CategoryName = "Electronics" },
            new Category { CategoryID = 2, CategoryName = "Gadgets" }
        };




        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"Category: {group.Category}");
            foreach (var product in group.Products)
            {
                Console.WriteLine($"  Product: {product.Name}");
            }
        }

        var groupedProd = products.GroupJoin(
            categories, 
            (p) => p.CategoryID, 
            (c) => c.CategoryID, 
            (p, c) => new {productName = p.Name, Cate = c});





        #endregion


        Console.ReadKey();
    }
}

