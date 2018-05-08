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
        private Word word { get; set; }
        private (int r,int c)[] addr { get; set; }
        private int[] columns { get; set; }
        public Agent(int x, int y) : base(x, y)
        {
            addr = new (int,int)[4] { (1,0),(-1,0),(0,1),(0,-1)};
        }

        private bool NotGoals(int x, int y)
        {
            return !word._goals.Exists(g => g._x == x && g._y == y);
        }
        private bool NotMember(int x, int y)
        {
            return !(word.team1._members.Exists(m => m._x == x && m._y == y) && 
                   word.team2._members.Exists(m => m._x == x && m._y == y));
        }

        private bool NotBall(int x, int y)
        {
            return !word.balls.Exists(b => b._x == x && b._y == y);
        }
        private bool ValidPos(int x, int y)
        {
            return x >= 0 && x < word._n && y >= 0 && y < word._n && NotGoals(x, y) && NotMember(x, y) && NotBall(x, y);
        }
        private bool canMoveBoll(int nextX, int nextY, (int r,int c) addr)
        {
            return word.balls.Exists(b => b._x == nextX && b._y == nextY) && ValidPos(nextX + addr.r, nextY + addr.c);
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

        public void doAction(Word word)
        {
            this.word = word;
            for (int i = 0; i < 4; i++)
            {
                if (canMoveBoll(this._x + addr[i].r,this._y+addr[i].c, addr[i]))
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
}
