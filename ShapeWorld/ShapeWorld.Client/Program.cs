using System;
using System.Collections.Generic;
using System.Linq;
using ShapeWorld.Library;

namespace ShapeWorld.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithRectangle();
            PlayWithShapes();
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

            //Jagged arrays: Arrays of arrays
            Shape[][] arrShapes5 = new Shape[2][];

            var arrayShapes6 = new Shape[][] {new Rectangle[2], new Square[3] 
            {new Rectangle() as Square, new Rectangle() as Square, new Rectangle() as Square}};

            var item3 = arrayShapes6[0][0];
            arrayShapes6[1][0] = item3;

            // List

            List<Shape> lsShapes1 = new List<Shape>();

            var lsShapes2 = new List<Shape> { new Rectangle(), new Square(), new Triangle() };
            var item4 = lsShapes2[1];
            var item5 = lsShapes2.ElementAt(2);

            lsShapes2.Add(item4);

            //lsShapes2[10] = item5;  //this will not throw error, will put null values at indexes 4 through 9 
                                    // probably use add instead of bracket index
            lsShapes2[2] = item5;
            lsShapes2.Add(item4); // will put it at index 11, it will probably leave empty hole

            // Dictionary
            Dictionary<string, List<Shape>> diShapes1 = new Dictionary<string, List<Shape>>();

            var diShapes2 = new Dictionary<string, List<Shape>>()
            {
                {"a", new List<Shape>()}, // index 0
                {"b", new List<Shape>()}, // index 1 //From dictionary standpoint it needs to be a shape because it is specified as List<Shape> value
                {"c", new List<Shape>() {new Rectangle(), new Triangle()}} // index 2

            };

            var item6 = diShapes2["a"]; // get back entire list
            var item7 = diShapes2.Keys.ElementAt(2); //internally keys are also indexed, should get value at index 2

            //diShapes2.Add("b", item6); // you would get error because key b already exists
            diShapes2["b"] = diShapes1[item7]; // you would not get an error because key b's value will be updated

            // if (diShapes1.ContainsKey("b"))  // This is what it is doing behind the scenes
            // {
            //     return false;
            // }

        }
    }
}
