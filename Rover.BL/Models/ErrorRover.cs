namespace Rover.BL.Models
{
    public class ErrorRover
    {
        public bool Error { get; set; }
        public string Message { get; set; }

        public ErrorRover(bool error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}