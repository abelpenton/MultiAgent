using Agents.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agents
{
    public class Game
    {

        public Word word { get; set; }

        public Game(int N = 10)
        {
            word = new Word(N);
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
