using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLibrary
{
    public class Node
    {
        public int Id { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int id)
        {
            Id = id;
        }

        public Node(Node left, Node right)
        {
            Left = left;
            Right = right;
        }
    }
}
