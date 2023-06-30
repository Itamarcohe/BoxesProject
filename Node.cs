using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesProject
{
    public class Node
    {
        public Box Box { get; set; }
        public AVLTree BoxTree { get; set; } // AVLTree to store boxes with the same X value
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Height { get; set; }

        public Node(Box box)
        {
            Box = box;
            BoxTree = new AVLTree();
            Height = 1;
        }

        public Node(Box box, bool sortByX = true)
        {
            Box = box;
            BoxTree = new AVLTree(sortByX);
            Height = 1;
        }

    }
}
