namespace ClassCalculator
{
    public class Triangle
    {
        /*
        public decimal FirstSide = 0.0m, SecondSide = 0.0m, ThirdSide = 0.0m;
        public float Alpha = 0.0f, Beta = 0.0f, Gamma = 0.0f;
        public float AlphaRad = 0.0f, BetaRad = 0.0f, GammaRad = 0.0f;

        public decimal Base = 0.0m, Height = 0.0m;

        public Triangle(decimal baselength, decimal height, float alpha)
        {
            Base = baselength;
            Height = height;
            Alpha = MathF.Round(alpha,2);
            ThirdSide = Base;

            SecondSide = (decimal)((float)Height / MathF.Sin(Alpha / 360 * 2 * MathF.PI));
            decimal p = (decimal)((float)Height / MathF.Tan(Alpha / 360 * 2 * MathF.PI));
            decimal q = Base - p;
            FirstSide = (decimal)MathF.Sqrt((float)(Height * Height + q * q));

            Beta = MathF.Round(MathF.Atan((float)(Height / q)) / (2 * MathF.PI) * 360, 2);
            Gamma = MathF.Round(180f - Alpha - Beta,2);
        }

        public decimal CalculateCircumference()
        {
            return FirstSide+SecondSide+ThirdSide;
        }

        public decimal CalculateArea()
        {
            return .5m * Base * Height;
        }
        */

        public float FirstSide = 0.0f, SecondSide = 0.0f, ThirdSide = 0.0f;
        public float Circumference { get { return FirstSide + SecondSide + ThirdSide; } }
        public float Area { get { return .25f * MathF.Sqrt((FirstSide + SecondSide + ThirdSide) * (-FirstSide + SecondSide + ThirdSide) * (FirstSide - SecondSide + ThirdSide) * (FirstSide + SecondSide - ThirdSide)); ; } }
        public Triangle(float a, float b, float c)
        {
            FirstSide = a;
            SecondSide = b;
            ThirdSide = c;
        }

    }
}
