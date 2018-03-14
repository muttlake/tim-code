

namespace ShapeWorld.Library
{
    public class Triangle : Shape
    {

        
        public double Base { get; set; }
        public double Height { get; set; }
        public Triangle(): base(3)
        {
            Edges = 3;
        }

        public override double Volume()
        {
            return -1;
        }
        
        public new int Edges { get; set; }  //triangle will use these Edges




        public override double Perimeter()
        {
            return 20;
        }

        public override double Area()
        {
            return Base * Height / 2;
        }


    }
}