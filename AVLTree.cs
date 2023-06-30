using System;
using System.Collections.Generic;

namespace BoxesProject
{
    public class AVLTree
    {
        public Node root;
        private bool sortByX;

        public AVLTree(bool sortByX = true)
        {
            this.sortByX = sortByX;
        }


        public void Insert(Box box)
        {
            root = Insert(root, box);
        }

        private Node Insert(Node node, Box box)
        {
            if (node == null)
                return new Node(box, sortByX);

            if (sortByX && box.X < node.Box.X)
            {
                node.Left = Insert(node.Left, box);
            }
            else if (!sortByX && box.Y < node.Box.Y)
            {
                node.Left = Insert(node.Left, box);
            }
            else if (sortByX && box.X > node.Box.X)
            {
                node.Right = Insert(node.Right, box);
            }
            else if (!sortByX && box.Y > node.Box.Y)
            {
                node.Right = Insert(node.Right, box);
            }
            else
            {
                // Box with the same X or Y value, insert it into the BoxTree
                node.BoxTree.Insert(box);
                return node;
            }

            // Update the height of the node
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            // Perform AVL rotations if necessary
            int balance = GetBalance(node);

            // Left-Left case
            if (balance > 1 && (sortByX ? box.X : box.Y) < (sortByX ? node.Left.Box.X : node.Left.Box.Y))
            {
                return RightRotate(node);
            }

            // Right-Right case
            if (balance < -1 && (sortByX ? box.X : box.Y) > (sortByX ? node.Right.Box.X : node.Right.Box.Y))
            {
                return LeftRotate(node);
            }

            // Left-Right case
            if (balance > 1 && (sortByX ? box.X : box.Y) > (sortByX ? node.Left.Box.X : node.Left.Box.Y))
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right-Left case
            if (balance < -1 && (sortByX ? box.X : box.Y) < (sortByX ? node.Right.Box.X : node.Right.Box.Y))
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        public Box GetBestMatch(double requestedValue, double percentageDifference, bool sortByX)
        {
            Node targetNode = SearchClosest(root, requestedValue);

            if (targetNode == null)
                return null;

            double closestValue;
            if (sortByX)
            {
                closestValue = targetNode.Box.X;
            }
            else
            {
                closestValue = targetNode.BoxTree.FindClosestGreater(requestedValue);
            }

            if (closestValue != default(double))
            {
                double difference = Math.Abs(requestedValue - closestValue);
                double maxDifference = (percentageDifference / 100) * requestedValue;

                if (difference <= maxDifference)
                {
                    if (sortByX)
                    {
                        return targetNode.Box;
                    }
                    else
                    {
                        return targetNode.BoxTree.Search(closestValue);
                    }
                }
            }

            return null;
        }

        public Box Search(double value)
        {
            return Search(root, value);
        }

        private Box Search(Node node, double value)
        {
            if (node == null)
                return null;

            int comparisonResult;
            if (sortByX)
            {
                comparisonResult = value.CompareTo(node.Box.X);
            }
            else
            {
                comparisonResult = value.CompareTo(node.Box.Y);
            }

            if (comparisonResult == 0)
            {
                return node.Box;
            }
            else if (comparisonResult < 0)
            {
                return Search(node.Left, value);
            }
            else
            {
                return Search(node.Right, value);
            }
        }

        private Node SearchClosest(Node node, double value)
        {
            if (node == null)
                return null;

            if (value < (sortByX ? node.Box.X : node.Box.Y))
            {
                if (node.Left != null)
                    return SearchClosest(node.Left, value);
                else
                    return node;
            }
            else if (value > (sortByX ? node.Box.X : node.Box.Y))
            {
                if (node.Right != null)
                    return SearchClosest(node.Right, value);
                else
                    return node;
            }
            else
            {
                return node;
            }
        }


        public Box FindClosestBaseSize(double requestedSize, double percentageDifference)
        {
            return FindClosestBaseSize(root, requestedSize, percentageDifference);
        }

        private Box FindClosestBaseSize(Node node, double requestedSize, double percentageDifference)
        {
            if (node == null)
                return null;

            double baseSize = node.Box.X;
            double difference = Math.Abs(baseSize - requestedSize);
            double maxDifference = (percentageDifference / 100) * requestedSize;

            if (difference <= maxDifference)
            {
                // Found a base size within the acceptable difference range
                return node.Box;
            }
            else if (requestedSize < baseSize)
            {
                // Traverse left subtree
                return FindClosestBaseSize(node.Left, requestedSize, percentageDifference);
            }
            else
            {
                // Traverse right subtree
                return FindClosestBaseSize(node.Right, requestedSize, percentageDifference);
            }
        }

        private int Height(Node node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }

        private int GetBalance(Node node)
        {
            if (node == null)
                return 0;

            return Height(node.Left) - Height(node.Right);
        }

        private Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        private Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        public double FindClosestGreater(double value)
        {
            return FindClosestGreater(root, value, double.MaxValue);
        }

        private double FindClosestGreater(Node node, double value, double closest)
        {
            if (node == null)
                return closest;

            int comparisonResult;
            if (sortByX)
            {
                comparisonResult = value.CompareTo(node.Box.X);
            }
            else
            {
                comparisonResult = value.CompareTo(node.Box.Y);
            }

            if (comparisonResult == 0)
            {
                return node.Box.X;
            }
            else if (comparisonResult < 0)
            {
                return FindClosestGreater(node.Left, value, node.Box.X);
            }
            else
            {
                return FindClosestGreater(node.Right, value, closest);
            }
        }


    }
}
