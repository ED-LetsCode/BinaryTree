namespace BinaryTreeLibrary
{
    public class BinaryTree
    {
        private int _leftNodeLevels = 0;
        private int _rightNodeLevels = 0;
        private Node _rootNode;

        /// <summary>
        /// Get nodes id as list ascending
        /// </summary>
        /// <param name="node">Root node</param>
        /// <param name="list">Hand over a empty list</param>
        public void GetAscending(Node node, ref List<int> list)
        {
            if (node.Left != null) GetAscending(node.Left, ref list);
            list.Add(node.Id);
            if (node.Right != null) GetAscending(node.Right, ref list);
        }
        /// <summary>
        /// Get nodes id as list descending
        /// </summary>
        /// <param name="node">Root node</param>
        /// <param name="list">Hand over a empty list</param>
        public void GetDescending(Node node, ref List<int> list)
        {
            if (node.Right != null) GetDescending(node.Right, ref list);
            list.Add(node.Id);
            if (node.Left != null) GetDescending(node.Left, ref list);
        }

        /// <summary>
        /// Creates the binary tree
        /// </summary>
        /// <param name="list">List of numbers</param>
        /// <returns>Root node from binary tree</returns>
        public Node CreateTree(List<int> list)
        {
            if (list.Count == 0) return null;
            list.Sort();

            //Get the middle element of the list
            var mid = list.Count / 2;

            //Create a new node with the middle element
            var node = new Node(list[mid]);

            //Create a new Node with the elements after the middle element RIGHT SIDE OF THE TREE
            node.Right = CreateTree(list.GetRange(mid + 1, list.Count - mid - 1));

            //Create a new Node with the elements before the middle element LEFT SIDE OF THE TREE
            node.Left = CreateTree(list.GetRange(0, mid));

            return node;
        }

        /// <summary>
        /// Get the levels of the tree
        /// </summary>
        /// <param name="node">Root node from tree</param>
        /// <returns>Levels from the tree</returns>
        public int GetLevels(Node node)
        {
            _leftNodeLevels = 0; _rightNodeLevels = 0;
            //To find the deepest level we have to go through both sides of the tree
            //because we don't know if the left or the right side has the deeper level.
            CountLeftNodeLevels(node);
            CountRightNodeLevels(node);
            return _leftNodeLevels < _rightNodeLevels ? _rightNodeLevels : _leftNodeLevels;
        }

        /// <summary>
        /// Count's the levels of the left side
        /// </summary>
        private void CountLeftNodeLevels(Node node) 
        {
            if (node.Left != null) CountLeftNodeLevels(node.Left);
            _leftNodeLevels++;
        }

        /// <summary>
        /// Count's the levels of the right side
        /// </summary>
        private void CountRightNodeLevels(Node node)
        {
            if (node.Right != null) CountRightNodeLevels(node.Right);
            _rightNodeLevels++;
        }

        /// <summary>
        /// Find's the node with the given id
        /// </summary>
        /// <param name="node">Root node from tree</param>
        /// <param name="id">Searched id</param>
        /// <returns>Searched node</returns>
        public Node FindNode(Node node, int id)
        {
            if (node == null || node.Id == id) return node;
            if (node.Id < id) return FindNode(node.Right, id);
            if (node.Id > id) return FindNode(node.Left, id);
            return null;
        }


        public Node AddNode(Node node, Node newNode)
        {
            if(node.Id < newNode.Id)
            {
                if (node.Right == null) node.Right = newNode;
                else return AddNode(node.Right, newNode);
            }

            if(node.Id > newNode.Id)
            {
                if (node.Left == null) node.Right = newNode;
                else return AddNode(node.Right, newNode);
            }
            return node;
        }
    }
}