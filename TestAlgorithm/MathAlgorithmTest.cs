using Algorithms;

namespace TestAlgorithms
{
    public class MathAlgorithmTest
    {
        [Fact]
        public void TestFactorial_DefaultInput()
        {
            int inputNumber = 5;

            Assert.Equal(120, MathAlgorithm.Factorial(inputNumber));
        }

        [Fact]
        public void TestFactorial_NegativeInput()
        {
            int inputNumber = -5;

            Assert.Equal(-1, MathAlgorithm.Factorial(inputNumber));
        }

        [Fact]
        public void TestFactorial_ZeroInput()
        {
            int inputNumber = 0;

            Assert.Equal(1, MathAlgorithm.Factorial(inputNumber));
        }

        [Fact]
        public void TestFactorialFor_DefaultInput()
        {
            int inputNumber = 5;

            Assert.Equal(120, MathAlgorithm.FactorialFor(inputNumber));
        }

        [Fact]
        public void TestFactorialFor_NegativeInput()
        {
            int inputNumber = -5;

            Assert.Equal(-1, MathAlgorithm.FactorialFor(inputNumber));
        }

        [Fact]
        public void TestFactorialFor_ZeroInput()
        {
            int inputNumber = 0;

            Assert.Equal(1, MathAlgorithm.FactorialFor(inputNumber));
        }

    }
}