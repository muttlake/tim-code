
using PizzaStore.MVC.Models;
using Xunit;

namespace PizzaStore.Test
{
    public class DemoTest
    {
        public void TestUp()
        {
            var sut = new PizzaViewModel();
            
            Assert.NotNull(sut.Crusts);
        }
    }
}