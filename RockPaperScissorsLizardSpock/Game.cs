using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class Game
    {
        int PlayerNumber;
        int D;
        string RestartChoice;
        Player PlayerOne;
        Player PlayerTwo;
        private void SelectPlayers()
        {
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
                    SelectPlayers();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a valid response" + "\nPress enter to continue");
                Console.ReadLine();
                SelectPlayers();
            }
        }
        private void PlayerInstance()
        {
            if (PlayerNumber == 1)
            {
                PlayerOne = new Users();
                PlayerTwo = new AI();

            }
            else if (PlayerNumber == 2)
            {
                Users PlayerOne = new Users();
                Users PlayerTwo = new Users();
            }
        }
        private void Initiate()
        {
            PlayerOne.Initialize();
            Console.Clear();
            PlayerTwo.Initialize();
            Console.Clear();
        }
        private void RoundWinnerCheck()
        {
            int a = PlayerOne.Answer;
            int b = PlayerTwo.Answer;
            D = (5 + a - b) % 5;
        }
        private void Announcment()
        {
            if (D == 1 || D == 3)
            {
                Console.WriteLine(PlayerOne.Name + " " + "has won the round!");
                Console.WriteLine(PlayerOne.AnswerString + "\n beats" + "\n" + PlayerTwo.AnswerString);
                Console.WriteLine("Press enter to continue to the next round");
                Console.ReadLine();
                Console.Clear();
                PlayerOne.Score += 1;
            }
            else if (D == 2 || D == 4)
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
                Announcment();
            }
        }
        private void FinalWinnerCheck()
        {
            if (PlayerOne.Score == 2)
            {
                Console.WriteLine(PlayerOne.Name + " Has won!" + "\n Do you want to play again(yes/no)");
                RestartChoice = Console.ReadLine();
                Restart();
            }
            else if(PlayerTwo.Score == 2)
            {
                Console.WriteLine(PlayerTwo.Name +" Has won!" + "\n Do you want to play again(yes/no)");
                RestartChoice = Console.ReadLine();
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
            SelectPlayers();
            PlayerInstance();
            Initiate();
            RoundWinnerCheck();
            Announcment();
            FinalWinnerCheck();

        }

        private void PostInitRounds()
        {
            RoundWinnerCheck();
            Announcment();
            FinalWinnerCheck();
            
        }
    }
}
