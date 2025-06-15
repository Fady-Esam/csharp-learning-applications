using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





public class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> _Childrent { get; set; }

    public TreeNode(T Value)
    {
        this.Value = Value;
        _Childrent = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> node)
    {
        _Childrent.Add(node);
    }

    public TreeNode<T> FindNode(T node)
    {
        if (EqualityComparer<T>.Default.Equals(Value, node))
            return this;


        foreach (var item in _Childrent)
        {
            var found = item.FindNode(node);
            if(found != null) return found;
        }
        return null;
    }

}

public class Tree<T>
{
    public TreeNode<T> Root { get; set; }

    public Tree(T value)
    {
        Root = new TreeNode<T>(value);
    }





    public void PrintTree(TreeNode<string> node)
    {
        Console.WriteLine(node.Value);
        foreach (var item in node._Childrent)
        {
            PrintTree(item);
        }
    }



}

internal class Program
{
    static void Main(string[] args)
    {
        Tree<string> companyTree = new Tree<string>("CEO");
        TreeNode<string> finance = new TreeNode<string>("CFO");
        TreeNode<string> tech = new TreeNode<string>("CTO");
        TreeNode<string> marketing = new TreeNode<string>("CMO");


        // Add departments to CEO
        companyTree.Root.AddChild(finance);
        companyTree.Root.AddChild(tech);
        companyTree.Root.AddChild(marketing);


        // Add employees to departments
        finance.AddChild(new TreeNode<string>("Accountant"));
        tech.AddChild(new TreeNode<string>("Developer"));
        tech.AddChild(new TreeNode<string>("UX Designer"));
        marketing.AddChild(new TreeNode<string>("Social Media Manager"));
        companyTree.PrintTree(companyTree.Root);
        Console.WriteLine("\n\n\n");

        Console.WriteLine(tech.FindNode("Developer").Value.ToString());
        Console.ReadKey();

    }







}

