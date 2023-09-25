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

        [Fact]
        public void TestPrime_TwoIsPrimeTest()
        {
            int inputNumber = 2;
            bool expected = true;
            Assert.Equal(expected,MathAlgorithm.isPrime(inputNumber));
        }

        [Fact]
        public void TestPrime_ThreeIsPrimeTest()
        {
            int inputNumber = 3;
            bool expected = true;
            Assert.Equal(expected, MathAlgorithm.isPrime(inputNumber));
        }

        [Fact]
        public void TestPrime_FourIsNotPrimeTest()
        {
            int inputNumber = 4;
            bool expected = false;
            Assert.Equal(expected, MathAlgorithm.isPrime(inputNumber));
        }

        [Fact]
        public void TestPrime_TwentyThreeIsPrimeTest()
        {
            int inputNumber = 23;
            bool expected = true;
            Assert.Equal(expected, MathAlgorithm.isPrime(inputNumber));
        }

        [Fact]
        public void TestPrime_997IsPrimeTest()
        {
            int inputNumber = 997;
            bool expected = true;
            Assert.Equal(expected, MathAlgorithm.isPrime(inputNumber));
        }

        [Fact]
        public void TestPrime_993IsNotPrimeTest()
        {
            int inputNumber = 993;
            bool expected = false;
            Assert.Equal(expected, MathAlgorithm.isPrime(inputNumber));
        }

        [Fact]
        public void TestPrime_100271IsPrimeTest()
        {
            int inputNumber = 100271;
            bool expected = true;
            Assert.Equal(expected, MathAlgorithm.isPrime(inputNumber));
        }

        [Fact]
        public void TestPrime_100269IsNotPrime()
        {
            int inputNumber = 100269;
            bool expected = false;
            Assert.Equal(expected, MathAlgorithm.isPrime(inputNumber));
        }
    }
}