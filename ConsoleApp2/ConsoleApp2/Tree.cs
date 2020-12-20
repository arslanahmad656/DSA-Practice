using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Tree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; private set; }

        public int Count { get; private set; }

        public Tree() : this((TreeNode<T>)null)
        {

        }

        public Tree(T rootData) : this(new TreeNode<T>(rootData))
        {

        }

        public Tree(TreeNode<T> root)
        {
            this.Root = root;
        }

        public void Insert(T nodeData) => Insert(new TreeNode<T>(nodeData));

        public void Insert(TreeNode<T> node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                var data = node.Data;
                var inserted = false;
                var current = Root;
                TreeNode<T> parent = null;
                while (!inserted)
                {
                    parent = current;
                    if (data.CompareTo(current.Data) < 0)   // data is to be inserted on the left of current node
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = node;
                            inserted = true;
                        }
                    }
                    else // data is to be inserted to the right of the current node
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = node;
                            inserted = true;
                        }
                    }
                }
            }

            ++Count;
        }

        public TreeNode<T> Remove(T data)
        {//WRONG!!!!
            if (Root == null)
            {
                return null;
            }

            var current = Root;
            TreeNode<T> parent = null;
            TreeNode<T> removedNode = null;
            var done = false;
            while (!done)
            {
                if (current == null)
                {
                    done = true;
                    removedNode = null;
                }
                else if (current.Data.CompareTo(data) == 0)
                {
                    done = true;
                    if (current.Left != null && current.Right != null)
                    {
                        removedNode = null;
                    }
                    else
                    {
                        removedNode = current;
                        if (current.Left != null)
                        {
                            if (IsRoot(data))
                            {
                                Root = current.Left;
                            } 
                            else if (current.Data.CompareTo(parent.Data) >= 0)
                            {
                                parent.Right = current.Left;
                            }
                            else
                            {
                                parent.Left = current.Left;
                            }
                        }
                        else
                        {
                            if (IsRoot(data))
                            {
                                Root = current.Right;
                            }
                            else if (current.Data.CompareTo(parent.Data) >= 0)
                            {
                                parent.Right = current.Right;
                            }
                            else
                            {
                                parent.Left = current.Right;
                            }
                        }
                    }
                }
                else
                {
                    if (data.CompareTo(current.Data) < 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }

                    parent = current;
                }
            }

            return removedNode;
        }

        public TreeNode<T> GetParent(T data)
        {
            var found = false;
            var current = Root;
            while (!found)
            {
                if (current == null)
                {
                    found = true;
                }
                else
                {
                    if ((current.Left != null && data.CompareTo(current.Left.Data) == 0) ||
                        current.Right != null && data.CompareTo(current.Right.Data) == 0)
                    {
                        found = true;
                    }
                    else if (data.CompareTo(current.Data) < 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }

            return current;
        }

        public (TreeNode<T> left, TreeNode<T> right) GetChildren(T data)
        {
            var node = Search(data);
            if (node == null)
            {
                return (null, null);
            }

            return (node.Left, node.Right);
        }

        public bool IsRoot(T data)
        {
            return Root != null && Root.Data.CompareTo(data) == 0;
        }

        public bool IsExternal(T data)
        {
            var node = Search(data);
            return node != null && node.Left == null && node.Right == null;
        }

        public bool IsInternal(T data)
        {
            var node = Search(data);
            return node != null && !IsRoot(data) && !IsExternal(data);
        }

        public TreeNode<T> Search(T data)
        {
            var current = Root;
            var found = false;
            do
            {
                if (current == null)
                {
                    found = true;
                }
                else
                {
                    if (data.CompareTo(current.Data) == 0)
                    {
                        found = true;
                    }
                    else if (data.CompareTo(current.Data) < 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            } while (!found);

            return current;
        }

        public int GetDepth(T data)
        {
            if (Root == null)
            {
                return 0;
            }

            var depth = GetGetDepthWorker(data);
            return depth;
        }

        public int GetMaxHeight(T data)
        {
            if (Root == null)
            {
                return 0;
            }

            var node = Search(data);
            if (node == null)
            {
                return 0;
            }

            var height = GetMaxHeightWorker(node);
            return height;
        }

        public int GetMinHeight(T data)
        {
            if (Root == null)
            {
                return 0;
            }

            var node = Search(data);
            if (node == null)
            {
                return 0;
            }

            var height = GetMinHeightWorker(node);
            return height;
        }

        public int GetTreeMaxHeight()
        {
            var height = GetMaxHeight(Root.Data);
            return height;
        }

        public int GetTreeMinHeight()
        {
            var height = GetMinHeight(Root.Data);
            return height;
        }

        private int GetMaxHeightWorker(TreeNode<T> node)
        {
            if (IsExternal(node.Data))
            {
                return 0;
            }

            var leftNode = node.Left;
            var rightNode = node.Right;
            var leftHeight = leftNode == null  ? 0 : GetMaxHeightWorker(leftNode);
            var rightHeight = rightNode == null ? 0 : GetMaxHeightWorker(rightNode);
            var selectedHeight = Math.Max(leftHeight, rightHeight);
            var nodeHeight = 1 + selectedHeight;    // this is the height of the node given in params
            return nodeHeight;
        }

        private int GetMinHeightWorker(TreeNode<T> node)
        {
            if (IsExternal(node.Data))
            {
                return 0;   // leaf node has 0 height
            }

            var leftNode = node.Left;
            var rightNode = node.Right;
            var leftHeight = leftNode == null ? 0 : GetMinHeightWorker(leftNode);
            var rightHeight = rightNode == null ? 0 : GetMinHeightWorker(rightNode);
            var selectedHeight = Math.Min(leftHeight, rightHeight);
            var nodeHeight = 1 + selectedHeight;    // this is the height of the node given in params
            return nodeHeight;
        }

        private int GetGetDepthWorker(T data)
        {
            if (IsRoot(data))
            {
                return 0;
            }

            var parent = GetParent(data);
            var parentDepth = GetGetDepthWorker(parent.Data);
            return 1 + parentDepth;
        }

        public List<TreeNode<T>> GetPreOrderTraversal()
        {
            var arr = new List<TreeNode<T>>(Count);
            PreOrderTraversalWorker(arr, Root);
            return arr;
        }

        public List<TreeNode<T>> GetInOrderTraversal()
        {
            var arr = new List<TreeNode<T>>(Count);
            InOrderTraversalWorker(arr, Root);
            return arr;
        }

        public List<TreeNode<T>> GetPostOrderTraversal()
        {
            var arr = new List<TreeNode<T>>(Count);
            PostOrderTraversalWorker(arr, Root);
            return arr;
        }

        private void PreOrderTraversalWorker(List<TreeNode<T>> outputList, TreeNode<T> currentNode)
        {
            if (currentNode != null)
            {
                outputList.Add(currentNode);
                PreOrderTraversalWorker(outputList, currentNode.Left);
                PreOrderTraversalWorker(outputList, currentNode.Right);
            }
        }

        private void InOrderTraversalWorker(List<TreeNode<T>> outputList, TreeNode<T> currentNode)
        {
            if (currentNode != null)
            {
                InOrderTraversalWorker(outputList, currentNode.Left);
                outputList.Add(currentNode);
                InOrderTraversalWorker(outputList, currentNode.Right);
            }
        }

        private void PostOrderTraversalWorker(List<TreeNode<T>> outputList, TreeNode<T> currentNode)
        {
            if (currentNode != null)
            {
                PostOrderTraversalWorker(outputList, currentNode.Left);
                PostOrderTraversalWorker(outputList, currentNode.Right);
                outputList.Add(currentNode);
            }
        }


        public void Print()
        {
            PrintPretty(Root, "", true);
        }

        public static Tree<T> FromEnumerable(IEnumerable<T> data)
        {
            var tree = new Tree<T>();

            if (data == null)
            {
                return tree;
            }

            foreach (var item in data)
            {
                tree.Insert(item);
            }

            return tree;
        }

        private void PrintPretty(TreeNode<T> item, string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }
            Console.WriteLine(item);

            if (item != null)
            {
                var children = new List<TreeNode<T>>();
                if (item.Left != null)
                    children.Add(item.Left);
                if (item.Right != null)
                    children.Add(item.Right);

                for (int i = 0; i < children.Count; i++)
                    PrintPretty(children[i], indent, i == children.Count - 1);
            }
        }
    }
}
