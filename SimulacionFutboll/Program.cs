using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agents;

namespace SimulacionFutboll
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Game();
            Console.WriteLine(g.word);
            Console.WriteLine("***********************");
            g.StartSimulation(10);
        }
    }
}
