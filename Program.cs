
using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nApplication solves a quadratic equation: ax^2 + bx + c = 0\nwhere a, b, c are real numbers and a ≠ 0.\n");
        double a, b, c;

        if (args.Length == 0)
        {
            a = ValidInput("a", true);
            b = ValidInput("b", false);
            c = ValidInput("c", false);

        } else
        {
            string file = args[0];
            string[] coefficients = File.ReadAllText(file).Trim().Split(' ');

            a = double.Parse(coefficients[0], CultureInfo.InvariantCulture);
            b = double.Parse(coefficients[1], CultureInfo.InvariantCulture);
            c = double.Parse(coefficients[2], CultureInfo.InvariantCulture);
        }

        EquationSolver(a, b, c);
    }
    
    static double ValidInput(string var, bool isFirst)
    {
        double val;

        while (true)
        {
            Console.Write($"Enter {var}: ");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"Error. Please enter coefficient '{var}'! ");
                continue;
            }

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
            {
                if (val == 0 && isFirst)
                    Console.WriteLine($"Error. '{var}' must not be zero!");
                else
                {
                    Console.ResetColor();
                    return val;
                }
            }
            else
                Console.WriteLine($"Error. Expected a valid real number, got '{input}' instead!");
        }
    }

    static void EquationSolver(double a, double b, double c)
    {
        double discriminant = (b * b) - (4 * a * c);

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            Console.WriteLine($"\nEquation: ({a:0.0}) x^2 + ({b:0.0}) x + ({c:0.0}) = 0");
            Console.WriteLine("There are two roots");
            Console.WriteLine($"x1 = {x1:0.0}\nx2 = {x2:0.0}");
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);

            Console.WriteLine($"\nEquation: ({a:0.0}) x^2 + ({b:0.0}) x + ({c:0.0}) = 0");
            Console.WriteLine("There are one root");
            Console.WriteLine($"x1 = {x:0.0}");
        }
        else
            Console.WriteLine("\nThere are 0 roots.");
    }
}