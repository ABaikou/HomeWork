using System;

namespace MultiplicationTable
{
    class Program
    {
        static void OutputMultTable(int x)
        {
            Console.WriteLine($"Multiplication table for: {x}");
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"{x} x {i} = {x * i}");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number (integer): ");
            int num;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out num))
            {
                OutputMultTable(num);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }

        }
    }
}
