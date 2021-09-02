namespace Rover.BL.Models
{
    public class PositionRover
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Direction { get; set; }
        public PositionRover(int coordinateX, int coordinateY, string direction)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Direction = direction;
        }

    }
}
