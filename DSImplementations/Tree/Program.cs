using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TreeNodeModel<T>
{
    public T Value { get; set; }
    public List<TreeNodeModel<T>> Children { get; set; }
    public TreeNodeModel(T Value)
    {
        this.Value = Value;
        Children = new List<TreeNodeModel<T>>();
    }
    public void AddNode(TreeNodeModel<T> Node)
    {
        Children.Add(Node);
    }
     public TreeNodeModel<T> Find(T Value)
    {
        if(EqualityComparer<T>.Default.Equals(this.Value, Value)) return this;
        foreach (var item in Children)
        {
            var child = item.Find(Value);
            if (child != null) return child;
        }
        return null;
    }

}

class Tree<T>
{
    public TreeNodeModel<T> Root { get; set; }
    public Tree(T RootValue)
    {
        Root = new TreeNodeModel<T>(RootValue);
    }
    public void PrintTree(TreeNodeModel<string> root)
    {
        Console.WriteLine(root.Value);
        foreach (var item in root.Children)
        {
            PrintTree(item);
        }
    }
}


internal class Program
{
    static void Main(string[] args)
    {
        Tree<string> root = new Tree<string>("CEO");
        TreeNodeModel<string> CTO = new TreeNodeModel<string>("CTO");
        TreeNodeModel<string> CFO = new TreeNodeModel<string>("CFO");
        root.Root.AddNode(CTO);
        root.Root.AddNode(CFO);
        CTO.AddNode(new TreeNodeModel<string>("Developer"));
        CTO.AddNode(new TreeNodeModel<string>("UX Designer"));
        CFO.AddNode(new TreeNodeModel<string>("Accountant"));

        root.PrintTree(root.Root);
        Console.WriteLine(CTO.Find("lkj")?.Value);
        Console.ReadKey();

    }




}

