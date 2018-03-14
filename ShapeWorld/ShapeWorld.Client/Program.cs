using System;
using ShapeWorld.Library;

namespace ShapeWorld.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithRectangle();
        }

        static void PlayWithRectangle()
        {
            //var r2;  //means absolutely nothing, var grabs type to right of assignment
            var r = new Rectangle();
            //Rectangle r1 = new Rectangle(); // we will use var not Rectangle
            var sq = new Square();
            //var s = new Shape();

            Shape s1 = r;  //We want shape to be available but not construct an empty Shape
            Shape s2 = sq;

            //r.Edges = 10;

            Console.WriteLine(s1.Edges);
            Console.WriteLine(r.Edges);
        }
    }
}
