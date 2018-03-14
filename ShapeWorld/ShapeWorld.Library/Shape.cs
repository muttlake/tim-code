
namespace ShapeWorld.Library
{
    public abstract class Shape 
    {
        //public int Edges { get; protected set; }
        public int Edges { get;}

        private Shape()
        {
            Edges = 10;
        }

        public Shape(int e)  //cannot access this constructor because class is abstract, but can access from children
        {
            Edges = e;
        }

        public virtual double Area()
        {
            return 0;
        }

        public abstract double Volume();  //Shape's children must override volume

        public virtual double Perimeter()
        {
            return 10;
        }
    }
}