using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Math;


public class AVLTreeNodeModel
{
    public int Value {  get; set; }
    public AVLTreeNodeModel RightNode { get; set; }
    public AVLTreeNodeModel LeftNode { get; set; }

    public int Height {  get; set; }

    public AVLTreeNodeModel(int Value)
    {
        this.Value = Value;
        Height = 1;
    }

}


public class AVLTree
{
    public AVLTreeNodeModel Root { get; set; }



    public void InsertNode(int Value)
    {
        Root = InsertNode(Root, Value);
    }
    public AVLTreeNodeModel InsertNode(AVLTreeNodeModel node, int Value)
    {

        if(node == null) return new AVLTreeNodeModel(Value);

        if (Value < node.Value)
        {
            node.LeftNode = InsertNode(node.LeftNode, Value);
        }
        else if (Value > node.Value)
        {
            node.RightNode = InsertNode(node.RightNode, Value);

        }
        else
            return node;

        UpdateHeight(node);
        return Balance(node);
    }


    public AVLTreeNodeModel Balance(AVLTreeNodeModel node)
    {
        int BF = GetBalanceFactor(node);


        if (BF < -1 && GetBalanceFactor(node.RightNode) <= 0)
        {
            return LeftRotation(node);
        }
        if (BF > 1 && GetBalanceFactor(node.LeftNode) >= 0)
        {
            return RightRotation(node);
        }
        if (BF > 1 && GetBalanceFactor(node.LeftNode) < 0)
        {

            node.LeftNode = LeftRotation(node.LeftNode);

            return RightRotation(node);

        }
        if (BF < -1 && GetBalanceFactor(node.RightNode) > 0)
        {
            node.RightNode = RightRotation(node.RightNode);

            return LeftRotation(node);
        }
        return node;
    }


    public void DeleteNode(int Value)
    {
        Root = DeleteNode(Root, Value);
    }

    public AVLTreeNodeModel DeleteNode(AVLTreeNodeModel node, int Value)
    {
        if (node == null) return null;

        if(Value < node.Value)
        {
            node.LeftNode = DeleteNode(node.LeftNode, Value);
        }
        else if (Value > node.Value)
        {
            node.RightNode = DeleteNode(node.RightNode, Value);
        }
        else
        {
            if (node.LeftNode == null) return node.RightNode;
            if (node.RightNode == null) return node.LeftNode;

            AVLTreeNodeModel temp = GetMinimum(node.RightNode);

            node.Value = temp.Value;

            node.RightNode = DeleteNode(node.RightNode, temp.Value);
        }

        UpdateHeight(node);
        return Balance(node);
    }

    public AVLTreeNodeModel GetMinimum(AVLTreeNodeModel node)
    {
        AVLTreeNodeModel Current = node;
        while(Current.LeftNode != null)
        {
            Current = Current.LeftNode;
        }
        return Current;
    }


    public AVLTreeNodeModel RightRotation(AVLTreeNodeModel OriginalNode)
    {
        AVLTreeNodeModel NewRoot = OriginalNode.LeftNode;
        AVLTreeNodeModel ChildNode = NewRoot.RightNode;

        NewRoot.RightNode = OriginalNode;
        OriginalNode.LeftNode = ChildNode;

        UpdateHeight(OriginalNode);
        UpdateHeight(NewRoot);


        return NewRoot;
    }
    public AVLTreeNodeModel LeftRotation(AVLTreeNodeModel OriginalNode)
    {
        AVLTreeNodeModel NewRoot = OriginalNode.RightNode;
        AVLTreeNodeModel ChildNode = NewRoot.LeftNode;

        NewRoot.LeftNode = OriginalNode;
        OriginalNode.RightNode = ChildNode;
        UpdateHeight(OriginalNode);
        UpdateHeight(NewRoot);
        return NewRoot;
    }

    public int GetBalanceFactor(AVLTreeNodeModel node)
    {
        return node != null ?  GetHeight(node.LeftNode) - GetHeight(node.RightNode) : 0;
    }

    public void UpdateHeight(AVLTreeNodeModel node)
    {
        node.Height = 1 + Max(GetHeight(node.LeftNode), GetHeight(node.RightNode));
    }

    public int GetHeight(AVLTreeNodeModel node)
    {
        return node == null ? 0 : node.Height;
    }

    public AVLTreeNodeModel Search(int Value)
    {
        return Search(Root, Value);
    }
    public AVLTreeNodeModel Search(AVLTreeNodeModel node, int Value)
    {
        if (node == null) return null;

        if (Value < node.Value)
        {
            return  Search(node.LeftNode, Value);
        }
        else if (Value > node.Value)
        {
            return Search(node.RightNode, Value);
        }
        else
            return node;
    }


    public bool IsExists(int Value)
    {
        return IsExists(Root, Value);
    }

    public bool IsExists(AVLTreeNodeModel node, int Value)
    {
        if (node == null) return false;

        if (Value < node.Value)
        {
            return IsExists(node.LeftNode, Value);
        }
        else if (Value > node.Value)
        {
            return IsExists(node.RightNode, Value);
        }
        else
            return true;
    }

    public void PrintTree()
    {
        PrintTree(Root, "", true);
    }

    private void PrintTree(AVLTreeNodeModel node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "     ";
            }
            else
            {
                Console.Write("L----");
                indent += "|    ";
            }
            Console.WriteLine(node.Value);
            PrintTree(node.LeftNode, indent, false);
            PrintTree(node.RightNode, indent, true);
        }
    }
}




internal class Program
{
    static void Main(string[] args)
    {
        AVLTree tree = new AVLTree();

        // Inserting values
        int[] values = { 10, 20, 30, 40, 50, 25 };
        foreach (var value in values)
        {
            tree.InsertNode(value);
        }

        // Print the tree
        tree.PrintTree();

        // Searching for values
        int searchValue = 30;
        bool found = tree.IsExists(searchValue);
        Console.WriteLine($"\nSearch for value {searchValue}: " + (found ? "Found" : "Not Found"));

        searchValue = 60;
        found = tree.IsExists(searchValue);
        Console.WriteLine($"Search for value {searchValue}: " + (found ? "Found" : "Not Found"));



        // Searching for values and printing the results
        int searchValue2 = 30;
        AVLTreeNodeModel foundNode = tree.Search(searchValue2);
        Console.WriteLine($"\nSearch for value {searchValue2}: " + (foundNode != null ? $"Found node with value: {foundNode.Value}" : "Not Found"));

        searchValue2 = 60;
        foundNode = tree.Search(searchValue);
        Console.WriteLine($"Search for value {searchValue2}: " + (foundNode != null ? $"Found node with value: {foundNode.Value}" : "Not Found"));

        Console.ReadKey();
    }
}
