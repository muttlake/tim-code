/*

using AdventureWorks.Data;
using Xunit;

namespace AdventureWorks.Test
{
    public class AdoTest
    {
        [Fact]
        public void ReadConnected()
        {
            //arrange
            var ad = new AdoData(); 
            var expected = string.Empty;

            //act
            var actual = ad.ReadConnected();
            System.Console.WriteLine("String Length: " + actual.Length.ToString());

            //assert
            Assert.NotEqual(expected, actual);
        }

                [Fact]
        public void ReadDisconnected()
        {
            //arrange
            var ad = new AdoData(); 
            var expected = string.Empty;

            //act
            var actual = ad.ReadDisconnected();
            System.Console.WriteLine("String Length: " + actual.Length.ToString());

            //assert
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void ReadDisconnected2()
        {
            //arrange
            var ad = new AdoData(); 
            var expected = 0;

            //act
            var people = ad.ReadPeopleDisconnected();

            //assert
            Assert.NotEqual(expected, people.Count);
        }
    }
}

*/