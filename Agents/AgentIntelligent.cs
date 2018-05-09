using Agents.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Agents.Map;
using Agents.Base.Enum;

namespace Agents
{
    public class AgentIntelligent : Agent
    {
        private bool rute { get; set; }
        private Route routePath { get; set; }
        public AgentIntelligent(int x, int y) : base(x, y)
        {
            routePath = new Route();
        }

        public override bool canMove((int r, int c) addr)
        {
            return true;
            
        }

        private Node SearchBall()
        {
            Queue<Node> queue = new Queue<Node>();
            Node node = new Node();
            node.pos = (_x, _y);
            queue.Enqueue(node);
            bool[,] used = new bool[word._n, word._n];            
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                used[current.pos.x, current.pos.y] = true;
                for (int i = 0; i < 4; i++)
                {
                    if(ValidPos2(current.pos.x + addr[i].r, current.pos.y + addr[i].c) && !used[current.pos.x + addr[i].r, current.pos.y + addr[i].c])
                    {
                        if (word.balls.Exists(b => b._x == current.pos.x + addr[i].r && b._y == current.pos.y + addr[i].c))
                        {
                            if(CanMoveBall(current.pos.x + addr[i].r, current.pos.y + addr[i].c))
                            {
                                rute = true;
                                return current;
                            }
                        }
                        else
                        {
                            var node1 = new Node();
                            node1.pos = (current.pos.x + addr[i].r, current.pos.y + addr[i].c);
                            node1.parent = current;
                            queue.Enqueue(node1);
                        }
                        
                    }
                }
            }
            return null;
        }

        public bool CanMoveBall(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                if(ValidPos(x + addr[i].r,y + addr[i].c))
                {
                    return true;
                }
            }
            return false;
        }
        public override void move((int r, int c) addr)
        {
            if(this.rute)
            {
                MoveForRoute();
            }
            else
            {
                var node = SearchBall();
                if (!this.rute)
                {
                    this.lastAction = Base.Enum.ActionPlay.Pass;
                }
                else
                {
                    Console.WriteLine($"A Agent Intelligent find a ball close of ({node.pos.x},{node.pos.y}) and go for");
                    while (node.parent != null)
                    {
                        this.routePath.route.Add(node.pos);
                        node = node.parent;
                    }
                    this.routePath.route.Reverse();
                    MoveForRoute();
                }
            }
            
        }

        private void MoveForRoute()
        {
            var top = this.routePath.route[0];
            this.routePath.route.RemoveAt(0);
            Console.WriteLine($"Move a Agent Intelligent from ({this._x},{this._y}) to ({top.x},{top.y})");
            lastAction = ActionPlay.Move;
            _x = top.x;
            _y = top.y;
            if(routePath.route.Count == 0)
            {
                rute = false;
            }
        }

    }
}
