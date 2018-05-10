using Agents.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Agents.Map
{
    public class Word
    {
        public Team team1 { get; set; }
        public Team team2 { get; set; }
        private Random r { get; set; }
        private bool[,] used { get; set; }
        public List<Boll> balls { get; set; }
        public List<Goals> _goals { get; set; }
        public int _n { get; set; }
        public string[,] map { get; set; }
        public Word(int N)
        {
            r = new Random();
            _n = N;
            used = new bool[_n, _n];
            map = new string[N, N];
            team1 = new Team();
            team2 = new Team();
            _goals = new List<Goals>();
            var count = r.Next(1, 11);
            SetGoals();
            FillTeam(team1,count);
            FillTeam(team2,count);
            FillBalls();
        }
        public override string ToString()
        {
            var goals = _n - 4;
            var top = goals / 2;

            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    map[i, j] = "_";
                }
            }

            for (int i = top; i < top + 4; i++)
            {
                map[i, 0] = map[i,_n-1] = "P";
                _goals.Add(new Goals(i,0));
                _goals.Add(new Goals(i, _n-1));

            }

            foreach (var t1 in team1._members)
            {
                map[t1._x, t1._y] = "1";
            }

            foreach (var t2 in team2._members)
            {
                map[t2._x, t2._y] = "2";
            }

            foreach (var b in balls)
            {
                map[b._x, b._y] = "B";
            }

            for (int i = 0; i < _n; i++)
            {

                for (int j = 0; j < _n; j++)
                {
                    Console.Write(map[i,j]+ " ");
                }
                Console.WriteLine();
            }
            return "";
        }

        private void SetGoals()
        {
            var goals = _n - 4;
            var top = goals / 2;

            for (int i = top; i < top + 4; i++)
            {
                used[i, 0] = used[i, _n - 1] = true;
            }
        }

        private void FillBalls()
        {
            balls = new List<Boll>();
            var count = r.Next(1, 6);
            int x, y;
            for (int i = 0; i < count; i++)
            {
                (x, y) = generatePos();
                balls.Add(new Boll(x, y));
            }
        }
        private void FillTeam(Team team, int count)
        {
            int x, y;
            if (count > 1)
            {
                for (int i = 0; i < count / 2; i++)
                {
                    (x, y) = generatePos();
                    team._members.Add(new AgentNormal(x, y));
                }

                for (int i = count / 2; i < count; i++)
                {
                    (x, y) = generatePos();
                    team._members.Add(new AgentIntelligent(x, y));
                }
            }
            else
            {
                (x, y) = generatePos();
                team._members.Add(new AgentIntelligent(x, y));
            }
        }

        public (int x, int y) generatePos()
        {
            int x, y;
            while(true)
            {
                x = r.Next(0, _n);
                y = r.Next(0, _n);
                if(!used[x,y])
                {
                    used[x, y] = true;
                    break;
                }
            }
            return (x, y);
        }
    }
}
