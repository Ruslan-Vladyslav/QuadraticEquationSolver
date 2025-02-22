
using EquationSolver;
using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nApplication solves a quadratic equation: ax^2 + bx + c = 0\nwhere a, b, c are real numbers and a ≠ 0.\n");
        
        double a, b, c;
        var valid = new Validation();

        if (args.Length == 0)
        {
            a = valid.ValidInput("a", true);
            b = valid.ValidInput("b", false);
            c = valid.ValidInput("c", false);

        } else
        {
            string file = args[0];
            if (Path.GetExtension(file).ToLower() != ".txt")
            {
                valid.ErrorColor("Error. File must be a text file (*.txt).");
                return;
            }

            if (!File.Exists(file))
            {
                valid.ErrorColor($"Error. File '{file}' not found.");
                return;
            }

            string[] coeffs = File.ReadAllText(file).Trim().Split(' ');
            if (coeffs.Length != 3)
            {
                valid.ErrorColor("Error. File must contain exactly three numbers.");
                return;
            }

            if (!double.TryParse(coeffs[0], NumberStyles.Float, CultureInfo.InvariantCulture, out a) ||
            !double.TryParse(coeffs[1], NumberStyles.Float, CultureInfo.InvariantCulture, out b) ||
            !double.TryParse(coeffs[2], NumberStyles.Float, CultureInfo.InvariantCulture, out c))
            {
                valid.ErrorColor("Error. File contains invalid numbers.");
                return;
            }

            if (a == 0)
            {
                valid.ErrorColor("Error. 'a' must not be zero.");
                return;
            }
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
            Console.WriteLine($"x1 = {Math.Abs(x):0.0}");
        }
        else
            Console.WriteLine("\nThere are 0 roots.");
    }
}