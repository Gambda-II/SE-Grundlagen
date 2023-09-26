using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ClassCalculator
{
    public class Rectangle
    {
        public decimal Length = 0.0m, Width = 0.0m;

        public Rectangle(decimal length, decimal width)
        {
            Length = length;
            Width = width;
        }

        // so schreibt man circumference
        public decimal CalculateCircumference()
        {
            return 2 * (Length + Width);
        }

        public decimal CalculateArea()
        {
            return Length * Width;
        }

    }
}
