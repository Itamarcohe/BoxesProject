using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesProject
{
    public class Box
    {
        public double X { get; } // Square base size
        public double Y { get; } // Height of the box
        public DateTime PurchaseDate { get; } // Date when the box was purchased

        public Box(double x, double y)
        {
            X = x;
            Y = y;
            PurchaseDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"X : {X} Y {Y} ";
        }
    }
}
