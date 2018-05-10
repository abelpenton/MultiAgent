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
            //var wait = Console.ReadLine();
            while (turn-- > 0)
            {
                

                if (EndOfGame())
                {
                    word.team1._members[0].GenerateNewBallsIfBlocks();
                    Console.WriteLine("End Game");
                    Console.ReadLine();
                    return;
                }

                var lik = r.Next(0, 2);
                if (lik == 0)
                {
                    Actions(word.team1, word.team2);
                }
                else
                    Actions(word.team2, word.team1);
            }
            Console.WriteLine("Time Complete!!!!");
        }

        private void Actions(Team t1, Team t2)
        {
            if(t1._members.Count == 0 || t2._members.Count == 0)
            {

            }
            foreach (var a in t1._members)
            {
                a.doAction(word);
                Console.WriteLine(word);
                Console.WriteLine();
                Console.WriteLine($"Score Team1: {word.team1._goals} \t Score Team2: {word.team2._goals}");
                Console.WriteLine("-----------------------------------");
                //var wait = Console.ReadLine();
            }
            foreach (var a in t2._members)
            {
                a.doAction(word);
                Console.WriteLine(word);
                Console.WriteLine();
                Console.WriteLine($"Score Team1: {word.team1._goals} \t Score Team2: {word.team2._goals}");
                Console.WriteLine("-----------------------------------");
                //var wait = Console.ReadLine();
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
