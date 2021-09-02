namespace Rover.BL.Models
{
    public class GridPlateau
    {
        public int MaximumX { get; set; }
        public int MaximumY { get; set; }

        public GridPlateau(int maxX, int maxY)
        {
            MaximumX = maxX;
            MaximumY = maxY;
        }

    }
}
