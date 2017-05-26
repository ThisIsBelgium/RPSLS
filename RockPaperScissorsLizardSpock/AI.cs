using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class AI : Player
    {
        public AI()
        {
            
        }
        public override void NameSelection()
        {
            Console.WriteLine("Name your rival");
            Name = Console.ReadLine();
            if (Name == "")
            {
                Console.WriteLine("Please enter your rivals name" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                NameSelection();

            }
        }
        public override void SelectHandPosition()
        {
            Random rnd = new Random();
            Answer = rnd.Next(0, 4);
        }
        public override void Initialize()
        {
            NameSelection();
            SelectHandPosition();
            HandPosition();
        }

    }
}
