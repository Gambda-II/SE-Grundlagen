namespace ClassCalculator
{
    public class Circle
    {
        public decimal Radius = 0.0m;
        public Circle(decimal radius)
        {
            Radius = radius;
        }

        public static decimal CalculatePI()
        {
            decimal doublePi = 0.0m;

            for (decimal i = 1.0m; i < 1000000; i++)
            {
                doublePi += 6 / (i * i);
            }

            return (decimal) Math.Sqrt((double)doublePi);
        }

        public decimal CalculateDiameter()
        {
            return 2 * Radius;
        }

        public decimal CalculateCircumference()
        {
            //Mathf floating points in single precision float
            return (decimal)MathF.Tau * Radius;
        }

        public decimal CalculateArea()
        {
            // Radius * Radius in double , float --> Math.Pow(Radius,2) , Mathf.Pow(Radius,2)
            //Math floating points in double precision double
            return Convert.ToDecimal(Math.PI) * Radius * Radius;
        }
    }
}
