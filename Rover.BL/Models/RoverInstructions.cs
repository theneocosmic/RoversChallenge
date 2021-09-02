using Rover.BL.Repository;
using System.Collections.Generic;


namespace Rover.BL.Models
{
    public class RoverInstructions
    {
        public GridPlateau Grid { get; set; }
        public PositionRover Position { get; set; }
        public IEnumerable<char> Instructions { get; set; }

        public RoverResponse ExecuteMovements()
        {
            Rovers rover = new Rovers(this);
            return rover.ExecuteRoverTask();

        }
    }
}
