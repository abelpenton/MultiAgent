using Agents.Base;
using Agents.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agents
{
    public class Team
    {
        public int _goals { get; set; }
        public List<Agent> _members {get;set;}

        public Team()
        {
            _goals = 0;
            _members = new List<Agent>();
        }

        public void markGoal(Word word)
        {
            if (IsGoal(word))
                _goals++;
        }

        private bool IsGoal(Word word)
        {
            throw new Exception();
        }
    }
}
