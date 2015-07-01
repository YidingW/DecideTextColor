using System;

namespace DecideTextColor
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Console.ReadLine() != "quit")
            {
                Console.WriteLine("Please enter the hex color: \n");
                var hexColor = Console.ReadLine();
                var textColor = getContrastYIQ(hexColor);
                Console.WriteLine("The text color should be {0}", textColor);
            }
        }

        private static string getContrastYIQ(string hexColor)
        {
            if (hexColor.Length != 6) return "Length needs to be 6";

            var r = Convert.ToInt32(hexColor.Substring(0, 2), 16);
            var g = Convert.ToInt32(hexColor.Substring(2, 2), 16);
            var b = Convert.ToInt32(hexColor.Substring(4, 2), 16);

            var yiq = (r * 299 + g * 587 + b * 114) / 1000;

            return yiq > 128 ? "Black" : "White";
        }
    }
}
