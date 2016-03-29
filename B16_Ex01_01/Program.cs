using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            int numbersToProcessCount = 6;
            int digitsPerNumber = 3;

            List<uint> numbersToProcess = new List<uint>();
            Console.WriteLine(
                string.Format("Please enter {0} numbers with {1} digits each:", numbersToProcessCount, digitsPerNumber));

            // first get numbers to process
            for (int i = 0; i < numbersToProcessCount; i++)
            {
                numbersToProcess.Add(GetUintFromUser(digitsPerNumber));
            }

            // processNumbersAndPrintStatics(numbersToProcess);
            processNumbers(numbersToProcess);
        }

        /**
         * Ask user for input and return a positive number
         * When invalid input is given, ask again till valid input;
         * if valid digits is -1 then allow all lengths
         * */

        public static uint GetUintFromUser(int i_ValidDigits)
        {
            uint userInputNumber;
            string userInputString = Console.ReadLine();
            bool successfulParse = uint.TryParse(userInputString, out userInputNumber);

            // a valid number is 
            while (!successfulParse || (userInputString.Length != i_ValidDigits && i_ValidDigits != -1))
            {
                Console.WriteLine(
                    string.Format(@"Invalid input,Please enter a {0} digits number :", i_ValidDigits));
                userInputString = Console.ReadLine();
                successfulParse = uint.TryParse(userInputString, out userInputNumber);
            }

            return userInputNumber;
        }

        /**
         * Convert list to binary numbers, print them
         * Count how many numbers have accending digits
         * Count how many numbers have decending digits
         * Calculate average binary digits 
         * Calcualte average of given numbers
         * */

        private static void processNumbers(List<uint> i_NumbersList)
        {
            float averageBinaryDigits;
            float averageNumber;
            int accendingNumbersCount = 0;
            int decendingNumbersCount = 0;

            // we will hold the binary convertions in strings to easily get their lengths and be available for printing
            List<string> convertedBinaryStrings =
                convertUintListToBinaryStringList(i_NumbersList);

            // calculate average digits
            averageBinaryDigits = calculateAverageChars(convertedBinaryStrings);

            // count accending order and decending order numbers
            countAccendingDecendingNumbers(i_NumbersList, ref accendingNumbersCount, ref decendingNumbersCount);

            // calculate average number
            averageNumber = getUintListAverage(i_NumbersList);

            // build string to print using string builder
            Console.WriteLine(
                string.Format(
                    @"The binary numbers are: {0}.
There are {1} nubmers which are accennding series and {2} which are decending.
The average digits of the binary series is {3}.
The general average of the inserted numbers is {4}.",
                    convertStringListToString(convertedBinaryStrings, ","),
                    accendingNumbersCount,
                    decendingNumbersCount,
                    averageBinaryDigits,
                    averageNumber));
        }

        /**
         * The function gets and converts a list of strings into a string of its values separated with a given string
         * */

        private static string convertStringListToString(
            List<string> i_ConvertedBinaryStrings,
            string i_Separator)
        {
            StringBuilder stringBuilderForStringsListChain = new StringBuilder();

            for (int i = 0; i < i_ConvertedBinaryStrings.Count; i++)
            {
                if (i != 0)
                {
                    stringBuilderForStringsListChain.Append(i_Separator);
                }

                stringBuilderForStringsListChain.Append(i_ConvertedBinaryStrings[i]);
            }

            return stringBuilderForStringsListChain.ToString();
        }

        /**
         * Calculate and return the average value of a numbers list
         * */

        private static float getUintListAverage(List<uint> i_NumbersList)
        {
            float sum = 0;
            int numbersCount = i_NumbersList.Count;

            for (int i = 0; i < numbersCount; i++)
            {
                sum += i_NumbersList[i];
            }

            return (float)(sum / numbersCount);
        }

        private static void countAccendingDecendingNumbers(
            List<uint> i_NumbersList,
            ref int io_AaccendingNumbersCount,
            ref int io_DecendingNumbersCount)
        {
            bool accend = false;
            bool decend = false;

            // for each number test if all numbers accending, or all numbers decending;
            for (int i = 0; i < i_NumbersList.Count; i++)
            {
                // init vars
                checkAccendDecendNumber(i_NumbersList[i], ref accend, ref decend);

                if (accend)
                {
                    io_AaccendingNumbersCount++;
                }
                else if (decend)
                {
                    io_DecendingNumbersCount++;
                }
            }
        }

        /**
         * For a single number check if its digits accend or decend
         * */

        private static void checkAccendDecendNumber(uint i_NumberToCheck, ref bool io_Accend, ref bool io_Decend)
        {
            io_Accend = true;
            io_Decend = true;
            uint rightDigit;
            int lastDigit = -1;

            while (i_NumberToCheck > 0)
            {
                rightDigit = i_NumberToCheck % 10;

                // after first digit
                // check if two following digits aren't accending / decending, cancel flag
                if (lastDigit > -1)
                {
                    if (rightDigit > lastDigit)
                    {
                        io_Accend = false;
                    }

                    if (rightDigit < lastDigit)
                    {
                        io_Decend = false;
                    }
                }

                i_NumberToCheck /= 10;
                lastDigit = (int)rightDigit;
            }

            // if both flags are up, shut it (to prevent case of both decend and accend)
            if (io_Accend && io_Decend)
            {
                io_Accend = false;
                io_Decend = false;
            }
        }

        /**
         * Get list of strings and return the average length of them
         * */

        private static float calculateAverageChars(List<string> i_ConvertedBinaryStrings)
        {
            float sum = 0;
            int total = i_ConvertedBinaryStrings.Count;
            string currentBinaryStringToGetLengh;

            for (int i = 0; i < total; i++)
            {
                currentBinaryStringToGetLengh = i_ConvertedBinaryStrings[i];
                sum += currentBinaryStringToGetLengh.Length;
            }

            return (float)(sum / total);
        }

        /**
         * Get list of unsigned ints and convert them all to a strings represenging their binary values
         * */

        private static List<string> convertUintListToBinaryStringList(
            List<uint> i_NumbersList)
        {
            // create empty string list to hold the new binary strings
            List<string> convertedList = new List<string>();

            for (int i = 0; i < i_NumbersList.Count; i++)
            {
                convertedList.Add(convertToBinaryString(i_NumbersList[i]));
            }

            return convertedList;
        }

        /**
         * get uint param and convert it to a binary representation string
         * */

        private static string convertToBinaryString(uint i_NumberToConvert)
        {
            uint remainder;
            uint convertedNumber = 0;
            uint factor = 1;

            while (i_NumberToConvert > 0)
            {
                remainder = i_NumberToConvert % 2;
                convertedNumber += remainder * factor;
                i_NumberToConvert /= 2;
                factor *= 10;
            }

            return convertedNumber.ToString();
        }
    }
}
