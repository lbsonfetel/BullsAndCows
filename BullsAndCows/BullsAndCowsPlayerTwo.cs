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

        public delegate void NotifyHandler(string message);
        public event NotifyHandler NotifyEvent;

        public delegate string UserInputHandler();
        public event UserInputHandler UserInputEvent;

        public BullsAndCowsPlayerTwo(int ndigits)
        {
            numberOfDigits = ndigits;
            CreateAllPossibleNumber();
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    ShowGuessNumber();
                    GetAnswerFromUser();
                    if (Bulls == numberOfDigits)
                    {
                        NotifyEvent("Finished!");
                        break;
                    }
                    ReducePossibelNumbers();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                if (allPossibleNumber.Count == 0)
                    NotifyEvent("Wrong Cow or Bull values.");
            }
        }

        private void ReducePossibelNumbers()
        {
            for (int i = 0; i < allPossibleNumber.Count;)
            {
                BullsAndCows response = GetBullsCowsResponse(allPossibleNumber[i], currentGuessNumber);
                if (!IsSame(response))
                    allPossibleNumber.RemoveAt(i);
                else
                    i++;
            }
        }

        private void ShowGuessNumber()
        {
            currentGuessNumber = allPossibleNumber[0];
            string message = String.Format("Guess: {0}", currentGuessNumber);
            NotifyEvent(message);
        }

        private void GetAnswerFromUser()
        {
            while (true)
            {
                try
                {
                    NotifyEvent("Results (Bulls,Cows):");
                    string answer = UserInputEvent();
                    string Cows = answer[2].ToString();
                    base.Cows = Convert.ToInt32(Cows);
                    string Bulls = answer[0].ToString();
                    base.Bulls = Convert.ToInt32(Bulls);

                    break;
                }
                catch (Exception e)
                {
                    NotifyEvent("Invalid Input! Please enter again:");
                }
            }
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
