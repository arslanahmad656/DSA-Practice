using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTree();
            //TestTree2();
        }

        static void TestTree()
        {
            var tree1 = new Tree<int>();
            tree1.Insert(50);
            tree1.Insert(30);
            tree1.Insert(70);
            tree1.Insert(70);
            tree1.Insert(70);
            tree1.Insert(20);
            tree1.Insert(40);
            tree1.Insert(60);
            tree1.Insert(80);
            tree1.Print();

            //var node1 = tree1.Search(40);
            //var node2 = tree1.Search(60);
            //var node3 = tree1.Search(-20);
            //var node4 = tree1.Search(100);

            //var parent1 = tree1.GetParent(50);
            //var parent2 = tree1.GetParent(70);
            //var parent3 = tree1.GetParent(40);
            //var parent4 = tree1.GetParent(-12);
            //var parent5 = tree1.GetParent(335);

            //var children1 = tree1.GetChildren(50);
            //var children2 = tree1.GetChildren(70);
            //var children3 = tree1.GetChildren(80);
            //var children4 = tree1.GetChildren(-12);

            //var isRoot1 = tree1.IsRoot(88);
            //var isRoot2 = tree1.IsRoot(50);
            //var isRoot3 = tree1.IsRoot(70);

            //var isExternal1 = tree1.IsExternal(88);
            //var isExternal2 = tree1.IsExternal(80);
            //var isExternal3 = tree1.IsExternal(40);

            //var isInternal1 = tree1.IsInternal(50);
            //var isInternal2 = tree1.IsInternal(88);
            //var isInternal3 = tree1.IsInternal(70);
            //var isInternal4 = tree1.IsInternal(80);

            //var depth = tree1.GetDepth(50);
            //var depth2 = tree1.GetDepth(70);
            //var depth3 = tree1.GetDepth(40);
            //var depth4 = tree1.GetDepth(45);

            //var height1 = tree1.GetTreeMaxHeight();
            //var height2 = tree1.GetMaxHeight(70);
            //var height3 = tree1.GetMaxHeight(30);
            //var height4 = tree1.GetMaxHeight(40);
            //var height5 = tree1.GetMaxHeight(100);

            var height1 = tree1.GetTreeMinHeight();
            var height2 = tree1.GetMinHeight(70);
            var height3 = tree1.GetMinHeight(30);
            var height4 = tree1.GetMinHeight(40);
            var height5 = tree1.GetMinHeight(100);
        }

        static void TestTree2()
        {
            var tree = Tree<char>.FromEnumerable("FCIBEHK");
            tree.Print();
            var preOrderTraversal = tree.GetPreOrderTraversal();
            var inOrderTraversal = tree.GetInOrderTraversal();
            var postOrderTraversal = tree.GetPostOrderTraversal();
        }
    }
}
