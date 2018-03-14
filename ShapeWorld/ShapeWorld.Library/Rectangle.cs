

namespace ShapeWorld.Library
{
    public class Rectangle : Shape
    {

        public new int Edges { get; set; }  //square will use these Edges

        public virtual double Length { get; set; }
        public virtual double Width { get; set; }

        public Rectangle(): base(4)
        {
            //Edges = 4;
        }

        public override double Area()
        {
            return Length * Width;
        }

        public override double Volume()
        {
            return -1;
        }

        public override double Perimeter()
        {
            return 2 * (Length + Width);
        }
    }
}