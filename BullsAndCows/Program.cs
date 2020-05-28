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
            BullsAndCowsPlayerOne playerOne = new BullsAndCowsPlayerOne(4);
            playerOne.NotifyEvent += PrintPlayerState;
            playerOne.UserInputEvent += Console.ReadLine;
            playerOne.Run();


            //BullsAndCowsPlayerTwo playerTwo = new BullsAndCowsPlayerTwo(4);
            //playerTwo.NotifyEvent += PrintPlayerState;
            //playerTwo.UserInputEvent += Console.ReadLine;
            //playerTwo.Run();

            Console.ReadLine();
        }

        static void PrintPlayerState(string message)
        {
            Console.WriteLine(message);
        }        

    }
}
