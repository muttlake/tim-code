using PizzaStore.Library;
using System;
using Xunit;

namespace PizzaStore.Test
{
    public class InventoryTest
    {
        [Fact]
        public void Test_EfData_CheckSauce()
        {
            //arrange
            EfData ef = new EfData();

            //act
            bool actual = ef.CheckSauce(1);
            bool expected = true;


            //assert
            Assert.Equal(actual, expected);
        }
    }
}
