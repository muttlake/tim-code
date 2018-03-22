
using System;
using System.Collections.Generic;

namespace PizzaStore.Library
{
    public class PizzaHelper<T> where T: new()
    {
        private List<T> _container = new List<T>();
        private int _maxNumber;

        public PizzaHelper()
        {
            _maxNumber = 1;
        }

        public PizzaHelper(int max)
        {
            _maxNumber = max;
        }

        public bool Add(T t)
        {
            if (_container.Count < _maxNumber)
            {
                _container.Add(t);
                return true;
            }
            Console.WriteLine("Cannot add any more to PizzaHelper List, Reached maximum.");
            return true;
        }

        public List<T> Read()
        {
            return _container;
        }
    }
}