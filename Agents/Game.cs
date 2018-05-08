using Agents.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agents
{
    public class Game
    {
        public Team team1 { get; set; }
        public Team team2 { get; set; }
        public Word word { get; set; }

        public Game()
        {
            team1 = new Team();
            team2 = new Team();
            word = new Word();
        }

        public void StartSimulation(int turn)
        {
            while(turn-- > 0)
            {
                if (EndOfGame())
                    return;

                //TODO
            }
        }

        private bool EndOfGame()
        {
            return true;
        }
    }
}
