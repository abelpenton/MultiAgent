using Agents.Base.Enum;
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
            var r = new Random();
            while(turn-- > 0)
            {
                if (EndOfGame())
                    return;

                var lik = r.Next(0, 2);
                if (lik == 0)
                {
                    Actions(word.team1, word.team2);
                }
                else
                    Actions(word.team2, word.team1);

            }
        }

        private void Actions(Team t1, Team t2)
        {
            foreach (var a in t1._members)
            {
                a.doAction();
            }
            foreach (var a in t2._members)
            {
                a.doAction();
            }
        }
        private bool EndOfGame()
        {
            var result = true;
            foreach (var a in word.team1._members)
            {
                result = result && a.lastAction == ActionPlay.Pass;
            }
            foreach (var a in word.team2._members)
            {
                result = result && a.lastAction == ActionPlay.Pass;
            }
            return result;
        }

      
    }
}
