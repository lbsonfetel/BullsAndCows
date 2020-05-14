using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    static class Utili
    {
        public static bool IsUniqueDigits(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (number[i] == number[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
