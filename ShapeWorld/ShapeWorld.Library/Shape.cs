
namespace ShapeWorld.Library
{
    public abstract class Shape : IShape, IForm
    {
        //public int Edges { get; protected set; }
        public int Edges { get; }

        // private Shape()
        // {
        //     Edges = 10;
        // }

        public Shape(int e)  //cannot access this constructor because class is abstract, but can access from children
        {
            Edges = e;
        }

        // public abstract double Area();
        // public abstract double Volume();
        // public abstract double Perimeter();

        // int IForm.Area()
        // {
        //     throw new System.NotImplementedException();
        // }

        public virtual double Area()
        {
            return 0;
        }

        int IForm.Area()  // don't need public because it is qualified from interface
        {
            return 901;
        }

        public abstract double Volume();  //Shape's children must override volume

        public virtual double Perimeter()
        {
            return 10;
        }
    }
}