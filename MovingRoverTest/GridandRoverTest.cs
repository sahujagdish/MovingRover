using WhenMovingRover;
using System;
using Xunit;

namespace MWhenovingRoverTest
{
    public class GridandRoverTest
    {       

        [Fact]
        public void ValidGridSize()
        {
            IGrid grid = new Plateau(40, 30);

            Assert.Equal(40, grid.Width);
            Assert.Equal(30, grid.Height);
        }

        [Fact]
        public void InValidGridSize()
        {
            IGrid grid = new Plateau(41, 35);

            Assert.True(grid.Width == 0);
            Assert.True(grid.Height == 0);
        }

        [Fact]
        public void Valid_Command_Sequence_Movement_Is_Successful()
        {
            IGrid grid = new Plateau(40, 30);
            
            RoverSquadron roverSquadron = new RoverSquadron(grid);
            roverSquadron.AddRover("10 10 N", "R1R3L2L1");
            roverSquadron.AddRover("10 10 N", "R1R3L2L2");

            IRover rover = roverSquadron[0];
            IRover rover1 = roverSquadron[1];
            Assert.Equal("13,8,N", rover.x + "," + rover.y + "," + rover.direction);
            Assert.Equal("13,9,N", rover1.x + "," + rover1.y + "," + rover1.direction);
        }

    }
}
