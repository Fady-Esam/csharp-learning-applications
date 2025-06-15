using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class BinaryTreeNode<T>
{
    public T Value { get; set; }

    public BinaryTreeNode<T> LeftNode { get; set; }
    public BinaryTreeNode<T> RightNode { get; set; }


    public BinaryTreeNode(T value)
    {
        Value = value;
        LeftNode = null;
        RightNode = null;

    }
}


public class BinaryTree<T>
{
    public BinaryTreeNode<T> RootNode { get; set; }
    public BinaryTree()
    {
        RootNode = null;
    }




    public void Insert(T Value)
    {
        /*
 We use Level-order insertion strategy,
 Level-order insertion: in a binary tree is a strategy that fills the tree level by level, 
 from left to right. This approach ensures that every level of the tree is completely 
 filled before any nodes are added to a new level, 
 and each parent node has at most two children before moving on to the next node in the 
 sequence.

 */

        BinaryTreeNode<T> NewNode = new BinaryTreeNode<T>(Value);
        if (RootNode == null)
        {
            RootNode = NewNode;
            return;
        }

        // Use Level Order Insertion Strategy
        Queue<BinaryTreeNode<T>> que = new Queue<BinaryTreeNode<T>>();
        que.Enqueue(RootNode);
        while (que.Count > 0)
        {
            BinaryTreeNode<T> current = que.Dequeue();
            if(current.LeftNode == null)
            {
                current.LeftNode = NewNode;
                break;
            }
            else
            {
                que.Enqueue(current.LeftNode);
            }
            if(current.RightNode == null)
            {
                current.RightNode = NewNode;
                break;
            }
            else
            {
                que.Enqueue(current.RightNode);

            }
        }


    }

    public void PrintBinaryTree()
    {
        PrintBinaryTree(RootNode, 0);
    }

    public void PreOrderTraversal()
    {
        PreOrderTraversal(RootNode);
        Console.WriteLine();
    }

    public void PreOrderTraversal(BinaryTreeNode<T> node) // Root - Left - Right
    {
        if(node != null)
        {
            Console.Write(node.Value + " ");
            PreOrderTraversal(node.LeftNode);
            PreOrderTraversal(node.RightNode);

        }
    }

    public void PostTraversal() // Left - Right - Root
    {
        PostTraversal(RootNode);
        Console.WriteLine();

    }


    public void PostTraversal(BinaryTreeNode<T> node) // Left - Right - Root
    {
        if (node != null)
        {
            PostTraversal(node.LeftNode);
            PostTraversal(node.RightNode);
            Console.Write(node.Value + " ");

        }
    }


    public void OrderTraversal() // Left - Root - Right
    {
        OrderTraversal(RootNode);
        Console.WriteLine();

    }


    public void OrderTraversal(BinaryTreeNode<T> node) // Left - Root - Right
    {
        if (node != null)
        {
            OrderTraversal(node.LeftNode);
            Console.Write(node.Value + " ");
            OrderTraversal(node.RightNode);

        }
    }









    public void PrintBinaryTree(BinaryTreeNode<T> node, int space)
    {
        int COUNT = 10;  // Distance between levels to adjust the visual representation
        if (node == null)
            return;


        space += COUNT;
        PrintBinaryTree(node.RightNode, space); // Print right subtree first, then root, and left subtree last


        Console.WriteLine();
        for (int i = COUNT; i < space; i++)
            Console.Write(" ");
        Console.WriteLine(node.Value); // Print the current node after space
        PrintBinaryTree(node.LeftNode, space); // Recur on the left child
    }



}



internal class Program
{
    static void Main(string[] args)
    {
        var binaryTree = new BinaryTree<int>();
        Console.WriteLine("Values to be inserted: 5,3,8,1,4,6,9\n");

        binaryTree.Insert(5);
        binaryTree.Insert(3);
        binaryTree.Insert(8);
        binaryTree.Insert(1);
        binaryTree.Insert(4);
        binaryTree.Insert(6);
        binaryTree.Insert(9);

        binaryTree.PrintBinaryTree();

        binaryTree.PreOrderTraversal(); // Root - Left - Right
        binaryTree.PostTraversal(); // Left - Right - Root
        binaryTree.OrderTraversal(); // Left - Root - Right  

        Console.ReadKey();
    }
}

