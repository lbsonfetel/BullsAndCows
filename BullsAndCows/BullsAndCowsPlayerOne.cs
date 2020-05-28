using System;
using System.Text;

namespace BullsAndCows 
{
    class BullsAndCowsPlayerOne : BullsAndCows
    {
        public delegate void NotifyHandler(string message);
        public event NotifyHandler NotifyEvent;

        public delegate string UserInputHandler();
        public event UserInputHandler UserInputEvent;

        private int numberOfDigits;
        private int[] secretNumberArray;
        private string guessNumber;                

        private Random random;

        public BullsAndCowsPlayerOne() : this(4)
        {
        }

        public BullsAndCowsPlayerOne(int digits)
        {            
            numberOfDigits = digits;
            secretNumberArray = new int[numberOfDigits];
            guessNumber = null;
            Cows = 0;
            Bulls = 0;
            random = new Random();
        }

        public void Run()
        {
            GenerateSecretNumber();
            ShowSecretNumber();

            while (true)
            {
                GetGuessNumber();

                Cows = 0;                
                Bulls = 0;
                PrintBullsAndCows();
                if (Bulls == numberOfDigits)
                {
                    NotifyEvent("********You Win!********");
                    break;
                }
            }            
        }

        private void PrintBullsAndCows()
        {
            CountBullsAndCows(secretNumberArray, guessNumber);
            NotifyEvent(String.Format("Bulls {0}. Cows: {1}.", Bulls, Cows));
        }

        private void GetGuessNumber()
        {
            bool isValidNumber = false;
            NotifyEvent("Please enter your guess number:");
            while (!isValidNumber)
            {
                guessNumber = UserInputEvent();
                if (guessNumber.Length == numberOfDigits && Utili.IsUniqueDigits(guessNumber))
                    isValidNumber = true;
                else
                    NotifyEvent("Invalid number! Please re-enter your guess number:");
            }
        }

        private void ShowSecretNumber()
        {
            StringBuilder s = new StringBuilder();
            foreach (int i in secretNumberArray)
            {
                s.Append(i);
                s.Append(" ");
            }
            NotifyEvent(s.ToString());
        }

        private void GenerateSecretNumber()
        {
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

        }
    }
}
