using System;
using System.Collections.Generic;
using System.Text;

namespace WhenMovingRover
{
    public class RoverSquadron: List<IRover>
    {
        public RoverSquadron(IGrid landingSurface)
        {
            this.LandingSurface = landingSurface;
        }

        public IGrid LandingSurface { get; set; }
        public List<IRover> squadron { get; set; }

        public void AddRover(string roverPosition, string commandSequence)
        {
            this.Add(new Rover(this, this.LandingSurface, roverPosition, commandSequence));
        }
    }
}
