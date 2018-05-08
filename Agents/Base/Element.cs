using System;

namespace Agents
{
    public abstract class Element
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public Element(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
