using Agents.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Agents.Map;

namespace Agents
{
    public class AgentIntelligent : Agent
    {
        private bool rute { get; set; }
        private Route routePath { get; set; }
        public AgentIntelligent(int x, int y) : base(x, y)
        {
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
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                for (int i = 0; i < 4; i++)
                {
                    if(ValidPos(current.pos.x + addr[i].r, current.pos.y + addr[i].c))
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
                    while(node != null)
                    {
                        this.routePath.route.Add(node.pos);
                        node = node.parent;
                    }
                }
            }
            
        }

        private void MoveForRoute()
        {
            var top = this.routePath.route[0];
            this.routePath.route.RemoveAt(0);
            _x = top.x;
            _y = top.y;
            if(routePath.route.Count == 0)
            {
                rute = false;
            }
        }

    }
}
