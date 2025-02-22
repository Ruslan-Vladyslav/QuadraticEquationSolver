
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
            Console.Write("a = ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out a) || a == 0)
            {
                Console.Write("Invalid input. Please enter a valid nonzero number for a: ");
            }

            Console.Write("b = ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out b))
            {
                Console.Write("Invalid input. Please enter a valid number for b: ");
            }

            Console.Write("c = ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out c))
            {
                Console.Write("Invalid input. Please enter a valid number for c: ");
            }

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