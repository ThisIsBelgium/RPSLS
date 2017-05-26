using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Game
    {
        Users PlayerOne = new Users();
        Users PlayerTwo = new Users();
        AI AIOne = new AI();

        private void SelectPlayers()
        {
            try
            {
                Console.WriteLine("Choose how you'd like to play!" +
                                  "\n1.Vs. AI" +
                                  "\n2.Or Vs. Another player" +
                                  "\nSelect 1 or 2");
                int playernumber = int.Parse(Console.ReadLine());
                if (playernumber == 1)
                {
                    PlayerOne.UserInit();
                    Console.Clear();
                    AIOne.AIInit();
                    Console.Clear();
                }
                else if (playernumber == 2)
                {
                    PlayerOne.UserInit();
                    Console.Clear();
                    PlayerTwo.UserInit();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please make a valid selection" + "\nPress enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    SelectPlayers();
                }
            }
            catch
            {
                Console.WriteLine("Please choose a  valid selection" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                SelectPlayers();

            }
        }

        private void WinnerCheck()
        {
            int a = PlayerOne.Answer;
            if (AIOne.Name != null)
            {
                int b = AIOne.Answer;
                int d = (5 + a - b) % 5;
                if (d == 1 || d == 3)
                {
                    Console.WriteLine(PlayerOne.Name + " " + "has won!");
                    Console.WriteLine(PlayerOne.AnswerString + "\n beats" + "\n" + AIOne.AnswerString);
                    Console.WriteLine("Press enter to end game");
                    Console.ReadLine();
                }
                else if (d == 2 || d == 4)
                {
                    Console.WriteLine(AIOne.Name + " " + "has won!");
                    Console.WriteLine(AIOne.AnswerString + "\n beats" + "\n" + PlayerOne.AnswerString);
                    Console.WriteLine("Press enter to end game");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You Have Tied");
                    Console.WriteLine(PlayerOne.AnswerString + "\n ties" + "\n" + AIOne.AnswerString);
                    Console.WriteLine("Press enter to end game");
                    Console.ReadLine();
                }
            }
            else
            {
                int b = PlayerTwo.Answer;
                int d = (5 + a - b) % 5;
                if (d == 1 || d == 3)
                {
                    Console.WriteLine(PlayerOne.Name + " " + "has won!");
                    Console.WriteLine(PlayerOne.AnswerString + "\n beats" + "\n" + PlayerTwo.AnswerString);
                    Console.WriteLine("Press enter to end game");
                    Console.ReadLine();
                }
                else if (d == 2 || d == 4)
                {
                    Console.WriteLine(PlayerTwo.Name + " " + "has won!");
                    Console.WriteLine(PlayerTwo.AnswerString + "\n beats" + "\n" + PlayerOne.AnswerString);
                    Console.WriteLine("Press enter to end game");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You Have Tied");
                    Console.WriteLine(PlayerOne.AnswerString + "\n ties" + "\n" + PlayerTwo.AnswerString);
                    Console.WriteLine("Press enter to end game");
                    Console.ReadLine();
                }
            }
        }
        public void run()
        {
            SelectPlayers();
            WinnerCheck();
        }
    }
}
