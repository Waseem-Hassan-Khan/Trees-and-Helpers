
using Trees.BinaryTree;

namespace Trees.BinaryTree
{
    public static class BinaryTree
    {
        static int index = -1;
        static int sum = 0;
        public static Node buildTree(int[] node)
        {
            index++;
            if (node[index] == -1)
                return null;

            Node newNode = new Node(node[index]);
            newNode.left = buildTree(node);
            newNode.right = buildTree(node);
            return newNode;
        }

        public static int countNodes(Node root)
        { 
            if (root == null) return 0;
           

            int leftNodes = countNodes(root.left);
            int rightNodes = countNodes(root.right);

            return leftNodes + rightNodes+ 1;
        }

        public static int sumOfNodes(Node root)
        {
            if (root == null) return 0;

            int leftNodes = sumOfNodes(root.left);
            int rightNodes = sumOfNodes(root.right);

            return leftNodes + rightNodes + root.data;
        }

        public static int nodeHeight(Node root)
        {
            if (root == null) return 0;

            int leftHeight = nodeHeight(root.left);
            int rightHeight = nodeHeight(root.right);
            return Math.Max(leftHeight , rightHeight)+1;
        }

        public static int nodeDiameter(Node root)
        {
            if (root == null) return 0;

            int leftDiameter = nodeDiameter(root.left);
            int righDiameter = nodeDiameter(root.right);
            int sumDiameter = nodeHeight(root.left) + nodeHeight(root.right) + 1;

            return Math.Max(sumDiameter,Math.Max(leftDiameter,righDiameter));
        }

        public static int GetExecutionCount()
        {
            return index;
        }

        public static void levelOrder(Node root)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty.");
                return;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            q.Enqueue(null);

            while (q.Count > 0)
            {
                Node node = q.Dequeue();

                if (node == null)
                {
                    Console.WriteLine();
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                    }
                }
                else
                {
                    Console.Write(node.data + " ");

                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }
            }
        }

    }
}
/*
 * { 1, 2, 4, -1, -1, 5, -1, -1, 3, -1, 6, -1, -1 }
root call:
1
left call:
    2
    left call:
        4
        left call:
            null
        right call:
            null
    right call:
        5
        left call:
            null
        right call:
            null
right call:
    3
     left call:
        null:
     right call:
         6
         left call:
             null
         right call:
             null
 */