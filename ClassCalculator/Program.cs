namespace ClassCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Calculator.AddTwoNumbers(1,5));
            //Console.WriteLine(Calculator.SubtractTwoNumbers(1, 5));
            //Console.WriteLine(Calculator.Factorial(5));

            Circle circle = new Circle(123.456m);
            Console.WriteLine($"Circle\n" +
                $"Radius: \t{circle.Radius}\n" +
                $"Diameter: \t{circle.CalculateDiameter()}\n" +
                $"Circumference: \t{circle.CalculateCircumference()}\n" +
                $"Area: \t\t{circle.CalculateArea()}\n");

            Rectangle rectangle = new Rectangle(123.4m,567.89m);
            Console.WriteLine($"Rectangle\n" +
                $"Length: \t{rectangle.Length}\n" +
                $"Width: \t\t{rectangle.Width}\n" +
                $"Circumference: \t{rectangle.CalculateCircumference()}\n" +
                $"Area: \t\t{rectangle.CalculateArea()}\n");


            Triangle triangle = new Triangle(3.0f,4.0f,5.0f);
            Console.WriteLine($"Triangle\n" +
                $"Sidelengths: \t " +
                $"a = {triangle.FirstSide}, b = {triangle.SecondSide}, c = {triangle.ThirdSide}\n" +
                $"Circumference: \t {triangle.Circumference}\n" +
                $"Area: \t\t {triangle.Area}");
        }
    }
}