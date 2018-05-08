using System;
using System.Collections.Generic;
using System.Text;
using Agents.Map;
using Agents.Base.Enum;

namespace Agents.Base
{
    public abstract class Agent : Element
    {
        public ActionPlay lastAction { get; set; }
        public Agent(int x, int y) : base(x, y)
        {
        }

        private bool canMoveBoll(Word word)
        {
            throw new Exception();
        }
        public Word moveBoll(Word word)
        {
            lastAction = ActionPlay.MoveBall;
            throw new ArgumentException();
        }
        
        private bool canMove(Word word)
        {
            throw new Exception();
        }
        public virtual Word move(Word word)
        {
            lastAction = ActionPlay.Move;
            throw new Exception();
        }

        public Word doAction(Word word)
        {
            if (canMoveBoll(word))
            {
               moveBoll(word);
            }
            else
            {
                if (canMove(word))
                    move(word);
                else
                {
                    lastAction = ActionPlay.Pass;
                }
            }
            return word;
        }
    }
}
