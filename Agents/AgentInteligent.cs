﻿using Agents.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Agents.Map;

namespace Agents
{
    public class AgentInteligent : Agent
    {
        public AgentInteligent(int x, int y) : base(x, y)
        {
        }

        public override Word move(Word word)
        {
            throw new Exception();
        }
    }
}
