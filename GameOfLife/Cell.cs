using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public bool State { get; set; }
    }
}
