using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure3
{
    class TNode
    {
        public TNode lc;
        public TNode rc;
        public object item;
        public TNode()
        {
            lc = null;
            rc = null;
            item = null;
        }
        public TNode(object item)
        {
            lc = null;
            rc = null;
            this.item = item;
        }
    }
    class BinaryTree
    {
        public TNode parent;
        public BinaryTree()
        {
            parent = null;
        }
        //add a node to first empty place in left sub tree 
        public void AddInTreeL(TNode t)
        {
            TNode p = parent;
            if(parent == null)
            {
                parent = t;
                return;
            }
            while (p.lc != null)
            {
                if (p.rc == null)
                {
                    p.rc = t;
                    return;
                }
                p = p.lc;
            }
            p.lc = t;
        }
        //add a node to first empty place in right sub tree 
        public void AddInTreeR(TNode t)
        {
            TNode p = parent;
            if (parent == null)
            {
                parent = t;
                return;
            }
            while (p.rc != null)
            {
                if (p.lc == null)
                {
                    p.lc = t;
                    return;
                }
                p = p.rc;
            }
            p.rc = t;
        }
        // delete a value of nodes
        public void DeleteValue(object x, TNode p)
        {
            if (p.item == x)
                p.item = null;
            if (p.lc != null || p.rc != null)
            {
                if (p.lc != null)
                    DeleteValue(x, p.lc);
                if (p.rc != null)
                    DeleteValue(x, p.rc);
            }
            return;
        }
        // Calculate the height pf tree
        public int HeightOfTree(TNode p)
        {
            if (p == null)
                return 0;
            return Math.Max(HeightOfTree(p.lc), HeightOfTree(p.rc)) + 1;
        }
        // Calculate number of nodes in tree
        public int AllNodes(TNode p)
        {
            if (p == null)
                return 0;
            return AllNodes(p.lc) + AllNodes(p.rc) + 1;
        }
        // Calculate sum of items( Converted to int )
        public int SumOfNodes(TNode t)
        {
            if (t == null)
                return 0;
            return SumOfNodes(t.lc) + SumOfNodes(t.rc) + Convert.ToInt32(t.item);
        }
        // Calculate the leaves
        public int AmountOfLeaves(TNode t)
        {
            if (t == null)
                return 0;
            if (t.lc == null && t.rc == null)
                return 1;
            return AmountOfLeaves(t.lc) + AmountOfLeaves(t.lc);
        }
        // Print the tree inorder
        public void PrintInOrder(TNode p)
        {
            if (p == null)
                return;
            PrintInOrder(p.lc);
            Console.Write(p.item+",");
            PrintInOrder(p.rc);
        }
        // Print the tree in postorder
        public void PrintPostOrder(TNode p)
        {
            if (p == null)
                return;
            PrintPostOrder(p.lc);
            PrintPostOrder(p.rc);
            Console.Write(p.item + ",");
        }
        // Print the tree inorder
        public void PrintPreOrder(TNode p)
        {
            if (p == null)
                return;
            Console.Write(p.item + ",");
            PrintPreOrder(p.lc);
            PrintPreOrder(p.rc);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string wellcome = "Welcome to our program";
            Console.SetCursorPosition((Console.WindowWidth - wellcome.Length) / 2, Console.CursorTop);
            Console.WriteLine(wellcome);
            Console.ResetColor();
            BinaryTree tree= new BinaryTree();
            while (true)
            {
                Console.WriteLine("please choose your command: ");
                Console.WriteLine("1: Create a new Tree: ");
                Console.WriteLine("2: Add node in tree:");
                Console.WriteLine("3: Delete value x of tree: ");
                Console.WriteLine("4: The sum of all item: ");
                Console.WriteLine("5: The height of current tree: ");
                Console.WriteLine("6: Numbers of all nodes in tree:");
                Console.WriteLine("7: Numbers of all leaves: ");
                Console.WriteLine("8: Print InOrder");
                Console.WriteLine("9: Print PreOrder");
                Console.WriteLine("10: Print postOrder");
                Console.WriteLine("11: Quit");
                int key = Convert.ToInt32(Console.ReadLine());
                if (key == 11)
                    break;

                if (key == 1)
                {
                    tree = CreateTree();

                }
                else if (key == 2)
                {
                    TNode temp = new TNode();
                    Console.WriteLine("Enter value: ");
                    temp.item = Console.ReadLine();
                    Console.WriteLine("Where to add ? LeftSubTree(1)/RightSubTree(0)");
                   
                    while (true)
                    {
                        int key1;
                        key1 = Convert.ToInt32(Console.ReadLine());
                        if (key1 == 0)
                        {
                            tree.AddInTreeR(temp);
                            break;
                        }
                        else if (key1 == 1)
                        {
                            tree.AddInTreeL(temp);
                            break;
                        }
                        else
                        {
                            //The massage is just for fun NO OFFENCE
                            Console.WriteLine("Are you stupid or something ? enter 0 or 1 please:");
                        }
                    }
                }

                else if (key == 3)
                {
                    TNode p = tree.parent;
                    object x;
                    Console.WriteLine("Enter value: ");
                    x = Console.ReadLine();
                    tree.DeleteValue(x, p);
                }
                else if (key == 4)
                {
                    TNode p = tree.parent;
                    Console.WriteLine(tree.SumOfNodes(p));
                }
                else if (key == 5)
                {
                    TNode p = tree.parent;
                    Console.WriteLine(tree.HeightOfTree(p));
                }
                else if (key == 6)
                {
                    TNode p = tree.parent;
                    Console.WriteLine(tree.AllNodes(p));
                }
                else if (key == 7)
                {
                    TNode p = tree.parent;
                    Console.WriteLine(tree.AmountOfLeaves(p));
                }
                else if(key == 8)
                {
                    TNode p = tree.parent;
                    tree.PrintInOrder(p);
                }
                else if (key == 9)
                {
                    TNode p = tree.parent;
                    tree.PrintPreOrder(p);
                }
                else if (key == 10)
                {
                    TNode p = tree.parent;
                    tree.PrintPostOrder(p);
                }


            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Do not visit us again thank you for your visit :) ");
            Console.ResetColor();


        
    }

        // Create Tree
        public static BinaryTree CreateTree()
        {
            BinaryTree tree = new BinaryTree();
            while(true)
            {
                Console.WriteLine("Want to continue? 1(Yes)/0(No) ");
                int key;
                key =Convert.ToInt32(Console.ReadLine());
                if (key == 0)
                    break;
                else if(key == 1)
                {
                   
                    TNode temp = new TNode();
                    Console.WriteLine("Enter value: ");
                    temp.item = Console.ReadLine();
                    Console.WriteLine("Where to add ? LeftSubTree(1)/RightSubTree(0)");
                    while (true)
                    {
                        int key1;
                        key1 = Convert.ToInt32(Console.ReadLine());
                        if (key1 == 0)
                        {
                            tree.AddInTreeR(temp);
                            break;
                        }
                        else if (key1 == 1)
                        {
                            tree.AddInTreeL(temp);
                            break;
                        }
                        else
                        {
                            //The massage is just for fun NO OFFENCE
                            Console.WriteLine("Are you stupid or something ? enter 0 or 1 please:");
                        }
                    }
                }
            }
            return tree;
        }
    }
}
