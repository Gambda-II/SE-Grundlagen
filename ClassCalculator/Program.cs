namespace ClassCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator.AddTwoNumbers(1,5));
            Console.WriteLine(Calculator.SubtractTwoNumbers(1, 5));
            Console.WriteLine(Calculator.Factorial(5));
            Calculator.DisplayPrimes();
        }
    }
}