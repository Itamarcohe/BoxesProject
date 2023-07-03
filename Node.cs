using System;
using System.Collections.Generic;

namespace BoxesProject
{
    public class Node
    {
        public Box Box { get; set; }
        public double MyX { get; set; } // X value of the node
        public List<Box> SameXList;
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Height { get; set; }

        public Node(Box box)
        {
            Box = box;
            MyX = box.X; // Store the X value in MyX property
            //SameXSortByY = null; // Initialize to null, it will be created only if needed
            SameXList = null; 
            Height = 1;
        }

        private void EnsureSameXListExists(Box newBox)
        {
            if (SameXList == null)
            {
                SameXList = new List<Box>();
            }

            int index = SameXList.BinarySearch(newBox, new BoxYComparer());
            if (index >= 0)
            {
                // Box with the same Y coordinate already exists
                Box existingBox = SameXList[index];
                existingBox.Quantity += newBox.Quantity;
            }
            else
            {
                // Convert the binary search result to the index where the newBox should be inserted
                int insertIndex = ~index;
                SameXList.Insert(insertIndex, newBox);
            }
        }

        private class BoxYComparer : IComparer<Box>
        {
            public int Compare(Box box1, Box box2)
            {
                return box1.Y.CompareTo(box2.Y);
            }
        }

        private void InsertBoxWithSameX(Box newBox)
        {
            int compareResult = newBox.X.CompareTo(MyX);

            if (compareResult == 0)
            {
                // This box has the same X as the current node
                EnsureSameXListExists(newBox); // Ensure SameXList exists before adding the box
            }
            else if (compareResult < 0)
            {
                if (Left == null)
                {
                    Left = new Node(newBox);
                }
                else
                {
                    Left.InsertBoxWithSameX(newBox);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node(newBox);
                }
                else
                {
                    Right.InsertBoxWithSameX(newBox);
                }
            }

            // Update the height of the current node
            Height = 1 + Math.Max(HeightOfNode(Left), HeightOfNode(Right));

            // Perform balancing after inserting the new box
            int balance = HeightOfNode(Left) - HeightOfNode(Right);

            if (balance > 1)
            {
                // Left-left case
                if (newBox.X.CompareTo(Left.MyX) < 0)
                {
                    RightRotate();
                }
                // Left-right case
                else
                {
                    Left.LeftRotate();
                    RightRotate();
                }
            }
            else if (balance < -1)
            {
                // Right-right case
                if (newBox.X.CompareTo(Right.MyX) > 0)
                {
                    LeftRotate();
                }
                // Right-left case
                else
                {
                    Right.RightRotate();
                    LeftRotate();
                }
            }
        }

        private int HeightOfNode(Node node)
        {
            return node?.Height ?? 0;
        }

        private void RightRotate()
        {
            Node y = Left;
            Left = y.Right;
            y.Right = this;

            // Update heights
            Height = 1 + Math.Max(HeightOfNode(Left), HeightOfNode(Right));
            y.Height = 1 + Math.Max(Height,
                            HeightOfNode(Right));
        }

        private void LeftRotate()
        {
            Node x = Right;
            Right = x.Left;
            x.Left = this;

            // Update heights
            Height = 1 + Math.Max(HeightOfNode(Left), HeightOfNode(Right));
            x.Height = 1 + Math.Max(HeightOfNode(x.Left), HeightOfNode(x.Right));
        }

        // Rest of the code after RightRotate

        public void InsertBox(Box newBox)
        {
            int compareResult = newBox.X.CompareTo(MyX);

            if (compareResult == 0)
            {
                InsertBoxWithSameX(newBox);
            }
            else if (compareResult < 0)
            {
                if (Left == null)
                {
                    Left = new Node(newBox);
                }
                else
                {
                    Left.InsertBox(newBox);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node(newBox);
                }
                else
                {
                    Right.InsertBox(newBox);
                }
            }

            // Update the height of the current node
            Height = 1 + Math.Max(HeightOfNode(Left), HeightOfNode(Right));

            // Perform balancing after inserting the new box
            int balance = HeightOfNode(Left) - HeightOfNode(Right);

            if (balance > 1)
            {
                // Left-left case
                if (newBox.X.CompareTo(Left.MyX) < 0)
                {
                    RightRotate();
                }
                // Left-right case
                else
                {
                    Left.LeftRotate();
                    RightRotate();
                }
            }
            else if (balance < -1)
            {
                // Right-right case
                if (newBox.X.CompareTo(Right.MyX) > 0)
                {
                    LeftRotate();
                }
                // Right-left case
                else
                {
                    Right.RightRotate();
                    LeftRotate();
                }
            }
        }
    }
}
