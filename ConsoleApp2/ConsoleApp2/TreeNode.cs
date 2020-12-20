using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Data { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public TreeNode(T data) : this(data, null, null)
        {
            
        }

        public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }

        public override string ToString() => Data?.ToString();
    }
}
