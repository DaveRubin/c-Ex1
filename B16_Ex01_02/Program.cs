using System;
using System.Text;

namespace B16_Ex01_02
{
    public class Program
    {
        // Simple class that prints a predefined hourglass
        public static void Main()
        {
            PrintHourGlass(5);
        }

        public static void PrintHourGlass(int i_HourglassHeight)
        {
            int halfHeight = i_HourglassHeight / 2;
            StringBuilder bottomHourglassStringBuilder = new StringBuilder();
            StringBuilder topHourglassStringBuilder = new StringBuilder();

            // insert top part
            for (int line = 0; line < halfHeight; line++)
            {
                // add spaces
                topHourglassStringBuilder.Append(createHourglassLine(line, i_HourglassHeight - (2 * line)));
            }

            // insert niddle only if odd
            if (i_HourglassHeight % 2 == 1)
            {
                topHourglassStringBuilder.Append(createHourglassLine(i_HourglassHeight / 2, 1));
            }

            // clear the last newLine from the top string
            topHourglassStringBuilder.Length--;

            // insert bottom part
            for (int line = halfHeight - 1; line >= 0; line--)
            {
                // add spaces
                bottomHourglassStringBuilder.Append(createHourglassLine(line, i_HourglassHeight - (2 * line)));
            }

            Console.WriteLine(topHourglassStringBuilder.ToString());
            Console.WriteLine(bottomHourglassStringBuilder.ToString());
        }

        // create a string line of spaces and stars
        private static string createHourglassLine(int i_SpacesCount, int i_StarsCount)
        {
            StringBuilder stringLineBuilder = new StringBuilder();

            stringLineBuilder.Append(' ', i_SpacesCount);
            stringLineBuilder.Append('*', i_StarsCount);
            stringLineBuilder.Append(Environment.NewLine);

            return stringLineBuilder.ToString();
        }
    }
}
