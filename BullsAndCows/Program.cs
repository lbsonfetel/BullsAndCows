using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] secretNumberArray = GenerateSecretNumber();
            ShowSecretNumber(secretNumberArray);
         
            while (true)
            {
                string guessNumber = GetGuessNumber();

                int Cows = 0;
                int Bulls = 0;
                CountBullsAndCows(secretNumberArray, guessNumber, ref Cows, ref Bulls);
                if (Bulls == 4)
                {
                    Console.WriteLine("********You Win!********");
                    break;
                }
            }

            Console.ReadLine();
        }

        private static void CountBullsAndCows(int[] secretNumberArray, string guessNumber, ref int Cow, ref int Bull)
        {
            for (int i = 0; i < secretNumberArray.Length; i++)
            {
                string digit = secretNumberArray[i].ToString();
                int index = guessNumber.IndexOf(digit);
                if (index == i)
                    Bull++;
                else if (index >= 0)
                    Cow++;
            }
            Console.WriteLine("Bulls {0}. Cows: {1}.", Bull, Cow);
        }

        private static string GetGuessNumber()
        {
            bool isValidNumber = false;
            Console.WriteLine("Please enter your guess number:");
            string guessNumber = "1234";
            while (!isValidNumber)
            {
                guessNumber = Console.ReadLine();
                if (guessNumber.Length == 4 && IsUniqueDigits(guessNumber))
                    isValidNumber = true;
                else
                    Console.WriteLine("Invalid number! Please re-enter your guess number:");
            }
            return guessNumber;
        }

        private static bool IsUniqueDigits(string number)
        {
            for(int i = 0; i < number.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if(number[i] == number[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void ShowSecretNumber(int[] secretNumberArray)
        {
            foreach (int i in secretNumberArray)
                Console.Write("{0 }", i);
            Console.WriteLine();
        }

        private static int[] GenerateSecretNumber()
        {
            Random random = new Random();
            int[] secretNumberArray = new int[4];

            for (int i = 0; i < secretNumberArray.Length; i++)
            {
                bool isUnique = false;
                int newNumber = 0;
                while (!isUnique)
                {
                    newNumber = random.Next(10);
                    isUnique = true;
                    for (int j = 0; j < i; j++)
                    {
                        if (newNumber == secretNumberArray[j])
                        {
                            isUnique = false;
                            break;
                        }
                    }
                }
                secretNumberArray[i] = newNumber;
            }

            return secretNumberArray;
        }
    }
}
