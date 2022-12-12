using BinaryTreeLibrary;

namespace BinaryTreeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 10, 5, 2, 4, 6, 7, 1, 8, 9 };
            List<int> list2 = new List<int>();
            BinaryTree bt = new BinaryTree();

            Node node = bt.CreateTree(list);

            Node node2 = bt.FindNode(node, 5);

            Node node3 = bt.AddNode(node, new Node(3));

            int levelsOfTree = bt.GetLevels(node);

            bt.GetAscending(node3, ref list2);
            //bt.GetDescending(node, ref list2);
            list2.ForEach(num => Console.WriteLine(num));
        }
    }
}