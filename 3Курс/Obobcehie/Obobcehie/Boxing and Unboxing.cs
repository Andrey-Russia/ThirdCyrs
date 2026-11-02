using System;
using System.Collections.Generic;

class Program
{
    static double GetSum(List<object> values)
    {
        double sum = 0;

        foreach (object value in values)
        {
            if (value is int intValue)
                sum += intValue;
            else if (value is float floatValue)
                sum += floatValue;
        }

        return sum;
    }

    static void Main()
    {
        Random random = new Random();

        List<object> values = new List<object>();

        for (int i = 0; i < 10; i++)
        {
            if (random.Next(2) == 0)
            {
                int number = random.Next(1, 100);
                values.Add(number);
            }
            else
            {
                float number = (float)(random.NextDouble() * 100);
                values.Add(number);
            }
        }

        foreach (object value in values)
        {
            Console.WriteLine(value);
        }

        double sum = GetSum(values);

        Console.WriteLine($"Сумма: {sum}");
    }
}