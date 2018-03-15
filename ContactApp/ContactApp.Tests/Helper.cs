using Xunit;
using ContactApp.Library.Models;
using ContactApp.Library.Enums;
using ContactApp.Library;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp.Tests
{
    public class Helper
    {

        public static Person p = new Person();

        //Need Attributes (method attributes), do not exist in C++
        [Fact] // Allows XUnit to figure out special methods it needs to run
        public void Test_ContactHelper_Add()
        {
            //arrange
            var ch = new ContactHelper<Person>();

            //act
            var added = ch.Add(new Person());
            var actual = ch.Read();  //Testing Read and Add technically

            //Assert
            Assert.True(added);
        }

        [Fact]
        public void Test_ContactHelper_Add_Negative()
        {
            //arrange
            var ch = new ContactHelper<Person>();

            //act
            var added = ch.Add(new Person());
            var actual = ch.Read();  //Testing Read and Add technically

            //Assert
            Assert.False(!added);
        }

        [Fact] // Fact means it must happen
        public void Test_ContactHelper_Read()
        {
            //arrange
            var ch = new ContactHelper<Person>();
            var expected = 0;

            //act
            var actual = ch.Read();

            var newList = new List<Person>();
            //assert
            Assert.True(actual.GetType() == typeof(List<Person>));
            Assert.NotNull(actual);
            Assert.True(actual.Count >= expected);
        }


        [Fact]
        // [Theory] // Theory Means you expect it to happen
        // [InlineData(typeof(Person))]  // Theory means you use some extra InlineData
        public void Test_ContactHelper_AddPerson()
        {
            var ch = new ContactHelper<Person>();
            var expected = new Name();
            ch.Add(p);  // creates an instant of a person
            var actual = ch.Read().Last(); // Need System.Linq to get Last()
            
            Assert.True(expected.First == actual.Name.First);
            Assert.True(expected.Last == actual.Name.Last);
        }
    }
}