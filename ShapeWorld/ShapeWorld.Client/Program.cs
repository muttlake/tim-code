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
            var r = new Rectangle();
            var s = r;

            r.Edges = 10;

            Console.WriteLine(s.Edges);
        }
    }
}
