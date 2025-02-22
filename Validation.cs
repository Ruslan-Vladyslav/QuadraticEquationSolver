using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolver
{
    public class Validation
    {
        public Validation() { }

        public double ValidInput(string var, bool isFirst)
        {
            double val;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Enter {var}: ");
                Console.ForegroundColor = ConsoleColor.Green;

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ErrorColor($"Error. Please enter coefficient '{var}'! ");
                    continue;
                }

                if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                {
                    if (val == 0 && isFirst)
                        ErrorColor($"Error. '{var}' must not be zero!");
                    else
                    {
                        Console.ResetColor();
                        return val;
                    }
                }
                else
                    ErrorColor($"Error. Expected a valid real number, got '{input}' instead!");
            }
        }

        public void ErrorColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();
        }
    }
}
