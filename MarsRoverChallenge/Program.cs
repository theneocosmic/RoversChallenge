using Rover.BL.Models;
using Rover.BL.Utils;
using System;
using System.Linq;

namespace MarsRoverChallenge
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the Rover's position and instructions:");
            var inputData = new InputData();
            inputData.Grid = Console.ReadLine().Trim();
            inputData.Position = Console.ReadLine().Trim().ToUpper();
            inputData.Instructions = Console.ReadLine().Trim().ToUpper();
            var inputValidation = Utils.InputValidations(inputData);

            Console.WriteLine("- - - - - RESULT - - - - - - ");

            if (!inputValidation.Item1)
            {
                string response = MoveRover(inputData);
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine($"Errors:{inputValidation.Item2}");
                Console.ReadLine();
            }
            Console.ReadLine();

        }

        /// <summary>
        /// Prepare the data for execute Rover moves
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static string MoveRover(InputData inputData)
        {
            var gridPlateau = inputData.Grid.Split(' ');
            var currentPositionRover = inputData.Position.Split(' ');
            var instructionsToRover = inputData.Instructions.Where(x => !Char.IsWhiteSpace(x) && !Char.IsDigit(x)).Select(x => x);

            if (gridPlateau.Length == 2 && currentPositionRover.Length == 3 && instructionsToRover.Count() > 0)
            {
                try
                {
                    string error = string.Empty;
                    var RoverTask = new RoverInstructions();
                    try
                    {
                        RoverTask.Grid = new GridPlateau(int.Parse(gridPlateau[0]), int.Parse(gridPlateau[1]));
                        RoverTask.Position = new PositionRover(int.Parse(currentPositionRover[0]), int.Parse(currentPositionRover[1]), currentPositionRover[2].ToUpper());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Not is a number ", ex.Message);
                    }

                    RoverTask.Instructions = instructionsToRover;

                    var response = RoverTask.ExecuteMovements();

                    if (!response.Error.Error)
                    {
                        return $"{response.NewPosition.CoordinateX} {response.NewPosition.CoordinateY} {response.NewPosition.Direction}";
                    }
                    else
                    {
                        return $"Error: {response.Error.Message}";
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return "Incomplete Data for request.";
            }

        }
    }
}