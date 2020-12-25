using System;
using System.Collections.Generic;
using System.Text;

namespace WhenMovingRover
{
    public interface IRover
    {
        public int x { get; set; }
        public int y { get; set; }
        public string direction { get; set; }
        List<IRover> Squadron { get; set; }
    }
}
