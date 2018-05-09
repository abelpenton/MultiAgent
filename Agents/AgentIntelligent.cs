using Agents.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Agents.Map;

namespace Agents
{
    public class AgentIntelligent : Agent
    {
        private List<(int x, int y)> rute = new List<(int x, int y)>();
        public AgentIntelligent(int x, int y) : base(x, y)
        {
        }

        public override bool canMove((int r, int c) addr)
        {
            SearchBall();
            return base.canMove(addr);
            
        }

        private void SearchBall()
        {
            for (int i = 0; i < 4; i++)
            {

            }
        }
        public override void move((int r, int c) addr)
        {
            base.move(addr);
        }

    }
}
