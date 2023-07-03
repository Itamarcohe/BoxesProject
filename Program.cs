using System;
using System.Diagnostics;
using System.IO;

namespace BoxesProject
{
    class Program
    {
        static void Main(string[] args)
         {
            Storage storage = new Storage(10);

            // Inserting boxes into the storage
            //  public Box(double x, double y, int quantity, int minQuantity, int maxQuantity)

            storage.AddBox(new Box(15.0, 25.0, 4, 5, 20));
            storage.AddBox(new Box(11.0, 20.0, 8, 5, 20));
            storage.AddBox(new Box(11.0, 20.0, 3, 5, 20));
            storage.AddBox(new Box(8.0, 15.0, 7, 5, 20));
            storage.AddBox(new Box(15.0, 28.0, 7, 5, 20));
            storage.AddBox(new Box(15.0, 30, 8, 5, 20));
            storage.AddBox(new Box(15.0, 21, 7, 5, 20));
            storage.AddBox(new Box(11.0, 22.0, 7, 5, 20));
            storage.AddBox(new Box(15.0, 258.0, 7, 5, 20));
            storage.AddBox(new Box(12.0, 34.0, 7, 5, 20));
            storage.AddBox(new Box(11.0, 22.0, 22, 5, 20));
            storage.AddBox(new Box(14.0, 27.0, 6, 5, 20));
            storage.AddBox(new Box(14.0, 44, 6, 5, 20));
            storage.AddBox(new Box(16.0, 29.0, 5, 5, 20));
            storage.AddBox(new Box(10.0, 20.0, 5, 5, 20));
            storage.AddBox(new Box(15.0, 30.0, 7, 5, 20));
            storage.AddBox(new Box(20.0, 40.0, 8, 5, 20));

            Box? box = storage.FindBestBoxMatch(13.6, 27.2);


            Console.WriteLine($"Found that box: {box}");

            Console.WriteLine("Hello New");

        }

    }
}
