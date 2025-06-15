using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class BinaryTreeNodeModel<T>
{
    public T Value { get; set; }
    public BinaryTreeNodeModel<T> LeftNode { get; set; }
    public BinaryTreeNodeModel<T> RightNode { get; set; }

    public BinaryTreeNodeModel(T Value)
    {
        this.Value = Value;
        LeftNode = null;
        RightNode = null;
    }

   

}



class BinaryTree<T> where T : IComparable
{
    public BinaryTreeNodeModel<T> Root { get; set; }
    public BinaryTree()
    {
        Root = null;
    }
        

    public void InsertNode(T Value) // level order insertion strategy
    {
        BinaryTreeNodeModel<T> newNode = new BinaryTreeNodeModel<T>(Value); 

        if (Root == null)
        {
            Root = newNode;
            return;
        }

        Queue<BinaryTreeNodeModel<T>> qu = new Queue<BinaryTreeNodeModel<T>>();

        qu.Enqueue(Root);
        while (qu.Count > 0)
        {
            BinaryTreeNodeModel<T> Current = qu.Dequeue();

            if(Current.LeftNode == null)
            {
                Current.LeftNode = newNode;
                break;
            }
            else
            {
                qu.Enqueue(Current.LeftNode);
            }
            if (Current.RightNode == null)
            {
                Current.RightNode = newNode;
                break;

            }
            else
            {
                qu.Enqueue(Current.RightNode);
            }
        }

    }
    public void PrintTree()
    {
        PrintTree(Root, 0);
    }
    public void PrintTree(BinaryTreeNodeModel<T> root, int space)
    {
        int COUNT = 10;  // Distance between levels
        if (root == null)
            return;

        space += COUNT;
        PrintTree(root.RightNode, space);

        Console.WriteLine();
        for (int i = COUNT; i < space; i++)
            Console.Write(" ");
        Console.WriteLine(root.Value);
        PrintTree(root.LeftNode, space);
    }


    public void PreOrderTraversal() // Root -> Left -> Right
    {
        PreOrderTraversal(Root);
    }
    public void PreOrderTraversal(BinaryTreeNodeModel<T> Root) // Root -> Left -> Right
    {
        if(Root == null) return;
        Console.WriteLine(Root.Value + " ");
        PreOrderTraversal(Root.LeftNode);
        PreOrderTraversal(Root.RightNode);

    }

    public void PostOrderTraversal() // Left -> Right -> Root
    {
        PostOrderTraversal(Root);
    }
    public void PostOrderTraversal(BinaryTreeNodeModel<T> Root) // Left -> Right -> Root
    {
        if(Root == null) return;
        PostOrderTraversal(Root.LeftNode);
        PostOrderTraversal(Root.RightNode);
        Console.WriteLine(Root.Value + " ");
    }



    public void InOrderTraversal() // Left -> Root -> Right
    {
        InOrderTraversal(Root);
    }
    public void InOrderTraversal(BinaryTreeNodeModel<T> Root) // Left -> Root -> Right
    {
        if(Root == null) return;
        InOrderTraversal(Root.LeftNode);
        Console.WriteLine(Root.Value + " ");
        InOrderTraversal(Root.RightNode);
    }


    public void LevelOrderTraversal()
    {
        LevelOrderTraversal(Root);
    }
    public void LevelOrderTraversal(BinaryTreeNodeModel<T> Root)
    {
        if (Root == null) return;
        Queue<BinaryTreeNodeModel<T>> que = new Queue<BinaryTreeNodeModel<T>>();
        que.Enqueue(Root);
        while(que.Count > 0)
        {
            BinaryTreeNodeModel<T> Current = que.Dequeue();
            Console.WriteLine(Current.Value);
            if (Current.LeftNode != null)
            {
                que.Enqueue(Current.LeftNode);
            }
            if(Current.RightNode != null)
            {
                que.Enqueue(Current.RightNode);

            }
        }
    }

    public void InsertBinarySearchTree(T Value)
    {
        Root = InsertBinarySearchTree(Root, Value);
    }
    public BinaryTreeNodeModel<T> InsertBinarySearchTree(BinaryTreeNodeModel<T> node, T Value)
    {
        if(node == null) return new BinaryTreeNodeModel<T>(Value);

        else if (Value.CompareTo(node.Value) < 0)
        {
            node.LeftNode = InsertBinarySearchTree(node.LeftNode, Value);
        }
        else 
        {
            node.RightNode = InsertBinarySearchTree(node.RightNode, Value);
        }
        return node;
    }

    public bool Search(T Value)
    {
        return Search(Root, Value) != null;
    }
    public BinaryTreeNodeModel<T> Search(BinaryTreeNodeModel<T> node, T Value)
    {
        if(node == null || node.Value.Equals(Value))
        {
            return node;
        }
        if(Value.CompareTo(node.Value) < 0)
        {
            return Search(node.LeftNode, Value);
        }
        else
        {
            return Search(node.RightNode, Value);

        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> bst = new BinaryTree<int>();
        //dat.InsertNode(5);
        //dat.InsertNode(3);
        //dat.InsertNode(8);
        //dat.InsertNode(1);
        //dat.InsertNode(4);
        //dat.InsertNode(6);
        //dat.InsertNode(0);


        Console.WriteLine("\nInserting : 45, 15, 79, 90, 10, 55, 12, 20, 50\r\n");
        bst.InsertBinarySearchTree(45);
        bst.InsertBinarySearchTree(15);
        bst.InsertBinarySearchTree(79);
        bst.InsertBinarySearchTree(90);
        bst.InsertBinarySearchTree(10);
        bst.InsertBinarySearchTree(55);
        bst.InsertBinarySearchTree(12);
        bst.InsertBinarySearchTree(20);
        bst.InsertBinarySearchTree(50);
        Console.WriteLine();
        bst.PrintTree();


        //dat.PrintTree();
        //dat.PreOrderTraversal();
        //dat.PostOrderTraversal();
        //dat.InOrderTraversal();
        bst.InOrderTraversal();
        Console.WriteLine();
        Console.WriteLine(bst.Search(90));
        Console.ReadKey();

    }
}

