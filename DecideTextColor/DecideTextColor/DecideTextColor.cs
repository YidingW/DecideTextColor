using System;

namespace DecideTextColor
{
    internal static class DecideTextColor
    {
        private static void Main()
        {
            var colorInput = "";
            while (colorInput != "quit")
            {
                Console.WriteLine("Please enter the hex color: \n");
                colorInput = Console.ReadLine();
                var textColor = getContrastYIQ(colorInput);
                Console.WriteLine("The text color should be {0}. \n", textColor);
            }
        }

        private static string getContrastYIQ(string hexColor)
        {
            if (hexColor.Length != 6) return "Length needs to be 6";
            try
            {
                var r = Convert.ToInt32(hexColor.Substring(0, 2), 16);
                var g = Convert.ToInt32(hexColor.Substring(2, 2), 16);
                var b = Convert.ToInt32(hexColor.Substring(4, 2), 16);

                var yiq = (r*299 + g*587 + b*114)/1000;

                return yiq > 128 ? "Black" : "White";
            }
            catch (Exception)
            {
                return "Invalid Input!";
            }
        }
    }
}