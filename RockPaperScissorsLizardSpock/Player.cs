using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public abstract class Player
    {
        public string Name;
        public int Answer;
        public string AnswerString;
        public int Score;

        public virtual void SelectHandPosition()
        {
            try
            {
                Console.WriteLine("Pick your choice" +
                                   "\n1.Rock" +
                                   "\n2.Paper" +
                                   "\n3.Scissors" +
                                   "\n4.Spock" +
                                   "\n5.Lizard" +
                                   "\n Please choose the number next to your choice");
                Answer = int.Parse(Console.ReadLine()) - 1;
                if (Answer > 4 || Answer < 0)
                {
                    Console.WriteLine("Choose a valid answer" + "\nPress enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    SelectHandPosition();
                }
            }
            catch
            {
                Console.WriteLine("Choose a valid answer" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                SelectHandPosition();

            }
        }
        public virtual void HandPosition()
        {
            switch (Answer)
            {
                case 0:
                    AnswerString = "Rock";
                    break;
                case 1:
                    AnswerString = "Paper";
                    break;
                case 2:
                    AnswerString = "Scissors";
                    break;
                case 3:
                    AnswerString = "Spock";
                    break;
                case 4:
                    AnswerString = "Lizard";
                    break;
                default:
                    Console.WriteLine("Please choose a valid selection");
                    Console.ReadLine();
                    break;

            }
        }
        public virtual void NameSelection()
        {
            Console.WriteLine("Enter your name please");
            Name = Console.ReadLine();
            if (Name == "")
            {
                Console.WriteLine("Please choose a name" + "\nPress enter to try again");
                Console.ReadLine();
                Console.Clear();
                NameSelection();
            }
        }
        public virtual void Initialize()
        {
            NameGet();
            AnswerGet();
            HandPosition();
        }
        private void NameGet()
        {
            NameSelection();
        }
        private void AnswerGet()
        {
            SelectHandPosition();
        }
        public void PostInitSelection()
        {
            AnswerGet();
            HandPosition();
        }
    }

}
