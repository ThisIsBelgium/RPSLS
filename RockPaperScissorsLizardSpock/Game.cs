using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class Game
    {
        Player PlayerOne;
        Player PlayerTwo;
        private int SelectPlayers()
        {
            int PlayerNumber = 0;
            try
            {
                Console.WriteLine("Choose how you'd like to play!" +
                                  "\n1.Vs. AI" +
                                  "\n2.Or Vs. Another player" +
                                  "\nSelect 1 or 2");


                PlayerNumber = int.Parse(Console.ReadLine());

                if (PlayerNumber > 2 || PlayerNumber < 1)
                {
                    Console.WriteLine("Please enter a valid response" + "\nPress enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    PlayerNumber=SelectPlayers();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid response" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                PlayerNumber=SelectPlayers();
            }
              
            return PlayerNumber;
        }

        private void PlayerInstance()
        {
            int PlayerNumber = SelectPlayers();
            if (PlayerNumber == 1)
            {
                PlayerOne = new Users();
                PlayerTwo = new AI();

            }
            else if (PlayerNumber == 2)
            {
                 PlayerOne = new Users();
                 PlayerTwo = new Users();
            }
        }
        private void Initiate()
        {
            PlayerOne.Initialize();
            Console.Clear();
            PlayerTwo.Initialize();
            Console.Clear();
        }
        private int CheckRoundWinner()
        {
            int a = PlayerOne.Answer;
            int b = PlayerTwo.Answer;
            int WinnerCheck = (5 + a - b) % 5;
            return WinnerCheck;
        }
        private void DisplayRoundWinner()
        {
            int WinnerCheck = CheckRoundWinner();
            if (WinnerCheck == 1 || WinnerCheck == 3)
            {
                Console.WriteLine(PlayerOne.Name + " " + "has won the round!");
                Console.WriteLine(PlayerOne.AnswerString + "\n beats" + "\n" + PlayerTwo.AnswerString);
                Console.WriteLine("Press enter to continue to the next round");
                Console.ReadLine();
                Console.Clear();
                PlayerOne.Score += 1;
            }
            else if (WinnerCheck == 2 || WinnerCheck == 4)
            {
                Console.WriteLine(PlayerTwo.Name + " " + "has won the round!");
                Console.WriteLine(PlayerTwo.AnswerString + "\n beats" + "\n" + PlayerOne.AnswerString);
                Console.WriteLine("Press enter to continue to the next round");
                Console.ReadLine();
                Console.Clear();
                PlayerTwo.Score += 1;
            }
            else
            {
                Console.WriteLine("You Have Tied");
                Console.WriteLine(PlayerOne.AnswerString + "\n ties" + "\n" + PlayerTwo.AnswerString);
                Console.WriteLine("Press enter to continue to the next round");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void Restart()
        {
            Console.WriteLine("Would you like to play again?(yes/no)");
            string RestartChoice = Console.ReadLine();
            if (RestartChoice == "yes")
            {
                Console.Clear();
                run();
            }
            else if (RestartChoice == "no")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Restart();
            }
        }
        private void CheckFinalWinner()
        {
            if (PlayerOne.Score == 2)
            {
                Console.WriteLine(PlayerOne.Name + " Has won!");
                Restart();
            }
            else if (PlayerTwo.Score == 2)
            {
                Console.WriteLine(PlayerTwo.Name + " Has won!");
                Restart();
            }
            else
            {
                PlayerOne.PostInitSelection();
                Console.Clear();
                PlayerTwo.PostInitSelection();
                Console.Clear();
                PostInitRounds();
            }

        }



        public void run()
        {
            PlayerInstance();
            Initiate();
            CheckRoundWinner();
            DisplayRoundWinner();
            CheckFinalWinner();

        }

        private void PostInitRounds()
        {
            CheckRoundWinner();
            DisplayRoundWinner();
            CheckFinalWinner();

        }
    }
}
