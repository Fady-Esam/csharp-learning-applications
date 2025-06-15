using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


class ReBlackTree
{
    public NodeModel Root { get; set; }
    public class NodeModel
    {
        public int Value;
        public NodeModel LeftNode, RightNode, ParentNode;
        public bool IsRed = true;
        public NodeModel(int Value)
        {
            this.Value = Value;
        }
    }

    public void Insert(int Value)
    {
        NodeModel NewNode = new NodeModel(Value);
        if (Root == null)
        {
            Root = NewNode;
            Root.IsRed = false;
            return;
        }


        NodeModel Parent = null;
        NodeModel Current = Root;
        while (Current != null)
        {
            Parent = Current;
            if (Value < Current.Value)
            {
                Current = Current.LeftNode;
            }
            else
            {
                Current = Current.RightNode;
            }

        }
        NewNode.ParentNode = Parent;
        if (Value < Parent.Value)
        {
            Parent.LeftNode = NewNode;
        }
        else
        {
            Parent.RightNode = NewNode;
        }
        FixInsert(NewNode);
    }
    public void FixInsert(NodeModel node)
    {
        NodeModel Parent = null;
        NodeModel GrandParent = null;


        while ((node != Root) && (node.IsRed) && (node.ParentNode.IsRed))
        {
            Parent = node.ParentNode;
            GrandParent = Parent.ParentNode;

            if (Parent == GrandParent.LeftNode)
            {
                NodeModel Uncle = GrandParent.RightNode;
                if (Uncle != null && Uncle.IsRed)
                {
                    Parent.IsRed = !Parent.IsRed;
                    GrandParent.IsRed = !GrandParent.IsRed;
                    Uncle.IsRed = !Uncle.IsRed;
                    node = GrandParent;

                }
                else
                {
                    if (node == Parent.RightNode)
                    {
                        // LeftRotaion
                        RotateLeft(Parent);
                        node = Parent;
                        Parent = node.ParentNode;
                    }

                    // RightRotation
                    RotateRight(GrandParent);

                    Parent.IsRed = !Parent.IsRed;
                    GrandParent.IsRed = !GrandParent.IsRed;
                    node = Parent;
                }
            }
            else
            {
                NodeModel Uncle = GrandParent.LeftNode;
                if (Uncle != null && Uncle.IsRed)
                {
                    Parent.IsRed = !Parent.IsRed;
                    GrandParent.IsRed = !GrandParent.IsRed;
                    Uncle.IsRed = !Uncle.IsRed;
                    node = GrandParent;

                }
                else
                {
                    if (node == Parent.LeftNode)
                    {
                        RotateRight(Parent);
                        // RightRotaion
                        node = Parent;
                        Parent = node.ParentNode;
                    }

                    // LeftRotation
                    RotateLeft(GrandParent);
                    Parent.IsRed = !Parent.IsRed;
                    GrandParent.IsRed = !GrandParent.IsRed;
                    node = Parent;
                }
            }
        }
        Root.IsRed = false;


    }
    // Rotate left pivots around the given node making the right child the parent of the pivoted node

    private void RotateLeft(NodeModel node)
    {
        NodeModel right = node.RightNode; // Right child becomes the new root of the subtree
        node.RightNode = right.LeftNode; // Move the left subtree of right to the right subtree of node

        if (node.RightNode != null)
            node.RightNode.ParentNode = node; // Set parent of the new right child

        right.ParentNode = node.ParentNode; // Connect new root with the grandparent

        if (node.ParentNode == null)
            Root = right; // The right child becomes the new root of the tree
        else if (node == node.ParentNode.LeftNode)
            node.ParentNode.LeftNode = right; // Set right child to left child of parent
        else
            node.ParentNode.RightNode = right; // Set right child to right child of parent

        right.LeftNode = node; // Original node becomes the left child of its right child
        node.ParentNode = right; // Update parent of the original node
    }

    // Rotate right pivots around the given node making the left child the parent of the pivoted node
    private void RotateRight(NodeModel node)
    {
        NodeModel left = node.LeftNode; // Left child becomes the new root of the subtree
        node.LeftNode = left.RightNode; // Move the right subtree of left to the left subtree of node

        if (node.LeftNode != null)
            node.LeftNode.ParentNode = node; // Set parent of the new left child

        left.ParentNode = node.ParentNode; // Connect new root with the grandparent

        if (node.ParentNode == null)
            Root = left; // The left child becomes the new root of the tree
        else if (node == node.ParentNode.RightNode)
            node.ParentNode.RightNode = left; // Set left child to right child of parent
        else
            node.ParentNode.LeftNode = left; // Set left child to left child of parent

        left.RightNode = node; // Original node becomes the right child of its left child
        node.ParentNode = left; // Update parent of the original node
    }
    public void PrintTree()
    {
        PrintHelper(Root, "", true);
    }


    // Helper method to print the tree
    private void PrintHelper(NodeModel node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "   ";
            }
            else
            {
                Console.Write("L----");
                indent += "|  ";
            }
            var color = node.IsRed ? "RED" : "BLK";
            Console.WriteLine(node.Value + "(" + color + ")");
            PrintHelper(node.LeftNode, indent, false);
            PrintHelper(node.RightNode, indent, true);

        }
    }

    public NodeModel Find(int Value)
    {
        return Find(Root, Value);
    }


    public NodeModel Find(NodeModel node, int Value)
    {
        if (node == null || node.Value == Value) return node;
        if(Value < node.Value)
        {
            return Find(node.LeftNode, Value);
        }
        else
        {
            return Find(node.RightNode, Value);

        }
    }
}



internal class Program
{
    static void Main(string[] args)
    {
        ReBlackTree rbTree = new ReBlackTree();


        // Test values to be inserted into the tree
        int[] values = { 10, 20, 30, 15, 25, 35, 5, 19 };
        foreach (var value in values)
        {
            Console.WriteLine($"Inserting {value} to the tree\n");
            rbTree.Insert(value);
            rbTree.PrintTree();
            Console.WriteLine("\n--------------------------------\n");
        }
        Console.ReadKey();
    }
}
