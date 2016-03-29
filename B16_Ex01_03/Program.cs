using System;

namespace B16_Ex01_03
{
    public class Program
    {
        // Simple class that prints an hourglass according to user input
        public static void Main()
        {
            // get input from user
            Console.WriteLine("Enter the wanted hourglass height");
            uint wantedHeight = B16_Ex01_01.Program.GetUintFromUser(-1);

            // print hourglass
            B16_Ex01_02.Program.PrintHourGlass((int)wantedHeight);
        }
    }
}
