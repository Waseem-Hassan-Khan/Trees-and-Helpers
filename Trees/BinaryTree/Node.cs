
namespace Trees.BinaryTree
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }

        public override string ToString()
        {
            return $"Root Node({data})";
        }

    }
}
