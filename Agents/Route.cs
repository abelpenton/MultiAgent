using System;
using System.Collections.Generic;
using System.Text;

namespace Agents
{
    public class Route
    {
        public List<(int x, int y)> route { get; set; }
        public Route()
        {
            route = new List<(int x, int y)>();
        }
    }
}
