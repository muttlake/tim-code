

namespace PizzaStore.Library
{
    public class PizzaHelper<T>  where T : Pizza
    {
        private ICollection<T> _container = new ICollection<T>();
        private int _max = 0;

        public bool Add(T t)
        {
            if(_container.Count < _max)
                _container.Add(t);
            else
                Console.WriteLine("Arrived to max.");
        }

        public ICollection<T> Read()
        {
            return _container.ToList();
        }

    }
}