using System;

namespace BoxesProject
{
    public class AVLTree
    {
        public Node root;
        public AVLTree()
        {
            root = null;
        }

        private int Height(Node node)
        {
            return node == null ? 0 : node.Height;

        }

        private int BalanceFactor(Node node)
        {
            return node == null ? 0 : Height(node.Left) - Height(node.Right);
        }

        private Node LeftRotate(Node node)
        {
            Node newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            newRoot.Height = 1 + Math.Max(Height(newRoot.Left), Height(newRoot.Right));

            return newRoot;
        }

        private Node RightRotate(Node node)
        {
            Node newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            newRoot.Height = 1 + Math.Max(Height(newRoot.Left), Height(newRoot.Right));

            return newRoot;
        }

        public void Insert(Box newBox)
        {
            root = Insert(root, newBox);
        }

        private Node Insert(Node node, Box newBox)
        {
            if (node == null)
            {
                //In case no other node at all
                return new Node(newBox);
            }

            if (newBox.X < node.MyX)
            {
                node.Left = Insert(node.Left, newBox);
            }

            else if (newBox.X > node.MyX)
            {
                node.Right = Insert(node.Right, newBox);
            }
            else
            {
                // Possibliy here is duplicated we will check that now
                Console.WriteLine("Entered Duplicated");
                if (node.Box.Y == newBox.Y)
                {
                    node.Box.Quantity += newBox.Quantity;
                    if (node.Box.MaxQuantity < node.Box.Quantity)
                    {
                        //Here we will show a dialog content box telling the user
                        //we reached the limit of the max Quantity box of this one and we will just
                        //update the quantity to the maxium
                        node.Box.Quantity = node.Box.MaxQuantity;
                    }
                } 
                else {
                    node.InsertBox(newBox);

                }
                Console.WriteLine($"MyX : {node.MyX} new box: {newBox.X}");
                Console.WriteLine($"Boxx: {node.Box}");
                return node; // Duplicate keys are not allowed in AVL tree
            }

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            int balance = BalanceFactor(node);

            // Left-Left case
            if (balance > 1 && newBox.X < node.Left.MyX)
            {
                return RightRotate(node);
            }

            // Right-Right case
            if (balance < -1 && newBox.X > node.Right.MyX)
            {
                return LeftRotate(node);
            }

            // Left-Right case
            if (balance > 1 && newBox.X > node.Left.MyX)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right-Left case
            if (balance < -1 && newBox.X < node.Right.MyX)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
            Console.WriteLine();
        }

        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.MyX + " ");
                InOrderTraversal(node.Right);
            }
        }
    }
}
