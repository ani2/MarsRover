using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover
{
    public class RoverController
    {
        public Tuple<int, int> NorthEastBound { get; set; }

        public string ReadInstructions(string[] instructionLines)
        {
            string output = string.Empty;

            if (instructionLines == null || instructionLines.Length == 0)
            {
                return output;
            }

            ParseBounds(instructionLines[0]);
            output = ParseRoverInstructions(instructionLines);
            return output;
        }

        // checks if a given coordinate is in the bounds of the plateau
        public bool IsInBounds(Tuple<int, int> coord)
        {
            return coord.Item1 >= 0 && coord.Item1 <= NorthEastBound.Item1 && coord.Item2 >= 0 && coord.Item2 <= NorthEastBound.Item2;
        }

        private void ParseBounds(string boundsLine)
        {
            if (!IsValidCoord(boundsLine))
            {
                throw new InvalidDataException("Invalid plateau bounds given");
            }

            var bounds = boundsLine.Split(' ');
            NorthEastBound = new Tuple<int, int>(int.Parse(bounds[0]), int.Parse(bounds[1]));
        }

        private string ParseRoverInstructions(string[] instructions)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 1; i < instructions.Length; i+=2)
            {
                var startPosLine = instructions[i];
                if (!IsValidPosition(startPosLine))
                {
                    output.AppendLine($"Warning: Invalid start position for Rover #{i / 2}. Sipping rover commands.");
                    continue;
                }

                var startPos = instructions[i].Split(' ');
                Rover rover = new Rover(int.Parse(startPos[0]), int.Parse(startPos[1]), startPos[2]);
                
                foreach(var command in instructions[i + 1])
                {
                    switch (command)
                    {
                        case 'L':
                        case 'l':
                            rover.RotateLeft();
                            break;
                        case 'R':
                        case 'r':
                            rover.RotateRight();
                            break;
                        case 'M':
                        case 'm':
                            if (IsInBounds(rover.GetNextPosition()))
                            {
                                rover.Position = rover.GetNextPosition();
                            }
                            else
                            {
                                output.AppendLine($"Warning: Cannot move Rover #{i / 2} out of bounds. Move command ignored.");
                            }
                            break;
                    }
                }
                // send updated position back to NASA
                output.AppendLine(rover.ToString());
            }

            return output.ToString();
        }

        // checks if a coordinate line is valid. eg "4 3"
        private bool IsValidCoord(string coord)
        {
            if (string.IsNullOrEmpty(coord))
            {
                return false;
            }

            return Regex.Match(coord, @"^\d+ \d+$").Success;
        }

        // checks if a position line is valid. eg "5 4 N"
        private bool IsValidPosition(string pos)
        {
            if (string.IsNullOrEmpty(pos))
            {
                return false;
            }

            return Regex.Match(pos, @"^\d+ \d+ [NESWnesw]$").Success;
        }

        // checks if a line of commands is valid. eg "LMRRML"
        private bool IsValidCommands(string commands)
        {
            // commands can be empty
            if (commands == null)
            {
                return false;
            }

            return Regex.Match(commands, @"^[LRMlrm]*$").Success;
        }

    }
}
