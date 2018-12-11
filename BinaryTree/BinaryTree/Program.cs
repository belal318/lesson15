using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree(80);
            //דוגמה
            //tree.Left = new TreeNode(10);
            //tree.Right = new TreeNode(5);
            //tree.Right.Left = new TreeNode(100);
            //BinaryTree bt = new BinaryTree(50);
            tree.Add(5);
            tree.Add(25);
            tree.Add(20);
            tree.Add(55);
            tree.Add(50);
            tree.Add(70);
            tree.PrintTree();
            Console.WriteLine("Add 75 to the tree :");
            tree.Add(75);
            tree.PrintTree();
            Console.WriteLine("************************************");
            Console.WriteLine("max: " + tree.GetMax());
            Console.WriteLine();
            Console.WriteLine("max: " + tree.GetMax2());
            Console.WriteLine("min: " + tree.GetMin());
            Console.WriteLine();
            Console.WriteLine("************************************");

            TreeNode myNode = tree.Find(0);
            if (myNode != null)
            {
                Console.WriteLine(myNode.Value + " is Found :)");
            }
            else
            {
                Console.WriteLine("Not Found!!!!!");
            }
            Console.WriteLine("************************************");
            Console.WriteLine();
            Console.Write("delete 5: \n" + tree.Delete(5));
            tree.PrintTree();
            Console.WriteLine();
            Console.Write("delete 20: \n" + tree.Delete(20));
            tree.PrintTree();
            Console.WriteLine();
            Console.Write("delete 75: \n" + tree.Delete(75));
            tree.PrintTree();
            Console.WriteLine();
            Console.Write("delete 70: \n" + tree.Delete(70));
            tree.PrintTree();
            Console.WriteLine();
            Console.Write("delete 55: \n" + tree.Delete(55));
            tree.PrintTree();

            //if head was public!!!!!
            //bt.head.Left = new TreeNode(20);
            //bt.head.Left.Left = new TreeNode(5);
            //bt.head.Left.Right = new TreeNode(25);
            //bt.head.Right = new TreeNode(70);
            //bt.PrintTree();

        }
    }
    class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Parent { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }
    }
    class BinaryTree
    {
        TreeNode head;
        public BinaryTree()
        {
            head = null;
        }
        public BinaryTree(int value)
        {
            head = new TreeNode(value);
        }
        public bool IsEmpty() { return head == null; }

        public void Add(int value)
        {
            if (IsEmpty())
            {
                TreeNode newTreeNode = new TreeNode(value);
                head = newTreeNode;
                head.Parent = head;
            }
            else
            {
                RecAdd(head, value);
            }
        }
        private void RecAdd(TreeNode temp, int value)
        {
            if (value < temp.Value)
            {
                if (temp.Left == null)
                {
                    temp.Left = new TreeNode(value);
                }
                else
                {
                    RecAdd(temp.Left, value);
                }
            }
            else
            {
                if (temp.Right == null)
                {
                    temp.Right = new TreeNode(value);
                }
                else
                {
                    RecAdd(temp.Right, value);
                }
            }
        }
        public void PrintTree()
        {
            Console.WriteLine();
            Print(head);
            Console.WriteLine();
        }
        private void Print(TreeNode node)
        {

            if (node.Left != null)
            {
                Print(node.Left);
            }
            Console.Write(node.Value + " ,");

            if (node.Right != null)
            {
                Print(node.Right);
            }
        }
        public int GetMax()
        {
            if (head == null)
            {
                return 0;
            }
            return GetMaxRec(head);
        }

        public int GetMaxRec(TreeNode node)
        {
            if (node.Right == null)
            {
                return node.Value;
            }
            return GetMaxRec(node.Right);

        }

        public int GetMax2()
        {
            if (head == null)
            {
                return 0;
            }
            TreeNode temp = head;
            for (; temp.Right != null; temp = temp.Right) { }
            return temp.Value;
        }

        public int GetMin()
        {
            if (head == null)
            {
                return 0;
            }
            TreeNode temp = head;
            for (; temp.Left != null; temp = temp.Left) { }
            return temp.Value;
        }
        public TreeNode Find(int valueToFind)
        {
            TreeNode temp = head;
            while (temp != null)
            {
                if (temp.Value == valueToFind)
                {
                    return temp;
                }

                else if (valueToFind < temp.Value)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }

            }
            return null;
        }
        public TreeNode Find2(int valueToFind)
        {
            return Find(head, valueToFind);
        }

        private TreeNode Find(TreeNode temp, int valueToFind)
        {
            if (temp != null)
            {
                if (temp.Value == valueToFind)
                {
                    return temp;
                }
                else if (valueToFind < temp.Value)
                {
                    return Find(temp.Left, valueToFind);
                }
                else
                {
                    return Find(temp.Right, valueToFind);
                }
            }
            return null;
        }

        public bool Delete(int valueToDelete)
        {
            TreeNode temp = head;
            if (head != null && head.Value == valueToDelete)
            {
                if (head.Left == null & head.Right == null)
                {
                    head = null;
                    return true;
                }
            }
            while (temp != null)
            {
                if (temp.Left != null && temp.Left.Value == valueToDelete &&
                     temp.Left.Left == null && temp.Left.Right == null)
                {
                    temp.Left = null;
                    return true;
                }
                else if (temp.Right != null && temp.Right.Value == valueToDelete &&
                   temp.Right.Left == null && temp.Right.Right == null)
                {
                    temp.Right = null;
                    return true;
                }
                else if (valueToDelete < temp.Value)
                {
                    temp = temp.Left;
                }
                else //if (temp.Value < valueToDelete)
                {
                    temp = temp.Right;
                }

            }
            return false;
        }
        //public bool DeleteWithoutTheNeedParent(int valueToDelete)
        //{

        //}
    }
}
