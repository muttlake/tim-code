using System;
using System.Collections.Generic;
using PizzaStore.Library.Interfaces;


namespace PizzaStore.Library
{
    public class PizzaHelper<T>  where T : IPizzaHas
    {
        private ICollection<T> _container = new HashSet<T>();
        private int _max = 0;

        public bool Add(T t)
        {
            if(_container.Count < _max)
            {
                _container.Add(t);
                return true;
            }
            else
            {
                Console.WriteLine("Arrived to max.");
                return false;
            }
        }

        public ICollection<T> get()
        {
            return _container;
        }

        public void set(ICollection<T> new_container)
        {
            _container = new_container;
        }

    }
}