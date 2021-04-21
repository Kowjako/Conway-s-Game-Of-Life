using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum State
{
    Live = 1,
    Dead = 2
}

namespace GameOfLife
{
    class Cell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public bool State { get; set; }
    }
}
