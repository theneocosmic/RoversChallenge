using Rover.BL.Interfaces;
using Rover.BL.Models;
using System;

namespace Rover.BL.Repository
{
    public class Rovers : IRover
    {
        private RoverInstructions _roverInstructions;
        public Rovers(RoverInstructions roverInstructions)
        {
            _roverInstructions = roverInstructions;
        }

        /// <summary>
        /// Execute the new Rover's  tasks
        /// </summary>
        /// <returns></returns>
        public RoverResponse ExecuteRoverTask()
        {

            bool errorInstruction = false;
            string unrecognizedInstruction = string.Empty;
            foreach (var instruction in _roverInstructions.Instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        _roverInstructions.Position.Direction = TurnLeft90();
                        break;
                    case 'R':
                        _roverInstructions.Position.Direction = TurnRight90();
                        break;
                    case 'M':
                        Foward();
                        break;
                    default:
                        errorInstruction = true;
                        unrecognizedInstruction = $"Unreconognized instruction {instruction.ToString()}";
                        break;
                };

                NewPositionValidation();
            }

            return new RoverResponse(new ErrorRover(errorInstruction, unrecognizedInstruction), _roverInstructions.Position);
        }

        /// <summary>
        /// Execute Left spin instruction
        /// </summary>
        /// <returns></returns>
        private string TurnLeft90()
        {
            return _roverInstructions.Position.Direction switch
            {
                "N" => "W",
                "E" => "N",
                "S" => "E",
                "W" => "S",
                _ => _roverInstructions.Position.Direction
            };
        }

        /// <summary>
        /// Execute Right spin instruction
        /// </summary>
        /// <returns></returns>
        private string TurnRight90()
        {
            return _roverInstructions.Position.Direction switch
            {
                "N" => "E",
                "E" => "S",
                "S" => "W",
                "W" => "N",
                _ => _roverInstructions.Position.Direction
            };
        }

        /// <summary>
        /// Execute Fowar instruction
        /// </summary>
        private void Foward()
        {
            switch (_roverInstructions.Position.Direction)
            {
                case "N":
                    _roverInstructions.Position.CoordinateY += 1;
                    break;
                case "S":
                    _roverInstructions.Position.CoordinateY -= 1;
                    break;
                case "E":
                    _roverInstructions.Position.CoordinateX += 1;
                    break;
                case "W":
                    _roverInstructions.Position.CoordinateX -= 1;
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Validate if new position is out of grid range.
        /// </summary>
        private void NewPositionValidation()
        {
            if (this._roverInstructions.Position.CoordinateX < 0 || this._roverInstructions.Position.CoordinateX > this._roverInstructions.Grid.MaximumX
                || this._roverInstructions.Position.CoordinateY < 0 || this._roverInstructions.Position.CoordinateY > this._roverInstructions.Grid.MaximumY)
            {
                throw new Exception($"OutRange Position");
            }
        }

    }
}
