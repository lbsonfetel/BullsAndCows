using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class BullsAndCows
    {
        public int Cows { get; set; }
        public int Bulls { get; set; }

        public void CountBullsAndCows(int[] secretNumberArray, string guessNumber)
        {
            string number = ConvertArrayToString(secretNumberArray);
            CountBullsAndCows(number, guessNumber);
        }

        public static BullsAndCows CountBullsAndCows(string secretNumberArray, string guessNumber)
        {
            BullsAndCows result = new BullsAndCows();
            for (int i = 0; i < secretNumberArray.Length; i++)
            {
                string digit = secretNumberArray[i].ToString();
                int index = guessNumber.IndexOf(digit);
                if (index == i)
                    result.Bulls++;
                else if (index >= 0)
                    result.Cows++;
            }
            return result;
        }

        public bool IsSame(BullsAndCows other)
        {
            if (other.Bulls == Bulls && other.Cows == Cows)
                return true;
            else
                return false;
        }

        private string ConvertArrayToString(int[] array)
        {
            string s = "";
            foreach (int i in array)
                s = s + i.ToString();
            return s;
        }
    }
}
