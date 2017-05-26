using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class Users:Player
    {
        public Users()
        {
            this.Name = Name;
            this.Answer = Answer;
            this.AnswerString = AnswerString;
        }
        private void NameGet()
        {
            NameSelection();
        }
        private void AnswerGet()
        {
            SelectHandPosition();
        }
        public void UserInit()
        {
            NameGet();
            AnswerGet();
            HandPosition();
        }


        


    } 
}
