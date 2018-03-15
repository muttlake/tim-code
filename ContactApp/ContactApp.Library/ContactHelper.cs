
using System;
using System.Collections.Generic;
using ContactApp.Library.Models;

namespace ContactApp.Library
{
    //public class ContactHelper<T> where T : IContact  //Right not Contact list will only have Persons
    public class ContactHelper<T> where T : Person, new()  //Right not Contact list will only have Persons
    {                                                      //but could include other things to make contacts of like Companies
        private List<T> container = new List<T>();

        public bool Add(T t)
        {
            try
            {
                container.Add(t);
                return true;
            }
            catch (ArgumentNullException e)
            {
                container.Add(new T());
                return true;
                throw new Exception("null", e);
            }
            catch (Exception e)   // We are doing exception handling but not really
            {
                
                return false;
                //throw;       // You technically never want to throw
                throw new Exception("my bad, i forgot about null", e);  //pass a message in custom Exception
                //throw e;  // you want to throw e so you get stack trace of actual exception
            }
            finally  // Finally Always Runs
            {
                GC.Collect();
            }
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        // public void Add(T t) //Add an Item to end of list
        // {
        //     container.Add(t);
        // }
        // public void Update(T t, int index)  //Update Item at given index
        // {
        //     container[index] = t;
        // }

        // public void Update(T t)
        // {
        //     int index = container.FindIndex(0, 1, a => a.Name == t.Name);
        //     container[index] = t;
        // }

        // public void Delete(int index)  // Delete itm at index
        // {
        //     container.RemoveAt(index);
        // }
        
        // public void Delete()  // Delete Item at end of list
        // {
        //     int lastIndex = container.Count - 1;
        //     container.RemoveAt(lastIndex);
        // }


    }
}