using Rover.BL.Models;
using System;
using System.Text.RegularExpressions;

namespace Rover.BL.Utils
{
    public static class Utils
    {
        /// <summary>
        /// Validate the inputs and verify characters allowed. Regex validation.
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static Tuple<bool, string> InputValidations(InputData inputData)
        {
            string position = inputData.Position.Replace(" ", "");
            string plateau = inputData.Grid.Replace(" ", ""); ;

            bool error = false;
            string message = string.Empty;
            if (String.IsNullOrEmpty(position))
            {
                error = true;
                message += Environment.NewLine + "The Rover's current position is empty.";
            }
            else
            {
                if (!Regex.Match(position, @"[0-9][0-9][NWES]").Success)
                {
                    error = true;
                    message += Environment.NewLine + "The Rover's position contains invalid characters.";
                }
            }

            if (String.IsNullOrEmpty(plateau))
            {
                error = true;
                message += Environment.NewLine + "The grid size is empty.";
            }
            else
            {
                if (!Regex.Match(plateau, @"[0-9][0-9]").Success)
                {
                    error = true;
                    message += Environment.NewLine + "The grid size contains invalid characters.";
                }
            }

            if (String.IsNullOrEmpty(inputData.Instructions))
            {
                error = true;
                message += Environment.NewLine + "The Rover's instructions are empty.";
            }
            else
            {
                if (Regex.Match(inputData.Instructions, @"[^LRM]").Success)
                {
                    error = true;
                    message += Environment.NewLine + "Instructions contains unrecognized characteres.";
                }
            }


            return new Tuple<bool, string>(error, message);
        }
    }
}
