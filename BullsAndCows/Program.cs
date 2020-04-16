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

            Console.ReadLine();
        }

        private static void ShowSecretNumber(int[] secretNumberArray)
        {
            foreach (int i in secretNumberArray)
                Console.Write("{0 }", i);
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
