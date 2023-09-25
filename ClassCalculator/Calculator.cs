namespace ClassCalculator
{
    public class Calculator
    {
        public static int AddTwoNumbers(int firstSummand, int secondSummand)
        {
            return firstSummand + secondSummand;
        }
        public static decimal AddTwoNumbers(decimal firstSummand, decimal secondSummand)
        {
            return firstSummand + secondSummand;
        }


        public static int SubtractTwoNumbers(int minuend, int subtrahend)
        {
            return minuend - subtrahend;
        }

        public static int Factorial(int n)
        {
            if (n < 0)
                return -1;
            else if (n == 0)
                return 1;
            else
            {
                int z = n;
                while (n > 1)
                {
                    n--;
                    z *= n;
                }
                return z;
            }
        }
    public static bool isPrime(int number)
    {
            bool isChecked = true;
        if (number < 2)
            return false;
        if (number == 2 || number == 3)
            return true;
        if (number % 2 == 0)
            return false;

        for (int k = 3; k <= Math.Sqrt(number); k = k + 2)
        {
            if (number % k == 0)
                return false;
        }

        return isChecked;
    }
    public static void DisplayPrimes()
    {
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine($"Is {i} a prime number? {isPrime(i)}");
        }
    }
    }


}
