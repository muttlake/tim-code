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

            var t = new Triangle();
            t.Base = 5;
            t.Height = 10;

            Shape s1 = r;  //We want shape to be available but not construct an empty Shape
            Shape s2 = sq;
            Shape s3 = t;

            sq.Length = 10;
            sq.Width = 11;

            //r.Edges = 10;

            Console.WriteLine(s2.Edges);
            Console.WriteLine(sq.Edges);

            Console.WriteLine(s2.Area());
            Console.WriteLine(sq.Area());

            Console.WriteLine(s3.Area());
            Console.WriteLine(t.Area());

            Console.WriteLine(s3.Area());

            Console.WriteLine(((IForm) r).Area());

        }

        static void PlayWithShapes()
        {
            Shape[] arrShapes1 = new Shape[10]; // These are 1D arrays
            var arrShapes2 = new Shape[] {new Rectangle(), new Square(), new Triangle()}; // array of shapes of 3

            //var item = arrShapes1[10]; // THis is not a compile error, this is a runtime error
            var item = arrShapes1[9];

            arrShapes2[0] = item;

            // multi-dimensional arrays
            Shape [,] arrShapes3 = new Shape[2,2];
            var arrShapes4 = new Shape[,] {
                {new Rectangle(), new Square()},
                {new Triangle(), new Triangle()}};
            
            //To do 3d arrays add commas, Each comma is an additional dimension

            var item2 = arrShapes4[1,0];
            arrShapes4[1,1] = item2;


            





        }
    }
}
