namespace Übungen;

internal class ProblemeInMethodenAufteilen
{

    public static double CalculateMean(double[] values)
    {
        if (values.Length < 1)
        {
            return 0.0;
        }

        // calculate the sum, then return the mean value
        double sum = 0.0;
        int n = values.Length;
        for (int i = 0; i < n; i++)
        {
            sum += values[i];
        }
        return sum / n;
    }

    public static double CalculateVariance(double[] values)
    {
        if (values.Length < 1)
        {
            return 0.0;
        }

        double mu = CalculateMean(values);
        int n = values.Length;
        double sum = 0.0;
        for (int i = 0; i < n; i++)
        {
            values[i] -= mu;
            values[i] *= values[i];
            sum += values[i];
        }
        return sum / n;
    }
    public static double CalculateStandardDeviation(double[] values)
    {
        return Math.Sqrt(CalculateVariance(values));
    }

    public static void CreateVisuals(List<double[]> datasets)
    {
        double[] means = new double[datasets.Count];
        Console.Write("# of values:\t");
        for (int i = 0; i < datasets.Count; i++)
            Console.Write(datasets[i].Length + "\t");

        Console.Write("\n");

        Console.Write("Mean:\t\t");
        for (int i = 0; i < datasets.Count; i++)
        {
            means[i] = CalculateMean(datasets[i]);
            Console.Write(Math.Round(means[i], 4) + "\t");
        }

        Console.Write("\n");

        Console.Write("Std.Dev.:\t");
        for (int i = 0; i < datasets.Count; i++)
            Console.Write(Math.Round(CalculateStandardDeviation(datasets[i]), 4) + "\t");

        Console.Write("\n\n\t\t0---------+---------+---------+---------1\n");
        for (int i = 0; i < datasets.Count; i++)
        {
            Console.Write("Diagram " + (i+1) + ":\t");
            for (double k = 0; k <= means[i]*100; k += 2.5)
            {
                //Console.Write("*");
                Console.Write("■");
            }
            Console.Write("\n");
        }
    }


    public static double[] CreateFakeRandomData(int n = 100, int minValue = 0, int maxValue = 1)
    {
        Random rand = new Random();
        double[] data = new double[n];
        for (int i = 0; i < n; i++)
        {
            data[i] = (maxValue - minValue) * rand.NextDouble() + minValue;
        }

        return data;
    }

    // does not work as I intended
    public static double[] NormalizeData(double[] origData)
    {
        double min = origData.Min(), max = origData.Max();
        double[] newData = new double[origData.Length];

        for (int i = 0; i < origData.Length; i++)
        {
            newData[i] = origData[i] / (max-min);
        }
        return newData;
    }
}