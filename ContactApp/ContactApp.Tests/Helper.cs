

namespace ContactApp.Tests
{
    public class Helper
    {
        public void Test_ContactHelper_Add()
        {
            //arrange
            var ch = new ContactHelper<Person>();
            var expected = 1;

            //act
            ch.Add(new Person());

            //Assert
            Assert.IsTrue(expected == ch.Size());
        }
    }
}