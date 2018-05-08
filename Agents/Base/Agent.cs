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
            throw new ArgumentException();
        }
        
        private bool canMove()
        {
            throw new Exception();
        }
        public virtual Word move(Word word)
        {
            throw new Exception();
        }

        public Word doAction(Word word)
        {
            throw new Exception();
        }
    }
}
