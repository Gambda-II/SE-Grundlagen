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
        public void TestLocateCard_DuplicateQueryInCards()
        {
            int[] cards = { 0, 1, 2, 3, 21, 21, 21, 21, 21, 21, 21, 42, 69, 420 };
            int query = 21;

            Assert.Equal(4, CardAlgorithm.FindCardLocation(cards, query));
        }

        [Fact]
        public void TestLocateCard_CardsIsEmpty()
        {
            int[] cards = { };
            int query = 69;

            Assert.Equal(-1, CardAlgorithm.FindCardLocation(cards, query));
        }
    }


    public class UnitTest2
    {
        [Fact]
        public void TestLocateCard_DefaultCaseBinarySearch()
        {
            int[] cards = { 1, 2, 3, 4, 5 };
            int query = 3;

            Assert.Equal(2, CardAlgorithm.FindCardLocationBinarySearch(cards, query));
        }

        [Fact]
        public void TestLocateCard_QueryNotInCardsBinarySearch()
        {
            int[] cards = { -1, 1 };
            int query = 0;

            Assert.Equal(-1, CardAlgorithm.FindCardLocationBinarySearch(cards, query));
        }

        [Fact]
        public void TestLocateCard_DuplicateQueryInCardsBinarySearch()
        {
            int[] cards = { 0, 1, 2, 3, 21, 21, 21, 21, 21, 21, 21, 42, 69, 420 };
            int query = 21;

            Assert.Equal(4, CardAlgorithm.FindCardLocationBinarySearch(cards, query));
        }

        [Fact]
        public void TestLocateCard_CardsIsEmptyBinarySearch()
        {
            int[] cards = { };
            int query = 69;

            Assert.Equal(-1, CardAlgorithm.FindCardLocationBinarySearch(cards, query));
        }
    }
    public class UnitTest3
    {
        [Fact]
        public void TestLocateCard_DefaultCaseBinarySearch()
        {
            int[] cards = { 1, 2, 3, 4, 5 };
            int query = 3;

            Assert.Equal(2, CardAlgorithm.BinaryFindCardLocation(cards, query));
        }

        [Fact]
        public void TestLocateCard_QueryNotInCardsBinarySearch()
        {
            int[] cards = { -1, 1 };
            int query = 0;

            Assert.Equal(-1, CardAlgorithm.BinaryFindCardLocation(cards, query));
        }

        [Fact]
        public void TestLocateCard_DuplicateQueryInCardsBinarySearch()
        {
            int[] cards = { 0, 1, 2, 3, 21, 21, 21, 21, 21, 21, 21, 42, 69, 420 };
            int query = 21;

            Assert.Equal(4, CardAlgorithm.BinaryFindCardLocation(cards, query));
        }

        [Fact]
        public void TestLocateCard_CardsIsEmptyBinarySearch()
        {
            int[] cards = { };
            int query = 69;

            Assert.Equal(-1, CardAlgorithm.BinaryFindCardLocation(cards, query));
        }
    }

    
}