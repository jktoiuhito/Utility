using NUnit.Framework;

namespace Utility.UnitTests
{
    public class Tests
    {
        [DatapointSource]
        public static readonly int[] ints = new[] { -1, 0, 1 };

        [Theory]
        public void Test1([Values(true)]bool tru, int number)
        {
            var val = number == 0;

            Assert.AreEqual(tru, val);
        }
    }
}