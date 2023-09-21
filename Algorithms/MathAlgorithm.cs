
namespace Algorithms;
public static class MathAlgorithm
{
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

    public static int FactorialFor(int n)
    {
        if (n < 0)
            return -1;

        var k = 1;
        for (int i = 1;i <= n;i++)
        {
            k *= i;
        }
        return k;
    }
}

