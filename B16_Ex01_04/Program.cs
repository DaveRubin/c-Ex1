using System;
using System.Text;

namespace B16_Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            string firstOutputLine;
            string secondOutputLine;
            int userInputAsInt;
            StringBuilder outputString = new StringBuilder();

            // get input from user
            string userInput = GetStringFromUser(6);

            // check if poyndrom
            bool isPolyndrom = checkIfPolyndrom(userInput);

            // if number get digits average
            // else get Capital chars count
            if (int.TryParse(userInput, out userInputAsInt))
            {
                float average = getDigitsAverage(userInputAsInt);
                secondOutputLine = string.Format("The digis average is {0} .{1}", average, Environment.NewLine);
            }
            else
            {
                int numOfCapitals = getCapitalCount(userInput);
                secondOutputLine = string.Format(
                    "The capital letters count is {0} .{1}",
                    numOfCapitals,
                    Environment.NewLine);
            }

            // create the output string
            if (isPolyndrom)
            {
                outputString.Append(string.Format("The input is a polyndrom.{0}", Environment.NewLine));
            }
            else
            {
                outputString.Append(string.Format("The input isn't a polyndrom.{0}", Environment.NewLine));
            }

            outputString.Append(secondOutputLine);

            // print results
            Console.WriteLine(outputString);
        }

        // Get a string in a specific length from a user
        public static string GetStringFromUser(int i_WantedLength)
        {
            Console.WriteLine(string.Format("Please enter a {0} chars long string:", i_WantedLength));
            string userInput = Console.ReadLine();

            while (userInput.Length != i_WantedLength)
            {
                Console.WriteLine(
                    string.Format("Invalid input, please enter a {0} chars long string:", i_WantedLength));
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        // Count the capital letters in a given string
        private static int getCapitalCount(string i_UserInput)
        {
            int capitalLettesInString = 0;

            foreach (char currentCharForCapitalTest in i_UserInput)
            {
                if (char.IsUpper(currentCharForCapitalTest))
                {
                    capitalLettesInString++;
                }
            }

            return capitalLettesInString;
        }

        // Calculate the digits average of a given number
        private static float getDigitsAverage(int i_Number)
        {
            int sum = 0;
            int digitCount = 0;
            while (i_Number > 0)
            {
                sum += i_Number % 10;
                digitCount++;
                i_Number /= 10;
            }

            return (float)sum / digitCount;
        }

        // Check if a given string is a polyndrom
        private static bool checkIfPolyndrom(string i_UserInput)
        {
            bool isPolyndrom = true;

            for (int i = 0; i < i_UserInput.Length / 2; i++)
            {
                if (i_UserInput[i] != i_UserInput[i_UserInput.Length - i - 1])
                {
                    isPolyndrom = false;
                    break;
                }
            }

            return isPolyndrom;
        }
    }
}
