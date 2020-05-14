using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class BullsAndCowsPlayerTwo : BullsAndCows
    {
        private int numberOfDigits;
        private List<string> allPossibleNumber;
        private string currentGuessNumber;

        public BullsAndCowsPlayerTwo(int ndigits)
        {
            numberOfDigits = ndigits;
            CreateAllPossibleNumber();
        }

        public void Run()
        {
            while(true)
            {
                ShowGuessNumber();
                GetAnswerFromUser();
                if (Bulls == numberOfDigits || allPossibleNumber.Count < 1)
                {
                    Console.WriteLine("Finished!");
                    break;
                }
                ReducePossibelNumbers();
            }
        }

        private void ReducePossibelNumbers()
        {
            for (int i = 0; i < allPossibleNumber.Count;)
            {
                BullsAndCows response = CountBullsAndCows(allPossibleNumber[i], currentGuessNumber);
                if (!IsSame(response))
                    allPossibleNumber.RemoveAt(i);
                else
                    i++;
            }
        }

        private void ShowGuessNumber()
        {
            currentGuessNumber = allPossibleNumber[0];
            Console.WriteLine("Guess: {0}", currentGuessNumber);
        }

        private void GetAnswerFromUser()
        {
            Console.WriteLine("Results (Bulls,Cows):");
            string answer = Console.ReadLine();
            string Cows = answer[2].ToString();
            base.Cows = Convert.ToInt32(Cows);
            string Bulls = answer[0].ToString();
            base.Bulls = Convert.ToInt32(Bulls);
        }

        private void CreateAllPossibleNumber()
        {
            allPossibleNumber = new List<string>();

            int max = (int)Math.Pow(10, numberOfDigits - 1); // 0999; 
            int min = (int)Math.Pow(10, numberOfDigits - 2); // 099;
            for(int i = min + 1; i < max; i++)
            {
                string number = "0" + i.ToString();
                if (Utili.IsUniqueDigits(number))
                    allPossibleNumber.Add(number);
            }

            max = (int)Math.Pow(10, numberOfDigits); // 9999; 
            min = (int)Math.Pow(10, numberOfDigits - 1); // 999;
            for (int i = min + 1; i < max; i++)
            {
                string number = i.ToString();
                if (Utili.IsUniqueDigits(number))
                    allPossibleNumber.Add(number);
            }
        }
    }
}
