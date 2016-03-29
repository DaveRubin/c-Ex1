using System.Collections.Generic;
using System;

namespace B16_Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            int wantedDigits = 7;

            Console.WriteLine(string.Format("Please enter a {0} digits number:", wantedDigits));
            uint userInput = B16_Ex01_01.Program.GetUintFromUser(wantedDigits);

            // we'll convert the number to list of its digits, and sort it to get all the wanted information
            List<uint> digits = getDigitsList(userInput);

            uint firstDigit = digits[wantedDigits - 1];
            digits.Sort();

            // because of the sort, the smallest number will be at the start and grater at the end
            uint smallestDigit = digits[0];
            uint largetsDigit = digits[wantedDigits - 1];

            // now we can also can count items smaller\greater then the first digit by its appearences in the sorted list
            int smallerThenFirst = digits.IndexOf(firstDigit);
            int greaterThenFirst = digits.Count - digits.LastIndexOf(firstDigit) - 1;

            // print output
            Console.WriteLine(string.Format(
@"The smallest digit is: {0}
The largest digit is : {1}
There are {2} digits smaller then the first digit
There are {3} digits greater then the first digit", 
smallestDigit, 
largetsDigit, 
smallerThenFirst, 
greaterThenFirst));
        }

        // get a natural number and return its digits as a list of unsined ints
        // notice that the converted list is in revers order!
        private static List<uint> getDigitsList(uint i_Number)
        {
            List<uint> digits = new List<uint>();
            while (i_Number > 0)
            {
                digits.Add(i_Number % 10);
                i_Number /= 10;
            }

            return digits;
        }
    }
}
