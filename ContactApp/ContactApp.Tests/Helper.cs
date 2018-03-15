using Xunit;
using ContactApp.Library.Models;
using ContactApp.Library.Enums;
using ContactApp.Library;
using System.Collections.Generic;

namespace ContactApp.Tests
{
    public class Helper
    {

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

        [Fact]
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

    }
}