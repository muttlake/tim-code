
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public class OrderHelper<T> where T : new()
    {
        private List<T> _container;
        private int _minNumber;

        public bool Add(T t)
        {
            _container.Add(t);
            return true;
        }

        public OrderHelper()
        {
            _minNumber = 1;
            _container = new List<T>();
        }

        public bool IsValid()
        {
            return _container.Count > _minNumber;
        }

        public List<T> Read()
        {
            return _container;
        }
    }
}