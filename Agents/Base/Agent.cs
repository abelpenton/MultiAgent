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
            addr = new (int,int)[4] { (0, 1), (0, -1),(1,0),(-1,0)};
        }

        private bool NotGoals(int x, int y)
        {
            return !word._goals.Exists(g => g._x == x && g._y == y);
        }
        private bool NotMember(int x, int y)
        {
            return !(word.team1._members.Exists(m => m._x == x && m._y == y) || 
                   word.team2._members.Exists(m => m._x == x && m._y == y));
        }

        private bool NotBall(int x, int y)
        {
            return !word.balls.Exists(b => b._x == x && b._y == y);
        }
        private bool ValidPos(int x, int y)
        {
            return x >= 0 && x < word._n && y >= 0 && y < word._n && NotMember(x, y) && NotBall(x, y);
        }
        private bool canMoveBoll(int nextX, int nextY, (int r,int c) addr)
        {
            return word.balls.Exists(b => b._x == nextX && b._y == nextY) && ValidPos(nextX + addr.r, nextY + addr.c);
        }
        public void moveBoll((int r, int c) addr)
        {
            lastAction = ActionPlay.MoveBall;
            var b = word.balls.Find(ball => ball._x == this._x + addr.r && ball._y == this._y + addr.c);
            this._x += addr.r;
            this._y += addr.c;
            if (word._goals.Exists(goal => goal._x == b._x + addr.r && goal._y == b._y + addr.c))
            {
                if(word.team1._members.Exists(m => m._x == this._x && m._y == this._y))
                {
                    word.team1._goals++;
                }
                else
                {
                    word.team2._goals++;
                }
                Console.WriteLine($"GOOOOOOOLLLLLLL!!!!!");
                word.balls.Remove(b);
                (int x,int y) = word.generatePos();
                word.balls.Add(new Boll(x, y));
            }
            else
            {
                Console.WriteLine($"Move a ball from ({b._x},{b._y}) to ({b._x + addr.r},{b._y + addr.c})");
                b._x += addr.r;
                b._y += addr.c;
            }
            
        }
        
        private bool canMove((int r,int c)addr)
        {
            return ValidPos(this._x + addr.r, this._y + addr.c) && NotGoals(this._x + addr.r, this._y + addr.c);            
        }
        public virtual void move((int r, int c) addr)
        {
            Console.WriteLine($"Move a Agent from ({this._x},{this._y}) to ({this._x + addr.r},{this._y + addr.c})");
            lastAction = ActionPlay.Move;
            this._x += addr.r;
            this._y += addr.c;
        }

        public void doAction(Word word)
        {
            this.word = word;
            var r = new Random();
            bool[] mark = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                if (canMoveBoll(this._x + addr[i].r, this._y + addr[i].c, addr[i]))
                {
                    moveBoll((addr[i].r, addr[i].c));
                    return;
                }
            }
            while (true)
            {                
                var lik = r.Next(0, 4);
                mark[lik] = true;
                if (canMove(addr[lik]))
                {
                    move(addr[lik]);
                    break;
                }
                else
                {
                    var c = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if(mark[i])
                        {
                            c++; 
                        }
                    }
                    if(c == 4)
                    {
                        lastAction = ActionPlay.Pass;
                        return;
                    }
                        
                }
                
            }
            
            
            
        }
    }
}
