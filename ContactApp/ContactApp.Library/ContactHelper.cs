
using System;
using System.Collections.Generic;
using ContactApp.Library.Interfaces;
using ContactApp.Library.Models;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ContactApp.Library
{
    //public class ContactHelper<T> where T : IContact  //Right not Contact list will only have Persons
    public class ContactHelper<T> where T : IContact, new()  //Right not Contact list will only have Persons
    {                                                      //but could include other things to make contacts of like Companies
        private static List<T> _container = new List<T>();  // container should be static so always same container 
                                                           // even with different instances of ContactHelper

        public bool Add(T t)
        {
            try
            {
                _container.Add(t);
                return true;
            }
            catch (ArgumentNullException e)
            {
                _container.Add(new T());
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

        public List<T> Read()
        {
            return _container;
        }

        public void Delete()
        {
            _container.Clear();
        }

        // public void Update(T t)
        // {
        //     int foundIndex = _container.FindIndex(0, 1, a => a.Name == t.Name);
        //     _container[foundIndex] = t;
        // }

        public int Size()
        {
            return _container.Count;
        }


        // public void WriteToText()
        // {
        //     var path = @"C:\Revature\contact.txt";
        //     using (var f = File.Open(path, FileMode.OpenOrCreate))
        //     {
        //         f.Write(_container.ToString());

        //         f.Close();   
        //     }
        // }

        public void WriteToText()
        {
            var path = @"C:\Revature\tim.code\ContactApp\contact.txt";
            File.WriteAllText(path, _container.FirstOrDefault().ToString());
        }


        public void WriteToXml()
        {
            var path = @"C:\Revature\tim.code\ContactApp\contact.xml";
            var p = _container.FirstOrDefault();

            using (var s = new StreamWriter(path))
            {
                var xml = new XmlSerializer(typeof(Person));
                xml.Serialize(s, p);
            }  // you are saving yourself from writing s.dispose() by using using 

            //xml.Serialize(s, p);
        }

        public Person ReadPersonFromTxt()
        {
            var path = @"C:\Revature\tim.code\ContactApp\contact.txt";
            var p = new Person();

            using (var s = new StreamReader(path))
            {
                var text = s.ReadLine();
                var first = text.Split()[1];
                var last = text.Split()[2];

                var n = new Name(first, last);
                p.Name = n;
            }
            return p;
        }


        public Person ReadFromXml()
        {
            var path = @"C:\Revature\tim.code\ContactApp\contact.xml";
            Person person;

            using(var s = new StreamReader(path))
            {
                var xml = new XmlSerializer(typeof(Person));
                person = (Person) xml.Deserialize(s);
                //person = xml.Deserialize(s) as Person;
            }

            return person;
        }

        public void Update(T t) //Assume you cannot change name for now
        {
            var a = _container.First(p => p.PId == t.PId); //Method as Parameter in another Method
            //We are passing it a predicate, predicates are usually small
            //In Collection this is called a predicate: p.PId == t.PId
            //_container.First(
            //var a = _container.Where(p => p.PId == t.PId).First(); //could also have done this
            // foreach (var item in _container)  // what this does _container.First(p => p.PId == t.PId);
            // {
            //     if (item.PId == t.PId)
            //     {
            //         return item;
            //     }
            // }
        }

        //Delegate is an abstraction for functions and actions

        //Functions
        Func<string> hello = () => { return "hello";}; //Func<returnType>
        Action<string> hello2 = (string h) => {Console.WriteLine(h);}; // Action<parameter>

        public delegate string Hello5();  //like Funct<string>, but now it is a type
        public delegate void Hello6(string s); //like Action<>, delegate like shorthand for Action<string>
                         

        public string Hello3()
        {
            return "hello3";
        }

        public string Hello4(Hello5 fs) // This is how first is written
                                                // Wants method that takes nothing and returns a string
        {
            return fs();
        }

        // public void Delete()
        // {

        // }

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