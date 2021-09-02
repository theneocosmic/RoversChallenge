namespace Rover.BL.Models
{
    public class RoverResponse
    {
        public ErrorRover Error { get; set; }
        public PositionRover NewPosition { get; set; }

        public RoverResponse(ErrorRover error, PositionRover position)
        {
            Error = error;
            NewPosition = position;
        }
    }
}
