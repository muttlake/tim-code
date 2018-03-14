
namespace ShapeWorld.Library
{
    public class Square: Rectangle
    {

        public new int Edges { get; set; }
        //Square is sharing Rectangle Constructor right now
        private double _length;

        public override double Length
        {
            get
            {
                return _length;
            }
            set 
            {
                _length = value;
            }
        }

        public override double Width
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        // We did not actually have to write this
        public Square(): base()  
        {
            
        }

        public override double Area()  // you can override the overrides
        {
            return 1;
        }
    }
}

