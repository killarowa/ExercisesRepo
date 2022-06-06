using NUnit.Framework;

namespace Collections.Tests
{
    public class CollectionTests
    {
        [Test]
        public void Test_EmptyConstructor()
        {
            //Arrange
            var nums = new Collection<int>();
            //Act
            //Assert
            Assert.That(nums.Count, Is.EqualTo(0));
            Assert.That(nums.Capacity, Is.EqualTo(16));
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
           
            var nums = new Collection<int>(5);
            
            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>();

            Assert.That(nums.Count == 2, "Count property");
            Assert.That(nums.Capacity, Is.EqualTo(16), "Capacity property");
            Assert.That(nums.ToString() == "[5, 6]");
        }

        [Test]
        public void Test_Collection_Add()
        {

            var nums = new Collection<int>(5);

            nums.Add(6);

            Assert.That(nums.ToString(), Is.EqualTo("[5, 6]"));
        }

        [TestCase("Peter", 0, "Peter")]
        public void Test_Collection_GetByValidIndex(
            string data, int index, string expectedValue)
        {
            var nums = new Collection<string>(data);

            var actual = nums[index];

            Assert.That(actual, Is.EqualTo(expectedValue));
        }




















    }
}