using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;



class AVLNodeModel
{
    public int Value { get; set; }
    public AVLNodeModel LeftNode { get; set; }
    public AVLNodeModel RightNode { get; set; }
    public int Height { get; set; }

    public AVLNodeModel(int Value)
    {
        this.Value = Value;
        Height = 1;
    }

}

class AVLTree
{
    public AVLNodeModel Root { get; set; }

    public void InsertNode(int Value)
    {
        Root = InsertNode(Root, Value);
    }

    public AVLNodeModel InsertNode(AVLNodeModel node, int Value)
    {
        if (node == null) return new AVLNodeModel(Value);

        if(Value < node.Value)
        {
            node.LeftNode = InsertNode(node.LeftNode, Value);
        }
        else if(Value > node.Value)
        {
            node.RightNode = InsertNode(node.RightNode, Value);
        }
        else
            return node;


        UpdateHeight(node);
        return Balance(node);
    }


    public void UpdateHeight(AVLNodeModel node)
    {
        node.Height = 1 + Max(GetHeight(node.LeftNode), GetHeight(node.RightNode));
    }
    public int GetHeight(AVLNodeModel node)
    {
        return node == null ? 0 : node.Height;
    }
    public AVLNodeModel Balance(AVLNodeModel node)
    {
        int BF = GetBalanceFactor(node);


        if(BF < -1 && GetBalanceFactor(node.RightNode) <= 0) // Right Rotate
           return LeftRotation(node);
        if(BF > 1 && GetBalanceFactor(node.LeftNode) >= 0) // Left Rotate
            return RightRotation(node);

        if(BF > 1 && GetBalanceFactor(node.LeftNode) < 0) // Left Righ
        {
            node.LeftNode = LeftRotation(node.LeftNode);

            return RightRotation(node);
        }
        if (BF < -1 && GetBalanceFactor(node.RightNode) > 0) // Right Left
        {
            node.RightNode = RightRotation(node.RightNode);

            return LeftRotation(node);
        }
        return node;
    }


    public int GetBalanceFactor(AVLNodeModel node)
    {
        // The balance factor is the height of the left subtree minus the height of the right subtree
        return node == null ? 0 : GetHeight(node.LeftNode) - GetHeight(node.RightNode);
    }

    public AVLNodeModel RightRotation(AVLNodeModel OriginalRoot)
    {
        AVLNodeModel NewRoot = OriginalRoot.LeftNode;
        AVLNodeModel RightOrigianlNode = NewRoot.RightNode;
        NewRoot.RightNode = OriginalRoot;
        OriginalRoot.LeftNode = RightOrigianlNode;
        UpdateHeight(OriginalRoot);
        UpdateHeight(NewRoot);

        return NewRoot;
    }
    public AVLNodeModel LeftRotation(AVLNodeModel OriginalRoot)
    {
        AVLNodeModel NewRoot = OriginalRoot.RightNode;
        AVLNodeModel LeftOriginalNode = NewRoot.LeftNode;
        NewRoot.LeftNode = OriginalRoot;
        OriginalRoot.RightNode = LeftOriginalNode;
        UpdateHeight(OriginalRoot);
        UpdateHeight(NewRoot);
        return NewRoot;
    }


    public void DeleteNode(int Value)
    {
        DeleteNode(Root, Value);
    }

    public AVLNodeModel DeleteNode(AVLNodeModel Node, int Value)
    {
        if (Node == null)
        {
            return null;
        }
        if (Value < Node.Value)
        {
            Node.LeftNode = DeleteNode(Node.LeftNode, Value);
        }
        else if(Value > Node.Value)
        {
            Node.RightNode = DeleteNode(Node.RightNode, Value);
        }
        else
        {
            // if the node has no children or the node has only one Child
            if (Node.LeftNode == null) return Node.RightNode;
            else if (Node.RightNode == null) return Node.LeftNode;


            // if the node has two children

            AVLNodeModel temp = GetMinValueNode(Node.RightNode);


            Node.Value = temp.Value;
            Node.RightNode = DeleteNode(Node.RightNode, temp.Value);
          
        }
        UpdateHeight(Node);
        return Balance(Node);
    }

    public AVLNodeModel GetMinValueNode(AVLNodeModel Node)
    {
        AVLNodeModel Current = Node;
        while (Current.LeftNode != null)
        {
            Current = Current.LeftNode;
        }
        return Current;
    }

    public void PrintTree()
    {
        PrintTree(Root, "", true);
    }

    private void PrintTree(AVLNodeModel node, string indent, bool last)
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




    public bool Exisits(int Value)
    {
        return Exisits(Root, Value);
    }
    public bool Exisits(AVLNodeModel Node, int Value)
    {
        if (Node == null) return false;


        if(Value < Node.Value)
        {
            return Exisits(Node.LeftNode, Value);
        }
        else if(Value > Node.Value)
        {
            return Exisits(Node.RightNode, Value);
        }
        else
        {
            return true;
        }
    }

    public AVLNodeModel Search(int Value)
    {
        return Search(Root, Value);
    }

    private AVLNodeModel Search(AVLNodeModel Node, int Value)
    {
        if (Node == null) return null;


        if(Value < Node.Value)
        {
            return Search(Node.LeftNode, Value);
        }
        else if(Value > Node.Value)
        {
            return Search(Node.LeftNode, Value);

        }
        else
        {
            return null;
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
        bool found = tree.Exisits(searchValue);
        Console.WriteLine($"\nSearch for value {searchValue}: " + (found ? "Found" : "Not Found"));

        searchValue = 60;
        found = tree.Exisits(searchValue);
        Console.WriteLine($"Search for value {searchValue}: " + (found ? "Found" : "Not Found"));



        // Searching for values and printing the results
        int searchValue2 = 30;
        AVLNodeModel foundNode = tree.Search(searchValue2);
        Console.WriteLine($"\nSearch for value {searchValue2}: " + (foundNode != null ? $"Found node with value: {foundNode.Value}" : "Not Found"));

        searchValue2 = 60;
        foundNode = tree.Search(searchValue);
        Console.WriteLine($"Search for value {searchValue2}: " + (foundNode != null ? $"Found node with value: {foundNode.Value}" : "Not Found"));

        Console.ReadKey();

    }
}

