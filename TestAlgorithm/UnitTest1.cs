using Algorithms;

namespace TestAlgorithms
{
    public class UnitTest1
    {
        [Fact]
        public void TestLocateCard_DefaultCase()
        {
            int[] cards = { 1, 2, 3, 4, 5 };
            int query = 3;

            Assert.Equal(2, CardAlgorithm.FindCardLocation(cards, query));
        }

        [Fact]
        public void TestLocateCard_QueryNotInCards()
        {
            int[] cards = { -1, 1 };
            int query = 0;

            Assert.Equal(-1, CardAlgorithm.FindCardLocation(cards, query));
        }

        [Fact]
        public void TestLocateCard_()
        {

        }
    }
}