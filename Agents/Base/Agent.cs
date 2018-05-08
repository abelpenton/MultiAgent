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

        private bool canMoveBoll()
        {
            throw new Exception();
        }
        public void moveBoll()
        {
            lastAction = ActionPlay.MoveBall;
            throw new ArgumentException();
        }
        
        private bool canMove()
        {
            throw new Exception();
        }
        public virtual void move()
        {
            lastAction = ActionPlay.Move;
            throw new Exception();
        }

        public void doAction()
        {
            if (canMoveBoll())
            {
               moveBoll();
            }
            else
            {
                if (canMove())
                    move();
                else
                {
                    lastAction = ActionPlay.Pass;
                }
            }
        }
    }
}
